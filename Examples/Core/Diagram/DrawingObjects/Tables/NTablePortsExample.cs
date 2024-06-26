﻿using Nevron.Nov.Diagram;
using Nevron.Nov.Diagram.Shapes;
using Nevron.Nov.Dom;
using Nevron.Nov.Graphics;
using Nevron.Nov.Text;
using Nevron.Nov.UI;

namespace Nevron.Nov.Examples.Diagram
{
    /// <summary>
    /// The example demonstrates how to connect table ports
    /// </summary>
    public class NTablePortsExample : NExampleBase
    {
        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public NTablePortsExample()
        {
        }

        /// <summary>
        /// Static constructor.
        /// </summary>
        static NTablePortsExample()
        {
            NTablePortsExampleSchema = NSchema.Create(typeof(NTablePortsExample), NExampleBaseSchema);
        }

		#endregion

		#region Example

		protected override NWidget CreateExampleContent()
		{
			// Create a simple drawing
			NDrawingViewWithRibbon drawingViewWithRibbon = new NDrawingViewWithRibbon();
			m_DrawingView = drawingViewWithRibbon.View;

			m_DrawingView.Document.HistoryService.Pause();
			try
			{
				InitDiagram(m_DrawingView.Document);
			}
			finally
			{
				m_DrawingView.Document.HistoryService.Resume();
			}

			return drawingViewWithRibbon;
		}
		protected override NWidget CreateExampleControls()
		{
			return null;
		}
		protected override string GetExampleDescription()
        {
            return @"<p>The example demonstrates how to connect table ports to other shapes.</p>";
        }

        private void InitDiagram(NDrawingDocument drawingDocument)
        {
            NDrawing drawing = drawingDocument.Content;
            NPage activePage = drawing.ActivePage;

            // hide the grid
            drawing.ScreenVisibility.ShowGrid = false;

			string[] tableDescription = new string[] { "Table With Column Ports", "Table With Row Ports", "Table With Cell Ports", "Table With Grid Ports" };
			ENPortsDistributionMode[] tablePortDistributionModes = new ENPortsDistributionMode[] { ENPortsDistributionMode.ColumnsOnly, ENPortsDistributionMode.RowsOnly, ENPortsDistributionMode.CellBased, ENPortsDistributionMode.GridBased };
			NTableBlock[] tableBlocks = new NTableBlock[tablePortDistributionModes.Length];

			double margin = 40;
			double tableSize = 200;
			double gap = activePage.Width - margin * 2 - tableSize * 2;
			
			double yPos = margin;
			int portDistributionModeIndex = 0;

			for (int y = 0; y < 2; y++)
			{
				double xPos = margin;

				for (int x = 0; x < 2; x++)
				{
					NShape shape = new NShape();
					shape.SetBounds(new NRectangle(xPos, yPos, tableSize, tableSize));

					xPos += tableSize + gap;

					// create table
					NTableBlock tableBlock = CreateTableBlock(tableDescription[portDistributionModeIndex]);

					// collect the block to connect it to the center shape
					tableBlocks[portDistributionModeIndex] = tableBlock;

					tableBlock.Content.AllowSpacingBetweenCells = false;
					tableBlock.ResizeMode = ENTableBlockResizeMode.FitToShape; 
					tableBlock.PortsDistributionMode = tablePortDistributionModes[portDistributionModeIndex++];
					shape.TextBlock = tableBlock;

					drawing.ActivePage.Items.AddChild(shape);
				}
				
				yPos += tableSize + gap;
			}

			NShape centerShape = new NBasicShapeFactory().CreateShape(ENBasicShape.Rectangle);
			centerShape.Text = "Table Ports allow you to connect tables to other shapes";
			centerShape.TextBlock.FontStyleBold = true;
			((NTextBlock)centerShape.TextBlock).VerticalAlignment = ENVerticalAlignment.Center;
			((NTextBlock)centerShape.TextBlock).HorizontalAlignment = ENAlign.Center;
			activePage.Items.AddChild(centerShape);

			double center = drawing.ActivePage.Width / 2.0;
			double shapeSize = 100;
			centerShape.SetBounds(new NRectangle(center - shapeSize / 2.0, center - shapeSize / 2.0, shapeSize, shapeSize));

			// get the column port for the first column on the bottom side
			NTableColumnPort columnPort;
			if (tableBlocks[0].TryGetColumnPort(0, false, out columnPort))
			{
				Connect(columnPort, centerShape.GetPortByName("Left"));
			}

			// get the row port for the second row on the left side
			NTableRowPort rowPort;
			if (tableBlocks[1].TryGetRowPort(1, true, out rowPort))
			{
				Connect(rowPort, centerShape.GetPortByName("Top"));
			}

			// get the cell port of the first cell on the top side
			NTableCellPort cellPort;
			if (tableBlocks[2].TryGetCellPort(0, 0, ENTableCellPortDirection.Top, out cellPort))
			{
				Connect(cellPort, centerShape.GetPortByName("Bottom"));
			}

			// get the cell port of the first row on the left side
			NTableRowPort rowPort1;
			if (tableBlocks[3].TryGetRowPort(0, true, out rowPort1))
			{
				Connect(rowPort1, centerShape.GetPortByName("Right"));
			}
		}
		private void Connect(NPort beginPort, NPort endPort)
		{
			NRoutableConnector connector = new NRoutableConnector();
			connector.RerouteMode = ENRoutableConnectorRerouteMode.Always;
			m_DrawingView.ActivePage.Items.AddChild(connector);

			connector.GlueBeginToPort(beginPort);
			connector.GlueEndToPort(endPort);
		}
		private NTableBlock CreateTableBlock(string description)
		{
			NTableBlock tableBlock = new NTableBlock(4, 3, NBorder.CreateFilledBorder(NColor.Black), new NMargins(1));

			NTableBlockContent tableBlockContent = tableBlock.Content;

			NTableCell tableCell = tableBlock.Content.Rows[0].Cells[0];
			tableCell.ColSpan = int.MaxValue;

			tableCell.Blocks.Clear();
			NParagraph par = new NParagraph(description);
			par.FontStyleBold = true;
			tableCell.Blocks.Add(par);

			for (int rowIndex = 1; rowIndex < tableBlockContent.Rows.Count; rowIndex++)
			{
				NTableRow row = tableBlockContent.Rows[rowIndex];

				for (int colIndex = 0; colIndex < tableBlockContent.Columns.Count; colIndex++)
				{
					NTableCell cell = row.Cells[colIndex];

					cell.Blocks.Clear();
					cell.Blocks.Add(new NParagraph("This is a table cell [" + rowIndex.ToString() + ", " + colIndex.ToString() + "]"));
				}
			}

			// make sure all columns are percentage based
			double percent = 100 / tableBlockContent.Columns.Count;

			for (int i = 0; i < tableBlockContent.Columns.Count; i++)
			{
				tableBlockContent.Columns[i].PreferredWidth = new Nevron.Nov.NMultiLength(Nevron.Nov.ENMultiLengthUnit.Percentage, percent);
			}

			return tableBlock;
		}

		#endregion

		#region Implementation 

		/// <summary>
		/// Adds rich formatted text to the specified text block content
		/// </summary>
		/// <param name="content"></param>
		private void AddFormattedTextToContent(NTextBlockContent content)
		{
			content.Blocks.Add(GetTitleParagraph("Bullet lists allow you to apply automatic numbering on paragraphs or groups of blocks.", 1));

			// setting bullet list template type
			{
				content.Blocks.Add(GetTitleParagraph("Following are bullet lists with different formatting", 2));

				ENBulletListTemplateType[] values = NEnum.GetValues<ENBulletListTemplateType>();
				string[] names = NEnum.GetNames<ENBulletListTemplateType>();

				string itemText = "Bullet List Item";

				for (int i = 0; i < values.Length - 1; i++)
				{
					NGroupBlock group = new NGroupBlock();
					content.Blocks.Add(group);
					group.MarginTop = 10;
					group.MarginBottom = 10;

					NBulletList bulletList = new NBulletList(values[i]);
					content.BulletLists.Add(bulletList);

					for (int j = 0; j < 3; j++)
					{
						NParagraph paragraph = new NParagraph(itemText + j.ToString());
						NBulletInline bullet = new NBulletInline();
						bullet.List = bulletList;
						paragraph.Bullet = bullet;

						group.Blocks.Add(paragraph);
					}
				}
			}

			// nested bullet lists
			{
				content.Blocks.Add(GetTitleParagraph("Following is an example of bullets with different bullet level", 2));

				NBulletList bulletList = new NBulletList(ENBulletListTemplateType.Decimal);
				content.BulletLists.Add(bulletList);

				NGroupBlock group = new NGroupBlock();
				content.Blocks.Add(group);

				for (int i = 0; i < 3; i++)
				{
					NParagraph par = new NParagraph("Bullet List Item" + i.ToString(), bulletList, 0);
					group.Blocks.Add(par);

					for (int j = 0; j < 2; j++)
					{
						NParagraph nestedPar = new NParagraph("Nested Bullet List Item" + i.ToString(), bulletList, 1);
						nestedPar.MarginLeft = 10;

						group.Blocks.Add(nestedPar);
					}
				}
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="text"></param>
		/// <param name="level"></param>
		/// <returns></returns>
		internal static NParagraph GetTitleParagraphNoBorder(string text, int level)
		{
			double fontSize = 10;
			ENFontStyle fontStyle = ENFontStyle.Regular;

			switch (level)
			{
				case 1:
					fontSize = 16;
					fontStyle = ENFontStyle.Bold;
					break;
				case 2:
					fontSize = 10;
					fontStyle = ENFontStyle.Bold;
					break;
			}

			NParagraph paragraph = new NParagraph();

			paragraph.HorizontalAlignment = ENAlign.Left;
			paragraph.FontSize = fontSize;
			paragraph.FontStyle = fontStyle;

			NTextInline textInline = new NTextInline(text);

			textInline.FontStyle = fontStyle;
			textInline.FontSize = fontSize;

			paragraph.Inlines.Add(textInline);

			return paragraph;

		}
		/// <summary>
		/// Gets a paragraph with title formatting
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		internal static NParagraph GetTitleParagraph(string text, int level)
		{
			NColor color = NColor.Black;

			NParagraph paragraph = GetTitleParagraphNoBorder(text, level);
			paragraph.HorizontalAlignment = ENAlign.Left;

			paragraph.Border = CreateLeftTagBorder(color);
			paragraph.BorderThickness = new NMargins(5.0, 0.0, 0.0, 0.0);

			return paragraph;
		}
		/// <summary>
		/// Creates a left tag border with the specified border
		/// </summary>
		/// <param name="color"></param>
		/// <returns></returns>
		private static NBorder CreateLeftTagBorder(NColor color)
		{
			NBorder border = new NBorder();

			border.LeftSide = new NBorderSide();
			border.LeftSide.Fill = new NColorFill(color);

			return border;
		}

		#endregion

		#region Fields

		private NDrawingView m_DrawingView;

		#endregion

		#region Schema

		/// <summary>
		/// Schema associated with NTablePortsExample.
		/// </summary>
		public static readonly NSchema NTablePortsExampleSchema;

        #endregion
    }
}
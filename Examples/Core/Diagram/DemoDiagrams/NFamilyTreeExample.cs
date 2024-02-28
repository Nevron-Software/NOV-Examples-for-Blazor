using System;

using Nevron.Nov.DataStructures;
using Nevron.Nov.Diagram;
using Nevron.Nov.Diagram.Formats;
using Nevron.Nov.Diagram.Layout;
using Nevron.Nov.Diagram.Shapes;
using Nevron.Nov.Dom;
using Nevron.Nov.Editors;
using Nevron.Nov.IO;
using Nevron.Nov.UI;

namespace Nevron.Nov.Examples.Diagram
{
	public class NFamilyTreeExample : NExampleBase
	{
		#region Constructors

		/// <summary>
		/// Default constructor.
		/// </summary>
		public NFamilyTreeExample()
		{
		}

		/// <summary>
		/// Static constructor.
		/// </summary>
		static NFamilyTreeExample()
		{
			NFamilyTreeExampleSchema = NSchema.Create(typeof(NFamilyTreeExample), NExampleBaseSchema);
		}

		#endregion

		#region Example

		protected override NWidget CreateExampleContent()
		{
			// Create a simple drawing
			NDrawingViewWithRibbon drawingViewWithRibbon = new NDrawingViewWithRibbon();
			m_DrawingView = drawingViewWithRibbon.View;

			m_DrawingView.Document.HistoryService.Pause();
			InitDiagram(m_DrawingView.Document);

			// Load the GEDCOM file format's family tree library (this needs to be done only once)
			NFile libraryFile = NApplication.ResourcesFolder.GetFile(NPath.Current.Combine(
					"ShapeLibraries", "Family Tree", "Family Tree Shapes.nlb"));
			NDrawingFormat.Gedcom.LoadFamilyTreeLibraryFromFileAsync(libraryFile).Then(
				delegate (NUndefined ud)
				{
					// Family tree library loaded successfully, so create the family tree diagram
					CreateFamilyTree(m_DrawingView.ActivePage);
					m_DrawingView.Document.HistoryService.Resume();
				},
				delegate (Exception ex)
				{
					// Failed to load the family tree library
					m_DrawingView.Document.HistoryService.Resume();
				}
			);

			return drawingViewWithRibbon;
		}
		protected override NWidget CreateExampleControls()
		{
			NStackPanel stack = new NStackPanel();

			// Get the family tree drawing extension
			NFamilyTreeExtension familyTreeExtension = (NFamilyTreeExtension)m_DrawingView.Content.Extensions.FindByType(NFamilyTreeExtension.FamilyTreeExtensionType);

			// Create property editors
			NList<NPropertyEditor> propertyEditors = NDesigner.GetDesigner(familyTreeExtension).CreatePropertyEditors(familyTreeExtension,
				NFamilyTreeExtension.DateFormatProperty,
				NFamilyTreeExtension.ShowPhotosProperty
			);

			for (int i = 0; i < propertyEditors.Count; i++)
			{
				stack.Add(propertyEditors[i]);
			}

			return new NUniSizeBoxGroup(stack);
		}
		protected override string GetExampleDescription()
		{
			return @"
<p>
	This example demonstrates how to create and arrange Family Tree diagrams. Use the controls
	on the right to change the family tree settings. You can also click the ""Settings"" button
	in the ""Family Tree"" contextual ribbon tab.
</p>";
		}

		#endregion

		#region Implementation

		private NShape CreateShape(ENFamilyTreeShape familyShape)
		{
			NLibraryItem libraryItem = NDrawingFormat.Gedcom.FamilyTreeLibrary.Items[(int)familyShape];
			NShape shape = (NShape)libraryItem.Items[0];
			return (NShape)shape.DeepClone();
		}
		private void InitDiagram(NDrawingDocument drawingDocument)
		{
			// Get drawing and the active page
			NDrawing drawing = drawingDocument.Content;

			// Set the family tree extension to the drawing to activate the "Family Tree" ribbon tab
			drawing.Extensions = new NDiagramExtensionCollection();
			drawing.Extensions.Add(new NFamilyTreeExtension());
		}
		private void CreateFamilyTree(NPage page)
		{
			// Create the parents
			NShape fatherShape = CreateShape(ENFamilyTreeShape.Male);
			fatherShape.SetShapePropertyValue("FirstName", "Abraham");
			fatherShape.SetShapePropertyValue("LastName", "Lincoln");
			fatherShape.SetShapePropertyValue("BirthDate", new NMaskedDateTime(1809, 02, 12));// NMaskedDateTime
			fatherShape.SetShapePropertyValue("DeathDate", new NMaskedDateTime(1865, 04, 15));
			page.Items.Add(fatherShape);

			NShape motherShape = CreateShape(ENFamilyTreeShape.Female);
			motherShape.SetShapePropertyValue("FirstName", "Mary");
			motherShape.SetShapePropertyValue("LastName", "Todd");
			motherShape.SetShapePropertyValue("BirthDate", new NMaskedDateTime(1811));
			page.Items.Add(motherShape);

			// Create the children
			NShape childShape1 = CreateShape(ENFamilyTreeShape.Male);
			childShape1.SetShapePropertyValue("FirstName", "Thomas");
			childShape1.SetShapePropertyValue("LastName", "Lincoln");
			childShape1.SetShapePropertyValue("BirthDate", new NMaskedDateTime(1853, 4, 4));
			childShape1.SetShapePropertyValue("DeathDate", new NMaskedDateTime(1871));
			page.Items.Add(childShape1);

			NShape childShape2 = CreateShape(ENFamilyTreeShape.Male);
			childShape2.SetShapePropertyValue("FirstName", "Robert Todd");
			childShape2.SetShapePropertyValue("LastName", "Lincoln");
			childShape2.SetShapePropertyValue("BirthDate", new NMaskedDateTime(1843, 8, 1));
			childShape2.SetShapePropertyValue("DeathDate", new NMaskedDateTime(1926, 7, 26));
			page.Items.Add(childShape2);

			NShape childShape3 = CreateShape(ENFamilyTreeShape.Male);
			childShape3.SetShapePropertyValue("FirstName", "William Wallace");
			childShape3.SetShapePropertyValue("LastName", "Lincoln");
			childShape3.SetShapePropertyValue("BirthDate", new NMaskedDateTime(1850, 12, 21));
			childShape3.SetShapePropertyValue("DeathDate", new NMaskedDateTime(1862, 2, 20));
			page.Items.Add(childShape3);

			NShape childShape4 = CreateShape(ENFamilyTreeShape.Male);
			childShape4.SetShapePropertyValue("FirstName", "Edward Baker");
			childShape4.SetShapePropertyValue("LastName", "Lincoln");
			childShape4.SetShapePropertyValue("BirthDate", new NMaskedDateTime(1846, 3, 10));
			childShape4.SetShapePropertyValue("DeathDate", new NMaskedDateTime(1850, 2, 1));
			page.Items.Add(childShape4);

			// Create the relationship shape
			NShape relShape = CreateShape(ENFamilyTreeShape.Relationship);
			relShape.SetShapePropertyValue("MarriageDate", new NMaskedDateTime(1842, 11, 4));
			page.Items.Add(relShape);

			page.Items.Add(CreateConnector(fatherShape, relShape));
			page.Items.Add(CreateConnector(motherShape, relShape));

			page.Items.Add(CreateConnector(relShape, childShape1));
			page.Items.Add(CreateConnector(relShape, childShape2));
			page.Items.Add(CreateConnector(relShape, childShape3));
			page.Items.Add(CreateConnector(relShape, childShape4));

			// Arrange the family tree shapes
			NFamilyGraphLayout layout = new NFamilyGraphLayout();
			object[] shapes = page.GetShapes(false).ToArray<object>();
			layout.Arrange(shapes, new NDrawingLayoutContext(page));

			// Size the page to its content
			page.SizeToContent();
		}

		#endregion

		#region Fields

		private NDrawingView m_DrawingView;

		#endregion

		#region Schema

		/// <summary>
		/// Schema associated with NFamilyTreeExample.
		/// </summary>
		public static readonly NSchema NFamilyTreeExampleSchema;

		#endregion

		#region Static Methods

		private static NRoutableConnector CreateConnector(NShape fromShape, NShape toShape)
		{
			NRoutableConnector connector = new NRoutableConnector();
			connector.GlueBeginToShape(fromShape);
			connector.GlueEndToShape(toShape);

			return connector;
		}

		#endregion
	}
}
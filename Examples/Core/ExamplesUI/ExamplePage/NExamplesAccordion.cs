using System;

using Nevron.Nov.Compression;
using Nevron.Nov.DataStructures;
using Nevron.Nov.Dom;
using Nevron.Nov.Graphics;
using Nevron.Nov.Layout;
using Nevron.Nov.UI;
using Nevron.Nov.Xml;

namespace Nevron.Nov.Examples
{
    /// <summary>
    /// An accordion that has an item for each NOV component and shows a tree view
    /// with the examples for the selected component.
    /// </summary>
    internal class NExamplesAccordion : NAccordion
	{
		#region Constructors

		/// <summary>
		/// Default constructor.
		/// </summary>
		public NExamplesAccordion()
		{
			m_ExamplesMap = new NMap<string, NTreeViewItem>();

			// Create a stack panel for the example categories (NOV components)
			m_FlexBox = new NAccordionFlexBoxPanel();
			m_FlexBox.Direction = ENHVDirection.TopToBottom;
			m_FlexBox.VerticalSpacing = 0;

			// Set the stack as content of the accordion
			Content = m_FlexBox;
		}

		/// <summary>
		/// Static constructor.
		/// </summary>
		static NExamplesAccordion()
		{
			NExamplesAccordionSchema = NSchema.Create(typeof(NExamplesAccordion), NAccordionSchema);

			// Create the component icon map
			NEmfDecompressor emfDecompressor = new NEmfDecompressor();
			NCompression.DecompressZip(NResources.RBIN_ComponentIcons_zip.Stream, emfDecompressor);
			ComponentIconMap = emfDecompressor.m_ImageMap;
		}

		#endregion

		#region Events

		public event Function<NValueChangeEventArgs> TreeViewSelectedPathChanged;

		#endregion

		#region Public Methods

		/// <summary>
		/// Initializes the accordion from the given XML document.
		/// </summary>
		/// <param name="xmlDocument"></param>
		public void InitializeFromXml(NXmlDocument xmlDocument)
		{
			m_FlexBox.Clear();
			m_ExamplesMap.Clear();

			NXmlNode categoriesNode = xmlDocument.GetFirstDescendant("categories");
			NList<NXmlNode> categories = categoriesNode.GetChildren(NExamplesXml.Element.Category);

			for (int i = 0; i < categories.Count; i++)
			{
				NXmlElement category = (NXmlElement)categories[i];
				NWidget sectionHeader = CreateSectionHeader(category);
				NWidget sectionContent = CreateSectionContent(category);

				// Create an expandable section for the current category
				NExpandableSection section = new NExpandableSection(sectionHeader, sectionContent);
				section.ContentPadding = NMargins.Zero;
				m_FlexBox.Add(section);
			}
		}

		/// <summary>
		/// Finds, navigates to and returns the default example element of the given XML element.
		/// </summary>
		/// <param name="xmlElement"></param>
		/// <returns></returns>
		public NXmlElement NavigateToExample(NXmlElement xmlElement)
		{
			switch (xmlElement.Name)
			{
				case NExamplesXml.Element.Example:
					break;

				case NExamplesXml.Element.Tile:
					xmlElement = GetExampleXmlElementForTile(xmlElement);
					break;

				case NExamplesXml.Element.Category:
					// Navigate to an example's category on the home screen
					NExamplesContent examplesContent = GetFirstAncestor<NExamplesContent>();
					examplesContent.NavigateToHomePageCategory(xmlElement.GetAttributeValue(NExamplesXml.Attribute.Name));
					return null;
			}

			string examplePath = NExamplesUiHelpers.GetExamplePath(xmlElement);

			NTreeViewItem treeViewItem;
			if (m_ExamplesMap.TryGet(examplePath, out treeViewItem))
			{
				// Navigate to an example or an example folder
				NTreeView treeView = treeViewItem.OwnerTreeView;
				treeView.ExpandPathToItem(treeViewItem);
				treeView.SelectedItem = treeViewItem;
				treeView.EnsureVisible(treeViewItem);

				NExpandableSection section = treeView.GetFirstAncestor<NExpandableSection>();
				section.OwnerAccordion.ExpandedSection = section;
			}
			else
			{
				NDebug.Assert(false);
			}

			return xmlElement;
		}

		#endregion

		#region Implementation - Accordion

		private NWidget CreateSectionHeader(NXmlElement category)
		{
			string name = category.GetAttributeValue(NExamplesXml.Attribute.Name);
			NImage icon = GetComponentIcon(GetCategoryName(category), ENImageStyle.Colored);

			NPairBox sectionHeaderPairBox = NPairBox.Create(icon, name);
			sectionHeaderPairBox.Box1.PreferredSize = NExampleTile.IconSize;
			return sectionHeaderPairBox;
		}
		private NWidget CreateSectionContent(NXmlElement category)
		{
			NTreeView treeView = new NTreeView();
			treeView.HScrollMode = ENScrollMode.Never;
			treeView.BorderThickness = NMargins.Zero;
			treeView.Items.Padding = new NMargins(NDesign.HorizontalSpacing, NDesign.VerticalSpacing);
			treeView.SelectedPathChanged += OnTreeViewSelectedPathChanged;

			AddItemsFor(treeView.Items, category);

			return treeView;
		}

		#endregion

		#region Implementation - Tree View

		private void AddItemsFor(NTreeViewItemCollection items, NXmlElement xmlElement)
		{
			int childrenCount = xmlElement.ChildrenCount;
			for (int i = 0; i < childrenCount; i++)
			{
				NXmlElement child = xmlElement.GetChildAt(i) as NXmlElement;
				if (child == null)
					continue;

				NTreeViewItem item = CreateTreeViewItem(child);
				if (item != null)
				{
					items.Add(item);
					if (item.Tag is NXmlElement == false)
					{
						// This is a folder item, so add items for its children, too
						AddItemsFor(item.Items, child);
					}
				}
				else
				{
					AddItemsFor(items, child);
				}
			}
		}
		private NTreeViewItem CreateTreeViewItem(NXmlElement xmlElement)
		{
            if (!NExamplesXml.IsSupportedOnTheCurrentPlatform(xmlElement))
                return null;

			if (NExamplesUiHelpers.IsSingleExampleTile(xmlElement))
			{
				// This is a tile with a single example, so create only the example tree view item
				return CreateTreeViewItem((NXmlElement)xmlElement.GetChildAt(0));
			}

			NImage icon;
			string name = xmlElement.GetAttributeValue(NExamplesXml.Attribute.Name);
			if (String.IsNullOrEmpty(name))
				return null;

			switch (xmlElement.Name)
			{
				case NExamplesXml.Element.Tile:
				case NExamplesXml.Element.Group:
					icon = new NImage(NResources.RIMG_ExamplesUI_Icons_Folder_emf);
					break;

				case NExamplesXml.Element.Example:
					// Get an icon for the example, which is a grayscale version of the example's category icon
					icon = GetComponentIcon(GetCategoryName(xmlElement), ENImageStyle.Grayscale);
					break;

				default:
					return null;
			}

			NExampleTile tile = new NExampleTile(icon, name);
			tile.Box1.Padding = new NMargins(0, 1, 0, 1);
			tile.Status = xmlElement.GetAttributeValue(NExamplesXml.Attribute.Status);
			tile.Box2.VerticalPlacement = ENVerticalPlacement.Center;
			tile.Spacing = NDesign.HorizontalSpacing;

			NTreeViewItem treeViewItem = new NTreeViewItem(tile);
			string examplePath = NExamplesUiHelpers.GetExamplePath(xmlElement);
			m_ExamplesMap.Add(examplePath, treeViewItem);

			if (xmlElement.Name == NExamplesXml.Element.Example)
			{
				// This is an example element
				treeViewItem.Tag = xmlElement;

				// Handle the right click event to show a context menu for copying a link to the example
				treeViewItem.MouseDown += OnTreeViewItemMouseDown;
			}

			return treeViewItem;
		}

		#endregion

		#region Event Handlers - Tree View

		/// <summary>
		/// Called when a new tree view item has been selected.
		/// </summary>
		/// <param name="arg"></param>
		private void OnTreeViewSelectedPathChanged(NValueChangeEventArgs arg)
		{
			NTreeView treeView = (NTreeView)arg.TargetNode;
			NTreeViewItem newSelectedItem = GetTreeViewItem(treeView, (NDomPath)arg.NewValue);
			NTreeViewItem oldSelectedItem = GetTreeViewItem(treeView, (NDomPath)arg.OldValue);
			if (IsExample(oldSelectedItem))
			{
				m_OldSelectedItem = oldSelectedItem;
			}

			NImageBox imageBox;
			string componentName;

			if (IsExample(newSelectedItem))
			{
				if (m_OldSelectedItem != null)
				{
					// Convert the image of the old selected tree view item to grayscale
					imageBox = m_OldSelectedItem.GetFirstDescendant<NImageBox>();
					componentName = GetCategoryName((NXmlElement)m_OldSelectedItem.Tag);
					imageBox.Image = GetComponentIcon(componentName, ENImageStyle.Grayscale);

					// Clear the "IsHighlighted" extended property for the old selected tree view item
					NStylePropertyEx.ClearIsHighlighted(m_OldSelectedItem);
					m_OldSelectedItem = null;
				}

				// Set a colored image to the new selected tree view image
				imageBox = newSelectedItem.GetFirstDescendant<NImageBox>();
				componentName = GetCategoryName((NXmlElement)newSelectedItem.Tag);
				imageBox.Image = GetComponentIcon(componentName, ENImageStyle.Colored);

				// Set the "IsHighlighted" extended property for the new selected tree view item
				NStylePropertyEx.SetIsHighlighted(newSelectedItem, true);
			}

			if (TreeViewSelectedPathChanged != null)
			{
				TreeViewSelectedPathChanged(arg);
			}
		}
		/// <summary>
		/// Called to show a context menu with a copy link to an example option.
		/// </summary>
		/// <param name="arg"></param>
		private void OnTreeViewItemMouseDown(NMouseButtonEventArgs arg)
		{
			if (arg.Cancel || arg.Button != ENMouseButtons.Right)
				return;

			// Mark the event as handled
			arg.Cancel = true;

			// Get the right clicked tree view item
			NTreeViewItem item = (NTreeViewItem)arg.CurrentTargetNode;
			NTreeView treeView = item.OwnerTreeView;

			// Create the context menu
			NMenu contextMenu = new NMenu();
			NMenuItem copyLinkToClipboard = new NMenuItem(Presentation.NResources.Image_Edit_Copy_png, "Copy link to clipboard");
			copyLinkToClipboard.Click += OnCopyLinkToClipboardClick;
			copyLinkToClipboard.Tag = item.Tag;
			contextMenu.Items.Add(copyLinkToClipboard);

			// Show the context menu
			NPopupWindow.OpenInContext(new NPopupWindow(contextMenu), treeView, arg.ScreenPosition);
		}
		/// <summary>
		/// Called to copy a link to an example to the clipboard.
		/// </summary>
		/// <param name="arg"></param>
		private void OnCopyLinkToClipboardClick(NEventArgs arg)
		{
			NXmlElement xmlElement = (NXmlElement)arg.CurrentTargetNode.Tag;
			if (NApplication.IntegrationPlatform == ENIntegrationPlatform.WebAssembly)
			{
				NExamplePage exampleHost = GetFirstAncestor<NExamplePage>();
				NExamplesUiHelpers.CopyExampleLinkToClipboard(xmlElement, exampleHost.ExamplesPath);
			}
			else
			{
				NExamplesUiHelpers.CopyExampleLinkToClipboard(xmlElement);
            }
		}

		#endregion

		#region Fields

		private NTreeViewItem m_OldSelectedItem;
		private NAccordionFlexBoxPanel m_FlexBox;
		private NMap<string, NTreeViewItem> m_ExamplesMap;

		#endregion

		#region Schema

		/// <summary>
		/// Schema associated with NExamplesAccordion.
		/// </summary>
		public static readonly NSchema NExamplesAccordionSchema;

		#endregion

		#region Static Methods

		/// <summary>
		/// Gets a component icon. Component icons are used in the accordion items.
		/// </summary>
		/// <param name="componentName"></param>
		/// <returns></returns>
		private static NImage GetComponentIcon(string componentName, ENImageStyle imageStyle)
		{
			if (imageStyle == ENImageStyle.Grayscale)
			{
				componentName += GrayscaleSuffix;
			}
			else if (componentName != null)
			{
				componentName = componentName.Replace(GrayscaleSuffix, String.Empty);
			}

			return (NImage)ComponentIconMap[componentName].DeepClone();
		}
		/// <summary>
		/// Gets the category name of the given XML element.
		/// </summary>
		/// <param name="xmlElement"></param>
		/// <returns></returns>
		private static string GetCategoryName(NXmlElement xmlElement)
		{
			NXmlElement categoryXmlElement = xmlElement.Name == NExamplesXml.Element.Category ?
				xmlElement :
				(NXmlElement)xmlElement.GetFirstAncestor(NExamplesXml.Element.Category);
			return categoryXmlElement.GetAttributeValue(NExamplesXml.Attribute.Namespace);
		}

		/// <summary>
		/// Gets the tree view item at the given DOM path.
		/// </summary>
		/// <param name="treeView"></param>
		/// <param name="domPath"></param>
		/// <returns></returns>
		private static NTreeViewItem GetTreeViewItem(NTreeView treeView, NDomPath domPath)
		{
			return domPath != null ? (NTreeViewItem)domPath.Select(treeView) : null;
		}
		/// <summary>
		/// Gets the default "example" XML element for the given "tile" XML element.
		/// </summary>
		/// <param name="tileXmlElement"></param>
		/// <returns></returns>
		private static NXmlElement GetExampleXmlElementForTile(NXmlElement tileXmlElement)
		{
			NList<NXmlNode> exampleXmlNodes = tileXmlElement.GetChildren(NExamplesXml.Element.Example);
			if (exampleXmlNodes.Count == 0)
			{
				NDebug.Assert(false, "Empty XML tile element found");
				return null;
			}

			for (int i = 0; i < exampleXmlNodes.Count; i++)
			{
				NXmlElement exampleXmlElement = (NXmlElement)exampleXmlNodes[i];
				if (exampleXmlElement.GetAttributeValue(NExamplesXml.Attribute.Default) == "true")
					return exampleXmlElement;
			}

			// A default XML element not found, so return the first one
			return (NXmlElement)exampleXmlNodes[0];
		}
		/// <summary>
		/// Checks whether the given tree view item represents an example.
		/// </summary>
		/// <param name="treeViewItem"></param>
		/// <returns></returns>
		private static bool IsExample(NTreeViewItem treeViewItem)
		{
			return treeViewItem != null &&
				treeViewItem.Tag is NXmlElement xmlElement &&
				xmlElement.Name == NExamplesXml.Element.Example;
		}

		#endregion

		#region Constants

		private static readonly NMap<string, NImage> ComponentIconMap;
		private const string GrayscaleSuffix = "Grayscale";

		#endregion

		#region Nested Types

		private enum ENImageStyle
		{
			Colored,
			Grayscale
		}

		#endregion
	}
}
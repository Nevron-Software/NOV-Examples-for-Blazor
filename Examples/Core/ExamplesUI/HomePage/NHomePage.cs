using System;

using Nevron.Nov.DataStructures;
using Nevron.Nov.Dom;
using Nevron.Nov.Graphics;
using Nevron.Nov.IO;
using Nevron.Nov.Layout;
using Nevron.Nov.UI;
using Nevron.Nov.Xml;

namespace Nevron.Nov.Examples
{
	/// <summary>
	/// The home page of the NOV examples.
	/// </summary>
	public class NHomePage : NPairBox
	{
		#region Constructors

		/// <summary>
		/// Default constructor.
		/// </summary>
		public NHomePage()
			: base(new NHomePageHeader(), new NHomePageContent(), ENPairBoxRelation.Box1AboveBox2)
		{
			Spacing = 0;

			// Subscribe to the ExampleOptions Changed event
			NExamplesOptions.Instance.Changed += OnExampleOptionsChanged;
		}

		/// <summary>
		/// Static constructor.
		/// </summary>
		static NHomePage()
		{
			NHomePageSchema = NSchema.Create(typeof(NHomePage), NPairBoxSchema);
		}

		#endregion

		#region Events

		public event Function<NXmlElement> TileSelected;

		#endregion

		#region Properties

		internal NHomePageHeader Header
		{
			get
			{
				return (NHomePageHeader)Box1;
			}
		}
		internal NHomePageContent Content
		{
			get
			{
				return (NHomePageContent)Box2;
			}
		}

		#endregion

		#region Public Methods

		public void InitializeFromXml(NXmlDocument xmlDocument)
		{
			// Process the XML document
			if (xmlDocument == null || xmlDocument.ChildrenCount != 1)
				return;

			m_ExamplesMap = new NStringMap<NWidget>(false);

			// Get the root element (i.e. the <document> element)
			NXmlElement rootElement = (NXmlElement)xmlDocument.GetChildAt(0);

			// Process the head
			NXmlElement titleElement = (NXmlElement)rootElement.GetFirstChild(NExamplesXml.Attribute.Title);
			string title = ((NXmlTextNode)titleElement.GetChildAt(0)).Text;

			NXmlElement statusColorsElement = (NXmlElement)rootElement.GetFirstChild("statusColors");
			m_StatusColorMap = ParseStatusColors(statusColorsElement);

			// Process the categories
			NXmlElement categoriesElement = (NXmlElement)rootElement.GetFirstChild("categories");
			//((NWelcomePanel)m_PagePanel[0]).Initialize(categoriesElement);

			for (int i = 0, count = categoriesElement.ChildrenCount; i < count; i++)
			{
				if (categoriesElement.GetChildAt(i) is NXmlElement childElement)
				{
					if (childElement.Name != NExamplesXml.Element.Category)
						throw new Exception("The body element can contain only category elements");

					// Create a widget and add it to the categories panel
					Content.AddCategory(childElement);

					// Parse the category
					ParseCategory(childElement);
				}
			}

			// Init the search box
			Header.SearchBox.InitAutoComplete(m_ExamplesMap, new NExampleTileFactory());
			Header.SearchBox.ListBoxItemSelected += OnSearchBoxListBoxItemSelected;
		}

		#endregion

		#region Internal Methods

		/// <summary>
		/// Gets the background color for the given status.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		internal NColor GetStatusColor(string status)
		{
			NColor color;
			if (m_StatusColorMap.TryGet(status, out color))
				return color;

			return m_StatusColorMap[String.Empty];
		}
		/// <summary>
		/// Raises the <see cref="TileSelected"/> event.
		/// </summary>
		/// <param name="xmlElement"></param>
		internal void RaiseTileSelected(NXmlElement xmlElement)
		{
			if (TileSelected != null)
			{
				TileSelected(xmlElement);
			}
		}

		#endregion

		#region Implementation - XML Parsing

		private void ParseCategory(NXmlElement categoryElement)
		{
			string categoryNamespace = categoryElement.GetAttributeValue(NExamplesXml.Attribute.Namespace);
			NList<NXmlNode> tiles = categoryElement.GetDescendants(NExamplesXml.Element.Tile);

			for (int i = 0; i < tiles.Count; i++)
			{
				if (tiles[i] is NXmlElement tileElement)
				{
					CreateTile(tileElement, categoryNamespace);
				}
			}
		}
		/// <summary>
		/// Creates a tile for the given example element.
		/// </summary>
		/// <param name="tileElement"></param>
		/// <param name="categoryNamespace"></param>
		/// <returns></returns>
		private NExampleTile CreateTile(NXmlElement tileElement, string categoryNamespace)
		{
			if (!NExamplesXml.IsSupportedOnTheCurrentPlatform(tileElement))
				return null;

			string tileTitle = tileElement.GetAttributeValue(NExamplesXml.Attribute.Name);
			string iconName = tileElement.GetAttributeValue(NExamplesXml.Attribute.Icon);

			// Get the icon for the tile
			NImage icon = GetTileIcon(categoryNamespace, iconName);

			// Create and configure the tile
			NExampleTile tile = new NExampleTile(icon, tileTitle);
			tile.HorizontalPlacement = ENHorizontalPlacement.Left;
			tile.Status = tileElement.GetAttributeValue(NExamplesXml.Attribute.Status);
			tile.Tag = new NExampleTileInfo(tileElement);

			// Add the examples of the current tile to the examples map
			INIterator<NXmlNode> iter = tileElement.GetChildNodesIterator();
			while (iter.MoveNext())
			{
				NXmlElement exampleElement = iter.Current as NXmlElement;
				if (exampleElement == null || !NExamplesXml.IsSupportedOnTheCurrentPlatform(exampleElement))
					continue;

				string examplePath = NExamplesUiHelpers.GetExamplePath(exampleElement);
				if (icon != null)
				{
					icon = new NImage(icon.ImageSource);
				}

				NExampleTile example = new NExampleTile(icon, examplePath);
				example.Status = exampleElement.GetAttributeValue(NExamplesXml.Attribute.Status);
				example.Tag = new NExampleTileInfo(exampleElement);

				if (!m_ExamplesMap.Contains(examplePath))
				{
					m_ExamplesMap.Add(examplePath, example);
				}
			}

			return tile;
		}

		#endregion

		#region Event Handlers

		private void OnExampleOptionsChanged(NEventArgs arg)
		{
			NValueChangeEventArgs changeArg = arg as NValueChangeEventArgs;
			if (changeArg == null)
				return;

			if (changeArg.Property == NExamplesOptions.RecentExamplesProperty)
			{
				// Update the Recent Examples menu drop down
				NExamplesUiHelpers.PopulateExamplesDropDown(
					Header.RecentExamplesDropDown,
					NExamplesOptions.Instance.RecentExamples.GetReverseIterator(), // Most recent examples should be first
					m_ExamplesMap,
					OnExampleMenuItemClick);
			}
			else if (changeArg.Property == NExamplesOptions.FavoriteExamplesProperty)
			{
				// Update Favorite Examples menu drop down
				NExamplesUiHelpers.PopulateExamplesDropDown(
					Header.FavoriteExamplesDropDown,
					NExamplesOptions.Instance.FavoriteExamples.GetIterator(),
					m_ExamplesMap,
					OnExampleMenuItemClick);
			}
		}
		private void OnExampleMenuItemClick(NEventArgs arg)
		{
			NXmlElement xmlElement = NExamplesUiHelpers.GetMenuItemExample((NMenuItem)arg.CurrentTargetNode);
			if (xmlElement != null)
			{
				RaiseTileSelected(xmlElement);
			}
		}
		private void OnSearchBoxListBoxItemSelected(NEventArgs arg)
		{
			if (arg.Cancel)
				return;

			INSearchableListBox listBox = (INSearchableListBox)arg.TargetNode;
			NWidget selectedItem = ((NKeyValuePair<string, NWidget>)listBox.GetSelectedItem()).Value;

			if (selectedItem != null && TileSelected != null)
			{
				NExampleTileInfo tileInfo = (NExampleTileInfo)selectedItem.Tag;
				TileSelected(tileInfo.XmlElement);
			}

			// Mark the event as handled
			arg.Cancel = true;
		}

		#endregion

		#region Fields

		// Examples data structures
		internal NStringMap<NWidget> m_ExamplesMap;
		private NMap<string, NColor> m_StatusColorMap;

		#endregion

		#region Static Methods - UI

		private static NImage GetTileIcon(string categoryNamespace, string iconName)
		{
			if (String.IsNullOrEmpty(iconName))
				return null;

			if (NPath.Current.DirectorySeparatorChar != '\\')
			{
				iconName = iconName.Replace('\\', NPath.Current.DirectorySeparatorChar);
			}

			string imageFolder = NPath.Current.GetParentFolderPath(iconName);
			if (String.IsNullOrEmpty(imageFolder))
			{
				// The icon is in the folder for the current category
				imageFolder = categoryNamespace;
			}
			else
			{
				// The icon is in a folder of another category
				imageFolder = NPath.Current.Normalize(NPath.Current.Combine(categoryNamespace, imageFolder));
				if (imageFolder[imageFolder.Length - 1] == NPath.Current.DirectorySeparatorChar)
				{
					imageFolder = imageFolder.Remove(imageFolder.Length - 1);
				}

				// Update the icon name
				iconName = NPath.Current.GetFileName(iconName);
			}

			iconName = "RIMG_ExampleIcons_" + imageFolder + "_" + iconName.Replace('.', '_');
			return new NImage(new NEmbeddedResourceRef(NResources.Instance, iconName));
		}

		#endregion

		#region Static Methods - Styling

		/// <summary>
		/// Parses the background colors of the status labels defined in the examples XML file.
		/// </summary>
		/// <param name="styleElement"></param>
		private static NMap<string, NColor> ParseStatusColors(NXmlElement styleElement)
		{
			NMap<string, NColor> statusColorMap = new NMap<string, NColor>();
			if (styleElement != null)
			{
				for (int i = 0, count = styleElement.ChildrenCount; i < count; i++)
				{
					NXmlElement child = styleElement.GetChildAt(i) as NXmlElement;
					if (child == null || child.Name != NExamplesXml.Attribute.Status)
						continue;

					// Get the status name
					string name = child.GetAttributeValue(NExamplesXml.Attribute.Name);
					if (name == null)
						continue;

					// Parse the status color
					string colorStr = child.GetAttributeValue(NExamplesXml.Attribute.Color);
					NColor color;
					if (NColor.TryParse(colorStr, out color) == false)
						continue;

					// Add the name/color pair to the status color map
					statusColorMap.Set(name, color);
				}
			}

			return statusColorMap;
		}

		#endregion

		#region Schema

		/// <summary>
		/// Schema associated with NHomePage.
		/// </summary>
		public static readonly NSchema NHomePageSchema;

		#endregion
	}
}
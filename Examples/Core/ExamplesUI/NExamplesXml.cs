using System;

using Nevron.Nov.Xml;

namespace Nevron.Nov.Examples
{
    /// <summary>
    /// Contains constants and helpers for working with the examples' XML.
    /// </summary>
    internal static class NExamplesXml
    {
        #region Public Methods

        /// <summary>
        /// Gets whether the given XML element (category, row, group, tile or example) is supported
        /// on the current platform by analyzing the "platforms" attribute of the XML element.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        /// <remarks>
        /// The "platforms" attribute should contain comma-separated values from the <see cref="ENIntegrationPlatform"/>
        /// enumeration. If not set, the element is considered supported on all platforms.
        /// </remarks>
        public static bool IsSupportedOnTheCurrentPlatform(NXmlElement element)
        {
            string platforms = element.GetAttributeValue(Attribute.Platforms);
            if (String.IsNullOrEmpty(platforms))
                return true;
            else
                return platforms.IndexOf(NApplication.IntegrationPlatform.ToString(), StringComparison.OrdinalIgnoreCase) != -1;
        }
		public static string GetNamespace(NXmlElement element)
		{
			string result;
			do
			{
				result = element.GetAttributeValue(Attribute.Namespace);
				element = element.Parent as NXmlElement;
			}
			while (String.IsNullOrEmpty(result) && element != null);

			return result;
		}

		#endregion

		#region XML Elements

		/// <summary>
		/// Contains example XML element names.
		/// </summary>
		public static class Element
        {
            public const string Category = "category";
            public const string Row = "row";
            public const string Group = "group";
            public const string Tile = "tile";
            public const string Example = "example";
            public const string Description = "description";
        }

        #endregion

        #region XML Attributes

        /// <summary>
        /// Contains example XML attribute names.
        /// </summary>
        public static class Attribute
        {
            public const string Color = "color";
            public const string Default = "default";
            public const string Icon = "icon";
            public const string MaxRows = "maxRows";
            public const string Name = "name";
            public const string Namespace = "namespace";
            /// <summary>
            /// Name of the attribute that lists the supported platforms as comma-separated values from
            /// the <see cref="ENIntegrationPlatform"/> enumeration.
            /// </summary>
            public const string Platforms = "platforms";
            public const string Status = "status";
            public const string Title = "title";
			public const string Link = "link";
        }

        #endregion
    }
}
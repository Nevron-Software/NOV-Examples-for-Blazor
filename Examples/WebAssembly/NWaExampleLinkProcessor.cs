using System;

using Nevron.Nov.Examples.ExamplesUI;

namespace Nevron.Nov.Examples.WebAssembly
{
    internal class NWaExampleLinkProcessor : INExampleLinkProcessor
    {
        #region Constructors

        public NWaExampleLinkProcessor(string baseUri)
        {
            m_BaseUri = baseUri;
        }

        #endregion

        #region INExampleLinkProcessor

        public string GetExampleLink(string exampleTypeName)
        {
            return m_BaseUri + "?example=" + exampleTypeName;
        }

        public string GetExampleType(string exampleLinkUri)
        {
            if (String.IsNullOrEmpty(exampleLinkUri))
                return null;

            int index = exampleLinkUri.IndexOf(ExampleParam);
            if (index == -1)
                return null;

            return exampleLinkUri.Substring(index + ExampleParam.Length);
        }

        #endregion

        #region Fields

        private string m_BaseUri;

        #endregion

        #region Constants

        private const string ExampleParam = "?example=";

        #endregion
    }
}
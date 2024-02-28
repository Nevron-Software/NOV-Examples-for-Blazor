using Nevron.Nov.Dom;
using Nevron.Nov.UI;

namespace Nevron.Nov.Examples
{
	/// <summary>
	/// Base class for NOV examples home page panels like the home page header and the home page content.
	/// </summary>
	internal abstract class NHomePageRootWidget : NDocumentBox
	{
		#region Constructors

		/// <summary>
		/// Default constructor.
		/// </summary>
		public NHomePageRootWidget()
		{
			// Create and apply an UI theme
			Document.InheritStyleSheets = false;
			Document.StyleSheets.ApplyTheme(CreateUiTheme());

			// Create the UI
			Surface = new NDocumentBoxSurface(CreateContent());
		}

		/// <summary>
		/// Static constructor.
		/// </summary>
		static NHomePageRootWidget()
		{
			NHomePageRootWidgetSchema = NSchema.Create(typeof(NHomePageRootWidget), NDocumentBoxSchema);
		}

		#endregion

		#region Protected Must Override - Styling

		protected abstract NUITheme CreateUiTheme();

		#endregion

		#region Protected Must Override - UI

		protected abstract NWidget CreateContent();

		#endregion

		#region Schema

		/// <summary>
		/// Schema associated with NHomePageRootWidget.
		/// </summary>
		public static readonly NSchema NHomePageRootWidgetSchema;

		#endregion

		#region Constants

		protected const double Spacing = 12;

		#endregion
	}
}
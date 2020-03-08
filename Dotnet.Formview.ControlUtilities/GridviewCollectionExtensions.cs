using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Dotnet.Formview.ControlUtilities
{
	public static class GridviewCollectionExtensions
	{
		/// <summary>
		/// For every grid view in all page controls process them to properly use thead, tbody, and tfooter
		/// </summary>
		public static void MakeGridViewsHtml5(this IEnumerable<GridView> controlSet) => controlSet.RegisterPreRenderToAll(GridViewEventHandler.Html5PreRenderEvent);
	}
}

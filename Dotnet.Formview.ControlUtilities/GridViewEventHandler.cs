using System;
using System.Web.UI.WebControls;

namespace Dotnet.Formview.ControlUtilities
{
	public static class GridViewEventHandler
	{
		public static void Html5PreRenderEvent(object sender, EventArgs e)
		{
			//each section must be done in order of thead -> tbody -> tfooter

			//both header sections must be done together
			try { ((GridView)sender).HeaderRow.TableSection = TableRowSection.TableHeader; } catch { }
			try { ((GridView)sender).TopPagerRow.TableSection = TableRowSection.TableHeader; } catch { }

			//all body items must be reset
			foreach (GridViewRow row in ((GridView)sender).Rows)
			{
				try { row.TableSection = TableRowSection.TableBody; } catch { }
			}

			//both footer sections must be done together
			try { ((GridView)sender).FooterRow.TableSection = TableRowSection.TableFooter; } catch { }
			try { ((GridView)sender).BottomPagerRow.TableSection = TableRowSection.TableFooter; } catch { }
		}
	}
}

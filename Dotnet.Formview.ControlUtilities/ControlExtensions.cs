using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace Dotnet.Formview.ControlUtilities
{
	public static class ControlExtensions
	{
		/// <summary>
		/// This function returns all the child controls for any given parent
		/// </summary>
		/// <param name="parent"></param>
		/// <returns></returns>
		public static IEnumerable<Control> GetAllControls(this Control parent)
		{
			foreach (var control in parent.GetAllControls<Control>())
			{
				yield return control;
			}
		}

		/// <summary>
		/// This function returns all the child controls for any given parent
		/// </summary>
		/// <param name="parent"></param>
		/// <returns></returns>
		public static IEnumerable<T> GetAllControls<T>(this Control parent) where T : Control
		{
			//recursively finds all controls and child controls for any given control
			foreach (var control in parent.Controls.Cast<Control>())
			{
				if (control is T)
					yield return (T)control;

				foreach (var descendant in control.GetAllControls<T>())
				{
					yield return descendant;
				}
			}
		}
	}
}

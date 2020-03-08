using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace Dotnet.Formview.ControlUtilities
{
	public static class WebControlExtensions
	{
		/// <summary>
		/// Creates a list of css classes from a space separated string. Returns an empty list if input is null or whitespace
		/// </summary>
		/// <param name="classes"></param>
		/// <returns></returns>
		private static List<string> GetList(string classes) => string.IsNullOrWhiteSpace(classes) ? new List<string>() : new List<string>(classes.Split(' '));

		/// <summary>
		/// Adds a set of classes to the control
		/// </summary>
		/// <param name="control"></param>
		/// <param name="classesToAdd"></param>
		/// <returns></returns>
		public static void AddCssClass(this WebControl control, string classesToAdd)
			=> control.AddCssClass(GetList(classesToAdd));

		/// <summary>
		/// Adds a set of classes to the control
		/// </summary>
		/// <param name="control"></param>
		/// <param name="classesToAdd"></param>
		public static void AddCssClass(this WebControl control, List<string> classesToAdd)
			=> control.CssClass = string.Join(" ", GetList(control.CssClass).Union(classesToAdd));

		/// <summary>
		/// Removes a set of classes from the control
		/// </summary>
		/// <param name="control"></param>
		/// <param name="classesToRemove"></param>
		public static void RemoveCssClass(this WebControl control, string classesToRemove) => control.RemoveCssClass(GetList(classesToRemove));

		/// <summary>
		/// Removes a set of classes from the control
		/// </summary>
		/// <param name="control"></param>
		/// <param name="classesToRemove"></param>
		public static void RemoveCssClass(this WebControl control, List<string> classesToRemove)
			=> control.CssClass = string.Join(" ", GetList(control.CssClass).Where(w => !classesToRemove.Contains(w)));
	}
}

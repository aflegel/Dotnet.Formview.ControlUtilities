﻿using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
		private static List<string> ToList(this string classes) => string.IsNullOrWhiteSpace(classes) ? new List<string>() : new List<string>(classes.Split(' '));

		private static string Union(this string existing, List<string> others) => string.Join(" ", existing.ToList().Union(others));
		private static string Except(this string existing, List<string> others) => string.Join(" ", existing.ToList().Except(others));

		/// <summary>
		/// Adds a set of classes to the control
		/// </summary>
		/// <param name="control"></param>
		/// <param name="classesToAdd"></param>
		/// <returns></returns>
		public static void AddCssClass<T>(this T control, string classesToAdd) where T : Control => control.AddCssClass(classesToAdd.ToList());

		/// <summary>
		/// Adds a set of classes to the control
		/// </summary>
		/// <param name="control"></param>
		/// <param name="classesToAdd"></param>
		public static void AddCssClass<T>(this T control, List<string> classesToAdd) where T : Control
		{
			if (control is HtmlControl)
				((HtmlControl)(object)control).Attributes["Class"] = ((HtmlControl)(object)control).Attributes["Class"].Union(classesToAdd);
			else if (control is WebControl)
				((WebControl)(object)control).CssClass = ((WebControl)(object)control).CssClass.Union(classesToAdd);
		}

		/// <summary>
		/// Removes a set of classes from the control
		/// </summary>
		/// <param name="control"></param>
		/// <param name="classesToRemove"></param>
		public static void RemoveCssClass<T>(this T control, string classesToRemove) where T : Control => control.RemoveCssClass(classesToRemove.ToList());

		/// <summary>
		/// Removes a set of classes from the control
		/// </summary>
		/// <param name="control"></param>
		/// <param name="classesToRemove"></param>
		public static void RemoveCssClass<T>(this T control, List<string> classesToRemove) where T : Control
		{
			if (control is HtmlControl)
				((HtmlControl)(object)control).Attributes["Class"] = ((HtmlControl)(object)control).Attributes["Class"].Except(classesToRemove);
			else if (control is WebControl)
				((WebControl)(object)control).CssClass = ((WebControl)(object)control).CssClass.Except(classesToRemove);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dotnet.Formview.ControlUtilities.Test
{
	[TestClass]
	public class WebControlExtensionTests
	{
		private TextBox BaseControl => new TextBox
		{
			CssClass = "class1 class2"
		};

		private string NullString => null;

		[TestMethod]
		public void AddingClasses()
		{
			var control = BaseControl;

			control.AddCssClass("class3 class4");

			control.CssClass.Should().Be("class1 class2 class3 class4");
		}

		[TestMethod]
		public void AddingListClasses()
		{
			var control = BaseControl;

			control.AddCssClass(new List<string> { "class3", "class4"  });

			control.CssClass.Should().Be("class1 class2 class3 class4");
		}

		[TestMethod]
		public void AddingDuplicateClasses()
		{
			var control = BaseControl;

			control.AddCssClass("class2 class3");

			control.CssClass.Should().Be("class1 class2 class3");
		}

		[TestMethod]
		public void BaseNullTollerance()
		{
			var control = new TextBox()
			{
				CssClass = NullString
			};

			control.CssClass.Should().Be("");

			control.AddCssClass(NullString);
			control.CssClass.Should().Be("");

			control.AddCssClass("          ");
			control.CssClass.Should().Be("");

			control.RemoveCssClass(NullString);
			control.CssClass.Should().Be("");
		}

		[TestMethod]
		public void MutableNullTollerance()
		{
			var control = BaseControl;

			control.AddCssClass(NullString);

			control.CssClass.Should().Be("class1 class2");

			control.RemoveCssClass(NullString);

			control.CssClass.Should().Be("class1 class2");
		}

		[TestMethod]
		public void RemoveClass()
		{
			var control = BaseControl;

			control.RemoveCssClass("class2");

			control.CssClass.Should().Be("class1");
		}

		[TestMethod]
		public void RemoveListClass()
		{
			var control = BaseControl;

			control.RemoveCssClass(new List<string> { "class1", "class2" });

			control.CssClass.Should().Be("");
		}

		[TestMethod]
		public void RemoveDuplicateClass()
		{
			var control = BaseControl;

			control.RemoveCssClass(new List<string> { "class1", "class1" });

			control.CssClass.Should().Be("class2");
		}

		[TestMethod]
		public void RemoveNoDuplicateClass()
		{
			var control = BaseControl;

			control.RemoveCssClass("class3");

			control.CssClass.Should().Be("class1 class2");
		}
	}
}

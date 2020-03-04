using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dotnet.Formview.ControlUtilities.Test
{
	[TestClass]
	public class ControlExtensionTests
	{
		private Control ControlWithChildren
		{
			get
			{
				var parent = new Control();

				parent.Controls.Add(new GridView());
				parent.Controls.Add(new TextBox());
				parent.Controls.Add(new HiddenField());
				parent.Controls.Add(new Repeater());
				return parent;
			}
		}

		private Control ControlWithGrandChildren
		{
			get
			{
				var parent = new Control();

				var withChildren = new GridView();
				withChildren.Controls.Add(new GridView());

				parent.Controls.Add(withChildren);
				parent.Controls.Add(new TextBox());
				parent.Controls.Add(new HiddenField());
				parent.Controls.Add(new Repeater());
				return parent;
			}
		}


		[TestMethod]
		public void GetAllControls()
		{
			var parent = ControlWithChildren;

			parent.GetAllControls().Should().HaveCount(4);
			parent.Controls.Add(new GridView());
			parent.GetAllControls().Should().HaveCount(5);
		}

		[TestMethod]
		public void GetAllControlsGeneric()
		{
			var parent = ControlWithChildren;
			parent.GetAllControls<GridView>().Should().HaveCount(1);
			parent.Controls.Add(new GridView());
			parent.GetAllControls<GridView>().Should().HaveCount(2);
		}

		[TestMethod]
		public void TestMethod2()
		{
			var parent = ControlWithGrandChildren;

			parent.GetAllControls().Should().HaveCount(5);
			parent.GetAllControls<GridView>().Should().HaveCount(2);
		}
	}
}

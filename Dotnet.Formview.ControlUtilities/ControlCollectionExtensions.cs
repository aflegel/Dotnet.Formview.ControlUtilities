using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace Dotnet.Formview.ControlUtilities
{
	public static class ControlCollectionExtensions
	{
		/// <summary>
		/// Registers the event to all the PreRender hook of all controls in the set
		/// </summary>
		public static void RegisterPreRenderToAll<T>(this IEnumerable<T> controlSet, EventHandler eventHandler) where T : Control =>
			controlSet.ToList().ForEach(control => control.PreRender += new EventHandler(eventHandler));

		/// <summary>
		/// Registers the event to all the DataBinding hook of all controls in the set
		/// </summary>
		public static void RegisterDataBindingToAll<T>(this IEnumerable<T> controlSet, EventHandler eventHandler) where T : Control =>
			controlSet.ToList().ForEach(control => control.DataBinding += new EventHandler(eventHandler));

		/// <summary>
		/// Registers the event to all the Load hook of all controls in the set
		/// </summary>
		public static void RegisterLoadToAll<T>(this IEnumerable<T> controlSet, EventHandler eventHandler) where T : Control =>
			controlSet.ToList().ForEach(control => control.Load += new EventHandler(eventHandler));

		/// <summary>
		/// Registers the event to all the Unload hook of all controls in the set
		/// </summary>
		public static void RegisterUnloadToAll<T>(this IEnumerable<T> controlSet, EventHandler eventHandler) where T : Control =>
			controlSet.ToList().ForEach(control => control.Unload += new EventHandler(eventHandler));

		/// <summary>
		/// Registers the event to all the Disposed hook of all controls in the set
		/// </summary>
		public static void RegisterDisposedToAll<T>(this IEnumerable<T> controlSet, EventHandler eventHandler) where T : Control =>
			controlSet.ToList().ForEach(control => control.Disposed += new EventHandler(eventHandler));
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Tsr.UI.Common.Mvvm
{
	public interface IWindowModel
	{
		bool WindowClosing();
		EventHandler WindowCloseRequest { get; set; }
	}
}

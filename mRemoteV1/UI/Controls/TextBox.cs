using System.Collections.Generic;
using System;
using AxWFICALib;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using AxMSTSCLib;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;


// Adapted from http://stackoverflow.com/a/3678888/2101395

namespace mRemoteNG.Controls
{
	public class TextBox : System.Windows.Forms.TextBox
	{
        #region Public Properties
		[Category("Behavior"),
			DefaultValue(false)]private bool _SelectAllOnFocus = false;
        public bool SelectAllOnFocus
		{
			get
			{
				return _SelectAllOnFocus;
			}
			set
			{
				_SelectAllOnFocus = value;
			}
		}
        #endregion
			
        #region Protected Methods
		protected override void OnEnter(EventArgs e)
		{
			base.OnEnter(e);
				
			if (MouseButtons == MouseButtons.None)
			{
				SelectAll();
				_focusHandled = true;
			}
		}
			
		protected override void OnLeave(EventArgs e)
		{
			base.OnLeave(e);
				
			_focusHandled = false;
		}
			
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
				
			if (!_focusHandled)
			{
				if (SelectionLength == 0)
				{
					SelectAll();
				}
				_focusHandled = true;
			}
		}
        #endregion
			
        #region Private Fields
		private bool _focusHandled = false;
        #endregion
	}
}
using System;
using System.Windows.Forms;
using System.Collections.Generic;
//
using System.Linq;
using System.Drawing;

namespace GNX
{
    public class cForm
    {
        public static T Open<T>(Form parent = null, bool once = true) where T : new()
        {
            T frmG = default(T);
            var FormGeneric = ((Form)(object)frmG);

            if (once && Application.OpenForms.OfType<T>().Count() == 0)
            {
                if (FormGeneric == null || FormGeneric.IsDisposed)
                {
                    //frm = new T();
                    //FormGeneric = ((Form)(object)frm);
                }
                frmG = new T();
                FormGeneric = ((Form)(object)frmG);

            }
            else
            {
                FormGeneric = ((Form)(object)(Application.OpenForms.OfType<T>().First()));
            }

            if (FormGeneric.WindowState == FormWindowState.Minimized)
            {
                FormGeneric.WindowState = FormWindowState.Normal;
            }

            if (parent != null)
            {
                FormGeneric.MdiParent = parent;
            }

            FormGeneric.Show();
            FormGeneric.Focus();
            return (T)(object)FormGeneric;
        }

        public static T Get<T>() where T : Form
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(T))
                {
                    return (T)f;
                    //return (T)(object)f;
                }
            }

            return default(T);
        }

        public static Point ControlLocation(Control c)
        {
            Point locationOnForm = c.FindForm().PointToClient(c.Parent.PointToScreen(c.Location));
            return locationOnForm;
        }

        public static IEnumerable<T> GetControls<T>(Control rootControl)
        {
            return rootControl.Controls.OfType<T>().
                   Concat(rootControl.Controls.OfType<Control>().SelectMany(GetControls<T>));
        }
    }
}

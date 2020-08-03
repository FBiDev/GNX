using System;
using System.Windows.Forms;
//
using System.Linq;

namespace GNX
{
    public class cForms
    {
        public static void OpenOnce<T>(Form parent = null) where T : new()
        {
            T frmG = default(T);
            var FormGeneric = ((Form)(object)frmG);

            if (Application.OpenForms.OfType<T>().Count() == 0)
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
        }

        private static void OpenOnce<T>(T frm, Form parent = null) where T : new()
        {
            var FormGeneric = ((Form)(object)frm);

            if (Application.OpenForms.OfType<T>().Count() == 0)
            {
                if (FormGeneric == null || FormGeneric.IsDisposed)
                {
                    frm = new T();
                    FormGeneric = ((Form)(object)frm);
                }
            }
            else
            {
                //FormGeneric.Dispose();
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
        }

        public static T GetForm<T>() where T : Form
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(T))
                {
                    return (T)f;
                }
            }

            return default(T);
        }

        private static Form GetFormNeedCast(Type TForm)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == TForm)
                {
                    return f;
                }
            }

            return null;
        }
    }
}

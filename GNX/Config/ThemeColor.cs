using System.Windows.Forms;

namespace GNX
{
    public class ThemeColor
    {
        public virtual void WindowForm(Form f) { }
        public virtual void MainBaseForm(MainBaseForm f) { }
        public virtual void ContentBaseForm(ContentBaseForm f) { }

        public virtual void FlatPanel(FlatPanel c) { }
        public virtual void FlatLabel(FlatLabel c) { }
        public virtual void FlatButton(FlatButton c) { }
        public virtual void FlatTextBox(FlatTextBox c) { }
        public virtual void FlatMaskedTextBox(FlatMaskedTextBox c) { }
        public virtual void FlatComboBox(FlatComboBox c) { }
        public virtual void FlatStatusBar(FlatStatusBar c) { }
    }
}
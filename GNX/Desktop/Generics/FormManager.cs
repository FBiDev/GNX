namespace GNX.Desktop
{
    public static class FormManager
    {
        public static void ResetControls(params object[] controls)
        {
            for (int i = 0; i < controls.Length; i++)
            {
                if (controls[i] is FlatLabel) ((FlatLabel)controls[i]).Text = string.Empty;
                else if (controls[i] is FlatTextBox) ((FlatTextBox)controls[i]).Text = string.Empty;
                else if (controls[i] is FlatTableLayoutPanel) ResetPanelForm((FlatTableLayoutPanel)controls[i]);
                else if (controls[i] is object) controls[i] = null;
            }
        }

        public static void ResetPanelForm(FlatPanel pnlForm)
        {
            var textbox = pnlForm.GetControls<FlatTextBox>();

            foreach (var item in textbox)
                ResetControls(item);
        }

        public static void ResetPanelForm(FlatTableLayoutPanel pnlForm)
        {
            var textbox = pnlForm.GetControls<FlatTextBox>();

            foreach (var item in textbox)
                ResetControls(item);
        }

        public static bool IsInvalidObject<T>(T obj) where T : class, new()
        {
            if (obj.IsNull() || obj.IsEqual(new T()))
                return true;

            return false;
        }

        public static bool IsInvalidValues(params object[] values)
        {
            foreach (var value in values)
            {
                if (value is int)
                {
                    if ((int)value <= 0)
                        return true;
                    continue;
                }

                if (value is string)
                {
                    if (string.IsNullOrWhiteSpace((string)value))
                        return true;
                    continue;
                }

                if (value is FlatTextBox)
                {
                    if (string.IsNullOrWhiteSpace(((FlatTextBox)value).Text))
                        return true;
                    continue;
                }
            }
            return false;
        }
    }
}
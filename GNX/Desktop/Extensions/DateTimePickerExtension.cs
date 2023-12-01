using System.Windows.Forms;

namespace GNX.Desktop
{
    public static class DateTimePickerExtension
    {
        public static void Open(this DateTimePicker obj)
        {
            obj.Select();
            SendKeys.Send("%{DOWN}");
        }
    }
}
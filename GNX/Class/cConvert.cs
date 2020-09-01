using System;
//
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
//

namespace GNX
{
    public class cConvert
    {
        public static int? ToIntNull(string value)
        {
            if (value != string.Empty)
            {
                int ValidInt;
                if (int.TryParse(value, out ValidInt))
                {
                    return ValidInt;
                }
                else { return null; }
            }
            else { return null; }
        }

        public static int? ToIntNull(object obj)
        {
            if (obj != null)
            {
                return ToIntNull(obj.ToString());
            }
            return null;
        }

        public static short? ToShortNull(string value)
        {
            if (value != string.Empty)
            {
                short ValidShort;
                if (short.TryParse(value, out ValidShort))
                {
                    return ValidShort;
                }
                else { return null; }
            }
            else { return null; }
        }

        public static float ToFloat(string value)
        {
            float result = 0;
            if (value != string.Empty)
            {
                string cs = cApp.CurrencySymbol;
                string gs = cApp.CurrencyGroupSeparator;
                value = value.ToString().Replace(cs, "").Replace(gs, "").Replace("'", "").Trim();
                float.TryParse(value, out result);
            }
            return result;
        }

        public static decimal ToDecimal(string value)
        {
            decimal result = 0;
            if (value != string.Empty)
            {
                string cs = cApp.CurrencySymbol;
                string gs = cApp.CurrencyGroupSeparator;
                value = value.ToString().Replace(cs, "").Replace(gs, "").Replace("'", "").Trim();
                decimal.TryParse(value, out result);
            }
            return result;
        }

        public static string ToCurrency(string value)
        {
            decimal result = 0;
            if (value != string.Empty)
            {
                if (decimal.TryParse(value, out result))
                {
                    value = String.Format("{0:C2}", result);
                }
            }
            return value;
        }

        public static bool ToBoolean(string value)
        {
            if (value == "Sim" || value == "1" || value == "True")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static DateTime? ToDateTimeNull(string value)
        {
            DateTime date = default(DateTime);

            if (value.Replace("/", "").Trim() != string.Empty)
            {
                DateTime ValidDate;
                if (DateTime.TryParse(value, out ValidDate))
                {
                    date = ValidDate;
                }
                else { return null; }
            }
            else { return null; }

            return date;
        }

        public static string ToDateTimeDB(DateTime? date)
        {
            if (date != null && date.Value != null)
            {
                return date.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            return null;
        }

        public static TimeSpan? ToTimeSpanNull(string value)
        {
            TimeSpan time = default(TimeSpan);

            if (value != string.Empty && value.Length >= 2)
            {
                value = value.Replace("h", "").Replace(":", "").Insert(2, ":");
                if (value.Length == 3) { value = value.Insert(3, "00"); }

                TimeSpan ValidTimeSpan;
                if (TimeSpan.TryParse(value, out ValidTimeSpan))
                {
                    time = ValidTimeSpan;
                }
                else { return null; }
            }
            else { return null; }

            return time;
        }

        public static Icon ToIco(Image img, Size size)
        {
            Icon icon;
            using (var msImg = new MemoryStream())
            {
                var msIco = new MemoryStream();

                img.Save(msImg, ImageFormat.Png);
                var bw = new BinaryWriter(msIco);

                bw.Write((short)0);           //0-1 reserved
                bw.Write((short)1);           //2-3 image type, 1 = icon, 2 = cursor
                bw.Write((short)1);           //4-5 number of images
                bw.Write((byte)size.Width);   //6 image width
                bw.Write((byte)size.Height);  //7 image height
                bw.Write((byte)0);            //8 number of colors
                bw.Write((byte)0);            //9 reserved
                bw.Write((short)0);           //10-11 color planes
                bw.Write((short)32);          //12-13 bits per pixel
                bw.Write((int)msImg.Length);  //14-17 size of image data
                bw.Write(22);                 //18-21 offset of image data
                bw.Write(msImg.ToArray());    // write image data
                bw.Flush();
                bw.Seek(0, SeekOrigin.Begin);
                icon = new Icon(msIco);

                bw.Dispose();
            }
            return icon;
        }
    }
}

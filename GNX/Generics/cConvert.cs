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
        public static int ToInt(string value)
        {
            int result = default(int);
            int.TryParse(value, out result);
            return result;
        }

        public static int ToInt(object obj)
        {
            if (obj == null) { return default(int); }
            return ToInt(obj.ToString());
        }

        public static int? ToIntNull(string value)
        {
            int result = default(int);

            if (string.IsNullOrEmpty(value)) { return null; }
            value = value.Trim().ToLower();

            if (value == "true") { return 1; }
            else if (value == "false") { return 0; }

            if (!int.TryParse(value, out result)) { return null; }
            return result;
        }

        public static int? ToIntNull(object obj)
        {
            if (obj == null) { return null; }
            return ToIntNull(obj.ToString());
        }

        public static short ToShort(string value)
        {
            short result = default(short);
            short.TryParse(value, out result);
            return result;
        }

        public static short? ToShortNull(string value)
        {
            short result = default(short);
            if (string.IsNullOrEmpty(value) || !short.TryParse(value, out result)) { return null; }
            return result;
        }

        private static string ToNumber(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                string cs = cApp.CurrencySymbol;
                string gs = cApp.CurrencyGroupSeparator;
                value = value.ToString().Replace(cs, "").Replace(gs, "").Replace("'", "").Trim();
            }
            return value;
        }

        public static float ToFloat(string value)
        {
            float result = default(float);
            value = ToNumber(value);
            float.TryParse(value, out result);
            return result;
        }

        public static float? ToFloatNull(string value)
        {
            float result = default(float);
            if (string.IsNullOrEmpty(value) || !float.TryParse(value, out result)) { return null; }
            return result;
        }

        public static Double ToDouble(string value)
        {
            Double result = default(Double);
            value = ToNumber(value);
            Double.TryParse(value, out result);
            return result;
        }

        public static Double? ToDoubleNull(string value)
        {
            Double result = default(Double);
            if (string.IsNullOrEmpty(value) || !Double.TryParse(value, out result)) { return null; }
            return result;
        }

        public static decimal ToDecimal(string value)
        {
            decimal result = default(decimal);
            value = ToNumber(value);
            decimal.TryParse(value, out result);
            return result;
        }

        public static Decimal? ToDecimalNull(string value)
        {
            Decimal result = default(Decimal);
            if (string.IsNullOrEmpty(value) || !Decimal.TryParse(value, out result)) { return null; }
            return result;
        }

        public static string ToCurrency(string value)
        {
            decimal result = default(decimal);
            if (decimal.TryParse(value, out result))
            {
                value = string.Format("{0:C2}", result);
            }
            return value;
        }

        public static bool ToBoolean(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;

            value = value.Trim().ToLower();

            if (value == "1" || value == "true" ||
                value == "y" || value == "yes" ||
                value == "s" || value == "sim"
               )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static DateTime ToDateTime(string value)
        {
            DateTime result = default(DateTime);
            DateTime.TryParse(value, out result);
            return result;
        }

        public static DateTime? ToDateTimeNull(string value)
        {
            DateTime result = default(DateTime);
            if (string.IsNullOrEmpty(value) || !DateTime.TryParse(value, out result)) { return null; }
            return result;
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

        public static T ToObject<T>(object obj) where T : new()
        {
            if (obj != null)
            {
                return (T)obj;
            }
            //return default(T);
            return new T();
        }

        public static Icon ToIco(System.Drawing.Image img, Size size)
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

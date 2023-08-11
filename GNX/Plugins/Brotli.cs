using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;

namespace GNX
{
    public static class Brotli
    {
        static Assembly assembly;

        static string DllName = "Brotli.Core";
        static string DllPath = "Plugins/" + DllName + ".dll";

        static Type BrotliClass;

        static bool LoadAssembly()
        {
            if (assembly == null)
            {
                try
                {
                    assembly = Assembly.LoadFrom(DllPath);
                    BrotliClass = assembly.GetType("Brotli.BrotliStream");
                }
                catch (Exception)
                {
                    throw new DllNotFoundException("DLL not found:\r\n" + DllPath);
                }
            }

            return assembly != null & BrotliClass != null;
        }

        public static byte[] Decompress(byte[] data)
        {
            if (LoadAssembly() == false) return null;

            var args = new object[] { new MemoryStream(data), CompressionMode.Decompress };
            using (var stream = (Stream)Activator.CreateInstance(BrotliClass, args))
            {
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    data = memoryStream.ToArray();

                    return data;
                }
                //using (var reader = new StreamReader(stream)) { return reader.ReadToEnd(); }
            }
        }
    }
}
﻿using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GNX
{
    public static class Json
    {
        static Assembly assembly;

        static string DllName = "Newtonsoft.Json";
        static string DllPath = "Plugins/" + DllName + ".dll";

        static Type JsonClass;
        static Type EnumFormatting;
        static MethodInfo SerializeObjectMethod;
        static MethodInfo DeserializeObjectMethod;

        static bool LoadAssembly()
        {
            if (assembly == null)
            {
                try
                {
                    assembly = Assembly.LoadFrom(DllPath);
                    JsonClass = assembly.GetType(DllName + ".JsonConvert");
                    EnumFormatting = assembly.GetType(DllName + ".Formatting");
                    SerializeObjectMethod = JsonClass.GetMethod("SerializeObject", new Type[] { typeof(object), EnumFormatting });
                }
                catch (Exception)
                {
                    throw new DllNotFoundException("DLL not found:\r\n" + DllPath);
                }
            }

            return assembly != null & JsonClass != null & EnumFormatting != null;
        }

        public static T DeserializeObject<T>(string value) where T : class
        {
            if (LoadAssembly() == false) return null;

            DeserializeObjectMethod = JsonClass.GetMethods()
                    .FirstOrDefault(m => m.Name == "DeserializeObject" && m.IsGenericMethod).MakeGenericMethod(typeof(T));

            var result = DeserializeObjectMethod.Invoke(null, new object[] { value });

            return (T)result;
        }

        public static string SerializeObject(object value, bool indented = true)
        {
            if (LoadAssembly() == false) return null;

            var formatting = Enum.ToObject(EnumFormatting, indented.ToInt());
            var result = (string)SerializeObjectMethod.Invoke(null, new object[] { value, formatting });

            return result;
        }

        public static bool Load<T>(ref T obj, string path) where T : class
        {
            if (File.Exists(path))
            {
                var jsonData = File.ReadAllText(path);
                obj = DeserializeObject<T>(jsonData);
                return true;
            }
            return false;
        }

        public static bool Save(object value, string path, bool indented = true)
        {
            try
            {
                var jsonData = SerializeObject(value, indented);
                jsonData = jsonData.Replace(@"\\", "/");

                File.WriteAllText(path, jsonData, Encoding.UTF8);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
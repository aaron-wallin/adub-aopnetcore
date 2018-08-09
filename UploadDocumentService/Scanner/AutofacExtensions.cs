using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac;

namespace UploadDocumentProcessor.Scanner
{
    public static class AutofacExtensions
    {
        public static void ScanAssembly(this ContainerBuilder builder, string searchPattern = "Document*.dll")
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            foreach (var assembly in Directory.GetFiles(path, searchPattern).Select(Assembly.LoadFrom))
            {
                builder.RegisterAssemblyModules(assembly);
            }
        }

        public static byte[] ToByteArray(this string valueToConvert)
        {
            return Encoding.ASCII.GetBytes(valueToConvert);
        }
    }
}

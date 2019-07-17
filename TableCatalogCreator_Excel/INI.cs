using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TableCatalogCreator2
{
    [SuppressUnmanagedCodeSecurity]
    static class INI
    {
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        public static extern int WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador.IntentoCodigoIntermedio
{
    internal class Convertidor_string_a_txt
    {
        public static bool serealizo;
        public static void Convertidor(string CodigoIntermedio)
        {
            string path = "";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(CodigoIntermedio);
                    
                }
            }

            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    MessageBox.Show(s);
                    serealizo= true;
                }
            }
        }
    }
}

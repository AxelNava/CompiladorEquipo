using System;
using System.IO;
using System.Windows.Forms;

namespace Compilador.IntentoCodigoIntermedio
{
   internal class Convertidor_string_a_txt
   {
      public static bool serealizo;

      public static void Convertidor(string CodigoIntermedio)
      {
         if (string.IsNullOrEmpty(CodigoIntermedio))
         {
            CodigoIntermedio = $"PrimeraLinea\nSegundaLínea\nTerceraLínea\nCuartaLínea";
         }

         string path = $"{Application.StartupPath}\\CodigoIntermedio.txt";
         if (!File.Exists(path))
         {
            using (StreamWriter sw = File.CreateText(path))
            {
               sw.WriteLine(CodigoIntermedio);
               sw.Close();
               serealizo = true;
            }
         }

         // using (FileStream fileStream = File.Open(path, FileMode.Truncate, FileAccess.Write))
         // {
         //    fileStream.Close();
         // }
         /*using (StreamReader sr = File.OpenText(path))
         {
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
               serealizo = true;
            }

            sr.Close();
         }*/
         if (serealizo)
         {
            if (MessageBox.Show("Se ha creado el código intermedio Exitosamente\nPulse \"OK\" para abrir la ubicación del archivo", "Conversion",
                   MessageBoxButtons.OK, MessageBoxIcon.Information,
                   MessageBoxDefaultButton.Button3) == DialogResult.OK)
            {
               System.Diagnostics.Process.Start(Application.StartupPath);
            }
         }
      }
   }
}
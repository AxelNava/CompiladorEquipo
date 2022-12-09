using System;
using System.IO;
using System.Windows.Forms;

namespace Compilador.IntentoCodigoIntermedio
{
   internal class Convertidor_string_a_txt
   {
      private static bool serealizo;

      public static void Convertidor(string CodigoIntermedio)
      {
         if (string.IsNullOrEmpty(CodigoIntermedio))
         {
            CodigoIntermedio = $"PrimeraLinea\nSegundaLínea\nTerceraLínea\nCuartaLínea";
         }

         string path = $"{Application.StartupPath}\\CodigoIntermedio.txt";
         TextWriter textWriter = new StreamWriter(path);
         textWriter.Write(CodigoIntermedio);
         textWriter.Close();
         serealizo = true;

         if (!serealizo) return;
         if (MessageBox.Show("Se ha creado el código intermedio Exitosamente\nPulse \"OK\" para abrir la ubicación del archivo", "Conversion",
                MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button3) == DialogResult.OK)
         {
            System.Diagnostics.Process.Start(Application.StartupPath);
         }
      }
   }
}
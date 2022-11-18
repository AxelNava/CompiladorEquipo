using System.Collections.Generic;

namespace Compilador.TablasGlobales
{
   public class Tabla_DesplazamientosValores
   {
      private static Dictionary<string, int> _desplazamientosValoresDictionary = new Dictionary<string, int>()
      {
         { "int", 4 },
         {"char", 1},
         {"string", 256},
         {"Entero", 4},
         {"Decimal", 4},
         {"Cadena", 256},
         {"Caracter",1}
      };

      public static Dictionary<string, int> DesplazamientosValoresDictionary => _desplazamientosValoresDictionary;

      public static int GetValueOfShift(string type)
      {
         return _desplazamientosValoresDictionary[type];
      }
      
   }
}
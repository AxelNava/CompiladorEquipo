using System.Collections.Generic;

namespace Compilador.TablasGlobales
{
   public class Tabla_DesplazamientosValores
   {
      private static Dictionary<string, int> _desplazamientosValoresDictionary = new Dictionary<string, int>()
      {
         { "int", 4 },
         {"char", 2},
         {"string", 256},
         {"float", 4},
         {"bool", 2},
         {"Entero", 4},
         {"Decimal", 4},
         {"Cadena", 256},
         {"Caracter",2},
         {"BOOL", 2}
      };

      public static Dictionary<string, int> DesplazamientosValoresDictionary => _desplazamientosValoresDictionary;

      public static int GetValueOfShift(string type)
      {
         return _desplazamientosValoresDictionary[type];
      }
      
   }
}
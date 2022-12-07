using System.Collections.Generic;

namespace Compilador.AnalizadorSemantico
{
   public class ContadorDesplazamiento
   {
      private static int conteoDesplazamiento;

      public static int ConteoDesplazamiento
      {
         get => conteoDesplazamiento;
         set => conteoDesplazamiento = value;
      }

      public static void AddShiftType(string type)
      {
         switch (type)
         {
            case "int":
               AddShift(4);
               break;
            case "string":
               AddShift(256);
               break;
            case "float":
               AddShift(4);
               break;
            case "bool":
               AddShift(1);
               break;
            case "char":
               AddShift(1);
               break;
         }
      }

      private static void AddShift(int desplazamineto)
      {
         conteoDesplazamiento += desplazamineto;
      }

      public static void AddShiftClass(int desplazamiento)
      {
         conteoDesplazamiento += desplazamiento;
      }
   }
}
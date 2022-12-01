using System.Collections.Generic;
using System.Text;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;

namespace Compilador.AnalizadorSintactico
{
   public class ErrorSintaxManager
   {
      private static Dictionary<string, AbstractActionFunction> FilaEstado;
      private static StringBuilder ErrorMessage = new StringBuilder();
      public static string GetMessageError()
      {
         return ErrorMessage.ToString();
      }

      public static void AddMessageError(Dictionary<string, AbstractActionFunction> filaEstado, int numLinea)
      {
         FilaEstado = filaEstado;
         foreach (var key in FilaEstado.Keys)
         {
            if(FilaEstado[key].Action == AbstractActionFunction.ActionEnum.DESPLAZAMIENTO)
               ErrorMessage.AppendFormat($"Se esperaba un \"{key}\" -- Línea {numLinea} \n");
         }
      }

      public static void AddDeclarationError(string identifier, int numLine)
      {
         ErrorMessage.AppendFormat($"El identificador {identifier} ya ha sido declarado  -- Línea {numLine} \n");
      }

      public static void ClearMessage()
      {
         ErrorMessage.Clear();
      }
   }
}
using System;

namespace Compilador.AnalizadorSintactico
{
   public class tokensNameGlobal
   {
      public enum tokensGlobals
      {
         NEGACION,
         Comparador,
         Asignacion,
         AND,
         OR,
         Identificador,
         ENTERO,
         DECIMAL,
         CADENA,
         CARACTER,
         OPERADOR,
         INCREMENTO,
         DECREMENTO,
         PUNTOYCOMA,
         CORCHETECIERRA,
         CORCHETEABRE,
         LLAVEABRE,
         LLAVECIERRA,
         PARENTESISABRE,
         PARENTESISCIERRA
      }

      private static readonly string[] tokens =
      {
         "Negacion",
         "Comparador",
         "Asignacion",
         "AND",
         "OR",
         "Identificador",
         "Entero",
         "Decimal",
         "Cadena",
         "Caracter",
         "Operador",
         "Incremento",
         "Decremento",
         "PuntoyComa",
         "CorcheteCierra",
         "CorcheteAbre",
         "LlaveAbre",
         "LlaveCierra",
         "ParentesisAbre",
         "ParentesisCierra"
      };
      public static string selectorString(tokensGlobals notTerminal)
      {
         return tokens.GetValue((int)Convert.ChangeType(notTerminal, notTerminal.GetTypeCode())).ToString();
      }
   }
}
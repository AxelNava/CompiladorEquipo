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
         PARENTESISCIERRA,
         TIPO,
         FOR,
         IF,
         WHILE,
         ELSE,
         USING,
         DO,
         CLASS,
         VOID,
         BOOL,
         SWITCH
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
         "ParentesisCierra",
         "TIPO",
         "FOR",
         "IF",
         "WHILE",
         "ELSE",
         "USING",
         "DO",
         "CLASS",
         "VOID",
         "BOOL",
         "SWITCH"
      };
      public static string selectorString(tokensGlobals notTerminal)
      {
         return tokens.GetValue((int)Convert.ChangeType(notTerminal, notTerminal.GetTypeCode())).ToString();
      }
   }
}
using System;
using Compilador.AnalizadorSintactico;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Compilador.TablasGlobales;

namespace Compilador.AnalizadorSemantico
{
   public static class AnalizadorDeLimites
   {
      public static void AnaliceIdentifier_Token()
      {
         // string token_Lexema = TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item3;
         string token_Lexema = "";
         if (TablaLexemaToken.LexemaTokensTable.ContainsKey(LexemaCount.CountLexemas))
         {
            token_Lexema = TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item3;
         }
         switch (token_Lexema)
         {
            case "Entero":
               CheckMaxMinValueOfInteger();
               break;
            case "Decimal":
               CheckMaxMinValueOfFloat();
               break;
            case "Cadena":
               CheckStringLenght();
               break;
         }
      }

      public static void HandleIdentifier(string lexemaToAnalice)
      {
         if (TablaSimbolos.CheckTypeOfLexema(lexemaToAnalice))
         {
            int numRow = TablaSimbolos.numRowInTable(lexemaToAnalice);
            if (TablaSimbolos.GetValues()[numRow] != string.Empty)
            {
               string type = TablaSimbolos.GetTypeOfLexema(lexemaToAnalice);
               switch (type)
               {
                  case "int":
                     CheckMaxMinValueOfInteger();
                     break;
                  case "string":
                     CheckStringLenght();
                     break;
                  case "float":
                     CheckMaxMinValueOfFloat();
                     break;
               }
            }
         }
      }

      #region AnalizadoresParaNoIdentificadores

      private static void CheckMaxMinValueOfFloat()
      {
         if (!float.TryParse(TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item2, out _))
         {
            Mensajes_ErroresSemanticos.AddErrorOverflowMaxMinValue(TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item2,
               TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item3,
               TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item1);
         }
      }

      private static void CheckStringLenght()
      {
         if (TablaLexemaToken.LexemaTokensTable.ContainsKey(LexemaCount.CountLexemas))
         {
            if (TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item2.Length > 256)
            {
               Mensajes_ErroresSemanticos.AddErrorOverflowMaxValue(TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item3,
                  TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item1);
            }
         }
      }

      private static void CheckMaxMinValueOfInteger()
      {
         if (TablaLexemaToken.LexemaTokensTable.ContainsKey(LexemaCount.CountLexemas))
         {
            if (!Int32.TryParse(TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item2, out _))
            {
               Mensajes_ErroresSemanticos.AddErrorOverflowMaxMinValue(TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item2,
                  TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item3,
                  TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item1);
            }
         }
      }

      #endregion

      #region AnalizadoresParasSoloValroes

      public static void AnaliceMinManInteger(string value)
      {
         if (!Int32.TryParse(value, out _))
         {
            Mensajes_ErroresSemanticos.AddErrorOverflowMaxMinValue(TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item2,
               TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item3,
               TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item1);
         }
      }
      public static void AnalizeMinMaxFloat(string value)
      {
         if (!float.TryParse(value, out _))
         {
            Mensajes_ErroresSemanticos.AddErrorOverflowMaxMinValue(TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item2,
               TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item3,
               TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item1);
         }
      }
      public static void AnalizeLenghtString(string value)
      {
         if (value.Length > 256)
         {
            Mensajes_ErroresSemanticos.AddErrorOverflowMaxValue("string",
               TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item1);
         }
      }
      

      #endregion

      public static void AnalizeValueIntFloat(string value)
      {
         if (!Int32.TryParse(value, out _))
         {
           
         }
      }
   }
}
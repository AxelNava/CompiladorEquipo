using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts.Internal;
using Compilador.AnalizadorSintactico;
using Compilador.AnalizadorSintactico.Gramaticas.AnalysisTables;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Compilador.TablasGlobales;

namespace Compilador.AnalizadorSintactico.Gramaticas
{
   public class GramaticaValores : AbstractAnalisisTable
   {
      public GramaticaValores()
      {
         tablaAnalisis = AnalisysTable_Valores_boolOpe.globalDictionaryValores;
         
         PilaComprobacion = new Stack<Tuple<int, string>>();
         PilaComprobacion.Push(new Tuple<int, string>(0, "0"));
      }
      public string EjecutarAnalisis()
      {
         analisisFinished = false;
         while (PilaTokens.GlobalTokens.Count >= 1)
         {
            if (!CheckTokenIn_Handler())
            {
               PilaTokens.GlobalTokens.Push("Lambda");
               if (!CheckTokenIn_Handler())
               {
                  PilaTokens.GlobalTokens.Pop();
                  PilaTokens.GlobalTokens.Push("FinCadena");
                  if (!CheckTokenIn_Handler())
                  {
                     PilaTokens.GlobalTokens.Pop();
                     return string.Empty;
                  }
               }
            }
            if (analisisFinished) return "Valores";
         }
         return string.Empty;
      }

      private bool CheckTokenIn_Handler()
      {
         int referenceState = PilaComprobacion.Peek().Item1;
        
         if (tablaAnalisis[referenceState].ContainsKey(PilaTokens.GlobalTokens.Peek()))
         {
            IdentifierToValue();
            AbstractActionFunction.ActionEnum actionEnum;
            actionEnum = tablaAnalisis[referenceState][PilaTokens.GlobalTokens.Peek()].Action;
            HandleActions(actionEnum);
            return true;
         }

         return false;
      }

      private void IdentifierToValue()
      {
         if (PilaTokens.GlobalTokens.Peek() == tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador))
         {
            if (TablaSimbolos.CheckLexema(TablaLexemaToken.GetLexema(LexemaCount.CountLexemas + 1)))
            {
               int numrow = TablaSimbolos.numRowInTable(TablaLexemaToken.GetLexema(LexemaCount.CountLexemas + 1));
               
            }
         }
      }
   }
}
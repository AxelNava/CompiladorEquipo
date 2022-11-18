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
         TablaAnalisis = AnalisysTable_Valores_boolOpe.globalDictionaryValores;
         
         PilaComprobacion = new Stack<Tuple<int, string>>();
         PilaComprobacion.Push(new Tuple<int, string>(0, "0"));
      }
      public string EjecutarAnalisis()
      {
         AnalisisFinished = false;
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
                     AddError();
                     return string.Empty;
                  }
               }
            }
            if (AnalisisFinished) return "Valores";
         }
         return string.Empty;
      }

      private bool CheckTokenIn_Handler()
      {
         int referenceState = PilaComprobacion.Peek().Item1;
        
         if (TablaAnalisis[referenceState].ContainsKey(PilaTokens.GlobalTokens.Peek()))
         {
            IdentifierToValue();
            AbstractActionFunction.ActionEnum actionEnum;
            actionEnum = TablaAnalisis[referenceState][PilaTokens.GlobalTokens.Peek()].Action;
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
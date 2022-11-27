using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts.Internal;
using Compilador.AnalizadorSemantico;
using Compilador.AnalizadorSintactico;
using Compilador.AnalizadorSintactico.Gramaticas.AnalysisTables;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Compilador.TablasGlobales;

namespace Compilador.AnalizadorSintactico.Gramaticas
{
   public class GramaticaValores : AbstractAnalisisTable
   {
      private string _tipoTotalValores;
      private string _valueIdentifier;
      private string _tipoTemporal;

      public GramaticaValores()
      {
         TablaAnalisis = AnalisysTable_Valores_boolOpe.globalDictionaryValores;
         PilaComprobacion = new Stack<Tuple<int, string>>();
         PilaComprobacion.Push(new Tuple<int, string>(0, "0"));
      }

      public string TipoTotalValores => _tipoTotalValores;

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

            if (AnalisisFinished)
            {
               return "Valores";
            }
         }

         return string.Empty;
      }

      private bool CheckTokenIn_Handler()
      {
         int referenceState = PilaComprobacion.Peek().Item1;

         if (TablaAnalisis[referenceState].ContainsKey(PilaTokens.GlobalTokens.Peek()))
         {
            CheckWheterIsMethod(referenceState);
            IdentifierToValue(referenceState);
            AbstractActionFunction.ActionEnum actionEnum;
            actionEnum = TablaAnalisis[referenceState][PilaTokens.GlobalTokens.Peek()].Action;
            HandleActions(actionEnum);
            return true;
         }

         return false;
      }

      /// <summary>
      /// Verifica que el identificador tenga un tipo
      /// </summary>
      private void IdentifierToValue(int referenceState)
      {
         if (PilaTokens.GlobalTokens.Peek() == tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador))
         {
            if (TablaSimbolos.CheckTypeOfLexema(TablaLexemaToken.GetLexema(LexemaCount.CountLexemas + 1)))
            {
               int numrow = TablaSimbolos.numRowInTable(TablaLexemaToken.GetLexema(LexemaCount.CountLexemas + 1));
               _tipoTemporal = TablaSimbolos.GetTypesValues()[numrow];
               return;
            }

            if (CheckIdentifier(referenceState))
            {
               return;
            }
            Mensajes_ErroresSemanticos.AddErrorInstanciation(PilaTokens.GlobalTokens.Peek(),
               TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas + 1].Item1);
         }
      }

      private bool CheckIdentifier(int referenceState)
      {
         if (referenceState == 4 || referenceState == 11 || referenceState == 41)
         {
            _valueIdentifier = TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item2;
            return true;
         }

         return false;
      }

      private void CheckWheterIsMethod(int referenceState)
      {
         if (referenceState == 18 || referenceState == 29 || referenceState == 60)
         {
            int numRow = TablaSimbolos.numRowInTable(_valueIdentifier);
            if (numRow != 0)
            {
               TablaSimbolos.GetValues()[numRow] = 1.ToString();
               TablaSimbolos.GetTypesValues()[numRow] = "Metodo";
            }
         }
      }
   }
}
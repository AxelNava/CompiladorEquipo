using System;
using System.Collections.Generic;
using Compilador.AnalizadorSemantico;
using Compilador.AnalizadorSintactico.Gramaticas.AnalysisTables;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using Compilador.TablasGlobales;

namespace Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales
{
   public class Gramatica_CuerpoClase : AbstractAnalisisTable
   {
      private string identificadorEncontrado;
      private string tipoEncontrado;

      public Gramatica_CuerpoClase()
      {
         TablaAnalisis = AnalisysTable_CuerpoClase.GlobalDictionary_CuerpoValores;
         PilaComprobacion = new Stack<Tuple<int, string>>();
         PilaComprobacion.Push(new Tuple<int, string>(0, "0"));
      }

      public string Ejecutar_Analisis()
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
               return "bodyclass";
            }
         }

         return string.Empty;
      }

      private bool CheckTokenIn_Handler()
      {
         int referenceState = PilaComprobacion.Peek().Item1;
         if (TablaAnalisis[referenceState].ContainsKey(PilaTokens.GlobalTokens.Peek()))
         {
            HandleTokenIdentType(referenceState);
            AbstractActionFunction.ActionEnum actionEnum;
            actionEnum = TablaAnalisis[referenceState][PilaTokens.GlobalTokens.Peek()].Action;
            HandleActions(actionEnum);
            return true;
         }

         return false;
      }

      private void HandleTokenIdentType(int referenceState)
      {
         if (referenceState == 2 )
         {
            tipoEncontrado = TablaLexemaToken.GetLexema(LexemaCount.CountLexemas);
            return;
         }

         if (referenceState == 3 && PilaTokens.GlobalTokens.Peek() != "ComplementoIdentificador" && PilaTokens.GlobalTokens.Peek() != 
         tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE))
         {
            identificadorEncontrado = TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item2;
            if (!HandleIdentifiers(identificadorEncontrado))
            {
               ErrorSintaxManager.AddDeclarationError(identificadorEncontrado, TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item1);
            }
         }
      }

      private bool HandleIdentifiers(string identifier)
      {
         int numRow = TablaSimbolos.numRowInTable(identifier);
         if (!TablaSimbolos.CheckTypeOfLexema(identifier))
         {
            TablaSimbolos.GetTypesValues()[numRow] = tipoEncontrado;
            AssignShiftToIdentifier(numRow);
            ContadorDesplazamiento.AddShiftType(tipoEncontrado);

            return true;
         }
         return false;
      }

      private void AssignShiftToIdentifier(int numRow)
      {
         TablaSimbolos.GetDesplazamientos()[numRow] = ContadorDesplazamiento.ConteoDesplazamiento.ToString();
      }
   }
}
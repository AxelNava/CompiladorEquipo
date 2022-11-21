using System;
using Compilador.AnalizadorSintactico.Gramaticas.AnalysisTables;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using System.Collections.Generic;
using System.Threading;
using Compilador.AnalizadorSemantico;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Compilador.Gramaticas;
using Compilador.TablasGlobales;

namespace Compilador.AnalizadorSintactico.Gramaticas
{
   public class Gramatica_Switch : AbstractAnalisisTable
   {
      private int _inicioConteo;
      private int _finConteo;
      private string _typeToCompare;
      private string _temporalType;

      public Gramatica_Switch()
      {
         TablaAnalisis = AnalysisTable_Switch.GlobalDictionarySwitch;
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

            if (AnalisisFinished) return "<Switch>";
         }

         return string.Empty;
      }

      private bool CheckTokenIn_Handler()
      {
         int referenceState = PilaComprobacion.Peek().Item1;
         if (referenceState == 3)
         {
            _inicioConteo = LexemaCount.CountLexemas + 1;
            GramaticaValores gramatica = new GramaticaValores();
            string tokenAux = gramatica.EjecutarAnalisis();
            if (!string.IsNullOrEmpty(tokenAux))
            {
               _finConteo = LexemaCount.CountLexemas + 1;
               PilaTokens.GlobalTokens.Push(tokenAux);
               ConversionNotacionInfija_PosFija conversor = new ConversionNotacionInfija_PosFija();
               conversor.EjecutarAnalisis(_inicioConteo, _finConteo);
               _typeToCompare = conversor.typeGlobalOfOperation;
            }
         }

         if (referenceState == 11)
         {
            if (!CheckTypes())
            {
               Mensajes_ErroresSemanticos.AddErrorOperatro(_typeToCompare, _temporalType,
                  TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item1);
            }
         }

         if (referenceState == 17 || referenceState == 18)
         {
            //Cambiar por cuerpoInstrucciones
            // string tokenAux = new GramaticaValores().EjecutarAnalisis();
            // if (!string.IsNullOrEmpty(tokenAux))
            //    PilaTokens.GlobalTokens.Push(tokenAux);
         }

         if (TablaAnalisis[referenceState].ContainsKey(PilaTokens.GlobalTokens.Peek()))
         {
            AbstractActionFunction.ActionEnum actionEnum;
            actionEnum = TablaAnalisis[referenceState][PilaTokens.GlobalTokens.Peek()].Action;
            HandleActions(actionEnum);
            return true;
         }

         return false;
      }

      private bool CheckTypes()
      {
         _temporalType = TablaRelacionTipoToken.TablaTokenTipo[TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item3];
         if (_temporalType == _typeToCompare)
         {
            return true;
         }

         return false;
      }
   }
}
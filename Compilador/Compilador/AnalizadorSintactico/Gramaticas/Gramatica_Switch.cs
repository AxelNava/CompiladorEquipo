using System;
using Compilador.AnalizadorSintactico.Gramaticas.AnalysisTables;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using System.Collections.Generic;
using Compilador.AnalizadorSemantico;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Compilador.Gramaticas;
using Compilador.IntentoCodigoIntermedio;
using Compilador.TablasGlobales;

namespace Compilador.AnalizadorSintactico.Gramaticas
{
   public class Gramatica_Switch : AbstractAnalisisTable
   {
      private int _inicioConteo;
      private int _finConteo;
      private string _typeToCompare;
      private string _temporalType;
      private int contadorCases;
      private string lexemaSwitch;
      private string lexemaCase;

      public Gramatica_Switch()
      {
         TablaAnalisis = AnalysisTable_Switch.GlobalDictionarySwitch;
         PilaComprobacion = new Stack<Tuple<int, string>>();
         PilaComprobacion.Push(new Tuple<int, string>(0, "0"));
         contadorCases = 0;
      }

      public string Ejecutar_Analisis()
      {
         AnalisisFinished = false;
         if (!TablaAnalisis[0].ContainsKey(PilaTokens.GlobalTokens.Peek()))
            return string.Empty;
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
               while (contadorCases>0)
               {
                  TablaInstrucciones.ModificarInstruccionSaltoTerminal();
                  contadorCases--;
               }
               return "<Switch>";
            }
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
            lexemaSwitch = TablaLexemaToken.GetLexema(_inicioConteo);
            string tokenAux = gramatica.EjecutarAnalisis();
            if (!string.IsNullOrEmpty(tokenAux))
            {
               _finConteo = LexemaCount.CountLexemas + 1;
               PilaTokens.GlobalTokens.Push(tokenAux);
               ConversionNotacionInfija_PosFija conversor = new ConversionNotacionInfija_PosFija(gramatica._pilaContadores);
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

         if ((referenceState == 17 || referenceState == 18) && PilaTokens.GlobalTokens.Peek() != "cuerpoInstrucciones")
         {
            // Cambiar por cuerpoInstrucciones
            string tokenAux = new Gramatica_CuerpoInstrucciones().Ejecutar_Analisis();
            if (!string.IsNullOrEmpty(tokenAux))
               PilaTokens.GlobalTokens.Push(tokenAux);
         }

         HandleJumpt(referenceState);
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

      private void HandleJumpt(int referenceState)
      {
         switch (referenceState)
         {
            case 8:
               if (PilaTokens.GlobalTokens.Peek() != "ValoresCase")
               {
                  lexemaCase = TablaLexemaToken.GetLexema(LexemaCount.CountLexemas+1);
                  contadorCases++;
                  HandleIdentifiersAndJumpsConditions(lexemaSwitch, lexemaCase);
               }

               break;
            case 9:
               for (int i = contadorCases; i > 0; i--)
               {
                  TablaInstrucciones.ModificarInstruccionSaltoCondicion();
               }

               break;
            case 22:
               TablaInstrucciones.AgregarInstruccion(string.Empty, TablaInstrucciones.IntermidiateCodeInstructions.InstruccionSalto);
               break;
         }
      }

      private void HandleIdentifiersAndJumpsConditions(string lexemaBefore, string lexemaafter)
      {
         string auxB = "";
         string auxF = "";
         if (TablaSimbolos.CheckLexema(lexemaBefore))
         {
            if (TablaSimbolos.CheckTypeOfLexema(lexemaBefore))
            {
               auxB = TablaSimbolos.GetDesplazamiento(lexemaBefore);
            }
         }
         else
         {
            auxB = $"{lexemaBefore}V";
         }

         if (TablaSimbolos.CheckLexema(lexemaafter))
         {
            if (TablaSimbolos.CheckTypeOfLexema(lexemaafter))
            {
               auxF = TablaSimbolos.GetDesplazamiento(lexemaafter);
            }
         }
         else
         {
            auxF = $"{lexemaafter}V";
         }
         TablaInstrucciones.AgregarInstruccion(auxB, auxF, TablaInstrucciones.IntermidiateCodeInstructions.InstruccionIgual);
      }
   }
}
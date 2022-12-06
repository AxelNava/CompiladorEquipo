using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts.Internal;
using Compilador.AnalizadorSemantico;
using Compilador.AnalizadorSintactico;
using Compilador.AnalizadorSintactico.Gramaticas.AnalysisTables;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Compilador.IntentoCodigoIntermedio;
using Compilador.TablasGlobales;

namespace Compilador.AnalizadorSintactico.Gramaticas
{
   public class GramaticaValores : AbstractAnalisisTable
   {
      
      private string _valueIdentifier;
      private string _tipoTemporal;
      public Stack<Tuple<int, int>> _pilaContadores;
      private ColaContadoraMetodos _contadoraMetodos;

      public GramaticaValores()
      {
         TablaAnalisis = AnalisysTable_Valores_boolOpe.globalDictionaryValores;
         PilaComprobacion = new Stack<Tuple<int, string>>();
         PilaComprobacion.Push(new Tuple<int, string>(0, "0"));
         _pilaContadores = new Stack<Tuple<int, int>>();
         _contadoraMetodos = new ColaContadoraMetodos();
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

            if (AnalisisFinished)
            {
               _pilaContadores = _contadoraMetodos.PilaResultante;
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
            CheckEndOfMethod(referenceState);
            IdentifierToValue(referenceState);
            CheckIncrementOrDecrementState(referenceState);
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

            Mensajes_ErroresSemanticos.AddErrorInstanciation(PilaTokens.GlobalTokens.Peek(),
               TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas + 1].Item1);
         }

         if (CheckIdentifier(referenceState))
         {
            return;
         }
      }

      private bool CheckIdentifier(int referenceState)
      {
         if ((referenceState == 4 || referenceState == 11 || referenceState == 41) && PilaTokens.GlobalTokens.Peek()!="InstruccionesIdentificador" && PilaTokens
         .GlobalTokens.Peek()!="RM")
         {
            _valueIdentifier = TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item2;
            return true;
         }

         return false;
      }

      private void CheckWheterIsMethod(int referenceState)
      {
         if ((referenceState == 18 || referenceState == 29 || referenceState == 61) && PilaTokens.GlobalTokens.Peek() != "VS" && PilaTokens
                .GlobalTokens.Peek() != "Param" && PilaTokens.GlobalTokens.Peek() != "Parametros")
         {
            int numRow = TablaSimbolos.numRowInTable(_valueIdentifier);
            _contadoraMetodos.AgregarInicioDeCola(LexemaCount.CountLexemas);
            if (numRow != 0)
            {
               TablaSimbolos.GetValues()[numRow] = 1.ToString();
               if (!TablaSimbolos.CheckTypeOfLexema(_valueIdentifier))
               {
                  TablaSimbolos.GetTypesValues()[numRow] = "Metodo";
               }
               tablaInstrucciones.AgregarInstruccion(_valueIdentifier, tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionLLamar);
            }
         }
      }

      //Agrega el final del conteo de un método
      private void CheckEndOfMethod(int referenceState)
      {
         if (referenceState == 39 || referenceState == 53 || referenceState == 75)
         {
            _contadoraMetodos.AgregarContador(LexemaCount.CountLexemas + 1);
         }
      }
/// <summary>
/// Chca si es un estado perteneciente a un incremento o decremento, luego de eso ejecuta el incremento en código intermedio
/// </summary>
/// <param name="referenceState"></param>
      private void CheckIncrementOrDecrementState(int referenceState)
      {
         if (referenceState == 19 || referenceState == 30 || referenceState == 62)
         {
            string identificador = TablaLexemaToken.GetLexema(LexemaCount.CountLexemas - 1);
            tablaInstrucciones.AgregarInstruccion(identificador, tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionIncremento);
            return;
         }

         if (referenceState != 20 && referenceState != 31 && referenceState != 63) return;
         {
            string identificador = TablaLexemaToken.GetLexema(LexemaCount.CountLexemas - 1);
            tablaInstrucciones.AgregarInstruccion(identificador, tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionDecremento);
         }
      }
   }
}
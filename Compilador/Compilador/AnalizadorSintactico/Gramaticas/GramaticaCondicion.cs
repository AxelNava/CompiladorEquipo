using System;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using System.Collections.Generic;
using Compilador.AnalizadorSemantico;
using Compilador.AnalizadorSintactico;
using Compilador.AnalizadorSintactico.Gramaticas;
using Compilador.AnalizadorSintactico.Gramaticas.AnalysisTables;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Compilador.IntentoCodigoIntermedio;
using Compilador.TablasGlobales;

namespace Compilador.Gramaticas
{
   enum nonTerminalTokens
   {
      veriM,
      VALOR,
      COMP,
      COMPI,
      VALORBOOL,
      VALORC,
      R,
      OPERADORLOG,
      CONDICION
   }

   public class GramaticaCondicion : AbstractAnalisisTable
   {
      private string _tokenBeforeComparison;
      private string _tokenAfterComparison;
      private string _tokenAfterNegation;

      private string[] nonTerminalsTokensString =
      {
         "VeriM",
         "Valores",
         "comp",
         "CompI",
         "ValorBool",
         "ValorC",
         "R",
         "OperadorLog",
         "Condicion"
      };

      public GramaticaCondicion()
      {
         //The first value is the state from Analysis Table, the second is the class with the 
         //token column, and the action-state reference
         TablaAnalisis = AnalysisTable_Condicion.GlobalDictionary;
         PilaComprobacion = new Stack<Tuple<int, string>>();
         PilaComprobacion.Push(new Tuple<int, string>(0, "0"));
      }

      private string lexemaComparador;
      private string lexemaBefore;
      private string lexemaAfter;
      private bool _yaSeAgrego;

      public string EjecutarAnalisis()
      {
         while (PilaTokens.GlobalTokens.Count >= 1)
         {
            if (!CheckTokenInHandler())
            {
               PilaTokens.GlobalTokens.Push("Lambda");
               if (!CheckTokenInHandler())
               {
                  PilaTokens.GlobalTokens.Pop();
                  PilaTokens.GlobalTokens.Push("FinCadena");
                  if (!CheckTokenInHandler())
                  {
                     PilaTokens.GlobalTokens.Pop();
                     AddError();
                     return string.Empty;
                  }
               }
            }

            if (AnalisisFinished) return "condicion";
         }

         return string.Empty;
      }

      private string selectorString(nonTerminalTokens token)
      {
         return nonTerminalsTokensString.GetValue((int)Convert.ChangeType(token, token.GetTypeCode())).ToString();
      }

      private bool CheckTokenInHandler()
      {
         int referenceState = PilaComprobacion.Peek().Item1;
         if (!CheckTokenBefore(referenceState))
         {
            if (CheckTokenAfter(referenceState))
            {
               if (_tokenBeforeComparison != _tokenAfterComparison)
               {
                  Mensajes_ErroresSemanticos.AddErrorOperatro(_tokenBeforeComparison, _tokenAfterComparison, TablaLexemaToken
                     .LexemaTokensTable[LexemaCount.CountLexemas].Item1);
               }

               AgregarInstruccionDeComparacion(lexemaBefore, lexemaAfter);
            }
         }

         if (referenceState == 4)
         {
            if (!CheckTokenWithNegation())
            {
               Mensajes_ErroresSemanticos.AddErrorOperatro("bool", _tokenAfterNegation,
                  TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item1);
            }
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

      private void CheckStateOfComparador()
      {
         lexemaComparador = TablaLexemaToken.GetLexema(LexemaCount.CountLexemas);
      }

      /// <summary>
      /// Construye la instrucción correspondiente
      /// </summary>
      /// <param name="lexemaB">Lexema antes del comparador (el primero que se encuentra a la izquierda)</param>
      /// <param name="lexemaF">Lexema después del comparador</param>
      private void AgregarInstruccionDeComparacion(string lexemaB, string lexemaF)
      {
         string auxB = "";
         string auxF = "";
         if (_yaSeAgrego) return;
         if (TablaSimbolos.CheckLexema(lexemaB))
         {
            if (TablaSimbolos.CheckTypeOfLexema(lexemaB))
            {
               auxB = TablaSimbolos.GetDesplazamiento(lexemaB);
               
            }
         }
         else
         {
            auxB = $"{lexemaB}V";
         }

         if (TablaSimbolos.CheckLexema(lexemaF))
         {
            if (TablaSimbolos.CheckTypeOfLexema(lexemaF))
            {
               auxF = TablaSimbolos.GetDesplazamiento(lexemaF);
            }
         }
         else
         {
            auxF = $"{lexemaF}V";
         }


         switch (lexemaComparador)
         {
            case "<":
               tablaInstrucciones.AgregarInstruccion(auxB, auxF, tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionMenor);
               break;
            case ">":
               tablaInstrucciones.AgregarInstruccion(auxB, auxF, tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionMayor);
               break;
            case "==":
               tablaInstrucciones.AgregarInstruccion(auxB, auxF, tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionIgual);
               break;
            case ">=":
               tablaInstrucciones.AgregarInstruccion(auxB, auxF, tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionMayorIgual);
               break;
            case "<=":
               tablaInstrucciones.AgregarInstruccion(auxB, auxF, tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionMenorIgual);
               break;
            case "!=":
               tablaInstrucciones.AgregarInstruccion(auxB, auxF, tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionDiferente);
               break;
         }

         _yaSeAgrego = true;
      }

      private bool CheckTokenBefore(int referenceState)
      {
         if ((referenceState == 0 || referenceState == 24) && PilaTokens.GlobalTokens.Peek() != selectorString(nonTerminalTokens.COMP) &&
             PilaTokens.GlobalTokens.Peek() != selectorString(nonTerminalTokens.CONDICION))
         {
            int inicioConteo = LexemaCount.CountLexemas + 1;
            GramaticaValores valores = new GramaticaValores();
            string tokenTemp = valores.EjecutarAnalisis();
            if (!string.IsNullOrEmpty(tokenTemp))
            {
               lexemaBefore = TablaLexemaToken.GetLexema(inicioConteo);
               int final = LexemaCount.CountLexemas + 1;
               PilaTokens.GlobalTokens.Push(tokenTemp);
               ConversionNotacionInfija_PosFija conversion = new ConversionNotacionInfija_PosFija(valores._pilaContadores);
               conversion.EjecutarAnalisis(inicioConteo, final);
               if (!string.IsNullOrEmpty(conversion.typeGlobalOfOperation))
               {
                  if (conversion.typeGlobalOfOperation == "bool")
                  {
                     PilaTokens.GlobalTokens.Pop();
                     PilaTokens.GlobalTokens.Push(selectorString(nonTerminalTokens.VALORBOOL));
                  }

                  _tokenBeforeComparison = conversion.typeGlobalOfOperation;
                  // return false;
               }

               return true;
            }
         }

         return false;
      }

      private bool CheckTokenAfter(int referenceState)
      {
         if ((referenceState == 11 || referenceState == 19) && PilaTokens.GlobalTokens.Peek() != selectorString(nonTerminalTokens.VALORC))
         {
            CheckStateOfComparador();
            int inicioConteo = LexemaCount.CountLexemas + 1;
            GramaticaValores valores = new GramaticaValores();
            string tokenTemp = valores.EjecutarAnalisis();
            if (!string.IsNullOrEmpty(tokenTemp))
            {
               PilaTokens.GlobalTokens.Push("ValorC");
               lexemaAfter = TablaLexemaToken.GetLexema(inicioConteo);
               int final = LexemaCount.CountLexemas + 1;
               ConversionNotacionInfija_PosFija conversion = new ConversionNotacionInfija_PosFija(valores._pilaContadores);
               conversion.EjecutarAnalisis(inicioConteo, final);
               if (conversion.typeGlobalOfOperation != string.Empty)
               {
                  if (conversion.typeGlobalOfOperation == "bool")
                  {
                     PilaTokens.GlobalTokens.Pop();
                     PilaTokens.GlobalTokens.Push(selectorString(nonTerminalTokens.VALORBOOL));
                  }

                  _tokenAfterComparison = conversion.typeGlobalOfOperation;
               }

               return true;
            }
         }

         return false;
      }

      private bool CheckTokenWithNegation()
      {
         int inicioConteo = LexemaCount.CountLexemas + 1;
         GramaticaValores valores = new GramaticaValores();
         string tokenTemp = valores.EjecutarAnalisis();
         if (!string.IsNullOrEmpty(tokenTemp))
         {
            PilaTokens.GlobalTokens.Push(selectorString(nonTerminalTokens.VALORBOOL));
            //Inicio de verificacion semantica
            int final = LexemaCount.CountLexemas + 1;
            ConversionNotacionInfija_PosFija conversion = new ConversionNotacionInfija_PosFija(valores._pilaContadores);
            conversion.EjecutarAnalisis(inicioConteo, final);
            if (conversion.typeGlobalOfOperation != string.Empty)
            {
               _tokenAfterNegation = conversion.typeGlobalOfOperation;
               tablaInstrucciones.AgregarInstruccion(TablaLexemaToken.GetLexema(inicioConteo),
                  tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionNegacion);
               return (_tokenAfterNegation == "bool");
            }
         }

         return false;
      }
   }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using Compilador.AnalizadorSemantico;
using Compilador.AnalizadorSintactico.Gramaticas.AnalysisTables;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using Compilador.Gramaticas;
using Compilador.IntentoCodigoIntermedio;
using Compilador.TablasGlobales;

namespace Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales
{
   public class Gramatica_CuerpoClase : AbstractAnalisisTable
   {
      private string identificadorEncontrado;
      private string identificadorClaseEncontrado;
      private string identificadorMetodoEncontrado;
      private string tipoEncontrado;
      private string ClaseEncontrada;
      private string tipoMetodo;
      private Stack<Tuple<int, int>> pilaContadores;
      private bool ThereAreReturn;

      public Gramatica_CuerpoClase(string NombreClase)
      {
         ClaseEncontrada = NombreClase;
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
               PilaTokens.GlobalTokens.Push("FinCadena");
               if (!CheckTokenIn_Handler())
               {
                  PilaTokens.GlobalTokens.Pop();
                  // AddError();
                  return string.Empty;
               }
            }

            if (!AnalisisFinished) continue;
            if (!TablaSimbolos.CheckLexema(ClaseEncontrada)) return "bodyclass";
            int numRow = TablaSimbolos.numRowInTable(ClaseEncontrada);
            TablaSimbolos.GetDesplazamientos()[numRow] = ContadorDesplazamiento.ConteoDesplazamiento.ToString();

            return "bodyclass";
         }

         return string.Empty;
      }

      /// <summary>
      /// This method, check and handle the referenceState
      /// </summary>
      /// <returns>True, if the token in is on the table</returns>
      /// <returns>False, if the token is not in the table</returns>
      private bool CheckTokenIn_Handler()
      {
         int referenceState = PilaComprobacion.Peek().Item1;
         if (referenceState == 17 && PilaTokens.GlobalTokens.Peek() != "cuerpoInstrucciones" && PilaTokens.GlobalTokens.Peek() != "CuerpoMetodo")
         {
            string tokenAux = new Gramatica_CuerpoInstrucciones().Ejecutar_Analisis();
            if (!string.IsNullOrEmpty(tokenAux))
            {
               PilaTokens.GlobalTokens.Push(tokenAux);
            }
         }

         HandleValueOfIdentifier(referenceState);
         if (referenceState == 25 && PilaTokens.GlobalTokens.Peek() != "FinCadena" && PilaTokens.GlobalTokens.Peek() != "TIPO")
         {
            if (tipoMetodo != "void")
            {
               if (!ThereAreReturn)
               {
                  int numLine = TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas - 1].Item1;
                  Mensajes_ErroresSemanticos.AddErrorMethod(tipoMetodo, numLine);
               }
            }
         }

         HandleClassIdentifiers(referenceState);
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
         if (referenceState == 2 || referenceState == 12)
         {
            tipoEncontrado = TablaLexemaToken.GetLexema(LexemaCount.CountLexemas);
            return;
         }

         if (referenceState == 5 && PilaTokens.GlobalTokens.Peek() != "")
         {
            tipoMetodo = tipoEncontrado;
            identificadorMetodoEncontrado = identificadorEncontrado;
         }

         if ((referenceState != 3 && referenceState != 15) ||
             (PilaTokens.GlobalTokens.Peek() == "ComplementoIdentificador" || PilaTokens.GlobalTokens.Peek() == "RecursionMeotod")) return;

         identificadorEncontrado = TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item2;
         if (!HandleIdentifiers(identificadorEncontrado))
         {
            ErrorSintaxManager.AddDeclarationError(identificadorEncontrado, TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item1);
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
            string desplazamiento = TablaSimbolos.GetDesplazamiento(identifier);
            tablaInstrucciones.AgregarInstruccion(desplazamiento, "00000", tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionAsignacion);
            return true;
         }

         return false;
      }

      private void AssignShiftToIdentifier(int numRow)
      {
         TablaSimbolos.GetDesplazamientos()[numRow] = ContadorDesplazamiento.ConteoDesplazamiento.ToString();
      }

      private void HandleValueOfIdentifier(int referenceState)
      {
         if (referenceState == 7)
         {
            int conteoInicial = LexemaCount.CountLexemas + 1;
            var grammar = new GramaticaValores();
            string tokenAux = grammar.EjecutarAnalisis();
            if (!string.IsNullOrEmpty(tokenAux))
            {
               PilaTokens.GlobalTokens.Push(tokenAux);
               pilaContadores = grammar._pilaContadores;
               int conteoFinal = LexemaCount.CountLexemas + 1;
               HandleValue(conteoInicial, conteoFinal);
               return;
            }
         }

         if (referenceState == 24)
         {
            int conteoInicial = LexemaCount.CountLexemas + 1;
            var grammar = new GramaticaValores();
            string tokenAux = grammar.EjecutarAnalisis();
            if (!string.IsNullOrEmpty(tokenAux))
            {
               PilaTokens.GlobalTokens.Push(tokenAux);
               pilaContadores = grammar._pilaContadores;
               int conteoFinal = LexemaCount.CountLexemas + 1;
               ConversionNotacionInfija_PosFija conversor = new ConversionNotacionInfija_PosFija(pilaContadores);
               conversor.EjecutarAnalisis(conteoInicial, conteoFinal);
               string tipoReturn = conversor.typeGlobalOfOperation;
               if (tipoMetodo != tipoReturn)
               {
                  Mensajes_ErroresSemanticos.AddErrorTypes(tipoMetodo, tipoReturn,
                     TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item1);
               }
               if (!HandleValueOfReturn(tipoReturn, conversor.ColaSalida))
               {
                  HandleBoolStringAndChar(conteoInicial, conteoFinal, conversor);
               }
               ThereAreReturn = true;
            }
         }
      }

      private void HandleBoolStringAndChar(int conteoInicial, int conteoFinal, ConversionNotacionInfija_PosFija conversor)
      {
         string[] _valorEncontrado = new string[conteoFinal - conteoInicial];
         for (int i = conteoInicial, j = 0; i < conteoFinal; i++, j++)
         {
            _valorEncontrado[j] = TablaLexemaToken.LexemaTokensTable[i].Item2;
         }

         if (conversor.typeGlobalOfOperation != string.Empty)
         {
            int numRow = TablaSimbolos.numRowInTable(identificadorMetodoEncontrado);
            if (_valorEncontrado.Length > 1)
            {
               if (!CheckBoolChar(conversor.typeGlobalOfOperation))
               {
                  string valorCompleto = string.Join(" ", _valorEncontrado);
                  AnalizadorDeLimites.AnalizeLenghtString(valorCompleto);
                  TablaSimbolos.GetValues()[numRow] = valorCompleto;
                  tablaInstrucciones.AgregarInstruccion(ContadorDesplazamiento.ConteoDesplazamiento.ToString(),
                     string.Format($"{valorCompleto}V"), tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionAsignacion);
               }
               else
               {
                  Mensajes_ErroresSemanticos.AddErrorWithBoolOrChar(conversor.typeGlobalOfOperation,
                     TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item1);
               }
            }
            else
            {
               TablaSimbolos.GetValues()[numRow] =
                  (_valorEncontrado.Length == 1)
                     ? TablaLexemaToken.GetLexema(LexemaCount.CountLexemas)
                     : string
                        .Empty;
               tablaInstrucciones.AgregarInstruccion(TablaSimbolos.GetDesplazamientos()[numRow],
                  string.Format($"{_valorEncontrado[0]}V"), tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionAsignacion);
            }
         }
      }

      private bool HandleValueOfReturn(string tipoReturn, Queue<string> colaSalida)
      {
         if (tipoReturn != "int" && tipoReturn != "float") return false;
         if (colaSalida.Count != 0)
         {
            EvaluadorNotacion_PosFija evaluacion = new EvaluadorNotacion_PosFija();
            evaluacion.lexemaIdentifier = identificadorMetodoEncontrado;
            float resultadoEvaluacion = evaluacion.ExecuteEvaluation(colaSalida);
            int resultadoEntero = (int)Math.Floor(resultadoEvaluacion);
            int numRow = TablaSimbolos.numRowInTable(identificadorMetodoEncontrado);
            if (tipoReturn == "int")
            {
               CheckMinMaxValues(resultadoEntero.ToString(CultureInfo.InvariantCulture), tipoReturn);
               string desplazamientoMetodo = TablaSimbolos.GetDesplazamiento(identificadorMetodoEncontrado);
               TablaSimbolos.GetValues()[numRow] = resultadoEntero.ToString(CultureInfo.InvariantCulture);
               tablaInstrucciones.AgregarInstruccion(desplazamientoMetodo, resultadoEntero.ToString(), tablaInstrucciones
                  .InstruccionesCodigoIntermedio
                  .InstruccionAsignacion);
            }
            else
            {
               CheckMinMaxValues(resultadoEntero.ToString(CultureInfo.InvariantCulture), tipoReturn);
               string desplazamientoMetodo = TablaSimbolos.GetDesplazamiento(identificadorMetodoEncontrado);
               tablaInstrucciones.AgregarInstruccionFloat(tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionAsignacion,
                  desplazamientoMetodo, resultadoEvaluacion.ToString(CultureInfo.InvariantCulture));
               TablaSimbolos.GetValues()[numRow] = resultadoEvaluacion.ToString(CultureInfo.InvariantCulture);
            }
         }

         return true;
      }

      private void HandleValue(int _inicioConteoValor, int finalCounteoValores)
      {
         int numRow = TablaSimbolos.numRowInTable(identificadorEncontrado);
         string[] _valorEncontrado = new string[finalCounteoValores - _inicioConteoValor];
         for (int i = _inicioConteoValor, j = 0; i < finalCounteoValores; i++, j++)
         {
            _valorEncontrado[j] = TablaLexemaToken.LexemaTokensTable[i].Item2;
         }

         ConversionNotacionInfija_PosFija conversion = new ConversionNotacionInfija_PosFija(pilaContadores);
         EvaluadorNotacion_PosFija evaluacion = new EvaluadorNotacion_PosFija();
         conversion.ExecuteAnalysis(_inicioConteoValor, finalCounteoValores, tipoEncontrado);
         float resultadoEvaluacion = 0;
         if (CheckType(conversion.typeGlobalOfOperation))
         {
            if (conversion.ColaSalida.Count != 0)
            {
               evaluacion.lexemaIdentifier = identificadorEncontrado;
               resultadoEvaluacion = evaluacion.ExecuteEvaluation(conversion.ColaSalida);
               CheckMinMaxValues(resultadoEvaluacion.ToString(), tipoEncontrado);
               TablaSimbolos.GetValues()[numRow] = resultadoEvaluacion.ToString();
            }
         }
         else
         {
            if (conversion.typeGlobalOfOperation != string.Empty)
            {
               if (_valorEncontrado.Length > 1)
               {
                  if (!CheckBoolChar(conversion.typeGlobalOfOperation))
                  {
                     string valorCompleto = string.Join(" ", _valorEncontrado);
                     AnalizadorDeLimites.AnalizeLenghtString(valorCompleto);
                     string desplazamiento =
                        TablaSimbolos.GetDesplazamientos()[numRow];
                     tablaInstrucciones.AgregarInstruccion(desplazamiento, $"{valorCompleto}V",
                        tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionAsignacion);
                     TablaSimbolos.GetValues()[numRow] = valorCompleto;
                  }
                  else
                  {
                     Mensajes_ErroresSemanticos.AddErrorWithBoolOrChar(conversion.typeGlobalOfOperation,
                        TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas - 1].Item1);
                  }
               }
               else
               {
                  TablaSimbolos.GetValues()[numRow] =
                     (_valorEncontrado.Length == 1)
                        ? TablaLexemaToken.GetLexema(LexemaCount.CountLexemas - 1)
                        : string
                           .Empty;
                  tablaInstrucciones.AgregarInstruccion(TablaSimbolos.GetDesplazamientos()[numRow],
                     $"{TablaLexemaToken.GetLexema(LexemaCount.CountLexemas - 1)}",
                     tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionAsignacion);
               }
            }
         }
      }

      private bool CheckBoolChar(string conversionTypeGlobalOfOperation)
      {
         if (conversionTypeGlobalOfOperation == "char" || conversionTypeGlobalOfOperation == "bool")
            return true;
         return false;
      }

      private bool CheckType(string conversionTypeGlobalOfOperation)
      {
         if (conversionTypeGlobalOfOperation == "int" || conversionTypeGlobalOfOperation == "float")
            return true;
         return false;
      }

      private void CheckMinMaxValues(string value, string type)
      {
         switch (type)
         {
            case "int":
               AnalizadorDeLimites.AnaliceMinManInteger(value);
               break;
            case "float":
               AnalizadorDeLimites.AnalizeMinMaxFloat(value);
               break;
         }
      }

      private void HandleClassIdentifiers(int referenceState)
      {
         if (referenceState == 28)
         {
            identificadorClaseEncontrado = TablaLexemaToken.GetLexema(LexemaCount.CountLexemas);
            return;
         }

         if (referenceState == 29)
         {
            identificadorEncontrado = TablaLexemaToken.GetLexema(LexemaCount.CountLexemas);
            if (identificadorEncontrado != TablaLexemaToken.GetLexema(LexemaCount.CountLexemas))
               Mensajes_ErroresSemanticos.AddErrorInstanciation(TablaLexemaToken.GetLexema(LexemaCount.CountLexemas), TablaLexemaToken
                  .LexemaTokensTable[LexemaCount.CountLexemas].Item1);
            return;
         }

         if (referenceState == 34)
         {
            AssignClassTypeToIdentifier(identificadorEncontrado);
         }
      }

      private void AgregarShiftClase(string desplazamiento)
      {
         if (int.TryParse(desplazamiento, out int result))
         {
            ContadorDesplazamiento.AddShiftClass(result);
         }
      }

      private void AssignClassTypeToIdentifier(string identifier)
      {
         if (!TablaSimbolos.CheckTypeOfLexema(identifier))
         {
            int numRow = TablaSimbolos.numRowInTable(identifier);
            TablaSimbolos.GetTypesValues()[numRow] = identificadorClaseEncontrado;
            string desplazamientoClase = TablaSimbolos.GetDesplazamiento(identificadorClaseEncontrado);
            // tablaInstrucciones.AgregarInstruccion(ConteoDezplazamiento.CountShift.ToString(), "000000000000V",
            //    tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionDeclaracion);
            AssignShiftToIdentifier(numRow);
            AgregarShiftClase(desplazamientoClase);
            return;
         }

         Mensajes_ErroresSemanticos.AddErrorDobleDeclaracion(identifier, TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item1);
      }
   }
}
using System;
using Compilador.AnalizadorSintactico.Gramaticas.AnalysisTables;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using System.Collections.Generic;
using System.Globalization;
using Compilador.AnalizadorSemantico;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Compilador.IntentoCodigoIntermedio;
using Compilador.TablasGlobales;

namespace Compilador.AnalizadorSintactico.Gramaticas
{
   public class GramaticaInstruccion : AbstractAnalisisTable
   {
      /// <summary>
      /// Es el tipo del identificador encontrado
      /// </summary>
      private string _tipoEncontrado;

      /// <summary>
      /// Es el lexema de token identificador
      /// </summary>
      private string _identificadorEncontrado;

      private string _identificadorClaseEncontrado;

      private string[] _valorEncontrado;
      private int _inicioConteoValor;
      private Stack<Tuple<int, int>> pilaContadoraMetodos;

      public GramaticaInstruccion()
      {
         TablaAnalisis = AnalisysTable_Instrucciones.GlobalDictionaryInstrucciones;
         PilaComprobacion = new Stack<Tuple<int, string>>();
         PilaComprobacion.Push(new Tuple<int, string>(0, "0"));
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
               PilaTokens.GlobalTokens.Push("FinCadena");
               if (!CheckTokenIn_Handler())
               {
                  PilaTokens.GlobalTokens.Pop();
                  AddError();
                  return string.Empty;
               }
            }

            if (AnalisisFinished)
            {
               return "Instruccion";
            }
         }

         return string.Empty;
      }

      private bool CheckTokenIn_Handler()
      {
         int referenceState = PilaComprobacion.Peek().Item1;

         if (referenceState == 9 || referenceState == 11)
         {
            ManejadorValores();
         }

         if (referenceState == 30)
         {
            AssignClassTypeToIdentifier(_identificadorEncontrado);
         }

         if (referenceState == 25)
         {
            _identificadorEncontrado = TablaLexemaToken.GetLexema(LexemaCount.CountLexemas);
         }

         if (TablaAnalisis[referenceState].ContainsKey(PilaTokens.GlobalTokens.Peek()))
         {
            HandleTokenIdentType(referenceState);
            HandleCallMethod(referenceState);
            AbstractActionFunction.ActionEnum actionEnum;
            actionEnum = TablaAnalisis[referenceState][PilaTokens.GlobalTokens.Peek()].Action;
            HandleActions(actionEnum);
            return true;
         }

         return false;
      }

      private void HandleCallMethod(int referenceState)
      {
         if (referenceState == 8 && PilaTokens.GlobalTokens.Peek() != "ParametrosMetodo")
         {
            var grammar = new GramaticaParametrosMetodo();
            string tokenAux = grammar.Ejecutar_Analisis();
            if (!string.IsNullOrEmpty(tokenAux))
            {
               PilaTokens.GlobalTokens.Push(tokenAux);
               tablaInstrucciones.AgregarLlamadaMetodo(tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionLLamar, _identificadorEncontrado);
               return;
            }
         }

         if (referenceState == 28)
         {
            if (_identificadorClaseEncontrado != TablaLexemaToken.GetLexema(LexemaCount.CountLexemas))
               Mensajes_ErroresSemanticos.AddErrorInstanciation(TablaLexemaToken.GetLexema(LexemaCount.CountLexemas), TablaLexemaToken
                  .LexemaTokensTable[LexemaCount.CountLexemas].Item1);
         }
      }

      private void ManejadorValores()
      {
         _inicioConteoValor = LexemaCount.CountLexemas + 1;
         var grammar = new GramaticaValores();
         string tokenAux = grammar.EjecutarAnalisis();
         if (!string.IsNullOrEmpty(tokenAux))
         {
            PilaTokens.GlobalTokens.Push(tokenAux);
            pilaContadoraMetodos = grammar._pilaContadores;
         }
      }

      /// <summary>
      /// Checa los los estados de referencia y verifica si están en la tabla de símbolos,
      /// el estado de referencia se encuentra en la pila
      /// Los tokens que analiza, habrán sido puestos primeramente en la PilaComprobacion
      /// </summary>
      /// <param name="referenceState">Estado de referencia para analizar</param>
      private void HandleTokenIdentType(int referenceState)
      {
         if (referenceState == 2)
         {
            _tipoEncontrado = TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item2;
            return;
         }

         if (referenceState == 4 && PilaTokens.GlobalTokens.Peek() != "ComplementoDeclaracion")
         {
            _identificadorEncontrado = TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item2;
            AnalizeIdentifierInSymbolTable(_identificadorEncontrado);
            //Agregar métodos para errores
         }

         if (referenceState == 22 || referenceState == 23)
         {
            AssingValueToIdentifier(_identificadorEncontrado);
         }

         #region instrucciones codigo intermedio

         if (referenceState == 6)
         {
            int numRow = TablaSimbolos.numRowInTable(_identificadorEncontrado);
            if (numRow != 0)
            {
               string desplazamiento = TablaSimbolos.GetDesplazamientos()[numRow];
               tablaInstrucciones.AgregarInstruccion(desplazamiento, tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionIncremento);
            }
         }

         if (referenceState == 7)
         {
            int numRow = TablaSimbolos.numRowInTable(_identificadorEncontrado);
            if (numRow != 0)
            {
               string desplazamiento = TablaSimbolos.GetDesplazamientos()[numRow];
               tablaInstrucciones.AgregarInstruccion(desplazamiento, tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionDecremento);
            }
         }

         #endregion

         if (referenceState == 3 && PilaTokens.GlobalTokens.Peek() != "ComplementoIdenti")
         {
            _identificadorEncontrado = TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item2;
            _identificadorClaseEncontrado = TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item2;
            if (!TablaSimbolos.CheckLexema(_identificadorEncontrado))
            {
               return;
            }

            GetTypeOfLexema();
         }
      }

      /// <summary>
      /// Obtiene el tipo de un identificador
      /// </summary>
      private void GetTypeOfLexema()
      {
         if (!TablaSimbolos.CheckTypeOfLexema(_identificadorEncontrado))
         {
            Mensajes_ErroresSemanticos.AddErrorInstanciation(_identificadorEncontrado,
               TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item1);
            return;
         }

         _tipoEncontrado = TablaSimbolos.GetTypesValues()[TablaSimbolos.numRowInTable(_identificadorEncontrado)];
      }

      /// <summary>
      /// Agrega el tipo a su respectivo lexema
      /// </summary>
      /// <param name="identifierToAnalize"></param>
      private void AnalizeIdentifierInSymbolTable(string identifierToAnalize)
      {
         if (!TablaSimbolos.CheckTypeOfLexema(identifierToAnalize))
         {
            int numRow = TablaSimbolos.numRowInTable(identifierToAnalize);
            TablaSimbolos.GetTypesValues()[numRow] = _tipoEncontrado;
            tablaInstrucciones.AgregarInstruccion(ContadorDesplazamiento.ConteoDesplazamiento.ToString(), "000000000000V",
               tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionDeclaracion);
            AssignShiftToIdentifier(identifierToAnalize);
            ContadorDesplazamiento.AddShiftType(_tipoEncontrado);
            return;
         }

         if (TablaSimbolos.GetTypesValues().ContainsValue(identifierToAnalize)) return;
         Mensajes_ErroresSemanticos.AddErrorDobleDeclaracion(identifierToAnalize, TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item1);
      }

      private void AssingValueToIdentifier(string identifier)
      {
         if (TablaSimbolos.CheckLexema(identifier))
         {
            int numRow = TablaSimbolos.numRowInTable(identifier);
            int finalCounteoValores = LexemaCount.CountLexemas;
            _valorEncontrado = new string[finalCounteoValores - _inicioConteoValor];
            for (int i = _inicioConteoValor, j = 0; i < finalCounteoValores; i++, j++)
            {
               _valorEncontrado[j] = TablaLexemaToken.LexemaTokensTable[i].Item2;
            }

            ConversionNotacionInfija_PosFija conversion = new ConversionNotacionInfija_PosFija(pilaContadoraMetodos);
            EvaluadorNotacion_PosFija evaluacion = new EvaluadorNotacion_PosFija();
            conversion.ExecuteAnalysis(_inicioConteoValor, finalCounteoValores, _tipoEncontrado);
            float resultadoEvaluacion;
            if (CheckType(conversion.typeGlobalOfOperation))
            {
               if (conversion.ColaSalida.Count != 0)
               {
                  evaluacion.lexemaIdentifier = identifier;
                  resultadoEvaluacion = evaluacion.ExecuteEvaluation(conversion.ColaSalida);
                  int resultadoEntero = (int)Math.Floor(resultadoEvaluacion);
                  if (conversion.typeGlobalOfOperation == "int")
                  {
                     CheckMinMaxValues(resultadoEntero.ToString(CultureInfo.InvariantCulture), _tipoEncontrado);
                     TablaSimbolos.GetValues()[numRow] = resultadoEvaluacion.ToString();
                     tablaInstrucciones.AgregarInstruccion(ContadorDesplazamiento.ConteoDesplazamiento.ToString(),
                        string.Format($"{resultadoEntero.ToString()}V"), tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionAsignacion);
                  }
                  else
                  {
                     CheckMinMaxValues(resultadoEntero.ToString(CultureInfo.InvariantCulture), _tipoEncontrado);
                     TablaSimbolos.GetValues()[numRow] = resultadoEvaluacion.ToString(CultureInfo.InvariantCulture);
                     tablaInstrucciones.AgregarInstruccionFloat(tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionAsignacion,
                        (ContadorDesplazamiento.ConteoDesplazamiento + 4).ToString(),
                        $"{resultadoEvaluacion.ToString(CultureInfo.InvariantCulture)}");
                  }
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
                        TablaSimbolos.GetValues()[numRow] = valorCompleto;
                        tablaInstrucciones.AgregarInstruccion(ContadorDesplazamiento.ConteoDesplazamiento.ToString(),
                           string.Format($"{valorCompleto}V"), tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionAsignacion);
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
                        string.Format($"{_valorEncontrado[0]}V"), tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionAsignacion);
                  }
               }
            }
         }
      }

      /// <summary>
      /// Asigna el desplazamiento a su respectivo identificador
      /// </summary>
      /// <param name="identifier">Identificador a agregar el desplazamiento</param>
      private void AssignShiftToIdentifier(string identifier)
      {
         if (TablaSimbolos.CheckLexema(identifier))
         {
            int numRow = TablaSimbolos.numRowInTable(identifier);
            if (numRow != 0)
            {
               TablaSimbolos.GetDesplazamientos()[numRow] = ContadorDesplazamiento.ConteoDesplazamiento.ToString();
            }
         }
      }

      private bool CheckType(string type)
      {
         if (type == "int" || type == "float")
            return true;
         return false;
      }

      private bool CheckBoolChar(string type)
      {
         if (type == "char" || type == "bool")
            return true;
         return false;
      }

      private void CheckMinMaxValues(string value, string type)
      {
         switch (type)
         {
            case "int":
               int valorRedondeado = Int32.Parse(Math.Floor(Decimal.Parse(value)).ToString(CultureInfo.InvariantCulture));
               AnalizadorDeLimites.AnaliceMinManInteger(valorRedondeado.ToString());
               break;
            case "float":
               AnalizadorDeLimites.AnalizeMinMaxFloat(value);
               break;
         }
      }

      private void CheckIdentifier(int referenceState)
      {
         if (referenceState == 10)
         {
            _identificadorEncontrado = TablaLexemaToken.GetLexema(LexemaCount.CountLexemas);
         }
      }

      private void AssignClassTypeToIdentifier(string identifier)
      {
         if (!TablaSimbolos.CheckTypeOfLexema(identifier))
         {
            int numRow = TablaSimbolos.numRowInTable(identifier);
            TablaSimbolos.GetTypesValues()[numRow] = _identificadorClaseEncontrado;
            string desplazamientoClase = TablaSimbolos.GetDesplazamiento(_identificadorClaseEncontrado);
            // tablaInstrucciones.AgregarInstruccion(ConteoDezplazamiento.CountShift.ToString(), "000000000000V",
            //    tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionDeclaracion);
            AssignShiftToIdentifier(identifier);
            AgregarShiftClase(desplazamientoClase);
            return;
         }

         Mensajes_ErroresSemanticos.AddErrorDobleDeclaracion(identifier, TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item1);
      }

      private void AgregarShiftClase(string desplazamiento)
      {
         if (int.TryParse(desplazamiento, out int result))
         {
            ContadorDesplazamiento.AddShiftClass(result);
         }
      }
   }
}
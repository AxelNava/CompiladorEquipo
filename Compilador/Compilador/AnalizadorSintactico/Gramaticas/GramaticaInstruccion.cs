using System;
using Compilador.AnalizadorSintactico.Gramaticas.AnalysisTables;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using System.Collections.Generic;
using Compilador.AnalizadorSemantico;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Compilador.Gramaticas;
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
      private string[] _valorEncontrado;
      private int _inicioConteoValor;
      public GramaticaInstruccion()
      {
         TablaAnalisis = AnalisysTable_Instrucciones.GlobalDictionaryInstrucciones;
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
               AssingValueToIdentifier(_identificadorEncontrado);
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
            _inicioConteoValor = LexemaCount.CountLexemas + 1;
            string tokenAux = new GramaticaValores().EjecutarAnalisis();
            if (!string.IsNullOrEmpty(tokenAux))
               PilaTokens.GlobalTokens.Push(tokenAux);
         }

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

         if (referenceState == 4 && PilaTokens.GlobalTokens.Peek()!= "ComplementoDeclaracion")
         {
            _identificadorEncontrado = TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item2;
            AnalizeIdentifierInSymbolTable(_identificadorEncontrado);
            //Agregar métodos para errores
         }

         if (referenceState == 3 && PilaTokens.GlobalTokens.Peek()!= "ComplementoIdenti")
         {
            _identificadorEncontrado = TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item2;
            if (!TablaSimbolos.CheckLexema(_identificadorEncontrado))
            {
               // GrammarErrors.MessageErrorsOfGrammarsM += String.Format($"El identificador {_identificadorEncontrado} no ha sido declarado" +
                                                                       // $"- Linea {TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item1}\n");
               return;
            }

            GetTypeOfLexema();
         }
      }

      private void GetTypeOfLexema()
      {
         if (!TablaSimbolos.CheckTokenOfLexema(_identificadorEncontrado))
         {
            // GrammarErrors.MessageErrorsOfGrammarsM += String.Format($"El identificador {_identificadorEncontrado} no ha sido declarado" +
                                                                    // $"- Linea {TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item1}\n");
            return;
         }

         _tipoEncontrado = TablaSimbolos.GetTokensValues()[TablaSimbolos.numRowInTable(_identificadorEncontrado)];
      }

      /// <summary>
      /// Agrega el tipo a su respectivo lexema
      /// </summary>
      /// <param name="identifierToAnalize"></param>
      private void AnalizeIdentifierInSymbolTable(string identifierToAnalize)
      {
         if (TablaSimbolos.CheckLexema(identifierToAnalize))
         {
            int numRow = TablaSimbolos.numRowInTable(identifierToAnalize);
            TablaSimbolos.GetTypesValues()[numRow] = _tipoEncontrado;
            return;
         }
         // GrammarErrors.MessageErrorsOfGrammarsM += string.Format($"El identificador: {identifierToAnalize} no se encuentra declarado");
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
            ConversionNotacionInfija_PosFija conversion = new ConversionNotacionInfija_PosFija();
            EvaluadorNotacion_PosFija evaluacion = new EvaluadorNotacion_PosFija();
            evaluacion.ExecuteEvaluation(conversion.ExecuteAnalysis(_valorEncontrado, _tipoEncontrado));
            // TablaSimbolos.GetValues()[numRow] = 
            TablaSimbolos.GetValues()[numRow] = string.Join(" ",_valorEncontrado);
         }
      }
   }
}
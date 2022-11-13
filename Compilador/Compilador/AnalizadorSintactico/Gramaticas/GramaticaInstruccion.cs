using System;
using Compilador.AnalizadorSintactico.Gramaticas.AnalysisTables;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Compilador.Gramaticas;
using Compilador.TablasGlobales;

namespace Compilador.AnalizadorSintactico.Gramaticas
{
   public class GramaticaInstruccion : AbstractAnalisisTable
   {
      private string TipoEncontrado;
      private string IdentificadorEncontrado;
      private string[] ValorEncontrado;
      private int inicioConteoValor;
      public GramaticaInstruccion()
      {
         tablaAnalisis = AnalisysTable_Instrucciones.GlobalDictionaryInstrucciones;
         PilaComprobacion = new Stack<Tuple<int, string>>();
         PilaComprobacion.Push(new Tuple<int, string>(0, "0"));
      }

      public string Ejecutar_Analisis()
      {
         analisisFinished = false;
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
                     return string.Empty;
                  }
               }
            }

            if (analisisFinished) return "Instruccion";
         }

         return string.Empty;
      }

      private bool CheckTokenIn_Handler()
      {
         int referenceState = PilaComprobacion.Peek().Item1;
         if (referenceState == 9 || referenceState == 11)
         {
            string tokenAux = new GramaticaValores().EjecutarAnalisis();
            if (!string.IsNullOrEmpty(tokenAux))
               PilaTokens.GlobalTokens.Push(tokenAux);
         }

         if (tablaAnalisis[referenceState].ContainsKey(PilaTokens.GlobalTokens.Peek()))
         {
            HandleTokenIdentTipe(referenceState);
            // PilaTokens.numLineToken.RemoveAt(0);
            AbstractActionFunction.ActionEnum actionEnum;
            actionEnum = tablaAnalisis[referenceState][PilaTokens.GlobalTokens.Peek()].Action;
            HandleActions(actionEnum);
            return true;
         }

         return false;
      }

      private void HandleTokenIdentTipe(int referenceState)
      {
         if (referenceState == 2)
         {
            TipoEncontrado = TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item2;
            return;
         }

         if (referenceState == 4)
         {
            string identifierToAnalize = TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item2;
            AnalizeIdentifierInSymbolTable(identifierToAnalize);
            //Agregar métodos para errores
         }

         if (referenceState == 3)
         {
            
         }
      }

      /// <summary>
      /// Agrega el tipo a su respectivo lexema
      /// </summary>
      /// <param name="identifierToAnalize"></param>
      private void AnalizeIdentifierInSymbolTable(string identifierToAnalize)
      {
         if (!TablaSimbolos.CheckLexema(identifierToAnalize))
         {
            int numRow = TablaSimbolos.numRowInTable(identifierToAnalize);
            TablaSimbolos.GetTypesValues()[numRow] = TipoEncontrado;
         }
      }
      // private bool AnalizeIdentifierInSymbolTable_Identifier(string identifierToAnalize)
      // {
      //    return TablaSimbolos.CheckLexema(identifierToAnalize) ? true : false;
      // }

      private void AssingValueToIdentifier(string identifier)
      {
         if (!TablaSimbolos.CheckLexema(identifier))
         {
            int numRow = TablaSimbolos.numRowInTable(identifier);
            int finalCounteoValores = LexemaCount.CountLexemas;
            ValorEncontrado = new string[finalCounteoValores - inicioConteoValor];
            for (int i = inicioConteoValor, j = 0; i < finalCounteoValores; i++, j++)
            {
               ValorEncontrado[j] = TablaLexemaToken.LexemaTokensTable[i].Item2;
            }
            // TablaSimbolos.get()[numRow] = TipoEncontrado;
         }
      }
   }
}
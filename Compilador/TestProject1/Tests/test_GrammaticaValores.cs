using System;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico;
using Compilador.AnalizadorSintactico.Gramaticas;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Xunit;

namespace Compilador.Gramaticas.Tests
{
   public class test_GrammaticaValores
   {
      [Theory]
      [MemberData(nameof(QDataTestStack))]
      public void AnalysisGrammarValores_ShouldReturnTheTokenValor(string expectet, Stack<string> stackIn)
      {
         PilaTokens.GlobalTokens = stackIn;
         GramaticaValores grammar = new GramaticaValores();
         Assert.Equal(expectet, grammar.EjecutarAnalisis());
      }

      public static IEnumerable<object[]> QDataTestStack()
      {
         string totalStack =
            string.Format(
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               "FinCadena");
         string[] tokensSeparate = totalStack.Split(' ');
         string totalStack2 = string.Format(
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
            "FinCadena"
         );

         string totalStack3 = string.Format(
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)} " +
            "FinCadena"
            );
         string[] tokensSeparate3 = totalStack3.Split(' ');
         
         string[] tokensSeparate2 = totalStack2.Split(' ');
         Stack<string> pilaEntrada = new Stack<string>();
         for (int i = tokensSeparate.Length - 1; i >= 0; i--)
         {
            pilaEntrada.Push(tokensSeparate[i]);
         }

         Stack<string> pilaEntrada2 = new Stack<string>();
         for (int i = tokensSeparate2.Length - 1; i >= 0; i--)
         {
            pilaEntrada2.Push(tokensSeparate2[i]);
         }
         Stack<string> pilaEntrada3 = new Stack<string>();
         for (var i = tokensSeparate3.Length - 1; i >= 0; i--)
         {
            pilaEntrada3.Push(tokensSeparate3[i]);
         }

         yield return new object[] { "Valores", pilaEntrada };
         yield return new object[] { "Valores", pilaEntrada2 };
         yield return new object[] { "Valores", pilaEntrada3 };
      }
   }
}
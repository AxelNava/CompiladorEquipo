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
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"FinCadena");
         string[] tokensSeparate = totalStack.Split(' ');
         Stack<string> pilaEntrada = new Stack<string>();
         for (int i = tokensSeparate.Length - 1; i >= 0; i--)
         {
            pilaEntrada.Push(tokensSeparate[i]);
         }
         yield return new object[] { "Valores", pilaEntrada };
      }
   }
}
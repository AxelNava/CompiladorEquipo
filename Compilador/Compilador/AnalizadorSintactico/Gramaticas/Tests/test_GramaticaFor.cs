using System;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Xunit;

namespace Compilador.AnalizadorSintactico.Gramaticas.Tests
{
   public class TestGramaticaFor
   {
      [Theory]
      [MemberData(nameof(QDataTestStack))]
      public void GrammarWhileShouldReturnToken_While(string expected, Stack<string> stackIN)
      {
         PilaTokens.GlobalTokens = stackIN;
         var doWhileGrammar = new Gramatica_For();
         Assert.Equal(expected, doWhileGrammar.EjecutarAnalisis());
      }

      public static IEnumerable<object[]> QDataTestStack()
      {
         string totalStack =
            string.Format(
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.FOR)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Asignacion)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Comparador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OR)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.NEGACION)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.AND)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE)} " +
               $"<CUERTPOINSTRUCCIONES> " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA)} " +
               $"FinCadena");
         string[] tokensSeparate = totalStack.Split(' ');


         string totalStack2 =
            string.Format(
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.FOR)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Asignacion)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Comparador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OR)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.NEGACION)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.AND)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE)} " +
               $"<CUERTPOINSTRUCCIONES> " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA)} " +
               $"FinCadena");

         Stack<string> pilaEntrada = new Stack<string>();
         string[] tokensSeparate2 = totalStack2.Split(' ');
         Stack<string> pilaEntrada2 = new Stack<string>();
         for (int i = tokensSeparate.Length - 1; i >= 0; i--)
         {
            pilaEntrada.Push(tokensSeparate[i]);
         }

         for (int i = tokensSeparate2.Length - 1; i >= 0; i--)
         {
            pilaEntrada2.Push(tokensSeparate2[i]);
         }

         yield return new object[] { "<for>", pilaEntrada2 };
         yield return new object[] { "<for>", pilaEntrada };
      }
   }
}
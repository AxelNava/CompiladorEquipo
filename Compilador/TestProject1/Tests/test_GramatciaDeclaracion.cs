using System;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Xunit;
namespace Compilador.Gramaticas.Tests
{
   public class test_GramatciaDeclaracion
   {
      [Theory]
      [MemberData(nameof(QDataTestStack))]
      public void Grammar_DeclarationShouldReturnDeclarationToken(string expected, Stack<string> stackIn)
      {
         var grammar = new Gramatica_Declaracion();
         PilaTokens.GlobalTokens = stackIn;
         Assert.Equal(expected, grammar.Ejecutar_Analisis());
      }
      public static IEnumerable<object[]> QDataTestStack()
      {
         string totalStack =
            string.Format(
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CORCHETEABRE)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CORCHETECIERRA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CORCHETEABRE)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CORCHETECIERRA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Asignacion)} " +
               "Valores " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)} " +
               $"FinCadena");
         string[] tokensSeparate = totalStack.Split(' ');
         Stack<string> pilaEntrada = new Stack<string>();
         for (int i = tokensSeparate.Length - 1; i >= 0; i--)
         {
            pilaEntrada.Push(tokensSeparate[i]);
         }
         yield return new object[] { "Declaracion", pilaEntrada };
      }
   }
}
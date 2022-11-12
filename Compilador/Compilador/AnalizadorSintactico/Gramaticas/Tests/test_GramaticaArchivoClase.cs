using System;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico;
using Compilador.AnalizadorSintactico.Gramaticas;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Xunit;
namespace Compilador.AnalizadorSintactico.Gramaticas.Tests
{
   public class test_GramaticaArchivoClase
   {
      [Theory]
      [MemberData(nameof(QDataTestStack))]
      public static void ArchivoClase_ShouldReturnTheTokenArchivoClase(string expected, Stack<string> stackIn)
      {
         Gramatica_ArchivoClase grammar = new Gramatica_ArchivoClase();
         PilaTokens.GlobalTokens = stackIn;
         
      }
      public static IEnumerable<object[]> QDataTestStack()
      {
         string totalStack =
            string.Format(
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.USING)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.USING)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CLASS)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               
               "FinCadena"
               );
         string[] tokensSeparate = totalStack.Split(' ');
         string totalStack2 = string.Format(
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
            
            "FinCadena"
         );
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

         yield return new object[] { "Valores", pilaEntrada };
         yield return new object[] { "Valores", pilaEntrada2 };
      }
   }
}
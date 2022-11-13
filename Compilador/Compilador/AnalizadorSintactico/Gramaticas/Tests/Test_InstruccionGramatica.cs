using System;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Xunit;

namespace Compilador.AnalizadorSintactico.Gramaticas.Tests
{
   public class Test_InstruccionGramatica
   {
      [Theory]
      [MemberData(nameof(QDataTestStack))]
      public static void GramaticaInstruccionesShouldReturn_TheTokenInstrucciones(string expected, Stack<string> stackIn)
      {
         GramaticaInstruccion grammarTest = new GramaticaInstruccion();
         PilaTokens.GlobalTokens = stackIn;
         Assert.Equal(expected, grammarTest.Ejecutar_Analisis());
      }

      public static IEnumerable<object[]> QDataTestStack()
      {
         string totalStack =
            string.Format(
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Asignacion)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)} " +
               $"FinCadena");
         string[] tokensSeparate = totalStack.Split(' ');

         string totalStack2 = string.Format(
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Asignacion)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Asignacion)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)} " +
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

         yield return new object[] { "Instruccion", pilaEntrada };
         yield return new object[] { "Instruccion", pilaEntrada2 };
      }
   }
}
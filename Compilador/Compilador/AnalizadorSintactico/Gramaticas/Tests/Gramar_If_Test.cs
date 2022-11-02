using System;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using Xunit;

namespace Compilador.Gramaticas.Tests
{
   public class Gramar_If_Test
   {
      private Gramatica_IF testGramaticaIf = new Gramatica_IF();

      [Theory]
      [MemberData(nameof(QDataTestStack))]
      public void AnalisisExecuted_ShouldBeIfToken(string expected, Stack<string> pilaEntrada)
      {
         // Assert.Equal(expected, testGramaticaIf.EjecutarAnalisisTest(pilaEntrada));
      }
      
      public static IEnumerable<object[]> QDataTest()
      {
         Stack<Tuple<int, string>> testTokens = new Stack<Tuple<int, string>>();
         testTokens.Push(new Tuple<int, string>(0, "0"));
         testTokens.Push(new Tuple<int, string>(15, "Instruccion"));
         Stack<string> pilaEntrada = new Stack<string>();
         pilaEntrada.Push("FinCadena");
         yield return new object[] { "bodyElse", 15, testTokens, pilaEntrada };
      }

      public static IEnumerable<object[]> QDataTestStack()
      {
         string totalStack = "if ( condicion ) { cuerpoInstrucciones } else Instruccion FinCadena";
         string[] tokensSeparate = totalStack.Split(' ');
         Stack<string> pilaEntrada = new Stack<string>();
         for (int i = tokensSeparate.Length - 1; i >= 0; i--)
         {
            pilaEntrada.Push(tokensSeparate[i]);
         }
         yield return new object[] { "<IF>", pilaEntrada };
      }
   }
}
using System;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Xunit;
namespace Compilador.AnalizadorSintactico.Gramaticas.Tests
{
    public class test_estructuraControl
    {
        [Theory]
        [MemberData(nameof(QDataTestStack))]
        public static void Test_EstructuraControl(string espected, Stack<string> estain)
        {
            GramaticaEstructuraControl gc = new GramaticaEstructuraControl();
            PilaTokens.GlobalTokens = estain;
            Assert.Equal(espected, gc.EjecutarAnalisis());
        }
      public static IEnumerable<object[]> QDataTestStack()
      {/*
         "<estructuracontrol>",
         "if",
         "while",
         "for",
         "do",
         "switch",
         "recursivo"
            */
         string totalStack =
            string.Format(
               $"if " +
               $"while " +
               $"for " +
               $"do " +
               $"switch " +
               $"FinCadena");
         string[] tokensSeparate = totalStack.Split(' ');
         Stack<string> pilaEntrada = new Stack<string>();
         for (int i = tokensSeparate.Length - 1; i >= 0; i--)
         {
            pilaEntrada.Push(tokensSeparate[i]);
         }
         yield return new object[] { "<estructuracontrol>", pilaEntrada };
      }
   }
}
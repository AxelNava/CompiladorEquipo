using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace Compilador.AnalizadorSintactico.Gramaticas.Tests
{
    public class Test_ArchivoClaseGramatica
    {
        [Theory]
        [MemberData(nameof(QDataTestStack))]
        public static void testarchivoclase(string expect, Stack<string> pilaentrada)
        {
            PilaTokens.GlobalTokens=pilaentrada;
            Gramatica_ArchivoClase gramatica = new Gramatica_ArchivoClase();
            Assert.Equal(expect, gramatica.EjecutarAnalisis());
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
                  $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE)} " +
                  $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA)} " +
                 
                  $"FinCadena");
            string[] tokensSeparate = totalStack.Split(' ');


            string totalStack2 =
               string.Format(
                  $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.USING)} " +
                  $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
                  $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)} " +
                  $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.USING)} " +
                  $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
                  $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)} " +
                  $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CLASS)} " +
                  $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
                  $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE)} " +
                  $"declaracionfunciones " +
                  $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA)} " +
                  $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CLASS)} " +
                  $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
                  $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE)} " +
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

            yield return new object[] { "<archivoclase>", pilaEntrada2 };
            yield return new object[] { "<archivoclase>", pilaEntrada };
        }
    }
}

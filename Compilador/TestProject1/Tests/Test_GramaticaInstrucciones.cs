using Compilador.AnalizadorSintactico;
using Compilador.AnalizadorSintactico.Gramaticas;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Xunit;
namespace TestProject1.Tests;

public class Test_GramaticaInstrucciones
{
   [Theory]
   [MemberData(nameof(QDataTest))]
   public static void GramaticaInstruccionesShouldReturntokenInstruccion(string expected, Stack<string> stackIn)
   {
      PilaTokens.GlobalTokens = stackIn;
      GramaticaInstruccion grammar = new GramaticaInstruccion();
      Assert.Equal(expected, grammar.Ejecutar_Analisis());
   }

   public static IEnumerable<object[]> QDataTest()
   {
      string totalStack =
         string.Format(
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Asignacion)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.NEW)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)} " +
            $"FinCadena");
      string[] tokensSeparate = totalStack.Split(' ');
      Stack<string> pilaEntrada = new Stack<string>();
      for (int i = tokensSeparate.Length - 1; i >= 0; i--)
      {
         pilaEntrada.Push(tokensSeparate[i]);
      }
      yield return new object[] { "Instruccion", pilaEntrada };
      // yield return new object[] { };
   }
}
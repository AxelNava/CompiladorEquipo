using Compilador.AnalizadorSintactico;
using Compilador.AnalizadorSintactico.Gramaticas;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Xunit;
namespace TestProject1.Tests;

public class Test_GramaticaSwitch
{
   [Theory]
   [MemberData(nameof(QDataTestStack))]
   public static void GramaticaSwitch_ShouldReturn_TokenSwitch(string expected, Stack<string> stackIn)
   {
      PilaTokens.GlobalTokens = stackIn;
      Gramatica_Switch grammar = new Gramatica_Switch();
      Assert.Equal(expected, grammar.Ejecutar_Analisis());
   }
   
   public static IEnumerable<object[]> QDataTestStack()
   {
      string totalStack =
         string.Format(
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.SWITCH)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE)} " +
            "Valores "+
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CASSSE)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DOSPUNTOS)} " +
            "cuerpoInstrucciones "+
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BREAAAK)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CASSSE)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DOSPUNTOS)} " +
            "cuerpoInstrucciones "+
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BREAAAK)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DEFAUUULT)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DOSPUNTOS)} " +
            "cuerpoInstrucciones "+
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BREAAAK)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA)} " +
            $"FinCadena");
      string[] tokensSeparate = totalStack.Split(' ');
      Stack<string> pilaEntrada = new Stack<string>();
      for (int i = tokensSeparate.Length - 1; i >= 0; i--)
      {
         pilaEntrada.Push(tokensSeparate[i]);
      }
      yield return new object[] { "<Switch>", pilaEntrada };
   }
}
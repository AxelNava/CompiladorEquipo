using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Compilador.Gramaticas;
using Xunit;
namespace TestProject1.Tests;
public class Test_GramaticaCuerpoInstrucciones
{
   [Theory]
   [MemberData(nameof(QDataTestStack))]
   public static void CuerpoInstruccionesShouldReturnToken_cuerpoInstrucciones(string expected, Stack<string> stackIn)
   {
      PilaTokens.GlobalTokens = stackIn;
      Gramatica_CuerpoInstrucciones grammar = new Gramatica_CuerpoInstrucciones();
      Assert.Equal(expected, grammar.Ejecutar_Analisis());      
   }
    public static IEnumerable<object[]> QDataTestStack()
   {
      string totalStack =
         string.Format(
            "Instruccion "+
            "EstructuraControl "+
            "Instruccion "+
            "Instruccion "+
            $"FinCadena");
      string[] tokensSeparate = totalStack.Split(' ');
      Stack<string> pilaEntrada = new Stack<string>();
      for (int i = tokensSeparate.Length - 1; i >= 0; i--)
      {
         pilaEntrada.Push(tokensSeparate[i]);
      }
      yield return new object[] { "cuerpoInstrucciones", pilaEntrada };
   }
}
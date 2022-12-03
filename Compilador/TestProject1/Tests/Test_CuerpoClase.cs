using Compilador.AnalizadorSintactico;
using Compilador.AnalizadorSintactico.Gramaticas;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Xunit;

namespace TestProject1.Tests;

public class Test_CuerpoClase
{
   [Theory]
   [MemberData(nameof(QDataTestStack2))]
   public static void CuerpoClaseSHourReturnToken_cuerpoClase(string expected, Stack<string> stackIn)
   {
      PilaTokens.GlobalTokens = stackIn;
      var GramticaCuerpoClas = new Gramatica_CuerpoClase("");
      Assert.Equal(expected, GramticaCuerpoClas.Ejecutar_Analisis());
   }
   public static IEnumerable<object[]> QDataTestStack()
      {
         string totalStack =
            string.Format(
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA)} " +
               // $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE)} " +
               // $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA)} " +
               $"FinCadena");
         string[] tokensSeparate = totalStack.Split(' ');
         string totalStack2 =
            string.Format(
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)} " +
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

         yield return new object[] { "bodyclass", pilaEntrada2 };
         yield return new object[] { "bodyclass", pilaEntrada };
      }

   public static IEnumerable<object[]> QDataTestStack2()
   {
      string tokens = string.Format($"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO)} " +
                                    $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
                                    $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Asignacion)} " +
                                    $"valores " +
                                    $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)} " +
                                    $"FinCadena");
      string[] tokensSeparate = tokens.Split(' '); 
      Stack<string> pilaEntrada = new Stack<string>();
      for (int i = tokensSeparate.Length - 1; i >= 0; i--)
      {
         pilaEntrada.Push(tokensSeparate[i]);
      }
      yield return new object[] { "bodyclass", pilaEntrada };
   }
}
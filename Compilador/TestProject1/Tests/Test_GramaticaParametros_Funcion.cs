using System.Collections.Generic;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Xunit;
namespace Compilador.AnalizadorSintactico.Gramaticas.Tests
{
   public class Test_GramaticaParametros_Funcion
   {
      [Theory]
      [MemberData(nameof(QDataTestStack))]
      public static void GramaticaParametrosMetodo_ShouldReturnTheToken_Parametros(string expected, Stack<string> stackIn)
      {
         PilaTokens.GlobalTokens = stackIn;
         GramaticaParametrosMetodo paramsMetodo = new GramaticaParametrosMetodo();
         Assert.Equal(expected, paramsMetodo.Ejecutar_Analisis());
      }
      
      public static IEnumerable<object[]> QDataTestStack()
      {
         string totalStack =
            string.Format(
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL)} " +
               "FinCadena");
         string[] tokensSeparate = totalStack.Split(' ');
         string totalStack2 = string.Format(
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA)} " +
            $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL)} " +
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

         yield return new object[] { "ParametrosMetodo", pilaEntrada };
         yield return new object[] { "ParametrosMetodo", pilaEntrada2 };
      }
   }
}
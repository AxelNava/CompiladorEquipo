using System.Collections.Generic;
using Compilador.AnalizadorSintactico;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Xunit;
namespace Compilador.Gramaticas.Tests
{
   public class testNetedGrammars
   {
      
      public static IEnumerable<object[]> QDataTestStack()
      {
         string totalStack =
            string.Format(
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Comparador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OR)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.NEGACION)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.AND)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)} " +
               $"FinCadena");
         string[] tokensSeparate = totalStack.Split(' ');
         Stack<string> pilaEntrada = new Stack<string>();
         for (int i = tokensSeparate.Length - 1; i >= 0; i--)
         {
            pilaEntrada.Push(tokensSeparate[i]);
         }
         yield return new object[] { "Condicion", pilaEntrada };
      }
   }
}
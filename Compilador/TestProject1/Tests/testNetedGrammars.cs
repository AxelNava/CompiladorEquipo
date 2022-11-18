using System.Collections.Generic;
using Compilador.AnalizadorSintactico;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Xunit;
namespace Compilador.Gramaticas.Tests
{
   public class testNetedGrammars
   {
      [Theory]
      [MemberData(nameof(QDataTestStack))]
      public void CheckIfTheGrammarNestedFunction_ShouldExecuteBoth(string expected, Stack<string> stackIn)
      {
         PilaTokens.GlobalTokens = stackIn;
         Gramatica_IF grammar = new Gramatica_IF();
         Assert.Equal(expected, grammar.EjecutarAnalisis());
      }
      public static IEnumerable<object[]> QDataTestStack()
      {
         
         string totalStack =
            string.Format(
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.IF)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Comparador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OR)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.NEGACION)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.AND)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE)} " +
               $"cuerpoInstrucciones " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ELSE)} " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE)} " +
               $"cuerpoInstrucciones " +
               $"{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA)} " +
               $"FinCadena");
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
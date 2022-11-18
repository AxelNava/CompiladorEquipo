using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Compilador.AnalizadorSemantico.Test_ConversorNotacionPosFija
{
   public class test_NotaciónPosFija
   {
      [Theory]
      [MemberData(nameof(DataForAnalysis))]
      public void ParsingPosFixShouldReturn_PosFixNotation(Queue<string> expected, string[] analysis)
      {
         ConversionNotacionInfija_PosFija test = new ConversionNotacionInfija_PosFija();
         // Assert.Equal(expected, test.ExecuteAnalysis(analysis));
      }

      public static IEnumerable<object[]> DataForAnalysis()
      {
         string[] opeArr = new string[]
         {
            "5",
            "-",
            "4",
            "+",
            "3",
            "+",
            "8",
            "*",
            "(",
            "5",
            "-",
            "3",
            ")",
            "+",
            "(",
            "4",
            "-",
            "16",
            ")"
         };
         
         Queue<string> colaEsperada = new Queue<string>();
         colaEsperada.Enqueue("5");
         colaEsperada.Enqueue("4");
         colaEsperada.Enqueue("-");
         colaEsperada.Enqueue("3");
         colaEsperada.Enqueue("+");
         colaEsperada.Enqueue("8");
         colaEsperada.Enqueue("5");
         colaEsperada.Enqueue("3");
         colaEsperada.Enqueue("-");
         colaEsperada.Enqueue("*");
         colaEsperada.Enqueue("+");
         colaEsperada.Enqueue("4");
         colaEsperada.Enqueue("16");
         colaEsperada.Enqueue("-");
         colaEsperada.Enqueue("+");

         yield return new object[] { colaEsperada, opeArr };
      }
   }
}
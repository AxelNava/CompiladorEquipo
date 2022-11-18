using System.Collections;
using System.Collections.Generic;
using Xunit;
namespace Compilador.AnalizadorSemantico.Test_ConversorNotacionPosFija
{
   public class test_EvaluacionNotaionPosFija
   {
      [Theory]
      [MemberData(nameof(QDataTest))]
      public static void TheEvaluationShouldReturn_8(float expected, Queue<string> queueIn)
      {
         EvaluadorNotacion_PosFija ev = new EvaluadorNotacion_PosFija();
         Assert.Equal(expected,ev.ExecuteEvaluation(queueIn));
      }
      public static IEnumerable<object[]> QDataTest()
      {
         Queue<string> colaEntrada = new Queue<string>();
         colaEntrada.Enqueue("5");
         colaEntrada.Enqueue("4");
         colaEntrada.Enqueue("-");
         colaEntrada.Enqueue("3");
         colaEntrada.Enqueue("+");
         colaEntrada.Enqueue("8");
         colaEntrada.Enqueue("5");
         colaEntrada.Enqueue("3");
         colaEntrada.Enqueue("-");
         colaEntrada.Enqueue("*");
         colaEntrada.Enqueue("+");
         colaEntrada.Enqueue("4");
         colaEntrada.Enqueue("16");
         colaEntrada.Enqueue("-");
         colaEntrada.Enqueue("+");
         float result = 8;
         yield return new object[] { result, colaEntrada};
      }
   }
}
using System.Collections.Generic;

namespace Compilador.AnalizadorSemantico
{
   public class EvaluadorNotacion_PosFija
   {
      /// <summary>
      /// Esta pila almacena todos los números de la operación así como el resultado
      /// </summary>
      private Stack<float> resultNums = new Stack<float>();
      private float auxResult = 0;
      public float ExecuteEvaluation(Queue<string> queueIn)
      {
         while (queueIn.Count > 0)
         {
            float auxNum;
            string stringCharacter = queueIn.Dequeue();
            if (float.TryParse(stringCharacter, out auxNum))
            {
               resultNums.Push(auxNum);
               continue;
            }

            HandleOperations(stringCharacter);
         }
         
         return resultNums.Pop();
      }

      private void HandleOperations(string stringCharacter)
      {
         float numberY = resultNums.Pop();
         float numberX = resultNums.Pop();
         float resultOperation;
         
         switch (stringCharacter)
         {
            case "+":
               resultOperation = numberX + numberY;
               resultNums.Push(resultOperation);
               break;
            case "-":
               resultOperation = numberX - numberY;
               resultNums.Push(resultOperation);
               break;
            case "/":
               resultOperation = numberX / numberY;
               resultNums.Push(resultOperation);
               break;
            case "*":
               resultOperation = numberX * numberY;
               resultNums.Push(resultOperation);
               break;
         }
      }
   }
}
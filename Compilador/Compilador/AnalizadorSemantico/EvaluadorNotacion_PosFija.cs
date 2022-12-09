using System.Collections.Generic;
using Compilador.IntentoCodigoIntermedio;

namespace Compilador.AnalizadorSemantico
{
   public class EvaluadorNotacion_PosFija
   {
      /// <summary>
      /// Esta pila almacena todos los números de la operación así como el resultado
      /// </summary>
      private Stack<float> resultNums = new Stack<float>();
      public string lexemaIdentifier;
      private string _memoryLocation;

      public float ExecuteEvaluation(Queue<string> queueIn)
      {
         _memoryLocation = TablaSimbolos.GetDesplazamiento(lexemaIdentifier);
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
               TablaInstrucciones.AgregarInstruccion(_memoryLocation, $"{numberX.ToString()}",
                  TablaInstrucciones.IntermidiateCodeInstructions.InstruccionSum);
               TablaInstrucciones.AgregarInstruccion(_memoryLocation, $"{numberY.ToString()}",
                  TablaInstrucciones.IntermidiateCodeInstructions.InstruccionSum);
               resultOperation = numberX + numberY;
               resultNums.Push(resultOperation);
               break;
            case "-":
               TablaInstrucciones.AgregarInstruccion(_memoryLocation, $"{numberX.ToString()}",
                  TablaInstrucciones.IntermidiateCodeInstructions.InstruccionRes);
               TablaInstrucciones.AgregarInstruccion(_memoryLocation, $"{numberY.ToString()}",
                  TablaInstrucciones.IntermidiateCodeInstructions.InstruccionRes);
               resultOperation = numberX - numberY;
               resultNums.Push(resultOperation);
               break;
            case "/":
               TablaInstrucciones.AgregarInstruccion(_memoryLocation, $"{numberX.ToString()}",
                  TablaInstrucciones.IntermidiateCodeInstructions.InstruccionDiv);
               TablaInstrucciones.AgregarInstruccion(_memoryLocation, $"{numberY.ToString()}",
                  TablaInstrucciones.IntermidiateCodeInstructions.InstruccionDiv);
               resultOperation = numberX / numberY;
               resultNums.Push(resultOperation);
               break;
            case "*":
               TablaInstrucciones.AgregarInstruccion(_memoryLocation, $"{numberX.ToString()}",
                  TablaInstrucciones.IntermidiateCodeInstructions.InstruccionMulti);
               TablaInstrucciones.AgregarInstruccion(_memoryLocation, $"{numberY.ToString()}",
                  TablaInstrucciones.IntermidiateCodeInstructions.InstruccionMulti);
               resultOperation = numberX * numberY;
               resultNums.Push(resultOperation);
               break;
         }
      }
   }
}
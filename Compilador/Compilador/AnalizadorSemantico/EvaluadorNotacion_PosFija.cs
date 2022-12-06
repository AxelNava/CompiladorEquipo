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
      private string memoryLocation;

      public float ExecuteEvaluation(Queue<string> queueIn)
      {
         int numRowInTable = TablaSimbolos.numRowInTable(lexemaIdentifier);
         memoryLocation = TablaSimbolos.GetDesplazamientos()[numRowInTable];
         if (queueIn.Count == 1)
         {
            tablaInstrucciones.AgregarInstruccion(memoryLocation, queueIn.Peek(),
               tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionAsignacion);
         }

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
               tablaInstrucciones.AgregarInstruccion(memoryLocation, $"{numberX.ToString()}",
                  tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionSum);
               tablaInstrucciones.AgregarInstruccion(memoryLocation, $"{numberY.ToString()}",
                  tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionSum);
               resultOperation = numberX + numberY;
               resultNums.Push(resultOperation);
               break;
            case "-":
               tablaInstrucciones.AgregarInstruccion(memoryLocation, $"{numberX.ToString()}",
                  tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionRes);
               tablaInstrucciones.AgregarInstruccion(memoryLocation, $"{numberY.ToString()}",
                  tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionRes);
               resultOperation = numberX - numberY;
               resultNums.Push(resultOperation);
               break;
            case "/":
               tablaInstrucciones.AgregarInstruccion(memoryLocation, $"{numberX.ToString()}",
                  tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionDiv);
               tablaInstrucciones.AgregarInstruccion(memoryLocation, $"{numberY.ToString()}",
                  tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionDiv);
               resultOperation = numberX / numberY;
               resultNums.Push(resultOperation);
               break;
            case "*":
               tablaInstrucciones.AgregarInstruccion(memoryLocation, $"{numberX.ToString()}",
                  tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionMulti);
               tablaInstrucciones.AgregarInstruccion(memoryLocation, $"{numberY.ToString()}",
                  tablaInstrucciones.InstruccionesCodigoIntermedio.InstruccionMulti);
               resultOperation = numberX * numberY;
               resultNums.Push(resultOperation);
               break;
         }
      }
   }
}
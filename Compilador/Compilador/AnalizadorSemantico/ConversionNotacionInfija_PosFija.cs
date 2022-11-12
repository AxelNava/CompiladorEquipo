using System.Collections.Generic;
namespace Compilador.AnalizadorSemantico
{
   public class ConversionNotacionInfija_PosFija
   {
      /// <summary>
      /// Secuencia de numeros y operaciones
      /// </summary>
      private string[] stringSplited;
      /// <summary>
      /// Contenedor de los operadores
      /// </summary>
      private Dictionary<string, byte> nivelProcedenciaOperador;
      /// <summary>
      /// Cola que almacena la salida de la conversión de InFijo a PosFijo
      /// </summary>
      private Queue<string> outQueue = new Queue<string>();
      /// <summary>
      /// Pila que almacena los operadores encontrados
      /// </summary>
      private Stack<string> operatorsStack = new Stack<string>();
      public ConversionNotacionInfija_PosFija()
      {
         nivelProcedenciaOperador = new Dictionary<string, byte>();
         nivelProcedenciaOperador.Add("+", 1);
         nivelProcedenciaOperador.Add("-", 1);
         nivelProcedenciaOperador.Add("*", 2);
         nivelProcedenciaOperador.Add("x", 2);
         nivelProcedenciaOperador.Add("/", 2);
         nivelProcedenciaOperador.Add("(", 0);
         nivelProcedenciaOperador.Add(")", 0);
      }

      public Queue<string> ExecuteAnalysis(string[] entrada)
      {
         stringSplited = entrada;
         Conversor();
         return outQueue;
      }

      private void Conversor()
      {
         for (int i = 0; i < stringSplited.Length; i++)
         {
            if (int.TryParse(stringSplited[i], out _))
            {
               outQueue.Enqueue(stringSplited[i]);
               continue;
            }

            HandlerCharactersOperator(i);
         }

         if (operatorsStack.Count > 0)
            outQueue.Enqueue(operatorsStack.Pop());
      }
/// <summary>
/// Maneja las entradas de "(" y cuando la pila no tiene nada, y las reglas de conversion
/// </summary>
/// <param name="i"></param>
      private void HandlerCharactersOperator(int i)
      {
         if (stringSplited[i] == "(")
         {
            operatorsStack.Push(stringSplited[i]);
            return;
         }

         if (operatorsStack.Count == 0)
         {
            operatorsStack.Push(stringSplited[i]);
            return;
         }

         OperationWithStackAndQueue(i);
      }
/// <summary>
/// Se encarga de ejecutar las reglas de conversión
/// </summary>
/// <param name="i">Posición del lexema a analizar</param>
      private void OperationWithStackAndQueue(int i)
      {
         if (nivelProcedenciaOperador[stringSplited[i]] == nivelProcedenciaOperador[operatorsStack.Peek()])
         {
            outQueue.Enqueue(operatorsStack.Pop());
            operatorsStack.Push(stringSplited[i]);
            return;
         }

         if (nivelProcedenciaOperador[stringSplited[i]] > nivelProcedenciaOperador[operatorsStack.Peek()])
         {
            operatorsStack.Push(stringSplited[i]);
            return;
         }

         if (nivelProcedenciaOperador[stringSplited[i]] < nivelProcedenciaOperador[operatorsStack.Peek()])
         {
            while (operatorsStack.Count > 0 && operatorsStack.Peek() != "(")
            {
               outQueue.Enqueue(operatorsStack.Pop());
            }

            if (operatorsStack.Count > 0 && operatorsStack.Peek() == "(")
            {
               operatorsStack.Pop();
            }

            if (stringSplited[i] != ")")
               operatorsStack.Push(stringSplited[i]);
         }
      }
   }
}
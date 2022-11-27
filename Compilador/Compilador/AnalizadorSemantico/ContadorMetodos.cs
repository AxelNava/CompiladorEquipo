using System;
using System.Collections.Generic;

namespace Compilador.AnalizadorSemantico
{
   public class ContadorMetodos
   {
      /// <summary>
      /// Esta cola almacena el conteo de la posición de donde empieza un método y donde termina
      /// La tupla, su primer valor es inicio, el segundo es final
      /// </summary>
      private static Queue<Tuple<int, int>> _colaDeConteos = new Queue<Tuple<int, int>>();

      public static void AddConteo(int inicio, int final)
      {
         _colaDeConteos.Enqueue(new Tuple<int, int>(inicio, final));
      }

      public static bool CheckPosition(int position)
      {
         if (_colaDeConteos.Peek().Item1 == position)
         {
            return true;
         }
         return false;
      }

      public static Tuple<int, int> ObtenerInicioFinal() => _colaDeConteos.Dequeue();
   }
}
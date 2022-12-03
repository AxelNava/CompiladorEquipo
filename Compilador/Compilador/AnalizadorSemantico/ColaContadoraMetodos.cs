using System;
using System.Collections.Generic;

namespace Compilador.AnalizadorSemantico
{
   public class ColaContadoraMetodos
   {
      private Stack<int> PilaDEInicioes = new Stack<int>();
      public Stack<Tuple<int, int>> PilaResultante = new Stack<Tuple<int, int>>();

      public void AgregarInicioDeCola(int inicio)
      {
         PilaDEInicioes.Push(inicio);
      }
      public void AgregarContador(int final)
      {
         PilaResultante.Push( new Tuple<int, int>(PilaDEInicioes.Pop(), final));
      }
   }
}
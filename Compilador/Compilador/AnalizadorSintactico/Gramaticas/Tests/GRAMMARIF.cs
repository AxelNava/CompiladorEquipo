// namespace Compilador.Gramaticas.Tests
// {
//    public class GRAMMARIF
//    {
//       
//       #region metodos para test
//
//       public string EjecutarAnalisisTest(Stack<string> pilaParaComprobar)
//       {
//          analisisFinished = false;
//          while (pilaParaComprobar.Count >= 1)
//          {
//             int referenceState = pilaComprobacion.Peek().Item1;
//             if (tablaAnalisis[referenceState].ContainsKey(pilaParaComprobar.Peek()))
//             {
//                AbstractActionFunction.ActionEnum actionEnum;
//                actionEnum = tablaAnalisis[referenceState][pilaParaComprobar.Peek()].Action;
//                HandleActionsTest(actionEnum, pilaParaComprobar);
//                if (analisisFinished) return "<IF>";
//             }
//          }
//
//          return pilaComprobacion.Count.ToString();
//       }
//
//       void HandleActionsTest(AbstractActionFunction.ActionEnum typeAction, Stack<string> pilaPrueba)
//       {
//          int referenceState = pilaComprobacion.Peek().Item1;
//          switch (typeAction)
//          {
//             case AbstractActionFunction.ActionEnum.DESPLAZAMIENTO:
//             case AbstractActionFunction.ActionEnum.GOTO:
//                PushPopStacks_Shit_Goto_Test(referenceState, pilaPrueba);
//                break;
//             case AbstractActionFunction.ActionEnum.ACEPTACION:
//                analisisFinished = true;
//                break;
//             case AbstractActionFunction.ActionEnum.REDUCCION:
//                jumpStackToGlobalStackTest(referenceState, pilaPrueba);
//                break;
//          }
//       }
//
//       #endregion
//    }
// }

using System;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
public class GramaticaBase : AbstractAnalisisTable
{
      
   public string jumpStackToGlobalStackTest(int referenceStateStack,
      Stack<string> pilaPrueba)
   {
      string reductionToken = (reductionHandlerTest(referenceStateStack, pilaPrueba));
      pilaPrueba.Push(reductionToken);
      return pilaPrueba.Peek();
   }

   public void PushPopStacks_Shit_Goto_Test(int referenceState, Stack<string> pilaprueba)
   {
      int nextState = 0;
      AccionFuncion_TablaAnalisis classReserve;
      classReserve =
         tablaAnalisis[referenceState][pilaprueba.Peek()] as AccionFuncion_TablaAnalisis;
      if (classReserve != null) nextState = classReserve._state;
      PilaComprobacion.Push(new Tuple<int, string>(nextState, pilaprueba.Pop()));
   }

   public string reductionHandlerTest(int referenceStatem, Stack<string> pilaPrueba)
   {
      ReducedAction classReserve;
      classReserve =
         tablaAnalisis[referenceStatem][pilaPrueba.Peek()] as ReducedAction;
      int sizeRule = classReserve._ruled.Length;
      string[] tokens = new string[sizeRule];
      for (int i = sizeRule - 1; i >= 0; i--)
      {
         tokens[i] = PilaComprobacion.Pop().Item2;
      }

      return classReserve.ReduceTokens(tokens);
   }
}
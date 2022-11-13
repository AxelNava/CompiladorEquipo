using System;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;

namespace Compilador.AnalizadorSintactico.Gramaticas.ClasesBase
{
   /// <summary>
   ///This class provides the methods to manipulate an analysis table of a grammar
   /// Has the properties of the stack and the dictionary which is the analysis table structure
   /// </summary>
   public class AbstractAnalisisTable
   {
      protected Stack<Tuple<int, string>> PilaComprobacion { get; set; }
      protected bool analisisFinished = false;
      /// <summary>
      /// The Key int, is the number of the state of the analysis table, the Dictionary in there
      /// has the string key, which is the TOKEN column, the AbstractActionFunction  has the
      /// type of action that would be executed
      /// </summary>
      protected Dictionary<int, Dictionary<string, AbstractActionFunction>> tablaAnalisis { get; set; }

      /// <summary>
      /// Pop a token from the global stack tokens, and push it to the analysis stack
      /// </summary>
      protected void PushPopStacks_Shit_Goto(int referenceState)
      {
         int nextState = 0;
         AccionFuncion_TablaAnalisis classReserve;
         classReserve =
            tablaAnalisis[referenceState][PilaTokens.GlobalTokens.Peek()] as AccionFuncion_TablaAnalisis;
         if (classReserve != null) nextState = classReserve._state;
         PilaComprobacion.Push(new Tuple<int, string>(nextState, PilaTokens.GlobalTokens.Pop()));
      }

      /// <summary>
      /// Move the current stack, to the global tokens stack
      /// </summary>
      /// <param name="referenceState"></param>
      protected void jumpStackToGlobalStack(int referenceState)
      {
         PilaTokens.GlobalTokens.Push(reductionHandler(referenceState));
      }

      /// <summary>
      /// Make the reduction of a secuense of tokens of the owner stack
      /// </summary>
      /// <param name="referenceState"></param>
      /// <returns>The Token rule, or the token producer</returns>
      protected string reductionHandler(int referenceState)
      {
         ReducedAction classReserve;
         classReserve =
            tablaAnalisis[referenceState][PilaTokens.GlobalTokens.Peek()] as ReducedAction;
         if (classReserve._ruled[0] == string.Empty)
         {
            return classReserve.ReturnTokenReduced();
         }
         int sizeRule = classReserve._ruled.Length;
         string[] tokens = new string[sizeRule];
         for (int i = sizeRule - 1; i >= 0; i--)
         {
            tokens[i] = PilaComprobacion.Pop().Item2;
         }

         return classReserve.ReduceTokens(tokens);
      }
      //Check what is the action to do, and do it
      protected void HandleActions(AbstractActionFunction.ActionEnum typeAction)
      {
         int referenceState = PilaComprobacion.Peek().Item1;
         switch (typeAction)
         {
            case AbstractActionFunction.ActionEnum.DESPLAZAMIENTO:
               PushPopStacks_Shit_Goto(referenceState);
               LexemaCount.CountLexemas++;
               break;
            case AbstractActionFunction.ActionEnum.GOTO:
               PushPopStacks_Shit_Goto(referenceState);
               break;
            case AbstractActionFunction.ActionEnum.ACEPTACION:
               if(PilaTokens.GlobalTokens.Count != 1 && PilaTokens.GlobalTokens.Peek() == "FinCadena")
                  PilaTokens.GlobalTokens.Pop();
               analisisFinished = true;
               break;
            case AbstractActionFunction.ActionEnum.REDUCCION:
               jumpStackToGlobalStack(referenceState);
               break;
         }
      }
   }
}
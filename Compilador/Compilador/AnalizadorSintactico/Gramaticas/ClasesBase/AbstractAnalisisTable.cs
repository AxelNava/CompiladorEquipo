using System;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Compilador.TablasGlobales;

namespace Compilador.AnalizadorSintactico.Gramaticas.ClasesBase
{
   /// <summary>
   ///This class provides the methods to manipulate an analysis table of a grammar
   /// Has the properties of the stack and the dictionary which is the analysis table structure
   /// </summary>
   public class AbstractAnalisisTable
   {
      protected Stack<Tuple<int, string>> PilaComprobacion { get; set; }
      protected bool AnalisisFinished = false;

      /// <summary>
      /// The Key int, is the number of the state of the analysis table, the Dictionary in there
      /// has the string key, which is the TOKEN column, the AbstractActionFunction  has the
      /// type of action that would be executed
      /// </summary>
      protected Dictionary<int, Dictionary<string, AbstractActionFunction>> TablaAnalisis { get; set; }

      /// <summary>
      /// Pop a token from the global stack tokens, and push it to the analysis stack
      /// </summary>
      protected void PushPopStacks_Shit_Goto(int referenceState)
      {
         int nextState = 0;
         AccionFuncion_TablaAnalisis classReserve;
         classReserve =
            TablaAnalisis[referenceState][PilaTokens.GlobalTokens.Peek()] as AccionFuncion_TablaAnalisis;
         if (classReserve != null) nextState = classReserve._state;
         PilaComprobacion.Push(new Tuple<int, string>(nextState, PilaTokens.GlobalTokens.Pop()));
      }

      /// <summary>
      /// Move the current stack, to the global tokens stack
      /// </summary>
      /// <param name="referenceState"></param>
      protected void JumpStackToGlobalStack(int referenceState)
      {
         PilaTokens.GlobalTokens.Push(ReductionHandler(referenceState));
      }

      /// <summary>
      /// Make the reduction of a secuense of tokens of the owner stack
      /// </summary>
      /// <param name="referenceState"></param>
      /// <returns>The Token rule, or the token producer</returns>
      protected string ReductionHandler(int referenceState)
      {
         ReducedAction classReserve;
         classReserve =
            TablaAnalisis[referenceState][PilaTokens.GlobalTokens.Peek()] as ReducedAction;
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
               if(PilaComprobacion.Peek().Item2 != "Lambda")
                  LexemaCount.CountLexemas++;
               CheckTypesLexema();
               break;
            case AbstractActionFunction.ActionEnum.GOTO:
               PushPopStacks_Shit_Goto(referenceState);
               break;
            case AbstractActionFunction.ActionEnum.ACEPTACION:
               if (PilaTokens.GlobalTokens.Count != 1 && PilaTokens.GlobalTokens.Peek() == "FinCadena")
                  PilaTokens.GlobalTokens.Pop();
               AnalisisFinished = true;
               break;
            case AbstractActionFunction.ActionEnum.REDUCCION:
               JumpStackToGlobalStack(referenceState);
               break;
         }
      }
      private void CheckTypesLexema()
      {
         int valueOfShift = 0;
         switch (PilaComprobacion.Peek().Item2)
         {
            case "TIPO":
               string typeOftype = TablaLexemaToken.GetLexema(LexemaCount.CountLexemas);
               valueOfShift = Tabla_DesplazamientosValores.GetValueOfShift(typeOftype);
               break;
            case "Entero":
            case "Cadena":
            case "Decimal":
            case "Caracter":
            case "BOOL":
               valueOfShift = Tabla_DesplazamientosValores.GetValueOfShift(PilaComprobacion.Peek().Item2);
               break;
         }
      }
      public void AddError()
      {
         int referenceState = PilaComprobacion.Peek().Item1;
         Dictionary<string, AbstractActionFunction> dictionaryState = TablaAnalisis[referenceState];
         int numLine = TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item1;
         ErrorSintaxManager.AddMessageError(dictionaryState, numLine);
      }
   }
}
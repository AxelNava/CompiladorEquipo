using System;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;

namespace Compilador.AnalizadorSintactico.Gramaticas.ClasesBase {
    public class AbstractAnalisisTable {
        protected Stack<Tuple<int, string>> PilaComprobacion { get; set; }

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
            int sizeRule = classReserve._ruled.Length;
            string[] tokens = new string[sizeRule];
            for (int i = sizeRule-1; i >= 0; i--)
            {
                tokens[i] = PilaComprobacion.Pop().Item2;
            }
            return classReserve.ReduceTokens(tokens);
        }
    }
}

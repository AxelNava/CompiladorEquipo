using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Compilador.Gramaticas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.AnalizadorSintactico.Gramaticas
{
    public class GramaticaEstructuraControl : AbstractAnalisisTable
    {
        public enum notTerminalsForThis
        {
            ESTRUCTURACONTROL,
            IF,
            WHILE,
            FOR,
            DO

        }

        private static readonly string[] notTerminalSymbols =
        {
            "<estructuracontrol>",
            "if",
            "while",
            "for",
            "do"
        };
        public GramaticaEstructuraControl()
        {
            tablaAnalisis = new Dictionary<int, Dictionary<string, AbstractActionFunction>>()
            {
                {


                   0, new Dictionary<string, AbstractActionFunction>()
                   {
                       {"if", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 2) },
                       {"while", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 3) },
                       {"for", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 4) },
                       {"do", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 5) },
                   }
                },
                {


                   1, new Dictionary<string, AbstractActionFunction>()
                   {
                       {"FinCadena", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.ACEPTACION, 6) },

                   }
                },
                {


                   2, new Dictionary<string, AbstractActionFunction>()
                   {
                       {"<IF>", new ReducedAction("EC", new []{"IF"}) },

                   }
                },
                {


                   3, new Dictionary<string, AbstractActionFunction>()
                   {
                       {"<WHILE>", new ReducedAction("EC", new []{"WHILE"}) },

                   }
                },
                {


                   4, new Dictionary<string, AbstractActionFunction>()
                   {
                       {"<FOR>", new ReducedAction("EC", new []{"FOR"}) },

                   }
                },
                {


                   5, new Dictionary<string, AbstractActionFunction>()
                   {
                       {"<DO>", new ReducedAction("EC", new []{"DO"}) },

                   }
                },


            };
            PilaComprobacion = new Stack<Tuple<int, string>>();
            PilaComprobacion.Push(new Tuple<int, string>(0, "0"));
        }

        
        public string selectorString(notTerminalsForThis notTerminal)
        {
            return notTerminalSymbols.GetValue((int)Convert.ChangeType(notTerminal, notTerminal.GetTypeCode())).ToString();
        }
        private bool analisisFinished;


        public string EjecutarAnalisis()
        {
            analisisFinished = false;
            while (PilaTokens.GlobalTokens.Count >= 1)
            {
                if (!CheckTokenInHandler())
                {
                    PilaTokens.GlobalTokens.Push("Lambda");
                    if (!CheckTokenInHandler())
                    {
                        PilaTokens.GlobalTokens.Pop();
                        PilaTokens.GlobalTokens.Push("FinCadena");
                        if (!CheckTokenInHandler())
                        {
                            return string.Empty;
                        }
                    }
                }
                if (analisisFinished) return "<IF>";
                GrammarErrors.MessageErrorsOfGrammarsM += string.Format($"Hay un error en la línea: {PilaTokens.numLineToken[0].Item1}\n");
            }

            return PilaComprobacion.Count.ToString();
        }



        void HandleActions(AbstractActionFunction.ActionEnum typeAction)
        {
            int referenceState = PilaComprobacion.Peek().Item1;
            switch (typeAction)
            {
                case AbstractActionFunction.ActionEnum.DESPLAZAMIENTO:
                case AbstractActionFunction.ActionEnum.GOTO:
                    PushPopStacks_Shit_Goto(referenceState);
                    break;
                case AbstractActionFunction.ActionEnum.ACEPTACION:
                    analisisFinished = true;
                    break;
                case AbstractActionFunction.ActionEnum.REDUCCION:
                    jumpStackToGlobalStack(referenceState);
                    break;
            }
        }
        private bool CheckTokenInHandler()
        {
            int referenceState = PilaComprobacion.Peek().Item1;
            string tokenAux = string.Empty;
            if (referenceState == 1)
            {
                tokenAux = new GramaticaCondicion().EjecutarAnalisis();
                if (!string.IsNullOrEmpty(tokenAux))
                    PilaTokens.GlobalTokens.Push(tokenAux);
            }
            if (tablaAnalisis[referenceState].ContainsKey(PilaTokens.GlobalTokens.Peek()))
            {
                // PilaTokens.numLineToken.RemoveAt(0);
                AbstractActionFunction.ActionEnum actionEnum;
                actionEnum = tablaAnalisis[referenceState][PilaTokens.GlobalTokens.Peek()].Action;
                HandleActions(actionEnum);
                return true;
            }
            return false;
        }
    }

   
}

using System;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Compilador.Gramaticas;
using System.Collections.Generic;
namespace Compilador.AnalizadorSintactico.Gramaticas {
    internal class Gramatica_For : AbstractAnalisisTable {
        public enum notTerminalsForThis {
            FOR,
            INSTACIACION,
            CONDICIONF,
            INCDEC,
            CUERPOINSTRUCCIONES,
            VALOR,
            CONDICION,
            INCREMENTO
        }

        private static readonly string [] notTerminalSymbols =
        {
            "<for>",
            "instaciacion",
            "condicionf",
            "IncDec",
            "CuerpoInstrucciones",
            "valor",
            "condicion",
            "incremento"
        };
        public Gramatica_For()
        {
            PilaComprobacion = new Stack<Tuple<int, string>>();
            PilaComprobacion.Push(new Tuple<int, string>(0, "0"));
            tablaAnalisis = new Dictionary<int, Dictionary<string, AbstractActionFunction>>() {
               {
                    0, new Dictionary<string, AbstractActionFunction>() {
                        {
                            tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.FOR), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 2)
                         },
                         {
                            "<FOR>", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 1)
                            }
                    }
                },
               {
                    2, new Dictionary<string, AbstractActionFunction>()
                    {
                        {
                            tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 3)
                        }
                    }
                },
                {
                    1, new Dictionary<string, AbstractActionFunction>()
                    {
                       {"FinCadena", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.ACEPTACION, 19) }
                    }
                },
                {
                    3, new Dictionary<string, AbstractActionFunction>()
                    {
                        {
                            tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 5)
                        }
                    }
                },
                {
                    4, new Dictionary<string, AbstractActionFunction>()
                    {
                        {
                            tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 7)
                        }
                    }
                },
                {
                    5, new Dictionary<string, AbstractActionFunction>()
                    {
                        {
                            tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 8)
                        }
                    }
                },
                {
                    6, new Dictionary<string, AbstractActionFunction>()
                    {
                          { "PUNTOYCOMA", new ReducedAction("INSTACIACION", new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA) }) }
                    }
                },
                {
                    7, new Dictionary<string, AbstractActionFunction>()
                    {
                          { "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 13) },
                          { "<CONDICIONF>", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 9) },
                          { "<CONDICION>", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 12) }
                    }
                },
                {
                    8, new Dictionary<string, AbstractActionFunction>()
                    {
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Asignacion), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 10)
                        }

                    }
                },
                {
                    9, new Dictionary<string, AbstractActionFunction>()
                    {
                        {
                            tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 14)
                        }

                    }
                },
                {
                    10, new Dictionary<string, AbstractActionFunction> ()
                    {
                            { "<VALOR>", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 11) },
                    }
                },
                {
                    11, new Dictionary<string, AbstractActionFunction>()
                    {
                            { "PUNTOYCOMA", new ReducedAction("INSTACIACION", new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA) }) }
                    }
                },
                {
                    12, new Dictionary<string, AbstractActionFunction>()
                    {
                            { "PUNTOYCOMA", new ReducedAction("CONDICIONF", new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA) }) }
                    }
                },
                {
                    13, new Dictionary<string, AbstractActionFunction>()
                    {
                            { "PUNTOYCOMA", new ReducedAction("CONDICIONF", new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA) }) }
                    }
                },
                {
                    14, new Dictionary<string, AbstractActionFunction>()
                     {
                        {
                            tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 16)
                        },
                        { "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 17) },
                        { "<INCDEC>", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 15) }
                     }
                },
                {
                     15, new Dictionary<string, AbstractActionFunction>()
                     {
                         {
                             tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 18)
                         }
                     }
                },
                {
                     16, new Dictionary<string, AbstractActionFunction>()
                     {
                          { "<INCREMENTO>", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 19) }
                     }
                },
                {
                     17, new Dictionary<string, AbstractActionFunction>()
                     {
                          { "PARENTESISCIERRA", new ReducedAction("INCDEC", new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA) }) }
                     }
                },
                {
                     18, new Dictionary<string, AbstractActionFunction>()
                     {
                         {
                             tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 20)
                         }
                     }
                },
                {
                     19, new Dictionary<string, AbstractActionFunction>()
                     {
                            { "PARENTESISCIERRA", new ReducedAction("INCDEC", new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA) }) }
                     }
                },
                {
                     20, new Dictionary<string, AbstractActionFunction>()
                     {
                            { "<CUERTPOINSTRUCCIONES>", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 21) }
                     }
                },
                {
                     21, new Dictionary<string, AbstractActionFunction>()
                     {
                         {
                             tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 22)
                         }
                     }
                },
                {
                     22, new Dictionary<string, AbstractActionFunction> ()
                     {
                             { "FinCadena", new ReducedAction("FOR", new[] { "FinCadena" }) }
                     }
                }
            };
        }
        public string EjecutarAnalisis() {
            analisisFinished = false;
            while ( PilaTokens.GlobalTokens.Count >= 1 ) {
                if ( !CheckTokenIn_Handler() ) {
                    PilaTokens.GlobalTokens.Push("Lambda");
                    if ( !CheckTokenIn_Handler() ) {
                        PilaTokens.GlobalTokens.Pop();
                        PilaTokens.GlobalTokens.Push("FinCadena");
                        if ( !CheckTokenIn_Handler() ) {
                            PilaTokens.GlobalTokens.Pop();
                            return string.Empty;
                        }
                    }
                }

                if ( analisisFinished ) return "<for>";

            }

            return PilaComprobacion.Count.ToString();
        }
        private bool CheckTokenIn_Handler() {
            int referenceState = PilaComprobacion.Peek().Item1;

            if ( referenceState == 2 || referenceState == 16 ) {
                string tokenAux = new GramaticaCondicion().EjecutarAnalisis();
                if ( !string.IsNullOrEmpty(tokenAux) )
                    PilaTokens.GlobalTokens.Push(tokenAux);
            }

            if ( tablaAnalisis [referenceState].ContainsKey(PilaTokens.GlobalTokens.Peek()) ) {

                AbstractActionFunction.ActionEnum actionEnum;
                actionEnum = tablaAnalisis [referenceState] [PilaTokens.GlobalTokens.Peek()].Action;
                HandleActions(actionEnum);
                return true;
            }

            return false;
        }
    }
}

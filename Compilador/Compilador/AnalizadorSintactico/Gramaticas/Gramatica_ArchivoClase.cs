using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Compilador.Gramaticas;
using System;
using System.Collections.Generic;
using static Compilador.Gramaticas.Gramatica_DoWhile;

namespace Compilador.AnalizadorSintactico.Gramaticas
{
    public class Gramatica_ArchivoClase : AbstractAnalisisTable
    {
        public enum notTerminalsForThis
        {
            ARCHIVOCLASE,
            USING,
            NOMBRECLASE,
            BODYCLASS,
            DECLARACIONFUNCIONES
        }

        private static readonly string[] notTerminalSymbols =
        {
         "<archivoclase>",
         "<using>",
         "nombreclase",
         "bodyclass",
         "declaracionfunciones"
        };
        public string selectorString(notTerminalsForThis tokenEnum)
        {
            return notTerminalSymbols.GetValue((int)Convert.ChangeType(tokenEnum, tokenEnum.GetTypeCode())).ToString();
        }


        public Gramatica_ArchivoClase()
        {
            tablaAnalisis = new Dictionary<int, Dictionary<string, AbstractActionFunction>>()
         {
            {
               0, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.USING),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 3)
                  },
                  {
                       tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CLASS), new ReducedAction("<using>", new[]{string.Empty})
                  },
                  { "<archivoclase>", new AccionFuncion_TablaAnalisis(AccionFuncion_TablaAnalisis.ActionEnum.GOTO, 1) },
                  {"<using>", new AccionFuncion_TablaAnalisis(AccionFuncion_TablaAnalisis.ActionEnum.GOTO, 2) },
                  {"FinCadena", new ReducedAction("<using>", new[] {string.Empty }) }


               }
            },
            {
               1, new Dictionary<string, AbstractActionFunction>()
               {
                  { "FinCadena", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.ACEPTACION, 1) }
               }
            },
            {
               2, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CLASS),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 5)
                  },
                  { "nombreclase", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 4) },
                  {"FinCadena", new ReducedAction("nombreclase", new[] {string.Empty }) }
               }
            },
            {
               3, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 6)
                  }
               }
            },
            {
               4, new Dictionary<string, AbstractActionFunction>()
               {
                   {"FinCadena", new ReducedAction("<archivoclase>", new[]{"<using>","nombreclase"})}
               }
            },
            {
               5, new Dictionary<string, AbstractActionFunction>()
               {
                   {


                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                        new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 7)
                   }
               }
            },
            {
               6, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 8)
                  },

               }
            },
            {
               7, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 9)
                  },
               }
            },
            {
               8, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                       tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.USING),
                      new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 3)
                  },
                  {
                       tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CLASS),
                       new ReducedAction("<using>", new[]{string.Empty})
                  },
                  {"<using>", new AccionFuncion_TablaAnalisis(AccionFuncion_TablaAnalisis.ActionEnum.GOTO, 10) },
                  {"FinCadena", new ReducedAction("<using>", new[] {string.Empty }) }

               }
            },
            {
               9, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "declaracionfunciones",
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 12)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA),
                     new ReducedAction("bodyclass", new[] {string.Empty})
                  },
                  {"bodyclass", new AccionFuncion_TablaAnalisis(AccionFuncion_TablaAnalisis.ActionEnum.GOTO,11) }
               }
            },
            {
               10, new Dictionary<string, AbstractActionFunction>()
               {
                   {
                       tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CLASS),
                       new ReducedAction("<using>", new[]{
                       tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.USING), tokensNameGlobal.selectorString
                       (tokensNameGlobal.tokensGlobals.Identificador), tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA),
                       "<using>"
                       })
                   },
               }
            },
            {
               11, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 13)
                  },
               }
            },
            {
               12, new Dictionary<string, AbstractActionFunction>()
               {
                   {
                       tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA),
                       new ReducedAction("bodyclass", new[]{"declaracionfunciones"})
                   }
               }
            },
            {
               13, new Dictionary<string, AbstractActionFunction>()
               {
                   { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CLASS), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 5) },
                   {"nombreclase", new AccionFuncion_TablaAnalisis(AccionFuncion_TablaAnalisis.ActionEnum.GOTO,14) },
                   {"FinCadena", new ReducedAction("nombreclase", new[] {string.Empty }) }

               }
            },
            {
                 14, new Dictionary<string, AbstractActionFunction>()
                 {
                     {"FinCadena", new ReducedAction("nombreclase", new[]{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CLASS),tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE), "bodyclass", tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA),"nombreclase"}) }
                 }

            },
         };
            PilaComprobacion = new Stack<Tuple<int, string>>();
            PilaComprobacion.Push(new Tuple<int, string>(0, "0"));
        }

        public string EjecutarAnalisis()
        {
            analisisFinished = false;
            while (PilaTokens.GlobalTokens.Count >= 1)
            {
                if (!CheckTokenIn_Handler())
                {
                    PilaTokens.GlobalTokens.Push("Lambda");
                    if (!CheckTokenIn_Handler())
                    {
                        PilaTokens.GlobalTokens.Pop();
                        PilaTokens.GlobalTokens.Push("FinCadena");
                        if (!CheckTokenIn_Handler())
                        {
                            PilaTokens.GlobalTokens.Pop();
                            return string.Empty;
                        }
                    }
                }
                if (analisisFinished) return "<archivoclase>";
            }

            return PilaComprobacion.Count.ToString();
        }

        private bool CheckTokenIn_Handler()
        {
            int referenceState = PilaComprobacion.Peek().Item1;
            if (referenceState == 9)
            {
                //llamar gramatica yahir
      
                Gramatica_While hola = new Gramatica_While();
                string tokenp = hola.Ejecutar_Analisis();
                if(! string.IsNullOrEmpty(tokenp) )
                {
                    PilaTokens.GlobalTokens.Push(tokenp);
                }
            }
            if (tablaAnalisis[referenceState].ContainsKey(PilaTokens.GlobalTokens.Peek()))
            {
                AbstractActionFunction.ActionEnum actionEnum;
                actionEnum = tablaAnalisis[referenceState][PilaTokens.GlobalTokens.Peek()].Action;
                HandleActions(actionEnum);
                return true;
            }

            return false;
        }
    }
}
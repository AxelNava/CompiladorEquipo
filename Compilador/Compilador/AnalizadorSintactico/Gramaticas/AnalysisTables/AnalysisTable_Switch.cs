using System;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;

namespace Compilador.AnalizadorSintactico.Gramaticas.AnalysisTables
{
   public class AnalysisTable_Switch
   {
      private enum nonTerminalTokensSwtich
      {
         Switch,
         ParametrosValores,
         Recursividad,
         BodySwitch,
         ValoresCase,
         cuerpoInstrucciones
      }

      private static readonly string[] nonTerminalsStrings =
      {
         "<Swtich>",
         "Valores",
         "Recursividad",
         "BodySwitch",
         "ValoresCase",
         "cuerpoInstrucciones"
      };

      private static string selectorString(nonTerminalTokensSwtich nonTerminal)
      {
         return nonTerminalsStrings.GetValue((int)Convert.ChangeType(nonTerminal, nonTerminal.GetTypeCode())).ToString();
      }

      public static Dictionary<int, Dictionary<string, AbstractActionFunction>> GlobalDictionarySwitch =
         new Dictionary<int, Dictionary<string, AbstractActionFunction>>()
         {
            {
               0, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.SWITCH), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 2)
                  },
                  {
                     selectorString(nonTerminalTokensSwtich.Switch), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 1)
                  }
               }
            },
            {
               1, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.ACEPTACION, 1)
                  }
               }
            },
            {
               2, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 3)
                  }
               }
            },
            {
               3, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     selectorString(nonTerminalTokensSwtich.ParametrosValores),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 4)
                  }
               }
            },
            {
               4, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 5)
                  }
               }
            },
            {
               5, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 6)
                  }
               }
            },
            {
               6, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CASSSE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 8)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DEFAUUULT), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 9)
                  },
                  {
                     selectorString(nonTerminalTokensSwtich.BodySwitch), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 7)
                  }
               }
            },
            {
               7, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 10)
                  }
               }
            },
            {
               8, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 12)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 13)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 14)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 15)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 16)
                  },
                  {
                     selectorString(nonTerminalTokensSwtich.ValoresCase), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 11)
                  }
               }
            },
            {
               9, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DOSPUNTOS), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 17)
                  }
               }
            },
            {
               10, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokensSwtich.Switch), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.SWITCH),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        selectorString(nonTerminalTokensSwtich.ParametrosValores),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE),
                        selectorString(nonTerminalTokensSwtich.BodySwitch),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA)
                     })
                  }
               }
            },
            {
               11, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DOSPUNTOS), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 18)
                  }
               }
            },
            {
               12, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DOSPUNTOS), new ReducedAction(
                        selectorString(nonTerminalTokensSwtich.ValoresCase), new[]
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO)
                        })
                  }
               }
            },
            {
               13, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DOSPUNTOS), new ReducedAction(
                        selectorString(nonTerminalTokensSwtich.ValoresCase), new[]
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA)
                        })
                  }
               }
            },
            {
               14, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DOSPUNTOS), new ReducedAction(
                        selectorString(nonTerminalTokensSwtich.ValoresCase), new[]
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER)
                        })
                  }
               }
            },
            {
               15, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DOSPUNTOS), new ReducedAction(
                        selectorString(nonTerminalTokensSwtich.ValoresCase), new[]
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL)
                        })
                  }
               }
            },
            {
               16, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DOSPUNTOS), new ReducedAction(
                        selectorString(nonTerminalTokensSwtich.ValoresCase), new[]
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL)
                        })
                  }
               }
            },
            {
               17, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     selectorString(nonTerminalTokensSwtich.cuerpoInstrucciones), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum
                        .GOTO, 19)
                  }
               }
            },
            {
               18, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     selectorString(nonTerminalTokensSwtich.cuerpoInstrucciones), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum
                        .GOTO, 20)
                  }
               }
            },
            {
               19, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BREAAAK),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 21)
                  }
               }
            },
            {
               20, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BREAAAK),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 22)
                  }
               }
            },
            {
               21, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA), new AccionFuncion_TablaAnalisis(
                        AbstractActionFunction
                           .ActionEnum.DESPLAZAMIENTO, 23)
                  }
               }
            },
            {
               22, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA), new AccionFuncion_TablaAnalisis(
                        AbstractActionFunction
                           .ActionEnum.DESPLAZAMIENTO, 24)
                  }
               }
            },
            {
               23, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA), new ReducedAction(selectorString
                        (nonTerminalTokensSwtich.BodySwitch), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DEFAUUULT),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DOSPUNTOS),
                        selectorString(nonTerminalTokensSwtich.cuerpoInstrucciones),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BREAAAK),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)
                     })
                  }
               }
            },
            {
               24, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA), new ReducedAction(selectorString
                        (nonTerminalTokensSwtich.Recursividad), new[]
                     {
                        string.Empty
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CASSSE), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 8)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DEFAUUULT), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 9)
                  },
                  {
                     selectorString(nonTerminalTokensSwtich.BodySwitch), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 26)
                  },
                  {
                     selectorString(nonTerminalTokensSwtich.Recursividad), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 25)
                  }
               }
            },
            {
               25, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA), new ReducedAction(selectorString
                        (nonTerminalTokensSwtich.BodySwitch), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CASSSE),
                        selectorString(nonTerminalTokensSwtich.ValoresCase),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DOSPUNTOS),
                        selectorString(nonTerminalTokensSwtich.cuerpoInstrucciones),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BREAAAK),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA),
                        selectorString(nonTerminalTokensSwtich.Recursividad)
                     })
                  }
               }
            },
            {
               26, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA), new ReducedAction(selectorString
                        (nonTerminalTokensSwtich.Recursividad), new[] { selectorString(nonTerminalTokensSwtich.BodySwitch) })
                  }
               }
            }
         };
   }
}
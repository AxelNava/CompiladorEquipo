using System.Collections.Generic;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using System;
using System.Security.Permissions;

namespace Compilador.AnalizadorSintactico.Gramaticas.AnalysisTables
{
   public class AnalysisTable_ParametrosFuncion
   {
      private enum nonTerminalTokens
      {
         Valores,
         Parametros,
         Recursividad,
         PARAMETRO,
         ParametrosMetodo
      }

      private static readonly string[] nonTerminalsStrings =
      {
         "Valores",
         "Parametros",
         "Recursividad",
         "Param",
         "ParametrosMetodo"
      };

      private static string selectorString(nonTerminalTokens nonTerminal)
      {
         return nonTerminalsStrings.GetValue((int)Convert.ChangeType(nonTerminal, nonTerminal.GetTypeCode())).ToString();
      }

      public static Dictionary<int, Dictionary<string, AbstractActionFunction>> GlobalDictionaryParametros = new Dictionary<int, Dictionary<string,
         AbstractActionFunction>>()
      {
         {
            0, new Dictionary<string, AbstractActionFunction>()
            {
               {
                  selectorString(nonTerminalTokens.Valores), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 4)
               },
               {
                  "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.Parametros), new[] { string.Empty })
               },
               {
                  selectorString(nonTerminalTokens.ParametrosMetodo), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 1)
               },
               {
                  selectorString(nonTerminalTokens.Parametros), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 2)
               },
               {
                  selectorString(nonTerminalTokens.PARAMETRO), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 3)
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
                  "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.ParametrosMetodo), new[]
                  {
                     selectorString(nonTerminalTokens.Parametros)
                  })
               }
            }
         },
         {
            3, new Dictionary<string, AbstractActionFunction>()
            {
               {
                  "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.Parametros), new[] { selectorString(nonTerminalTokens.PARAMETRO) })
               }
            }
         },
         {
            4, new Dictionary<string, AbstractActionFunction>()
            {
               {
                  tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                     .ActionEnum.DESPLAZAMIENTO, 6)
               },
               {
                  "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.Recursividad), new[] { string.Empty })
               },
               {
                  selectorString(nonTerminalTokens.Recursividad), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 5)
               }
            }
         },
         {
            5, new Dictionary<string, AbstractActionFunction>()
            {
               {
                  "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.PARAMETRO), new[]
                  {
                     selectorString(nonTerminalTokens.Valores),
                     selectorString(nonTerminalTokens.Recursividad)
                  })
               }
            }
         },
         {
            6, new Dictionary<string, AbstractActionFunction>()
            {
               {
                  selectorString(nonTerminalTokens.Valores), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 4)
               },
               {
                  selectorString(nonTerminalTokens.PARAMETRO), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 7)
               }
            }
         },
         {
            7, new Dictionary<string, AbstractActionFunction>()
            {
               {
                  "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.Recursividad), new[]
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA),
                     selectorString(nonTerminalTokens.PARAMETRO)
                  })
               }
            }
         }
      };
   }
}
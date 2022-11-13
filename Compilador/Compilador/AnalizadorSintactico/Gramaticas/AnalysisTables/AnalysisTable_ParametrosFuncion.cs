using System.Collections.Generic;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using System;
using System.Security.Permissions;

namespace Compilador.AnalizadorSintactico.Gramaticas.AnalysisTables
{
   public class AnalysisTable_ParametrosFuncion
   {
      public enum nonTerminalTokens
      {
         Valores,
         OperacionIdentificicador,
         Recursividad,
         RecursividadMetodo,
         Parametros
      }

      private static readonly string[] nonTerminalsStrings =
      {
         "Valores",
         "OperacionIdentificador",
         "Recursividad",
         "RecursividadMetodo",
         "Parametros"
      };
      public static string selectorString(nonTerminalTokens nonTerminal)
      {
         return nonTerminalsStrings.GetValue((int)Convert.ChangeType(nonTerminal, nonTerminal.GetTypeCode())).ToString();
      }
      
      public static Dictionary<int, Dictionary<string, AbstractActionFunction>> GlobalDictionaryParametros = new Dictionary<int, Dictionary<string, AbstractActionFunction>>()
         {
            {
               0, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 2)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 4)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 5)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 6)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 7)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 8)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 9)
                  },
                  {
                     selectorString(nonTerminalTokens.Parametros), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 1)
                  },
                  {
                     selectorString(nonTerminalTokens.Valores), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 3)
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
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 11)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 12)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 13)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 14)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 15)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 16)
                  },
                  {
                     selectorString(nonTerminalTokens.Valores), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 10)
                  }
               }
            },
            {
               3, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena",
                     new ReducedAction(selectorString(nonTerminalTokens.Parametros), new[] { selectorString(nonTerminalTokens.Valores) })
                  }
               }
            },
            {
               4, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 18)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 19)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO), new AccionFuncion_TablaAnalisis(
                        AbstractActionFunction
                           .ActionEnum.DESPLAZAMIENTO, 20)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[] { string.Empty })
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalTokens.OperacionIdentificicador), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.GOTO, 17)
                  }
               }
            },
            {
               5, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 22)
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.Recursividad), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalTokens.Recursividad), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 21)
                  }
               }
            },
            {
               6, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 22)
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.Recursividad), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalTokens.Recursividad), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 23)
                  }
               }
            },
            {
               7, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 22)
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.Recursividad), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalTokens.Recursividad), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 24)
                  }
               }
            },
            {
               8, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 22)
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.Recursividad), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalTokens.Recursividad), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 25)
                  }
               }
            },
            {
               9, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 22)
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.Recursividad), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalTokens.Recursividad), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 26)
                  }
               }
            },
            {
               10, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 27)
                  }
               }
            },
            {
               11, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 29)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 30)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 31)
                  },
                  {
                     selectorString(nonTerminalTokens.OperacionIdentificicador),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 28)
                  }
               }
            },
            {
               12, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.Recursividad), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 33)
                  },
                  {
                     selectorString(nonTerminalTokens.Recursividad), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 32)
                  }
               }
            },
            {
               13, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.Recursividad), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 33)
                  },
                  {
                     selectorString(nonTerminalTokens.Recursividad), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 34)
                  }
               }
            },
            {
               14, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.Recursividad), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 33)
                  },
                  {
                     selectorString(nonTerminalTokens.Recursividad), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 35)
                  }
               }
            },
            {
               15, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.Recursividad), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 33)
                  },
                  {
                     selectorString(nonTerminalTokens.Recursividad), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 36)
                  }
               }
            },
            {
               16, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.Recursividad), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 33)
                  },
                  {
                     selectorString(nonTerminalTokens.Recursividad), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 37)
                  }
               }
            },
            {
               17, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 22)
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.Recursividad), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalTokens.Recursividad), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 38)
                  }
               }
            },
            {
               18, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.RecursividadMetodo), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 41)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 42)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 43)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 44)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 45)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 46)
                  },
                  {
                     selectorString(nonTerminalTokens.Valores), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 40)
                  },
                  {
                     selectorString(nonTerminalTokens.Para), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 39)
                  }
               }
            },
            {
               19, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals
                           .INCREMENTO)
                     })
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals
                           .INCREMENTO)
                     })
                  }
               }
            },
            {
               20, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals
                           .DECREMENTO)
                     })
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals
                           .DECREMENTO)
                     })
                  }
               }
            },
            {
               21, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA),
                        selectorString(nonTerminalTokens.Recursividad)
                     })
                  }
               }
            },
            {
               22, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 48)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 4)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 5)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 6)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 7)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 8)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 9)
                  },
                  {
                     selectorString(nonTerminalTokens.Valores), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 49)
                  },
                  {
                     selectorString(nonTerminalTokens.PR), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 47)
                  }
               }
            },
            {
               23, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER),
                        selectorString(nonTerminalTokens.Recursividad)
                     })
                  }
               }
            },
            {
               24, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),
                        selectorString(nonTerminalTokens.Recursividad)
                     })
                  }
               }
            },
            {
               25, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL),
                        selectorString(nonTerminalTokens.Recursividad)
                     })
                  }
               }
            },
            {
               26, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL),
                        selectorString(nonTerminalTokens.Recursividad)
                     })
                  }
               }
            },
            {
               27, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 22)
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.Recursividad), new[]
                     {
                        string.Empty
                     })
                  },
                  {
                     selectorString(nonTerminalTokens.Recursividad), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 50)
                  }
               }
            },
            {
               28, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.Recursividad), new[]
                     {
                        string.Empty
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 33)
                  },

                  {
                     selectorString(nonTerminalTokens.Recursividad), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 51)
                  }
               }
            },
            {
               29, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.Para), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 41)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 42)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 43)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 44)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 45)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 46)
                  },
                  {
                     selectorString(nonTerminalTokens.Valores), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 40)
                  },
                  {
                     selectorString(nonTerminalTokens.Para), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 52)
                  }
               }
            },
            {
               30, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals
                           .INCREMENTO)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals
                           .INCREMENTO)
                     })
                  }
               }
            },
            {
               31, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals
                           .DECREMENTO)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals
                           .DECREMENTO)
                     })
                  }
               }
            },
            {
               32, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA),
                        selectorString(nonTerminalTokens.Recursividad)
                     })
                  }
               }
            },
            {
               33, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 54)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 11)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 12)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 13)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 14)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 15)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 16)
                  },
                  {
                     selectorString(nonTerminalTokens.Valores), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 55)
                  },
                  {
                     selectorString(nonTerminalTokens.PR), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 53)
                  }
               }
            },
            {
               34, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(
                        selectorString(nonTerminalTokens.Valores), new[]
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER),
                           selectorString(nonTerminalTokens.Recursividad)
                        })
                  }
               }
            },
            {
               35, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(
                        selectorString(nonTerminalTokens.Valores), new[]
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),
                           selectorString(nonTerminalTokens.Recursividad)
                        })
                  }
               }
            },
            {
               36, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(
                        selectorString(nonTerminalTokens.Valores), new[]
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL),
                           selectorString(nonTerminalTokens.Recursividad)
                        })
                  }
               }
            },
            {
               37, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL),
                        selectorString(nonTerminalTokens.Recursividad)
                     })
                  }
               }
            },
            {
               38, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena",
                     new ReducedAction(selectorString(nonTerminalTokens.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                        selectorString(nonTerminalTokens.OperacionIdentificicador),
                        selectorString(nonTerminalTokens.Recursividad)
                     })
                  }
               }
            },
            {
               39, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 56)
                  }
               }
            },
            {
               40, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.RecursividadM), new[]
                     {
                        string
                           .Empty
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 58)
                  },
                  {
                     selectorString(nonTerminalTokens.RecursividadM), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 57)
                  }
               }
            },
            {
               41, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 60)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     new ReducedAction(selectorString(nonTerminalTokens.OperacionIdentificicador), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 61)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 62)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalTokens.OperacionIdentificicador), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.GOTO, 59)
                  }
               }
            },
            {
               42, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.Recursividad), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 64)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalTokens.Recursividad), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalTokens.Recursividad), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 63)
                  }
               }
            },
            {
               43, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.Recursividad), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 64)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalTokens.Recursividad), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalTokens.Recursividad), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 65)
                  }
               }
            },
            {
               44, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.Recursividad), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 64)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalTokens.Recursividad), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalTokens.Recursividad), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 66)
                  }
               }
            },
            {
               45, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.Recursividad), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 64)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalTokens.Recursividad), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalTokens.Recursividad), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 67)
                  }
               }
            },
            {
               46, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.Recursividad), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 64)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalTokens.Recursividad), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalTokens.Recursividad), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 68)
                  }
               }
            },
            {
               47, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.Recursividad), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                        selectorString(nonTerminalTokens.PR)
                     })
                  }
               }
            },
            {
               48, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 11)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 12)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 13)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 14)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 15)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 16)
                  },
                  {
                     selectorString(nonTerminalTokens.Valores), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 69)
                  }
               }
            },
            {
               49, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.PR), new[]
                     {
                        selectorString(nonTerminalTokens.Valores)
                     })
                  }
               }
            },
            {
               50, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        selectorString(nonTerminalTokens.Valores),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                        selectorString(nonTerminalTokens.Recursividad)
                     })
                  }
               }
            },
            {
               51, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     new ReducedAction(selectorString(nonTerminalTokens.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                        selectorString(nonTerminalTokens.OperacionIdentificicador),
                        selectorString(nonTerminalTokens.Recursividad)
                     })
                  }
               }
            },
            {
               52, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 70)
                  }
               }
            },
            {
               53, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     new ReducedAction(selectorString(nonTerminalTokens.Recursividad), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                        selectorString(nonTerminalTokens.PR)
                     })
                  }
               }
            },
            {
               54, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 11)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 12)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 13)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 14)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 15)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 16)
                  },
                  {
                     selectorString(nonTerminalTokens.Valores), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 71)
                  }
               }
            },
            {
               55, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.PR), new[]
                     {
                        selectorString(nonTerminalTokens.Valores)
                     })
                  }
               }
            },
            {
               56, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        selectorString(nonTerminalTokens.Para),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     })
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        selectorString(nonTerminalTokens.Para),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     })
                  }
               }
            },
            {
               57, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.Para), new[]
                     {
                        selectorString(nonTerminalTokens.Valores),
                        selectorString(nonTerminalTokens.RecursividadM)
                     })
                  }
               }
            },
            {
               58, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.Para), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 41)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 42)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 43)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 44)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 45)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 46)
                  },
                  {
                     selectorString(nonTerminalTokens.Valores), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 40)
                  },
                  {
                     selectorString(nonTerminalTokens.Para), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 72)
                  }
               }
            },
            {
               59, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                     (nonTerminalTokens.Recursividad), new []{string.Empty})
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 64)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalTokens.Recursividad), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalTokens.Recursividad), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 73)
                  }
               }
            },
            {
               60, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.Para), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 41)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 42)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 43)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 44)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 45)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 46)
                  },
                  {
                     selectorString(nonTerminalTokens.Valores), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 40)
                  },
                  {
                     selectorString(nonTerminalTokens.Para), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 74)
                  }
               }
            },
            {
               61, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals
                           .INCREMENTO)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals
                           .INCREMENTO)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals
                           .INCREMENTO)
                     })
                  }
               }
            },
            {
               62, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals
                           .DECREMENTO)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals
                           .DECREMENTO)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals
                           .DECREMENTO)
                     })
                  }
               }
            },
            {
               63, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals
                           .CADENA),
                        selectorString(nonTerminalTokens.Recursividad)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalTokens.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals
                           .CADENA),
                        selectorString(nonTerminalTokens.Recursividad)
                     })
                  }
               }
            },
            {
               64, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 76)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 41)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 42)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 43)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 44)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 45)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 46)
                  },
                  {
                     selectorString(nonTerminalTokens.Valores), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 77)
                  },
                  {
                     selectorString(nonTerminalTokens.PR), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 75)
                  }
               }
            },
            {
               65, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER),
                        selectorString(nonTerminalTokens.Recursividad)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalTokens.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER),
                        selectorString(nonTerminalTokens.Recursividad)
                     })
                  }
               }
            },
            {
               66, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(
                        selectorString(nonTerminalTokens.Valores), new[]
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),
                           selectorString(nonTerminalTokens.Recursividad)
                        })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(
                        selectorString(nonTerminalTokens.Valores), new[]
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),
                           selectorString(nonTerminalTokens.Recursividad)
                        })
                  }
               }
            },
            {
               67, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(
                        selectorString(nonTerminalTokens.Valores), new[]
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL),
                           selectorString(nonTerminalTokens.Recursividad)
                        })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(
                        selectorString(nonTerminalTokens.Valores), new[]
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL),
                           selectorString(nonTerminalTokens.Recursividad)
                        })
                  }
               }
            },
            {
               68, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(
                        selectorString(nonTerminalTokens.Valores), new[]
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL),
                           selectorString(nonTerminalTokens.Recursividad)
                        })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(
                        selectorString(nonTerminalTokens.Valores), new[]
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL),
                           selectorString(nonTerminalTokens.Recursividad)
                        })
                  }
               }
            },
            {
               69, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 78)
                  }
               }
            },
            {
               70, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.PR), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        selectorString(nonTerminalTokens.Para),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                        (nonTerminalTokens.PR), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        selectorString(nonTerminalTokens.Para),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     })
                  }
               }
            },
            {
               71, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 79)
                  }
               }
            },
            {
               72, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.RecursividadM), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA),
                        selectorString(nonTerminalTokens.Para)
                     })
                  }
               }
            },
            {
               73, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     new ReducedAction(selectorString(nonTerminalTokens.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                        selectorString(nonTerminalTokens.OperacionIdentificicador),
                        selectorString(nonTerminalTokens.Recursividad)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA),
                     new ReducedAction(selectorString(nonTerminalTokens.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                        selectorString(nonTerminalTokens.OperacionIdentificicador),
                        selectorString(nonTerminalTokens.Recursividad)
                     })
                  }
               }
            },
            {
               74, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 80)
                  }
               }
            },
            {
               75, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     new ReducedAction(selectorString(nonTerminalTokens.Recursividad), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                        selectorString(nonTerminalTokens.PR)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA),
                     new ReducedAction(selectorString(nonTerminalTokens.Recursividad), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                        selectorString(nonTerminalTokens.PR)
                     })
                  }
               }
            },
            {
               76, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 11)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 12)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 13)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 14)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 15)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 16)
                  },
                  {
                     selectorString(nonTerminalTokens.Valores), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 81)
                  }
               }
            },
            {
               77, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.PR), new[]
                     {
                        selectorString(nonTerminalTokens.Valores)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalTokens.PR), new[]
                     {
                        selectorString(nonTerminalTokens.Valores)
                     })
                  }
               }
            },
            {
               78, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 22)
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.Recursividad), new[]
                     {
                        string.Empty
                     })
                  },
                  {
                     selectorString(nonTerminalTokens.Recursividad), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 82)
                  }
               }
            },
            {
               79, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.Recursividad), new[]
                     {
                        string.Empty
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 33)
                  },

                  {
                     selectorString(nonTerminalTokens.Recursividad), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 83)
                  }
               }
            },
            {
               80, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        selectorString(nonTerminalTokens.Para),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        selectorString(nonTerminalTokens.Para),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalTokens.OperacionIdentificicador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        selectorString(nonTerminalTokens.Para),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     })
                  }
               }
            },
            {
               81, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 84)
                  }
               }
            },
            {
               82, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.PR), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        selectorString(nonTerminalTokens.Valores),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                        selectorString(nonTerminalTokens.Recursividad)
                     })
                  }
               }
            },
            {
               83, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.PR), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        selectorString(nonTerminalTokens.Valores),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                        selectorString(nonTerminalTokens.Recursividad)
                     })
                  }
               }
            },
            {
               84, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.Recursividad), new[]
                     {
                        string.Empty
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 64)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalTokens.Recursividad), new[]
                     {
                        string.Empty
                     })
                  },
                  {
                     selectorString(nonTerminalTokens.Recursividad), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 85)
                  }
               }
            },
            {
               85, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalTokens.PR), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        selectorString(nonTerminalTokens.Valores),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                        selectorString(nonTerminalTokens.Recursividad)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalTokens.PR), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        selectorString(nonTerminalTokens.Valores),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                        selectorString(nonTerminalTokens.Recursividad)
                     })
                  }
               }
            }
         };


   }
}
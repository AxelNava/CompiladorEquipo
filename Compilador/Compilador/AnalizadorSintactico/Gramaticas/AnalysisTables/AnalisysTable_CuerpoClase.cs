using System;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;

namespace Compilador.AnalizadorSintactico.Gramaticas.AnalysisTables
{
   public class AnalisysTable_CuerpoClase
   {
      public enum TokensNonTerminal
      {
         Declaracion_Metodo,
         ComplementoIdenti,
         Parametros,
         Parametro,
         CuerpoMetodo,
         ReturnNonTErminal,
         RecuercionMetodo,
         Recursion,
         CuerpoInstrucciones,
         Valores
      }

      private static string[] _tokensNonTerminal =
      {
         "DeclaracionMetodo",
         "ComplementoIdentificador",
         "Parametros",
         "Parametro",
         "CuerpoMetodo",
         "<Return>",
         "RecursionMeotod",
         "Recurcion",
         "cuerpoInstrucciones",
         "valores"
      };

      public static string SelectorString(TokensNonTerminal nonTerminal)
      {
         return _tokensNonTerminal.GetValue((int)Convert.ChangeType(nonTerminal, nonTerminal.GetTypeCode())).ToString();
      }

      public static Dictionary<int, Dictionary<string, AbstractActionFunction>> GlobalDictionary_CuerpoValores =
         new Dictionary<int, Dictionary<string, AbstractActionFunction>>()
         {
            {
               0, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 2)
                  },
                  {
                     SelectorString(TokensNonTerminal.Declaracion_Metodo), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 1)
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
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 3)
                  }
               }
            },
            {
               3, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 5)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 6)
                  },
                  {
                     SelectorString(TokensNonTerminal.ComplementoIdenti),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 4)
                  }
               }
            },
            {
               4, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 2)
                  },
                  {
                     "FinCadena", new ReducedAction(SelectorString(TokensNonTerminal.Recursion), new[] { string.Empty })
                  },
                  {
                     SelectorString(TokensNonTerminal.Declaracion_Metodo), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 8)
                  },
                  {
                     SelectorString(TokensNonTerminal.Recursion), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 7)
                  }
               }
            },
            {
               5, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 11)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(SelectorString
                        (TokensNonTerminal.Parametros), new[] { string.Empty })
                  },
                  {
                     SelectorString(TokensNonTerminal.Parametros), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 9)
                  },
                  {
                     SelectorString(TokensNonTerminal.Parametro), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 10)
                  }
               }
            },
            {
               6, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO), new ReducedAction(SelectorString(TokensNonTerminal
                        .ComplementoIdenti), new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA) })
                  },
                  {
                     "FinCadena", new ReducedAction(SelectorString(TokensNonTerminal
                        .ComplementoIdenti), new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA) })
                  }
               }
            },
            {
               7, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(SelectorString(TokensNonTerminal.Declaracion_Metodo), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                        SelectorString(TokensNonTerminal.ComplementoIdenti),
                        SelectorString(TokensNonTerminal.Recursion)
                     })
                  }
               }
            },
            {
               8, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(SelectorString(TokensNonTerminal.Recursion), new[]
                     {
                        SelectorString(TokensNonTerminal.Declaracion_Metodo)
                     })
                  }
               }
            },
            {
               9, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 12)
                  }
               }
            },
            {
               10, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(SelectorString
                        (TokensNonTerminal.Parametros), new[] { SelectorString(TokensNonTerminal.Parametro) })
                  }
               }
            },
            {
               11, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 13)
                  }
               }
            },
            {
               12, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 14)
                  }
               }
            },
            {
               13, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(SelectorString
                        (TokensNonTerminal.RecuercionMetodo), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 16)
                  },
                  {
                     SelectorString(TokensNonTerminal.RecuercionMetodo), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 15)
                  }
               }
            },
            {
               14, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA), new ReducedAction(SelectorString(TokensNonTerminal
                        .CuerpoMetodo), new[] { string.Empty })
                  },
                  {
                     SelectorString(TokensNonTerminal.CuerpoInstrucciones),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 18)
                  },
                  {
                     SelectorString(TokensNonTerminal.CuerpoMetodo), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 17)
                  }
               }
            },
            {
               15, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(SelectorString
                        (TokensNonTerminal.Parametro), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                        SelectorString(TokensNonTerminal.RecuercionMetodo)
                     })
                  }
               }
            },
            {
               16, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 11)
                  },
                  {
                     SelectorString(TokensNonTerminal.Parametro), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 19)
                  }
               }
            },
            {
               17, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 20)
                  }
               }
            },
            {
               18, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA), new ReducedAction(SelectorString
                        (TokensNonTerminal.ReturnNonTErminal), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Retuuuurrnnn), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 22)
                  },
                  {
                     SelectorString(TokensNonTerminal.ReturnNonTErminal), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 21)
                  }
               }
            },
            {
               19, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(SelectorString
                        (TokensNonTerminal.RecuercionMetodo), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA),
                        SelectorString(TokensNonTerminal.Parametro)
                     })
                  }
               }
            },
            {
               20, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO), new ReducedAction(SelectorString
                        (TokensNonTerminal.ComplementoIdenti), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        SelectorString(TokensNonTerminal.Parametros),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE),
                        SelectorString(TokensNonTerminal.CuerpoMetodo),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA)
                     })
                  },
                  {
                     "FinCadena", new ReducedAction(SelectorString
                        (TokensNonTerminal.ComplementoIdenti), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        SelectorString(TokensNonTerminal.Parametros),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE),
                        SelectorString(TokensNonTerminal.CuerpoMetodo),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA)
                     })
                  }
               }
            },
            {
               21, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA), new ReducedAction(SelectorString(TokensNonTerminal
                        .CuerpoMetodo), new[]
                     {
                        SelectorString(TokensNonTerminal.CuerpoInstrucciones),
                        SelectorString(TokensNonTerminal.ReturnNonTErminal)
                     })
                  }
               }
            },
            {
               22, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     SelectorString(TokensNonTerminal.Valores), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 23)
                  }
               }
            },
            {
               23, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 24)
                  }
               }
            },
            {
               24, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA), new ReducedAction(SelectorString
                        (TokensNonTerminal.ReturnNonTErminal), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Retuuuurrnnn),
                        SelectorString(TokensNonTerminal.Valores),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)
                     })
                  }
               }
            }
         };
   }
}
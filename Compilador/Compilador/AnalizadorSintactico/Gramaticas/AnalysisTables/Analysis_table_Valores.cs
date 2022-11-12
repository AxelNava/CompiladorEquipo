using System.Collections.Generic;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using System;

namespace Compilador.AnalizadorSintactico.Gramaticas.AnalysisTables
{
   public class Analysis_table_Valores
   {
      public enum nonTerminalsForThisGrammar
      {
         VsB,
         Valores,
         InstruccionesIDentificador,
         RM,
         Para,
         R
      }

      private static readonly string[] nonTerminalsTokenString =
      {
         "VsB",
         "Valores",
         "InstruccionesIdentificador",
         "RM",
         "Params",
         "R"
      };

      public static Dictionary<int, Dictionary<string, AbstractActionFunction>> globalDictionaryValores = new Dictionary<int, Dictionary<string, AbstractActionFunction>>()
      {
         {
               0, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 2)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 3)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 4)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO), new AccionFuncion_TablaAnalisis(
                        AbstractActionFunction.ActionEnum.DESPLAZAMIENTO
                        , 5)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 6)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 7)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.Valores), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum
                        .DESPLAZAMIENTO, 1)
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
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.InstruccionesIDentificador), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 9)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 10)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 11)
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 8)
                  }
               }
            },
            {
               3, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 13)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 12)
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  }
               }
            },
            {
               4, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 13)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 14)
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  }
               }
            },
            {
               5, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 13)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 15)
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  }
               }
            },
            {
               6, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 13)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 16)
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  }
               }
            },
            {
               7, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString
                           (tokensNameGlobal.tokensGlobals.BOOL)
                     })
                  }
               }
            },
            {
               8, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 13)
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 17)
                  }
               }
            },
            {
               9, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 20)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 21)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 22)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO), new AccionFuncion_TablaAnalisis(
                        AbstractActionFunction.ActionEnum.DESPLAZAMIENTO
                        , 23)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 24)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 25)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Para), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.Valores), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 19)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.Para), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 18)
                  }
               }
            },
            {
               10, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                           (nonTerminalsForThisGrammar.InstruccionesIDentificador),
                        new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO) })
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString
                           (nonTerminalsForThisGrammar.InstruccionesIDentificador),
                        new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO) })
                  }
               }
            },
            {
               11, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                           (nonTerminalsForThisGrammar.InstruccionesIDentificador),
                        new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO) })
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString
                           (nonTerminalsForThisGrammar.InstruccionesIDentificador),
                        new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO) })
                  }
               }
            },
            {
               12, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               13, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 27)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 28)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 29)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO), new AccionFuncion_TablaAnalisis(
                        AbstractActionFunction.ActionEnum.DESPLAZAMIENTO
                        , 31)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 30)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.VsB), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 26)
                  }
               }
            },
            {
               14, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               15, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               16, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               17, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                        selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               18, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 32)
                  }
               }
            },
            {
               19, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.RM), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 34)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.RM), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 33)
                  }
               }
            },
            {
               20, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.InstruccionesIDentificador), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 36)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.InstruccionesIDentificador), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 37)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 38)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.InstruccionesIDentificador), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 35)
                  }
               }
            },
            {
               21, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Comparador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 40)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 39)
                  }
               }
            },
            {
               22, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Comparador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 40)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 41)
                  }
               }
            },
            {
               23, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Comparador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 40)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 42)
                  }
               }
            },
            {
               24, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Comparador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 40)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 43)
                  }
               }
            },
            {
               25, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL) })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL) })
                  }
               }
            },
            {
               26, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.R), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                        selectorString(nonTerminalsForThisGrammar.VsB)
                     })
                  }
               }
            },
            {
               27, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.InstruccionesIDentificador), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 9)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 10)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 11)
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.InstruccionesIDentificador), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 44)
                  }
               }
            },
            {
               28, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 13)
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 45)
                  }
               }
            },
            {
               29, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 13)
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 46)
                  }
               }
            },
            {
               30, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 13)
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 47)
                  }
               }
            },
            {
               31, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 13)
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 48)
                  }
               }
            },
            {
               32, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.InstruccionesIDentificador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals
                           .PARENTESISABRE),
                        selectorString(nonTerminalsForThisGrammar.Para),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)
                     })
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.InstruccionesIDentificador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals
                           .PARENTESISABRE),
                        selectorString(nonTerminalsForThisGrammar.Para),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)
                     })
                  }
               }
            },
            {
               33, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Para), new[]
                     {
                        selectorString(nonTerminalsForThisGrammar.Valores), selectorString(nonTerminalsForThisGrammar.RM)
                     })
                  }
               }
            },
            {
               34, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 20)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 21)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 22)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO), new AccionFuncion_TablaAnalisis(
                        AbstractActionFunction.ActionEnum.DESPLAZAMIENTO
                        , 23)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 24)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 25)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Para), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.Valores), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 19)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.Para), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 49)
                  }
               }
            },
            {
               35, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 40)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 50)
                  }
               }
            },
            {
               36, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 20)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 21)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 22)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO), new AccionFuncion_TablaAnalisis(
                        AbstractActionFunction.ActionEnum.DESPLAZAMIENTO
                        , 23)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 24)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 25)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Para), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.Valores), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 19)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.Para), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 51)
                  }
               }
            },
            {
               37, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.InstruccionesIDentificador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals
                           .INCREMENTO)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.InstruccionesIDentificador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals
                           .INCREMENTO)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.InstruccionesIDentificador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals
                           .INCREMENTO)
                     })
                  }
               }
            },
            {
               38, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.InstruccionesIDentificador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals
                           .DECREMENTO)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.InstruccionesIDentificador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals
                           .DECREMENTO)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.InstruccionesIDentificador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals
                           .DECREMENTO)
                     })
                  }
               }
            },
            {
               39, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               40, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 53)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 54)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 55)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO), new AccionFuncion_TablaAnalisis(
                        AbstractActionFunction.ActionEnum.DESPLAZAMIENTO
                        , 57)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 56)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.VsB), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 52)
                  }
               }
            },
            {
               41, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               42, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               43, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               44, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 13)
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 58)
                  }
               }
            },
            {
               45, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.VsB), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA)
                     })
                  }
               }
            },
            {
               46, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.VsB), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER)
                     })
                  }
               }
            },
            {
               47, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.VsB), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL)
                     })
                  }
               }
            },
            {
               48, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.VsB), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               49, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(
                        selectorString(nonTerminalsForThisGrammar.RM), new[]
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA),
                           selectorString(nonTerminalsForThisGrammar.Para)
                        })
                  }
               }
            },
            {
               50, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                        selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador), selectorString(nonTerminalsForThisGrammar.R)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                        selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador), selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               51, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 59)
                  }
               }
            },
            {
               52, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.R), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                        selectorString(nonTerminalsForThisGrammar.VsB)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.R), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                        selectorString(nonTerminalsForThisGrammar.VsB)
                     })
                  }
               }
            },
            {
               53, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.InstruccionesIDentificador), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 36)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.InstruccionesIDentificador), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 37)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 38)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.InstruccionesIDentificador), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.GOTO, 60)
                  }
               }
            },
            {
               54, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 40)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 61)
                  }
               }
            },
            {
               55, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 40)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 62)
                  }
               }
            },
            {
               56, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 40)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 63)
                  }
               }
            },
            {
               57, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 40)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.R), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 64)
                  }
               }
            },
            {
               58, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.VsB), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                        selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador), selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               59, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),new ReducedAction(selectorString
                     (nonTerminalsForThisGrammar.InstruccionesIDentificador), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        selectorString(nonTerminalsForThisGrammar.Para),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.InstruccionesIDentificador), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        selectorString(nonTerminalsForThisGrammar.Para),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA),new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.InstruccionesIDentificador), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        selectorString(nonTerminalsForThisGrammar.Para),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)
                     })
                  }
               }
            },
            {
               60, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new AccionFuncion_TablaAnalisis
                     (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 40)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                     (nonTerminalsForThisGrammar.R), new []{string.Empty})
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.R), new []{string.Empty})
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 65)
                  }
               }
            },
            {
               61, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                     (nonTerminalsForThisGrammar.VsB), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.VsB), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               62, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.VsB), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.VsB), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               63, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.VsB), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.VsB), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               64, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.VsB), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.VsB), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               65, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.VsB), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                        selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.VsB), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                        selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            }
      };

      public static string selectorString(nonTerminalsForThisGrammar nonTerminal)
      {
         return nonTerminalsTokenString.GetValue((int)Convert.ChangeType(nonTerminal, nonTerminal.GetTypeCode())).ToString();
      }
   }
}
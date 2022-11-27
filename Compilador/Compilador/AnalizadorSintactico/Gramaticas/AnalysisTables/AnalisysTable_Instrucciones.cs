using System.Collections.Generic;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using System;
using System.Reflection.Emit;

namespace Compilador.AnalizadorSintactico.Gramaticas.AnalysisTables
{
   public class AnalisysTable_Instrucciones
   {
      private enum nonTerminalsInstrucciones
      {
         Recursion,
         ComplementoDeclaracion,
         ComplementoIdentificador,
         Instruccion,
         Valores,
         ParametroMetodo
      }

      private static readonly string[] nonTerminalsString =
      {
         "Recursion",
         "ComplementoDeclaracion",
         "ComplementoIdenti",
         "Instruccion",
         "Valores",
         "ParametrosMetodo"
      };

      private static string selectorString(nonTerminalsInstrucciones nonTerminal)
      {
         return nonTerminalsString.GetValue((int)Convert.ChangeType(nonTerminal, nonTerminal.GetTypeCode())).ToString();
      }

      public static Dictionary<int, Dictionary<string, AbstractActionFunction>> GlobalDictionaryInstrucciones =
         new Dictionary<int, Dictionary<string, AbstractActionFunction>>()
         {
            {
               0, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 2)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 3)
                  },
                  {
                     selectorString(nonTerminalsInstrucciones.Instruccion), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 1)
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
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 4)
                  }
               }
            },
            {
               3, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Asignacion), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 9)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 6)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 7)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 8)
                  },
                  {
                     selectorString(nonTerminalsInstrucciones.ComplementoIdentificador), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.GOTO, 5)
                  }
               }
            },
            {
               4, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Asignacion), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 11)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 12)
                  },
                  {
                     selectorString(nonTerminalsInstrucciones.ComplementoDeclaracion), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.GOTO, 10)
                  }
               }
            },
            {
               5, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 2)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 3)
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsInstrucciones.Recursion), new[] { string.Empty })
                  },
                  {
                     selectorString(nonTerminalsInstrucciones.Instruccion),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 14)
                  },
                  {
                     selectorString(nonTerminalsInstrucciones.Recursion), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 13)
                  }
               }
            },
            {
               6, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 15)
                  }
               }
            },
            {
               7, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 16)
                  }
               }
            },
            {
               //Modificar este estado, agregar la gramatica para "Parametros de función"
               8, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "ParametrosMetodo",
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 15)
                  }
               }
            },
            {
               9, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     selectorString(nonTerminalsInstrucciones.Valores), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO,18)
                  }
               }
            },
            {
               10, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 2)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 3)
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsInstrucciones.Recursion), new []{string.Empty})
                  },
                  {
                     selectorString(nonTerminalsInstrucciones.Instruccion),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 14)
                  },
                  {
                     selectorString(nonTerminalsInstrucciones.Recursion), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 19)
                  }
               }
            },
            {
               11, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     selectorString(nonTerminalsInstrucciones.Valores), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO,20)
                  }
               }
            },
            {
               12, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO), new ReducedAction(selectorString
                     (nonTerminalsInstrucciones.ComplementoDeclaracion), new []{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)})
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new ReducedAction(selectorString
                        (nonTerminalsInstrucciones.ComplementoDeclaracion), new []{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)})
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString
                        (nonTerminalsInstrucciones.ComplementoDeclaracion), new []{tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)})
                  }
               }
            },
            {
               13, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsInstrucciones.Instruccion), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                        selectorString(nonTerminalsInstrucciones.ComplementoIdentificador),
                        selectorString(nonTerminalsInstrucciones.Recursion)
                     })
                  }
               }
            },
            {
               14, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsInstrucciones.Recursion), new []
                     {
                        selectorString(nonTerminalsInstrucciones.Instruccion)
                     })
                  } 
               }
            },
            {
               15, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO), new ReducedAction(selectorString
                     (nonTerminalsInstrucciones.ComplementoIdentificador), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new ReducedAction(selectorString
                        (nonTerminalsInstrucciones.ComplementoIdentificador), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)
                     })
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString
                        (nonTerminalsInstrucciones.ComplementoIdentificador), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)
                     })
                  }
               }
            },
            {
               16, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO), new ReducedAction(selectorString
                        (nonTerminalsInstrucciones.ComplementoIdentificador), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new ReducedAction(selectorString
                        (nonTerminalsInstrucciones.ComplementoIdentificador), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)
                     })
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString
                        (nonTerminalsInstrucciones.ComplementoIdentificador), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)
                     })
                  }
               }
            },
            {
               17, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new AccionFuncion_TablaAnalisis
                     (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 21)
                  }
               }
            },
            {
               18, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA), new AccionFuncion_TablaAnalisis
                     (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 22)
                  }
               }
            },
            {
               19, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsInstrucciones.Instruccion),new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                        selectorString(nonTerminalsInstrucciones.ComplementoDeclaracion),
                        selectorString(nonTerminalsInstrucciones.Recursion)
                     })
                  }
               }
            },
            {
               20, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA), new AccionFuncion_TablaAnalisis
                     (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 23)
                  }
               }
            },
            {
               21, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 24)
                  }
               }
            },
            {
               22, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO), new ReducedAction(selectorString
                        (nonTerminalsInstrucciones.ComplementoIdentificador), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Asignacion),
                        selectorString(nonTerminalsInstrucciones.Valores),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new ReducedAction(selectorString
                        (nonTerminalsInstrucciones.ComplementoIdentificador), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Asignacion),
                        selectorString(nonTerminalsInstrucciones.Valores),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)
                     })
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString
                        (nonTerminalsInstrucciones.ComplementoIdentificador), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Asignacion),
                        selectorString(nonTerminalsInstrucciones.Valores),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)
                     })
                  }
               }
            },
            {
               23, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO), new ReducedAction(selectorString
                        (nonTerminalsInstrucciones.ComplementoDeclaracion), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Asignacion),
                        selectorString(nonTerminalsInstrucciones.Valores),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new ReducedAction(selectorString
                        (nonTerminalsInstrucciones.ComplementoDeclaracion), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Asignacion),
                        selectorString(nonTerminalsInstrucciones.Valores),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)
                     })
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString
                        (nonTerminalsInstrucciones.ComplementoDeclaracion), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Asignacion),
                        selectorString(nonTerminalsInstrucciones.Valores),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)
                     })
                  }
               }
            },
            {
               //Modificar este estado, agregar la gramatica para "Parametros de función"
               24, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO), new ReducedAction(selectorString
                        (nonTerminalsInstrucciones.ComplementoIdentificador), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        selectorString(nonTerminalsInstrucciones.ParametroMetodo),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new ReducedAction(selectorString
                        (nonTerminalsInstrucciones.ComplementoIdentificador), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        selectorString(nonTerminalsInstrucciones.ParametroMetodo),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)
                     })
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString
                        (nonTerminalsInstrucciones.ComplementoIdentificador), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        selectorString(nonTerminalsInstrucciones.ParametroMetodo),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)
                     })
                  }
               }
            }
         };
   }
}
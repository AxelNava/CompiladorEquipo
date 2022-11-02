using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using System;
using System.Collections.Generic;

namespace Compilador.Gramaticas
{
   public class Gramatica_CuerpoInstrucciones : AbstractAnalisisTable
   {
      enum NotTerminalsForThisGrammar
      {
         CUERPOINSTRUCCIONES,
         INSTRUCCION,
         LLAMADAMETODO,
         ESTRUCTURACONTROL,
         RECURSIVIDAD
      }

      private static readonly string[] notTerminalSymbolsString =
      {
         "CuerpoInstrucciones",
         "Instruccion",
         "LLamadaMetodo",
         "EstructuraControl",
         "Recursividad"
      };

      string selectorString(NotTerminalsForThisGrammar notTerminal)
      {
         return notTerminalSymbolsString.GetValue((int)Convert.ChangeType(notTerminal, notTerminal.GetTypeCode()))
            .ToString();
      }
      public Gramatica_CuerpoInstrucciones()
      {
         tablaAnalisis = new Dictionary<int, Dictionary<string, AbstractActionFunction>>()
         {
            {
               0, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     selectorString(NotTerminalsForThisGrammar.CUERPOINSTRUCCIONES),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 1)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.INSTRUCCION),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 2)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.LLAMADAMETODO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 3)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.ESTRUCTURACONTROL),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 4)
                  }
               }
            },
            {
               1, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "Lambda",
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 5)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.CUERPOINSTRUCCIONES),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 6)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.INSTRUCCION),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 2)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.LLAMADAMETODO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 3)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.ESTRUCTURACONTROL),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 4)
                  }
               }
            },
            {
               2, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "Lambda",
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 5)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.CUERPOINSTRUCCIONES),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 6)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.INSTRUCCION),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 2)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.LLAMADAMETODO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 3)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.ESTRUCTURACONTROL),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 4)
                  }
               }
            },
            {
               3, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "Lambda",
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 5)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.CUERPOINSTRUCCIONES),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 6)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.INSTRUCCION),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 2)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.LLAMADAMETODO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 3)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.ESTRUCTURACONTROL),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 4)
                  }
               }
            },
            {
               4, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "Lambda",
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 5)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.CUERPOINSTRUCCIONES),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 6)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.INSTRUCCION),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 2)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.LLAMADAMETODO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 3)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.ESTRUCTURACONTROL),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 4)
                  }
               }
            },
            {
               5, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(NotTerminalsForThisGrammar.RECURSIVIDAD), new[] { "Lambda" })
                  }
               }
            },
            {
               6, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena",
                     new ReducedAction(selectorString(NotTerminalsForThisGrammar.RECURSIVIDAD),
                        new[] { selectorString(NotTerminalsForThisGrammar.CUERPOINSTRUCCIONES) })
                  }
               }
            },
            {
               7, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(NotTerminalsForThisGrammar.CUERPOINSTRUCCIONES), new[]
                     {
                        selectorString
                           (NotTerminalsForThisGrammar.ESTRUCTURACONTROL),
                        selectorString(NotTerminalsForThisGrammar.RECURSIVIDAD)
                     })
                  }
               }
            },
            {
               8, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(NotTerminalsForThisGrammar.CUERPOINSTRUCCIONES), new[]
                     {
                        selectorString
                           (NotTerminalsForThisGrammar.LLAMADAMETODO),
                        selectorString(NotTerminalsForThisGrammar.RECURSIVIDAD)
                     })
                  }
               }
            },
            {
               9, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(NotTerminalsForThisGrammar.CUERPOINSTRUCCIONES), new[]
                     {
                        selectorString
                           (NotTerminalsForThisGrammar.INSTRUCCION),
                        selectorString(NotTerminalsForThisGrammar.RECURSIVIDAD)
                     })
                  }
               }
            }
         };
      }
      
   }
}
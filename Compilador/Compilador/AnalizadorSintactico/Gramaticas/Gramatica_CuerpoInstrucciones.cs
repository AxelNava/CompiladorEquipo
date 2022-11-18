using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using System;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico.Gramaticas;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;

namespace Compilador.Gramaticas
{
   public class Gramatica_CuerpoInstrucciones : AbstractAnalisisTable
   {
      enum NotTerminalsForThisGrammar
      {
         CUERPOINSTRUCCIONES,
         INSTRUCCION,
         ESTRUCTURACONTROL,
         RECURSIVIDAD
      }

      private static readonly string[] notTerminalSymbolsString =
      {
         "cuerpoInstrucciones",
         "Instruccion",
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
                     selectorString(NotTerminalsForThisGrammar.INSTRUCCION), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum
                        .GOTO, 2)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.ESTRUCTURACONTROL), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum
                        .GOTO, 3)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.CUERPOINSTRUCCIONES), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum
                        .GOTO, 1)
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
                     selectorString(NotTerminalsForThisGrammar.INSTRUCCION), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum
                        .GOTO, 2)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.ESTRUCTURACONTROL), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum
                        .GOTO, 3)
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(NotTerminalsForThisGrammar.RECURSIVIDAD), new[] { string.Empty })
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.CUERPOINSTRUCCIONES), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum
                        .GOTO, 5)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.RECURSIVIDAD), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum
                        .GOTO, 4)
                  }
               }
            },
            {
               3, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     selectorString(NotTerminalsForThisGrammar.INSTRUCCION), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum
                        .GOTO, 2)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.ESTRUCTURACONTROL), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum
                        .GOTO, 3)
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(NotTerminalsForThisGrammar.RECURSIVIDAD), new[] { string.Empty })
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.CUERPOINSTRUCCIONES), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum
                        .GOTO, 5)
                  },
                  {
                     selectorString(NotTerminalsForThisGrammar.RECURSIVIDAD), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum
                        .GOTO, 6)
                  }
               }
            },
            {
               4, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(NotTerminalsForThisGrammar.CUERPOINSTRUCCIONES), new[]
                     {
                        selectorString(NotTerminalsForThisGrammar.INSTRUCCION),
                        selectorString(NotTerminalsForThisGrammar.RECURSIVIDAD)
                     })
                  }
               }
            },
            {
               5, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(NotTerminalsForThisGrammar.RECURSIVIDAD), new[]
                     {
                        selectorString(NotTerminalsForThisGrammar.CUERPOINSTRUCCIONES)
                     })
                  }
               }
            },
            {
               6, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(NotTerminalsForThisGrammar.CUERPOINSTRUCCIONES), new[]
                     {
                        selectorString(NotTerminalsForThisGrammar.ESTRUCTURACONTROL),
                        selectorString(NotTerminalsForThisGrammar.RECURSIVIDAD)
                     })
                  }
               }
            }
         };
         PilaComprobacion = new Stack<Tuple<int, string>>();
         PilaComprobacion.Push(new Tuple<int, string>(0, "0"));
      }

      public string Ejecutar_Analisis()
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

            if (analisisFinished) return "cuerpoInstrucciones";
         }

         return string.Empty;
      }

      private bool CheckTokenIn_Handler()
      {
         int referenceState = PilaComprobacion.Peek().Item1;
         if ((referenceState == 0 || referenceState == 2 || referenceState == 3) && PilaTokens.GlobalTokens.Peek() != selectorString
                (NotTerminalsForThisGrammar.CUERPOINSTRUCCIONES) &&
             PilaTokens.GlobalTokens.Peek() != selectorString(NotTerminalsForThisGrammar.RECURSIVIDAD))
         {
            string tokenAux = new GramaticaInstruccion().Ejecutar_Analisis();
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
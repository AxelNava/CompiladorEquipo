using System;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;

namespace Compilador.Gramaticas
{
   public class Gramatica_While : AbstractAnalisisTable
   {
      private enum nonTerminalsTokens
      {
         Condicion,
         CuerpoInstruccion,
         While,
         BodyWhile,
         F
      }

      private static readonly string[] nonTerminalsTokenString =
      {
         "condicion",
         "CuerpoInstrucciones",
         "<while>",
         "<BodyWhile>",
         "<F>"
      };

      private string selectorString(nonTerminalsTokens notTerminal)
      {
         return nonTerminalsTokenString.GetValue((int)Convert.ChangeType(notTerminal, notTerminal.GetTypeCode())).ToString();
      }

      public Gramatica_While()
      {
         TablaAnalisis = new Dictionary<int, Dictionary<string, AbstractActionFunction>>()
         {
            {
               0, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.WHILE), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 2)
                  },
                  {
                     selectorString(nonTerminalsTokens.While), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 1)
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
                     selectorString(nonTerminalsTokens.Condicion), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 4)
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
                  },
                  {
                     selectorString(nonTerminalsTokens.BodyWhile), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 9)
                  }
               }
            },
            {
               6, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     selectorString(nonTerminalsTokens.CuerpoInstruccion), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 7)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA), new ReducedAction(selectorString
                        (nonTerminalsTokens.CuerpoInstruccion), new[] { string.Empty })
                  }
               }
            },
            {
               7, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 8)
                  }
               }
            },
            {
               8, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 12)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 11)
                  },
                  {
                     selectorString(nonTerminalsTokens.F), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 10)
                  }
               }
            },
            {
               9, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena",
                     new ReducedAction(selectorString(nonTerminalsTokens.While), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.WHILE),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        selectorString(nonTerminalsTokens.Condicion),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                        selectorString(nonTerminalsTokens.BodyWhile)
                     })
                  }
               }
            },
            {
               10, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsTokens.BodyWhile), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE),
                        selectorString(nonTerminalsTokens.CuerpoInstruccion),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA),
                        selectorString(nonTerminalsTokens.F)
                     })
                  }
               }
            },
            {
               11, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsTokens.F), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)
                     })
                  }
               }
            },
            {
               12, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsTokens.F), new[]
                     {
                        "Lambda"
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
         AnalisisFinished = false;
         if (!TablaAnalisis[0].ContainsKey(PilaTokens.GlobalTokens.Peek()))
            return string.Empty;
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
                     AddError();
                     return string.Empty;
                  }
               }
            }

            if (AnalisisFinished) return "<While>";
         }

         return string.Empty;
      }

      private bool CheckTokenIn_Handler()
      {
         int referenceState = PilaComprobacion.Peek().Item1;
         if (referenceState == 3)
         {
            string tokenAux = new GramaticaCondicion().EjecutarAnalisis();
            if (!string.IsNullOrEmpty(tokenAux))
               PilaTokens.GlobalTokens.Push(tokenAux);
         }

         if (TablaAnalisis[referenceState].ContainsKey(PilaTokens.GlobalTokens.Peek()))
         {
            // PilaTokens.numLineToken.RemoveAt(0);
            AbstractActionFunction.ActionEnum actionEnum;
            actionEnum = TablaAnalisis[referenceState][PilaTokens.GlobalTokens.Peek()].Action;
            HandleActions(actionEnum);
            return true;
         }

         return false;
      }
   }
}
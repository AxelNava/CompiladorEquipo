using System;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;

namespace Compilador.Gramaticas
{
   public class Gramatica_DoWhile : AbstractAnalisisTable
   {
      private enum nonTerminalsDoWhile
      {
         DW,
         CuerpoInstruccion,
         Condicion,
         FinDo
      }

      private static readonly string[] nonTerminalsTokenString =
      {
         "DW",
         "CuerpoInstrucciones",
         "condicion",
         "FinDo"
      };

      private string selectorString(nonTerminalsDoWhile tokenEnum)
      {
         return nonTerminalsTokenString.GetValue((int)Convert.ChangeType(tokenEnum, tokenEnum.GetTypeCode())).ToString();
      }

      public Gramatica_DoWhile()
      {
         PilaComprobacion = new Stack<Tuple<int, string>>();
         PilaComprobacion.Push(new Tuple<int, string>(0, "0"));
         tablaAnalisis = new Dictionary<int, Dictionary<string, AbstractActionFunction>>()
         {
            {
               0, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DO), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 2)
                  },
                  {
                     selectorString(nonTerminalsDoWhile.DW), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 1)
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
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 3)
                  }
               }
            },
            {
               3, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     selectorString(nonTerminalsDoWhile.CuerpoInstruccion), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 4)
                  }
               }
            },
            {
               4, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 5)
                  }
               }
            },
            {
               5, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.WHILE), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 6)
                  },
                  {
                     selectorString(nonTerminalsDoWhile.FinDo), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 11)
                  }
               }
            },
            {
               6, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 7)
                  }
               }
            },
            {
               7, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     selectorString(nonTerminalsDoWhile.Condicion), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 8)
                  }
               }
            },
            {
               8, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 9)
                  }
               }
            },
            {
               9, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 10)
                  }
               }
            },
            {
               10, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsDoWhile.FinDo), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.WHILE),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        selectorString(nonTerminalsDoWhile.Condicion),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA)
                     })
                  }
               }
            },
            {
               11, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsDoWhile.DW), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DO),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE),
                        selectorString(nonTerminalsDoWhile.CuerpoInstruccion),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA),
                        selectorString(nonTerminalsDoWhile.FinDo)
                     })
                  }
               }
            }
         };
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

            if (analisisFinished) return "DoWhile";
         }

         return string.Empty;
      }

      private bool CheckTokenIn_Handler()
      {
         int referenceState = PilaComprobacion.Peek().Item1;
         if (referenceState == 7)
         {
            string tokenAux = new GramaticaCondicion().EjecutarAnalisis();
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
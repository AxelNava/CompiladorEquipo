using System;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;

namespace Compilador.Gramaticas
{
   public class Gramatica_IF : AbstractAnalisisTable
   {
      public enum notTerminalsForThis
      {
         IF,
         CONDICION,
         FINBODY,
         BODYIF,
         CUERPOINSTRUCCIONES,
         INSTRUCCION,
         FINBODYA,
         IFA,
         BODYIFA,
         FINELSE,
         BODYELSE
      }

      private static readonly string[] notTerminalSymbols =
      {
         "<if>",
         "condicion",
         "Finbody",
         "bodyIf",
         "cuerpoInstrucciones",
         "Instruccion",
         "finBodyA",
         "ifA",
         "bodyifA",
         "finElse",
         "bodyElse"
      };

      public Gramatica_IF()
      {
         tablaAnalisis = new Dictionary<int, Dictionary<string, AbstractActionFunction>>()
         {
            {
               0, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.IF),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 1)
                  },
                  {
                     selectorString(notTerminalsForThis.IF),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 36)
                  }
               }
            },
            {
               1, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 2)
                  }
               }
            },
            {
               2, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     selectorString(notTerminalsForThis.CONDICION),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 3)
                  }
               }
            },
            {
               3, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 4)
                  }
               }
            },
            {
               4, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 5)
                  },
                  {
                     selectorString(notTerminalsForThis.BODYIF),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 10)
                  },
                  { selectorString(notTerminalsForThis.INSTRUCCION), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 6) }
               }
            },
            {
               5, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     selectorString(notTerminalsForThis.CUERPOINSTRUCCIONES),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 7)
                  }
               }
            },
            {
               6, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ELSE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 24)
                  },
                  { "Lamda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 12) }
               }
            },
            {
               7, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 8)
                  }
               }
            },
            {
               8, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ELSE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 24)
                  },
                  { "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 33) },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 32)
                  },
                  { "Finbody", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 9) }
               }
            },
            {
               9, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena",
                     new ReducedAction(selectorString(notTerminalsForThis.BODYIF),
                        new[]
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE),
                           selectorString(notTerminalsForThis.CUERPOINSTRUCCIONES),
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA), "Finbody"
                        })
                  }
               }
            },
            {
               10, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena",
                     new ReducedAction(selectorString(notTerminalsForThis.IF),
                        new []
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.IF),
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                           selectorString(notTerminalsForThis.CONDICION),
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                           selectorString(notTerminalsForThis.BODYIF)
                        })
                  }
               }
            },
            {
               11, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(notTerminalsForThis.BODYIF), new
                        []
                        {
                           selectorString(notTerminalsForThis.INSTRUCCION), selectorString(notTerminalsForThis.FINBODY)
                        })
                  }
               }
            },
            {
               12, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.IF),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 13)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 26)
                  },
                  {
                     selectorString(notTerminalsForThis.INSTRUCCION), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 15)
                  },
                  {
                     selectorString(notTerminalsForThis.IFA), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.GOTO, 14)
                  }
               }
            },
            {
               13, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 16)
                  }
               }
            },
            {
               14, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(notTerminalsForThis.BODYELSE), new
                        [] { selectorString(notTerminalsForThis.IFA) })
                  }
               }
            },
            {
               15, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(notTerminalsForThis.BODYELSE), new
                        [] { selectorString(notTerminalsForThis.INSTRUCCION) })
                  }
               }
            },
            {
               16, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     selectorString(notTerminalsForThis.CONDICION),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 16)
                  }
               }
            },
            {
               17, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 18)
                  }
               }
            },
            {
               18, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 20)
                  },
                  {
                     selectorString(notTerminalsForThis.BODYIFA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 19)
                  }
               }
            },
            {
               19, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(notTerminalsForThis.IFA), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.IF),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        selectorString(notTerminalsForThis.CONDICION),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), selectorString(notTerminalsForThis.BODYIFA)
                     })
                  }
               }
            },
            {
               20, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     selectorString(notTerminalsForThis.CUERPOINSTRUCCIONES),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 21)
                  }
               }
            },
            {
               21, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 22)
                  }
               }
            },
            {
               22, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ELSE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 24)
                  },
                  {
                     selectorString(notTerminalsForThis.FINBODY),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 23)
                  }
               }
            },
            {
               23, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(notTerminalsForThis.BODYIFA), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE),
                        selectorString(notTerminalsForThis.CUERPOINSTRUCCIONES),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA),
                        selectorString(notTerminalsForThis.FINBODY)
                     })
                  }
               }
            },
            {
               24, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.IF),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 1)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 26)
                  },
                  {
                     selectorString(notTerminalsForThis.INSTRUCCION),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 15)
                  },
                  {
                     selectorString(notTerminalsForThis.BODYELSE), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 25)
                  }
               }
            },
            {
               25, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(notTerminalsForThis.FINBODY), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ELSE),
                        selectorString(notTerminalsForThis.BODYELSE)
                     })
                  }
               }
            },
            {
               26, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     selectorString(notTerminalsForThis.CUERPOINSTRUCCIONES),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 27)
                  }
               }
            },
            {
               27, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 28)
                  }
               }
            },
            {
               28, new Dictionary<string, AbstractActionFunction>()
               {
                  { "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 31) },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 30)
                  },
                  {
                     selectorString(notTerminalsForThis.FINELSE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 29)
                  }
               }
            },
            {
               29, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(notTerminalsForThis.BODYELSE), new []
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE),
                        selectorString(notTerminalsForThis.CUERPOINSTRUCCIONES),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA),
                        selectorString(notTerminalsForThis.FINELSE)
                     })
                  }
               }
            },
            {
               30, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena",
                     new ReducedAction(selectorString(notTerminalsForThis.FINELSE),
                        new [] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA) })
                  }
               }
            },
            {
               31, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena",
                     new ReducedAction(selectorString(notTerminalsForThis.FINELSE), new [] { "Lambda" })
                  }
               }
            },
            {
               32, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena",
                     new ReducedAction(selectorString(notTerminalsForThis.FINBODY),
                        new [] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA) })
                  }
               }
            },
            {
               33, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena",
                     new ReducedAction(selectorString(notTerminalsForThis.FINBODY), new [] { "Lambda" })
                  }
               }
            },
            {
               34, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(notTerminalsForThis.BODYIFA), new
                        []
                        {
                           selectorString(notTerminalsForThis.INSTRUCCION), selectorString(notTerminalsForThis.FINBODYA)
                        })
                  }
               }
            },
            {
               35, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(notTerminalsForThis.FINBODY), new
                        [] { "Lambda" })
                  }
               }
            },
            {
               36, new Dictionary<string, AbstractActionFunction>()
               {
                  { "FinCadena", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.ACEPTACION, 0) }
               }
            }
         };
         PilaComprobacion = new Stack<Tuple<int, string>>();
         PilaComprobacion.Push(new Tuple<int, string>(0, "0"));
      }

      /// <summary>
      /// Get the value of the string, with the non-terminal token from the Enum notTerminalForThis
      /// </summary>
      /// <param name="notTerminal">Position string</param>
      /// <returns>Token non-terminal</returns>
      public string selectorString(notTerminalsForThis notTerminal)
      {
         return notTerminalSymbols.GetValue((int)Convert.ChangeType(notTerminal, notTerminal.GetTypeCode())).ToString();
      }
      public string EjecutarAnalisis()
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

            if (analisisFinished) return "<IF>";
            // GrammarErrors.MessageErrorsOfGrammarsM += string.Format($"Hay un error en la línea: {PilaTokens.numLineToken[0].Item1}\n");
         }

         return PilaComprobacion.Count.ToString();
      }
      
      private bool CheckTokenIn_Handler()
      {
         int referenceState = PilaComprobacion.Peek().Item1;
         
         if (referenceState == 2 || referenceState == 16)
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
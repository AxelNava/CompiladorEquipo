using System;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico;
using Compilador.AnalizadorSintactico.Gramaticas;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Compilador.IntentoCodigoIntermedio;

namespace Compilador.Gramaticas
{
   public class Gramatica_IF : AbstractAnalisisTable
   {
      private enum notTerminalsForThis
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
         TablaAnalisis = new Dictionary<int, Dictionary<string, AbstractActionFunction>>()
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
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 36)
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
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA), new ReducedAction(selectorString
                        (notTerminalsForThis.CUERPOINSTRUCCIONES), new[] { string.Empty })
                  },
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
                        new[]
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
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 16)
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
                     "FinCadena", new ReducedAction(selectorString(notTerminalsForThis.IFA), new[]
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
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA), new ReducedAction(selectorString
                        (notTerminalsForThis.CUERPOINSTRUCCIONES), new[] { string.Empty })
                  },
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
                     "FinCadena", new ReducedAction(selectorString(notTerminalsForThis.BODYIFA), new[]
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
                     "FinCadena", new ReducedAction(selectorString(notTerminalsForThis.FINBODY), new[]
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
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA), new ReducedAction(selectorString
                        (notTerminalsForThis.CUERPOINSTRUCCIONES), new[] { string.Empty })
                  },
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
                     "FinCadena", new ReducedAction(selectorString(notTerminalsForThis.BODYELSE), new[]
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
                        new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA) })
                  }
               }
            },
            {
               31, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena",
                     new ReducedAction(selectorString(notTerminalsForThis.FINELSE), new[] { "Lambda" })
                  }
               }
            },
            {
               32, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena",
                     new ReducedAction(selectorString(notTerminalsForThis.FINBODY),
                        new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA) })
                  }
               }
            },
            {
               33, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena",
                     new ReducedAction(selectorString(notTerminalsForThis.FINBODY), new[] { "Lambda" })
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
      private string selectorString(notTerminalsForThis notTerminal)
      {
         return notTerminalSymbols.GetValue((int)Convert.ChangeType(notTerminal, notTerminal.GetTypeCode())).ToString();
      }

      private int contadorSaltosIf_finales = 0;
      public string EjecutarAnalisis()
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

            if (AnalisisFinished)
            {
               while (contadorSaltosIf_finales>=0)
               {
                  TablaInstrucciones.ModificarInstruccionSaltoTerminal();
                  contadorSaltosIf_finales--;
               }
               return "<IF>";
            }
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

         HandleCuerpoInstrucciones(referenceState);
         HandleInstruccion(referenceState);
         HandleJumps(referenceState);
         if (TablaAnalisis[referenceState].ContainsKey(PilaTokens.GlobalTokens.Peek()))
         {
            AbstractActionFunction.ActionEnum actionEnum;
            actionEnum = TablaAnalisis[referenceState][PilaTokens.GlobalTokens.Peek()].Action;
            HandleActions(actionEnum);
            return true;
         }

         return false;
      }

      private void HandleCuerpoInstrucciones(int referenceState)
      {
         if ((referenceState != 5 && referenceState != 20 && referenceState != 26) || PilaTokens.GlobalTokens.Peek() == "cuerpoInstrucciones") return;
         string tokenAux = new Gramatica_CuerpoInstrucciones().Ejecutar_Analisis();
         if (!string.IsNullOrEmpty(tokenAux))
         {
            PilaTokens.GlobalTokens.Push(tokenAux);
         }
      }

      private void HandleInstruccion(int referenceState)
      {
         if ((referenceState == 4 || referenceState == 12 ||
              referenceState == 24) && PilaTokens.GlobalTokens.Peek() != selectorString(notTerminalsForThis.INSTRUCCION))
         {
            string tokenAux;
            var grammar = new GramaticaInstruccion();
            tokenAux = grammar.Ejecutar_Analisis();
            if (!string.IsNullOrEmpty(tokenAux))
            {
               PilaTokens.GlobalTokens.Push(tokenAux);
            }
         }
      }

      private void HandleJumps(int referenceState)
      {
         switch (referenceState)
         {
            case 7:
            case 21:
            case 27:
               TablaInstrucciones.AgregarInstruccion(string.Empty, TablaInstrucciones.IntermidiateCodeInstructions.InstruccionSalto);
               contadorSaltosIf_finales++;
               break;
            case 6:
            case 15:
               TablaInstrucciones.AgregarInstruccion(string.Empty, TablaInstrucciones.IntermidiateCodeInstructions.InstruccionSalto);
               contadorSaltosIf_finales++;
               break;
            case 24:
               if (PilaTokens.GlobalTokens.Peek() == selectorString(notTerminalsForThis.CUERPOINSTRUCCIONES) || PilaTokens.GlobalTokens.Peek() ==
                   selectorString(notTerminalsForThis.BODYELSE))
                  break;
               TablaInstrucciones.ModificarInstruccionSaltoCondicion();
               contadorSaltosIf_finales--;
               break;
         }

         var tabla = TablaInstrucciones.TablaINstrucciones;
      }
   }
}
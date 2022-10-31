using System;
using System.Collections.Generic;
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

      private Stack<Tuple<int, string>> pilaComprobacion;

      public Gramatica_IF()
      {
         tablaAnalisis = new Dictionary<int, Dictionary<string, AbstractActionFunction>>()
         {
            {
               0, new Dictionary<string, AbstractActionFunction>()
               {
                  { "if", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 1) },
                  {
                     selectorString(notTerminalsForThis.IF),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 36)
                  }
               }
            },
            {
               1, new Dictionary<string, AbstractActionFunction>()
               {
                  { "(", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 2) }
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
                  { ")", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 4) }
               }
            },
            {
               4, new Dictionary<string, AbstractActionFunction>()
               {
                  { "{", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 5) },
                  {
                     selectorString(notTerminalsForThis.BODYIF),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 10)
                  },
                  {selectorString(notTerminalsForThis.INSTRUCCION),new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 6)}
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
                  { "else", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 24) },
                  { "Lamda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 12) }
               }
            },
            {
               7, new Dictionary<string, AbstractActionFunction>()
               {
                  { "}", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 8) }
               }
            },
            {
               8, new Dictionary<string, AbstractActionFunction>()
               {
                  { "else", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 24) },
                  { "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 33) },
                  { ";", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 32) },
                  { "Finbody", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 9) }
               }
            },
            {
               9, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena",
                     new ReducedAction(selectorString(notTerminalsForThis.BODYIF),
                        new[] { "{", selectorString(notTerminalsForThis.CUERPOINSTRUCCIONES), "}", "Finbody" })
                  }
               }
            },
            {
               10, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena",
                     new ReducedAction(selectorString(notTerminalsForThis.IF),
                        new string[]
                        {
                           "if", "(", selectorString(notTerminalsForThis.CONDICION), ")",
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
                        string[]
                        {
                           selectorString(notTerminalsForThis.INSTRUCCION), selectorString(notTerminalsForThis.FINBODY)
                        })
                  }
               }
            },
            {
               12, new Dictionary<string, AbstractActionFunction>()
               {
                  { "if", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 13) },
                  { "{", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 26) },
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
                  { "(", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 16) }
               }
            },
            {
               14, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(notTerminalsForThis.BODYELSE), new
                        string[] { selectorString(notTerminalsForThis.IFA) })
                  }
               }
            },
            {
               15, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(notTerminalsForThis.BODYELSE), new
                        string[] { selectorString(notTerminalsForThis.INSTRUCCION) })
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
                  { ")", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 18) }
               }
            },
            {
               18, new Dictionary<string, AbstractActionFunction>()
               {
                  { "{", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 20) },
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
                     "FinCadena", new ReducedAction(selectorString(notTerminalsForThis.IFA), new string[]
                     {
                        "if", "(",
                        selectorString(notTerminalsForThis.CONDICION), ")", selectorString(notTerminalsForThis.BODYIFA)
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
                  { "}", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 22) }
               }
            },
            {
               22, new Dictionary<string, AbstractActionFunction>()
               {
                  { "else", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 24) },
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
                     "FinCadena", new ReducedAction(selectorString(notTerminalsForThis.BODYIFA), new string[]
                     {
                        "{",
                        selectorString(notTerminalsForThis.CUERPOINSTRUCCIONES), "}",
                        selectorString(notTerminalsForThis.FINBODY)
                     })
                  }
               }
            },
            {
               24, new Dictionary<string, AbstractActionFunction>()
               {
                  { "if", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 1) },
                  { "{", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 26) },
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
                     "FinCadena", new ReducedAction(selectorString(notTerminalsForThis.FINBODY), new string[]
                     {
                        "else",
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
                  { "}", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 28) }
               }
            },
            {
               28, new Dictionary<string, AbstractActionFunction>()
               {
                  { "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 31) },
                  { ";", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 30) },
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
                     "FinCadena", new ReducedAction(selectorString(notTerminalsForThis.BODYELSE), new string[]
                     {
                        "{",
                        selectorString(notTerminalsForThis.CUERPOINSTRUCCIONES), "}",
                        selectorString(notTerminalsForThis.FINELSE)
                     })
                  }
               }
            },
            {
               30, new Dictionary<string, AbstractActionFunction>()
               {
                  { "FinCadena", new ReducedAction(selectorString(notTerminalsForThis.FINELSE), new string[] { ";" }) }
               }
            },
            {
               31, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena",
                     new ReducedAction(selectorString(notTerminalsForThis.FINELSE), new string[] { "Lambda" })
                  }
               }
            },
            {
               32, new Dictionary<string, AbstractActionFunction>()
               {
                  { "FinCadena", new ReducedAction(selectorString(notTerminalsForThis.FINBODY), new string[] { ";" }) }
               }
            },
            {
               33, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena",
                     new ReducedAction(selectorString(notTerminalsForThis.FINBODY), new string[] { "Lambda" })
                  }
               }
            },
            {
               34, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(notTerminalsForThis.BODYIFA), new
                        string[]
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
                        string[] { "Lambda" })
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
         pilaComprobacion = new Stack<Tuple<int, string>>();
         pilaComprobacion.Push(new Tuple<int, string>(0, "0"));
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

      private bool analisisFinished;

      public string EjecutarAnalisis()
      {
         analisisFinished = false;
         while (PilaTokens.GlobalTokens.Count>=1)
         {
            int referenceState = pilaComprobacion.Peek().Item1;
            if (tablaAnalisis[referenceState].ContainsKey(PilaTokens.GlobalTokens.Peek()))
            {
               AbstractActionFunction.ActionEnum actionEnum;
               actionEnum = tablaAnalisis[referenceState][PilaTokens.GlobalTokens.Peek()].Action;
               HandleActions(actionEnum);
               if (analisisFinished) return "<IF>";
            }
         }
         return pilaComprobacion.Count.ToString();
      }

      void HandleActions(AbstractActionFunction.ActionEnum typeAction)
      {
         int referenceState = pilaComprobacion.Peek().Item1;
         switch (typeAction)
         {
            case AbstractActionFunction.ActionEnum.DESPLAZAMIENTO:
            case AbstractActionFunction.ActionEnum.GOTO:
               PushPopStacks_Shit_Goto(referenceState);
               break;
            case AbstractActionFunction.ActionEnum.ACEPTACION:
               analisisFinished = true;
               break;
            case AbstractActionFunction.ActionEnum.REDUCCION:
               jumpStackToGlobalStack(referenceState);
               break;
         }
      }

      /// <summary>
      /// Pop a token from the global stack tokens, and push it to the analysis stack
      /// </summary>
      void PushPopStacks_Shit_Goto(int referenceState)
      {
         int nextState = 0;
         AccionFuncion_TablaAnalisis classReserve;
         classReserve =
            tablaAnalisis[referenceState][PilaTokens.GlobalTokens.Peek()] as AccionFuncion_TablaAnalisis;
         if (classReserve != null) nextState = classReserve._state;
         pilaComprobacion.Push(new Tuple<int, string>(nextState, PilaTokens.GlobalTokens.Pop()));
      }

      public void jumpStackToGlobalStack(int referenceState)
      {
         PilaTokens.GlobalTokens.Push(reductionHandler(referenceState));
      }

      public string reductionHandler(int referenceState)
      {
         ReducedAction classReserve;
         classReserve =
            tablaAnalisis[referenceState][PilaTokens.GlobalTokens.Peek()] as ReducedAction;
         int sizeRule = classReserve._ruled.Length;
         string[] tokens = new string[sizeRule - 1];
         for (int i = sizeRule; i >= 0; i--)
         {
            tokens[i] = pilaComprobacion.Pop().Item2;
         }

         return classReserve.ReduceTokens(tokens);
      }

      #region metodos para test

      public string EjecutarAnalisisTest(Stack<string> pilaParaComprobar)
      {
         analisisFinished = false;
         while (pilaParaComprobar.Count >= 1)
         {
            int referenceState = pilaComprobacion.Peek().Item1;
            if (tablaAnalisis[referenceState].ContainsKey(pilaParaComprobar.Peek()))
            {
               AbstractActionFunction.ActionEnum actionEnum;
               actionEnum = tablaAnalisis[referenceState][pilaParaComprobar.Peek()].Action;
               HandleActionsTest(actionEnum, pilaParaComprobar);
               if (analisisFinished) return "<IF>";
            }
         }

         return pilaComprobacion.Count.ToString();
      }

      void HandleActionsTest(AbstractActionFunction.ActionEnum typeAction, Stack<string> pilaPrueba)
      {
         int referenceState = pilaComprobacion.Peek().Item1;
         switch (typeAction)
         {
            case AbstractActionFunction.ActionEnum.DESPLAZAMIENTO:
            case AbstractActionFunction.ActionEnum.GOTO:
               PushPopStacks_Shit_Goto_Test(referenceState, pilaPrueba);
               break;
            case AbstractActionFunction.ActionEnum.ACEPTACION:
               analisisFinished = true;
               break;
            case AbstractActionFunction.ActionEnum.REDUCCION:
               jumpStackToGlobalStackTest(referenceState, pilaPrueba);
               break;
         }
      }

      public string jumpStackToGlobalStackTest(int referenceStateStack,
         Stack<string> pilaPrueba)
      {
         string reductionToken = (reductionHandlerTest(referenceStateStack, pilaPrueba));
         pilaPrueba.Push(reductionToken);
         return pilaPrueba.Peek();
      }

      public void PushPopStacks_Shit_Goto_Test(int referenceState, Stack<string> pilaprueba)
      {
         int nextState = 0;
         AccionFuncion_TablaAnalisis classReserve;
         classReserve =
            tablaAnalisis[referenceState][pilaprueba.Peek()] as AccionFuncion_TablaAnalisis;
         if (classReserve != null) nextState = classReserve._state;
         pilaComprobacion.Push(new Tuple<int, string>(nextState, pilaprueba.Pop()));
      }

      public string reductionHandlerTest(int referenceStatem, Stack<string> pilaPrueba)
      {
         ReducedAction classReserve;
         classReserve =
            tablaAnalisis[referenceStatem][pilaPrueba.Peek()] as ReducedAction;
         int sizeRule = classReserve._ruled.Length;
         string[] tokens = new string[sizeRule];
         for (int i = sizeRule - 1; i >= 0; i--)
         {
            tokens[i] = pilaComprobacion.Pop().Item2;
         }

         return classReserve.ReduceTokens(tokens);
      }

      #endregion
   }
}
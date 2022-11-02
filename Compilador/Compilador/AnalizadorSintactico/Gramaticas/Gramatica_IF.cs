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
      private bool analisisFinished;

      public string EjecutarAnalisis()
      {
         analisisFinished = false;
         while (PilaTokens.GlobalTokens.Count >= 1)
         {
            if (!CheckTokenInHandler())
            {
               PilaTokens.GlobalTokens.Push("Lambda");
               if (!CheckTokenInHandler())
               {
                  PilaTokens.GlobalTokens.Pop();
                  PilaTokens.GlobalTokens.Push("FinCadena");
                  if (!CheckTokenInHandler())
                  {
                     return string.Empty;
                  }
               }
            }
            if (analisisFinished) return "<IF>";
            GrammarErrors.MessageErrorsOfGrammarsM += string.Format($"Hay un error en la línea: {PilaTokens.numLineToken[0].Item1}\n");
         }

         return PilaComprobacion.Count.ToString();
      }

      void HandleActions(AbstractActionFunction.ActionEnum typeAction)
      {
         int referenceState = PilaComprobacion.Peek().Item1;
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
      private bool CheckTokenInHandler()
      {
         int referenceState = PilaComprobacion.Peek().Item1;
         string tokenAux = string.Empty;
         if (referenceState == 1 || referenceState == 13)
         {
            tokenAux = new GramaticaCondicion().EjecutarAnalisis();
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
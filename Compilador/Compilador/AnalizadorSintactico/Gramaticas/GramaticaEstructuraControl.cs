using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Compilador.Gramaticas;
using System;
using System.Collections.Generic;

namespace Compilador.AnalizadorSintactico.Gramaticas
{
   public class GramaticaEstructuraControl : AbstractAnalisisTable
   {
      public enum notTerminalsForThis
      {
         ESTRUCTURACONTROL,
         IF,
         WHILE,
         FOR,
         DO,
         SWITCH,
         RECURSIVO
      }

      private static readonly string[] notTerminalSymbols =
      {
         "<estructuracontrol>",
         "if",
         "while",
         "for",
         "do",
         "switch",
         "recursivo"
      };

      public GramaticaEstructuraControl()
      {
         TablaAnalisis = new Dictionary<int, Dictionary<string, AbstractActionFunction>>()
         {
            {
               0, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.IF),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 2)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.WHILE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 3)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.FOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 4)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 5)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.SWITCH),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 6)
                  },
                  {"<estructuracontrol>", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 1) }
               }
            },
            {
               1, new Dictionary<string, AbstractActionFunction>()
               {
                   { "FinCadena", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.ACEPTACION, 1) }
               }
            },
            {
               2, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.IF),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 2)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.WHILE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 3)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.FOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 4)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 5)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.SWITCH),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 6)
                  },
                  {"<estructuracontrol>", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 8) },
                  {"recursivo", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 7) },
                  {"FinCadena", new ReducedAction("recursivo", new[] {string.Empty }) }
               }
            },
            {
               3, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.IF),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 2)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.WHILE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 3)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.FOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 4)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 5)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.SWITCH),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 6)
                  },
                  {"<estructuracontrol>", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 8) },
                  {"recursivo", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 9) },
                  {"FinCadena", new ReducedAction("recursivo", new[] {string.Empty }) }
               }
            },
            {
               4, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.IF),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 2)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.WHILE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 3)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.FOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 4)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 5)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.SWITCH),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 6)
                  },
                  {"<estructuracontrol>", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 8) },
                  {"recursivo", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 10) },
                  {"FinCadena", new ReducedAction("recursivo", new[] {string.Empty }) }
               }
            },
            {
               5, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.IF),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 2)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.WHILE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 3)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.FOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 4)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 5)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.SWITCH),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 6)
                  },
                  {"<estructuracontrol>", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 8) },
                  {"recursivo", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 11) },
                  {"FinCadena", new ReducedAction("recursivo", new[] {string.Empty }) }
               }
            },
            {
               6, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.IF),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 2)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.WHILE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 3)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.FOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 4)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 5)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.SWITCH),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 6)
                  },
                  {"<estructuracontrol>", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 8) },
                  {"recursivo", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 12) },
                  {"FinCadena", new ReducedAction("recursivo", new[] {string.Empty }) }
               }
            },
             {
                 7, new Dictionary<string, AbstractActionFunction>()
                 {
                     {"FinCadena", new ReducedAction("<estructuracontrol>", new[] {"if","recursivo"}) }
                 }
             },
             {
                 8, new Dictionary<string, AbstractActionFunction>()
                 {
                     {"FinCadena", new ReducedAction("recursivo", new[] {"<estructuracontrol>"}) }
                 }
             },
             {
                 9, new Dictionary<string, AbstractActionFunction>()
                 {
                     {"FinCadena", new ReducedAction("<estructuracontrol>", new[] {"while","recursivo"}) }
                 }
             },
             {
                 10, new Dictionary<string, AbstractActionFunction>()
                 {
                     {"FinCadena", new ReducedAction("<estructuracontrol>", new[] {"for","recursivo"}) }
                 }
             },
             {
                 11, new Dictionary<string, AbstractActionFunction>()
                 {
                     {"FinCadena", new ReducedAction("<estructuracontrol>", new[] {"do","recursivo"}) }
                 }
             },
             {
                 12, new Dictionary<string, AbstractActionFunction>()
                 {
                    {"FinCadena", new ReducedAction("<estructuracontrol>", new[] { "switch", "recursivo"}) }
                 }
             },
         };
         PilaComprobacion = new Stack<Tuple<int, string>>();
         PilaComprobacion.Push(new Tuple<int, string>(0, "0"));
      }

      public string EjecutarAnalisis()
      {
         AnalisisFinished = false;
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
                     AddError();
                     PilaTokens.GlobalTokens.Pop();
                     return string.Empty;
                  }
               }
            }

            if (AnalisisFinished) return "<estructuracontrol>";
         }

         return PilaComprobacion.Count.ToString();
      }

      private bool CheckTokenIn_Handler()
      {
         int referenceState = PilaComprobacion.Peek().Item1;
         checkcontrolestructure(referenceState);
         

            if (tablaAnalisis[referenceState].ContainsKey(PilaTokens.GlobalTokens.Peek()))
            {
                AbstractActionFunction.ActionEnum actionEnum;
                actionEnum = tablaAnalisis[referenceState][PilaTokens.GlobalTokens.Peek()].Action;
                HandleActions(actionEnum);
                return true;
            }

            return false;
        }

        private static void checkcontrolestructure(int referenceState)
        {
            if (referenceState == 0 || referenceState == 1 || referenceState == 2 || referenceState == 3 || referenceState == 4 || referenceState == 5 || referenceState == 6)
            {
                Gramatica_IF gramatica_if = new Gramatica_IF();
                string tokeng = gramatica_if.EjecutarAnalisis();
                if (!string.IsNullOrEmpty(tokeng))
                {
                    PilaTokens.GlobalTokens.Push(tokeng);
                    return;
                }
                Gramatica_For gramatica_for = new Gramatica_For();
                tokeng = gramatica_for.EjecutarAnalisis();
                if (!string.IsNullOrEmpty(tokeng))
                {
                    PilaTokens.GlobalTokens.Push(tokeng);
                    return;
                }
                Gramatica_While gramatica_while= new Gramatica_While();
                tokeng = gramatica_while.Ejecutar_Analisis();
                if (!string.IsNullOrEmpty(tokeng))
                {
                    PilaTokens.GlobalTokens.Push(tokeng);
                    return;
                }
                Gramatica_DoWhile gramatica_dowhile = new Gramatica_DoWhile();
                tokeng = gramatica_dowhile.Ejecutar_Analisis();
                if (!string.IsNullOrEmpty(tokeng))
                {
                    PilaTokens.GlobalTokens.Push(tokeng);
                    return;
                }
                /*
                Gramatica_Switch gramatica_switch = new Gramatica_Switch();
                tokeng = gramatica_switch.Ejecutar_Analisis();
                if (!string.IsNullOrEmpty(tokeng))
                {
                    PilaTokens.GlobalTokens.Push(tokeng);
                    
                }
                */
                

            }
        }
    }
}
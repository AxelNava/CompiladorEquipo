using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Compilador.Gramaticas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
         SWITCH
      }

      private static readonly string[] notTerminalSymbols =
      {
         "<estructuracontrol>",
         tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.IF),
         "while",
         "for",
         "do",
         "switch"
      };

      public GramaticaEstructuraControl()
      {
         tablaAnalisis = new Dictionary<int, Dictionary<string, AbstractActionFunction>>()
         {
            {
               0, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.IF),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 2)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.WHILE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 3)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.FOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 4)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 5)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.SWITCH),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 6)
                  },
               }
            },
            {
               1, new Dictionary<string, AbstractActionFunction>()
               {
                  { "FinCadena", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.ACEPTACION, 6) },
               }
            },
            {
               2, new Dictionary<string, AbstractActionFunction>()
               {
                  { "<IF>", new ReducedAction("EC", new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.IF) }) },
               }
            },
            {
               3, new Dictionary<string, AbstractActionFunction>()
               {
                  { "<WHILE>", new ReducedAction("EC", new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.WHILE) }) },
               }
            },
            {
               4, new Dictionary<string, AbstractActionFunction>()
               {
                  { "<FOR>", new ReducedAction("EC", new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.FOR) }) },
               }
            },
            {
               5, new Dictionary<string, AbstractActionFunction>()
               {
                  { "<DO>", new ReducedAction("EC", new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DO) }) },
               }
            },
            {
               6, new Dictionary<string, AbstractActionFunction>()
               {
                  { "<SWITCH>", new ReducedAction("EC", new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.SWITCH) }) },
               }
            },
         };
         PilaComprobacion = new Stack<Tuple<int, string>>();
         PilaComprobacion.Push(new Tuple<int, string>(0, "0"));
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

            if (analisisFinished) return "<estructuracontrol>";
         }

         return PilaComprobacion.Count.ToString();
      }

      private bool CheckTokenIn_Handler()
      {
         int referenceState = PilaComprobacion.Peek().Item1;
         if (tablaAnalisis[referenceState].ContainsKey(PilaTokens.GlobalTokens.Peek()))
         {
            AbstractActionFunction.ActionEnum actionEnum;
            actionEnum = tablaAnalisis[referenceState][PilaTokens.GlobalTokens.Peek()].Action;
            HandleActions(actionEnum);
            return true;
         }

         return false;
      }
   }
}
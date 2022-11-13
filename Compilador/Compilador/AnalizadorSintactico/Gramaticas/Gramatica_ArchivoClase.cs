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
   public class Gramatica_ArchivoClase : AbstractAnalisisTable
   {
      public enum notTerminalsForThis
      {
         ARCHIVOCLASE,
         USING,
         NOMBRECLASE,
         BODYCLASS
      }

      private static readonly string[] notTerminalSymbols =
      {
         "<archivoclase>",
         "using",
         "nombreclase",
         "bodyclass"
      };

      public Gramatica_ArchivoClase()
      {
         tablaAnalisis = new Dictionary<int, Dictionary<string, AbstractActionFunction>>()
         {
            {
               0, new Dictionary<string, AbstractActionFunction>()
               {
                  { "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 4) },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.USING),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 3)
                  },
                  { "<ARCHIVOCLASE>", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 1) },
                  { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.USING), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                  .ActionEnum.GOTO, 2) }
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
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CLASS),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 7)
                  },
                  { "<NOMBRECLASE>", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 5) }
               }
            },
            {
               3, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 6)
                  }
               }
            },
            {
               4, new Dictionary<string, AbstractActionFunction>()
               {
                  { "CLASS", new ReducedAction("USING", new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CLASS) }) }
               }
            },
            {
               5, new Dictionary<string, AbstractActionFunction>()
               {
                  { "FinCadena", new ReducedAction("ARCHIVOCLASE", new[] { "FinCadena" }) }
               }
            },
            {
               6, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 8)
                  },
                  { "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 4) },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.USING),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 3)
                  }
               }
            },
            {
               7, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 9)
                  },
               }
            },
            {
               8, new Dictionary<string, AbstractActionFunction>()
               {
                  { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.USING), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 13) }
               }
            },
            {
               9, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 10)
                  },
               }
            },
            {
               10, new Dictionary<string, AbstractActionFunction>()
               {
                  { "<BODYCLASS>", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 11) }
               }
            },
            {
               11, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 12)
                  },
               }
            },
            {
               12, new Dictionary<string, AbstractActionFunction>()
               {
                  { "FinCadena", new ReducedAction("NOMBRECLASE", new[] { "FinCadena" }) }
               }
            },
            {
               13, new Dictionary<string, AbstractActionFunction>()
               {
                  { "CLASS", new ReducedAction("USING", new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CLASS) }) }
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
            if (analisisFinished) return "<archivoclase>";
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
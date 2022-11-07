using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts.Internal;
using Compilador.AnalizadorSintactico;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;

namespace Compilador.AnalizadorSintactico.Gramaticas
{
   public class GramaticaValores : AbstractAnalisisTable
   {
      public enum nonTerminalsForThisGrammar
      {
         VsB,
         Valores,
         InstruccionesIDentificador,
         RM,
         Para,
         R
      }

      private static readonly string[] nonTerminalsTokenString =
      {
         "VsB",
         "Valores",
         "InstruccionesIdentificador",
         "RM",
         "Params",
         "R"
      };

      public GramaticaValores()
      {
         tablaAnalisis = new Dictionary<int, Dictionary<string, AbstractActionFunction>>()
         {
            {
               0, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 7)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 5)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 2)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER), new AccionFuncion_TablaAnalisis(
                        AbstractActionFunction.ActionEnum.DESPLAZAMIENTO
                        , 3)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 6)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 4)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.Valores), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum
                        .DESPLAZAMIENTO, 1)
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
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 25)
                  },
                  {
                     "FinCadena", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 23)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 38)
                  }
               }
            },
            {
               3, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 25)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 23)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 39)
                  }
               }
            },
            {
               4, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 25)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 23)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 40)
                  }
               }
            },
            {
               5, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena",
                     new ReducedAction(selectorString(nonTerminalsForThisGrammar.Valores),
                        new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL) })
                  }
               }
            },
            {
               6, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 25)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 23)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 41)
                  }
               }
            },
            {
               7, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 11)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 8)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 9)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 10)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 18)
                  }
               }
            },
            {
               8, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                           (nonTerminalsForThisGrammar.InstruccionesIDentificador),
                        new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO) })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                           (nonTerminalsForThisGrammar.InstruccionesIDentificador),
                        new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO) })
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString
                           (nonTerminalsForThisGrammar.InstruccionesIDentificador),
                        new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO) })
                  }
               }
            },
            {
               9, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                           (nonTerminalsForThisGrammar.InstruccionesIDentificador),
                        new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO) })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                           (nonTerminalsForThisGrammar.InstruccionesIDentificador),
                        new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO) })
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString
                           (nonTerminalsForThisGrammar.InstruccionesIDentificador),
                        new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO) })
                  }
               }
            },
            {
               10, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                           (nonTerminalsForThisGrammar.InstruccionesIDentificador),
                        new[] { "Lambda" })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                           (nonTerminalsForThisGrammar.InstruccionesIDentificador),
                        new[] { "Lambda" })
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString
                           (nonTerminalsForThisGrammar.InstruccionesIDentificador),
                        new[] { "Lambda" })
                  }
               }
            },
            {
               11, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 16)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 68)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 42)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 43)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 45)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 44)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.Valores), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 14)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.Para), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 12)
                  }
               }
            },
            {
               12, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 13)
                  }
               }
            },
            {
               13, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.InstruccionesIDentificador), new[]
                     {
                        selectorString(nonTerminalsForThisGrammar.Para)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     new ReducedAction(selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador), new[]
                     {
                        selectorString(nonTerminalsForThisGrammar.Para)
                     })
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador), new[]
                     {
                        selectorString(nonTerminalsForThisGrammar.Para)
                     })
                  }
               }
            },
            {
               14, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 70)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 69)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.RM), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 15)
                  }
               }
            },
            {
               15, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Para), new[]
                     {
                        selectorString(nonTerminalsForThisGrammar.Valores), selectorString(nonTerminalsForThisGrammar.RM)
                     })
                  }
               }
            },
            {
               16, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 17)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 8)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 9)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 10)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO,18)
                  }
               }
            },
            {
               17, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 16)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 68)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 42)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 43)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 44)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.Valores), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 14)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.Para), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 12)
                  }
               }
            },
            {
               18, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 25)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 23)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 25)
                  }
               }
            },
            {
               23, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.R), new[]
                     {
                        "Lambda"
                     })
                  }
               }
            },
            {
               24, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Asignacion), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 27)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 29)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 30)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 31)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 32)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.VsB), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 26)
                  }
               }
            },
            {
               25, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                        selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               26, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.R), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), selectorString(nonTerminalsForThisGrammar.VsB)
                     })
                  }
               }
            },
            {
               27, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 11)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO), new AccionFuncion_TablaAnalisis(
                        AbstractActionFunction
                           .ActionEnum.DESPLAZAMIENTO, 8)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO), new AccionFuncion_TablaAnalisis(
                        AbstractActionFunction
                           .ActionEnum.DESPLAZAMIENTO, 9)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 10)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.GOTO, 28)
                  }
               }
            },
            {
               28, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 25)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 23)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 33)
                  }
               }
            },
            {
               29, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 25)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 23)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 34)
                  }
               }
            },
            {
               30, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 25)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 23)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 35)
                  }
               }
            },
            {
               31, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 25)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 23)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 36)
                  }
               }
            },
            {
               32, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 25)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 23)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 37)
                  }
               }
            },
            {
               33, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.VsB), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), selectorString(nonTerminalsForThisGrammar
                           .InstruccionesIDentificador),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               34, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.VsB), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               35, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.VsB), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               36, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.VsB), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               37, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.VsB), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               38, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               39, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               40, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               41, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               42, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 52)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 51)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 46)
                  }
               }
            },
            {
               43, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 52)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 51)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 47)
                  }
               }
            },
            {
               44, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 52)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 51)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 48)
                  }
               }
            },
            {
               45, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 52)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 51)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 49)
                  }
               }
            },
            {
               46, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               47, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               48, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               49, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               50, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 52)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 51)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 54)
                  }
               }
            },
            {
               51, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalsForThisGrammar.R), new[] { "Lambda" })
                  }
               }
            },
            {
               52, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 55)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 60)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 61)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 63)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 62)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.VsB), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum
                        .DESPLAZAMIENTO, 53)
                  }
               }
            },
            {
               53, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(
                        selectorString(nonTerminalsForThisGrammar.R),
                        new[]
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), selectorString(nonTerminalsForThisGrammar.VsB)
                        })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(
                        selectorString(nonTerminalsForThisGrammar.R),
                        new[]
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), selectorString(nonTerminalsForThisGrammar.VsB)
                        })
                  }
               }
            },
            {
               54, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(
                        selectorString(nonTerminalsForThisGrammar.Valores),
                        new[]
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                           selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador),
                           selectorString(nonTerminalsForThisGrammar.R)
                        })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(
                        selectorString(nonTerminalsForThisGrammar.Valores),
                        new[]
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                           selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador),
                           selectorString(nonTerminalsForThisGrammar.R)
                        })
                  }
               }
            },
            {
               55, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 77)
                  }
               }
            },
            {
               56, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               57, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER), selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               58, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL), selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               59, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO), selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               60, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 52)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 51)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 64)
                  }
               }
            },
            {
               61, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 52)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 51)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 65)
                  }
               }
            },
            {
               62, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 52)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 51)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 66)
                  }
               }
            },
            {
               63, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 52)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 51)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 67)
                  }
               }
            },
            {
               64, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.VsB), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.VsB), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               65, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.VsB), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.VsB), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               66, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.VsB), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.VsB), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               67, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.VsB), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.VsB), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL),
                        selectorString(nonTerminalsForThisGrammar.R)
                     })
                  }
               }
            },
            {
               68, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.Valores), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL)
                     })
                  }
               }
            },
            {
               69, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.RM), new[]
                     {
                        "Lambda"
                     })
                  }
               }
            },
            {
               70, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 16)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 42)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 43)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 45)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 44)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 77)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.Valores), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 14)
                  },
                  {
                     selectorString(nonTerminalsForThisGrammar.Para), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 76)
                  }
               }
            },
            {
               71, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 72)
                  }
               }
            },
            {
               72, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.InstruccionesIDentificador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        selectorString(nonTerminalsForThisGrammar.Para),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)
                     })
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.InstruccionesIDentificador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        selectorString(nonTerminalsForThisGrammar.Para),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)
                     })
                  }
               }
            },
            {
               73, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new ReducedAction(selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA),
                     new ReducedAction(selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     new ReducedAction(selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO)
                     })
                  }
               }
            },
            {
               74, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new ReducedAction(selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA),
                     new ReducedAction(selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO)
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     new ReducedAction(selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador), new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO)
                     })
                  }
               }
            },
            {
               75, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OPERADOR),
                     new ReducedAction(selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador), new[]
                     {
                        "Lambda"
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.COMA),
                     new ReducedAction(selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador), new[]
                     {
                        "Lambda"
                     })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     new ReducedAction(selectorString(nonTerminalsForThisGrammar.InstruccionesIDentificador), new[]
                     {
                        "Lambda"
                     })
                  }
               }
            },
            {
               76, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction(selectorString
                        (nonTerminalsForThisGrammar.RM), new[]
                     {
                        selectorString(nonTerminalsForThisGrammar.Para)
                     })
                  }
               }
            }
         };
         PilaComprobacion = new Stack<Tuple<int, string>>();
         PilaComprobacion.Push(new Tuple<int, string>(0, "0"));
      }

      public string selectorString(nonTerminalsForThisGrammar nonTerminal)
      {
         return nonTerminalsTokenString.GetValue((int)Convert.ChangeType(nonTerminal, nonTerminal.GetTypeCode())).ToString();
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
            if (analisisFinished) return "Valores";
         }
         return string.Empty;
      }

      private bool CheckTokenIn_Handler()
      {
         int referenceState = PilaComprobacion.Peek().Item1;
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
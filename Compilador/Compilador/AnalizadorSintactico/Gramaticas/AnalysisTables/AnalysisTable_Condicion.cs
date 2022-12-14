using System;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;

namespace Compilador.AnalizadorSintactico.Gramaticas.AnalysisTables
{
   public class AnalysisTable_Condicion
   {
      enum nonTerminalTokens
      {
         veriM,
         VALOR,
         COMP,
         COMPI,
         VALORBOOL,
         VALORC,
         R,
         OPERADORLOG,
         CONDICION
      }

      static ReducedAction OperadorAND_LogicToken = new ReducedAction("OperadorLog", new string[] { "AND" });
      static ReducedAction OperadorOR_LogicToken = new ReducedAction("OperadorLog", new string[] { "OR" });
      static ReducedAction Comp_compareToken = new ReducedAction("comp", new string[] { "Valores", "Comparador", "ValorC" });
      static ReducedAction CompI_compareToken = new ReducedAction("CompI", new string[] { "Comparador", "ValorC" });
      static ReducedAction Valor_enteroToken = new ReducedAction("ValorC", new string[] { "Entero" });
      static ReducedAction Valor_decimalToken = new ReducedAction("ValorC", new string[] { "Decimal" });
      static ReducedAction Valor_cadenaToken = new ReducedAction("ValorC", new string[] { "Cadena" });
      static ReducedAction Valor_charToken = new ReducedAction("ValorC", new string[] { "Caracter" });

      private static string[] nonTerminalsTokensString =

      {
         "VeriM",
         "Valores",
         "comp",
         "CompI",
         "ValorBool",
         "ValorC",
         "R",
         "OperadorLog",
         "Condicion"
      };

      private static string selectorString(nonTerminalTokens token)
      {
         return nonTerminalsTokensString.GetValue((int)Convert.ChangeType(token, token.GetTypeCode())).ToString();
      }

      public static Dictionary<int, Dictionary<string, AbstractActionFunction>> GlobalDictionary =
         new Dictionary<int, Dictionary<string, AbstractActionFunction>>()
         {
            {
               0, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.NEGACION),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 4)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 2)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 6)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 7)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 8)
                  },
                  {
                     selectorString(nonTerminalTokens.VALOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 10)
                  },
                  {
                     selectorString(nonTerminalTokens.COMP),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 5)
                  },
                  {
                     selectorString(nonTerminalTokens.VALORBOOL),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 25)
                  },
                  {
                     selectorString(nonTerminalTokens.CONDICION),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 1)
                  }
               }
            },
            {
               1, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.ACEPTACION, 0)
                  }
               }
            },
            {
               2, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 35)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 33)
                  },
                  {
                     selectorString(nonTerminalTokens.veriM), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 3)
                  }
               }
            },
            {
               3, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 37)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Comparador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 19)
                  },
                  {
                     selectorString(nonTerminalTokens.COMPI), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 36)
                  }
               }
            },
            {
               4, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 2)
                  },
                  {
                     selectorString(nonTerminalTokens.VALORBOOL), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 21)
                  }
               }
            },
            {
               5, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.AND), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 26)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OR), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 27)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 23)
                  },
                  {
                     selectorString(nonTerminalTokens.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 28)
                  },
                  {
                     selectorString(nonTerminalTokens.OPERADORLOG), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 24)
                  }
               }
            },
            {
               6, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Comparador), new ReducedAction(selectorString(nonTerminalTokens
                        .VALOR), new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO) })
                  }
               }
            },
            {
               7, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Comparador), new ReducedAction(selectorString(nonTerminalTokens
                        .VALOR), new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL) })
                  }
               }
            },
            {
               8, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Comparador), new ReducedAction(selectorString(nonTerminalTokens
                        .VALOR), new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA) })
                  }
               }
            },
            {
               9, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Comparador), new ReducedAction(selectorString(nonTerminalTokens
                        .VALOR), new[] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER) })
                  }
               }
            },
            {
               10, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Comparador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 11)
                  }
               }
            },
            {
               11, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 12)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 16)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 17)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 14)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 15)
                  },
                  {
                     selectorString(nonTerminalTokens.VALORC), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 18)
                  }
               }
            },
            {
               12, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 35)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 13)
                  },
                  {
                     selectorString(nonTerminalTokens.veriM), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 32)
                  }
               }
            },
            {
               13, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 31)
                  }
               }
            },
            {
               14, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.AND), Valor_cadenaToken
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OR), Valor_cadenaToken
                  },
                  {
                     "FinCadena", Valor_cadenaToken
                  }
               }
            },
            {
               15, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.AND), Valor_charToken
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OR), Valor_charToken
                  },
                  {
                     "FinCadena", Valor_charToken
                  }
               }
            },
            {
               16, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.AND), Valor_enteroToken
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OR), Valor_enteroToken
                  },
                  {
                     "FinCadena", Valor_enteroToken
                  }
               }
            },
            {
               17, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.AND), Valor_decimalToken
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OR), Valor_decimalToken
                  },
                  {
                     "FinCadena", Valor_enteroToken
                  }
               }
            },
            {
               18, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.AND), Comp_compareToken
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OR), Comp_compareToken
                  },
                  {
                     "FinCadena", Comp_compareToken
                  }
               }
            },
            {
               19, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 12)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 16)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 17)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 14)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 15)
                  },
                  {
                     selectorString(nonTerminalTokens.VALORC), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 20)
                  }
               }
            },
            {
               20, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.AND), CompI_compareToken
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OR), CompI_compareToken
                  },
                  {
                     "FinCadena", CompI_compareToken
                  }
               }
            },
            {
               21, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.AND), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 26)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OR), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 27)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 23)
                  },
                  {
                     selectorString(nonTerminalTokens.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 22)
                  },
                  {
                     selectorString(nonTerminalTokens.OPERADORLOG), new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 24)
                  }
               }
            },
            {
               22, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.CONDICION), new[]
                     {
                        tokensNameGlobal.selectorString
                           (tokensNameGlobal.tokensGlobals.NEGACION),
                        selectorString(nonTerminalTokens.VALORBOOL), selectorString(nonTerminalTokens.R)
                     })
                  }
               }
            },
            {
               23, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.R), new[] { "Lambda" })
                  }
               }
            },
            {
               24, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.NEGACION), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 4)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 2)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 6)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 7)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 8)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 9)
                  },
                  {
                     selectorString(nonTerminalTokens.VALOR), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 10)
                  },
                  {
                     selectorString(nonTerminalTokens.COMP), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 5)
                  },
                  {
                     selectorString(nonTerminalTokens.VALORBOOL), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 25)
                  },
                  {
                     selectorString(nonTerminalTokens.CONDICION), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.GOTO, 30)
                  }
               }
            },
            {
               25, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.AND), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 26)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OR), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 27)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.DESPLAZAMIENTO, 23)
                  },
                  {
                     selectorString(nonTerminalTokens.R), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.GOTO, 38)
                  },
                  {
                     selectorString(nonTerminalTokens.OPERADORLOG), new AccionFuncion_TablaAnalisis(AbstractActionFunction
                        .ActionEnum.GOTO, 24)
                  }
               }
            },
            {
               26, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.NEGACION), OperadorAND_LogicToken
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), OperadorAND_LogicToken
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO), OperadorAND_LogicToken
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL), OperadorAND_LogicToken
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), OperadorAND_LogicToken
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER), OperadorAND_LogicToken
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL), OperadorAND_LogicToken
                  }
               }
            },
            {
               27, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.NEGACION), OperadorOR_LogicToken
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), OperadorOR_LogicToken
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO), OperadorOR_LogicToken
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL), OperadorOR_LogicToken
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA), OperadorOR_LogicToken
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER), OperadorOR_LogicToken
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL), OperadorOR_LogicToken
                  }
               }
            },
            {
               28, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.CONDICION), new
                        [] { selectorString(nonTerminalTokens.COMP), selectorString(nonTerminalTokens.R) })
                  }
               }
            },
            {
               29, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.VALORBOOL), new
                        [] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), selectorString(nonTerminalTokens.COMPI) })
                  }
               }
            },
            {
               30, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.R), new
                        [] { selectorString(nonTerminalTokens.OPERADORLOG), selectorString(nonTerminalTokens.CONDICION) })
                  }
               }
            },
            {
               31, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.veriM), new
                        []
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE), tokensNameGlobal.selectorString
                              (tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)
                        })
                  }
               }
            },
            {
               32, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.VALORC), new
                        [] { tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), selectorString(nonTerminalTokens.veriM) })
                  }
               }
            },
            {
               33, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 34)
                  }
               }
            },
            {
               34, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.AND), new ReducedAction(selectorString(nonTerminalTokens.veriM),
                        new
                           []
                           {
                              tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE), tokensNameGlobal.selectorString
                                 (tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)
                           })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OR), new ReducedAction(selectorString(nonTerminalTokens.veriM),
                        new
                           []
                           {
                              tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE), tokensNameGlobal.selectorString
                                 (tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)
                           })
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.veriM), new
                        []
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE), tokensNameGlobal.selectorString
                              (tokensNameGlobal.tokensGlobals.PARENTESISCIERRA)
                        })
                  }
               }
            },
            {
               35, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.AND), new ReducedAction(selectorString(nonTerminalTokens.veriM),
                        new
                           [] { "Lambda" })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OR), new ReducedAction(selectorString(nonTerminalTokens.veriM),
                        new
                           [] { "Lambda" })
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.veriM), new
                        [] { "Lambda" })
                  }
               }
            },
            {
               36, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.AND), new ReducedAction(
                        selectorString(nonTerminalTokens.VALORBOOL),
                        new
                           []
                           {
                              tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), selectorString(nonTerminalTokens
                                 .veriM),
                              selectorString(nonTerminalTokens.COMPI)
                           })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OR), new ReducedAction(
                        selectorString(nonTerminalTokens.VALORBOOL),
                        new
                           []
                           {
                              tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), selectorString(nonTerminalTokens
                                 .veriM),
                              selectorString(nonTerminalTokens.COMPI)
                           })
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.VALORBOOL), new
                        []
                        {
                           tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador), selectorString(nonTerminalTokens
                              .veriM),
                           selectorString(nonTerminalTokens.COMPI)
                        })
                  }
               }
            },
            {
               37, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.AND), new ReducedAction(
                        selectorString(nonTerminalTokens.COMPI),
                        new
                           []
                           {
                              "Lambda"
                           })
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.OR), new ReducedAction(selectorString(nonTerminalTokens.COMPI),
                        new
                           [] { "Lambda" })
                  },
                  {
                     "FinCadena", new ReducedAction(selectorString(nonTerminalTokens.COMPI), new
                        [] { "Lambda" })
                  }
               }
            },
            {
               38, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     "FinCadena",
                     new ReducedAction(selectorString(nonTerminalTokens.CONDICION),
                        new[] { selectorString(nonTerminalTokens.VALORBOOL), selectorString(nonTerminalTokens.R) })
                  }
               }
            }
         };
   }
}
using System;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Compilador.Gramaticas;
using System.Collections.Generic;
using Compilador.AnalizadorSemantico;
using Compilador.IntentoCodigoIntermedio;
using Compilador.TablasGlobales;

namespace Compilador.AnalizadorSintactico.Gramaticas
{
   public class Gramatica_For : AbstractAnalisisTable
   {
      public enum notTerminalsForThis
      {
         FOR,
         INSTACIACION,
         CONDICIONF,
         INCDEC,
         CUERPOINSTRUCCIONES,
         VALOR,
         CONDICION,
         INCREMENTO
      }

      private static readonly string[] notTerminalSymbols =
      {
         "<for>",
         "instaciacion",
         "condicionf",
         "IncDec",
         "CuerpoInstrucciones",
         "valor",
         "condicion",
         "incremento"
      };

      private string tipoEncontrado;
      private string identificadorEncontrado;

      public Gramatica_For()
      {
         PilaComprobacion = new Stack<Tuple<int, string>>();
         PilaComprobacion.Push(new Tuple<int, string>(0, "0"));
         TablaAnalisis = new Dictionary<int, Dictionary<string, AbstractActionFunction>>()
         {
            {
               0, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.FOR),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 2)
                  },
                  {
                     "<FOR>", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 1)
                  }
               }
            },
            {
               2, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 3)
                  }
               }
            },
            {
               1, new Dictionary<string, AbstractActionFunction>()
               {
                  { "FinCadena", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.ACEPTACION, 1) }
               }
            },
            {
               3, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 5)
                  },
                  {
                     "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 6)
                  },
                  {
                     "INSTACIACION", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 4)
                  }
               }
            },
            {
               4, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 7)
                  }
               }
            },
            {
               5, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 8)
                  }
               }
            },
            {
               6, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA),
                     new ReducedAction("INSTACIACION", new[] { "Lambda" })
                  }
               }
            },
            {
               7, new Dictionary<string, AbstractActionFunction>()
               {
                  { "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 13) },
                  { "CONDICIONF", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 9) },
                  { "condicion", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 12) }
               }
            },
            {
               8, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Asignacion),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 10)
                  }
               }
            },
            {
               9, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 14)
                  }
               }
            },
            {
               10, new Dictionary<string, AbstractActionFunction>()
               {
                  { "Valores", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 11) },
               }
            },
            {
               11, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA),
                     new ReducedAction("INSTACIACION", new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.TIPO),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Asignacion),
                        "Valores"
                     })
                  }
               }
            },
            {
               12, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA),
                     new ReducedAction("CONDICIONF", new[] { "condicion" })
                  }
               }
            },
            {
               13, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA),
                     new ReducedAction("CONDICIONF", new[] { "Lambda" })
                  }
               }
            },
            {
               14, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 16)
                  },
                  { "Lambda", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 17) },
                  { "INCDEC", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 15) }
               }
            },
            {
               15, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 18)
                  }
               }
            },
            {
               16, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 24)
                  },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO), new AccionFuncion_TablaAnalisis
                        (AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 23)
                  },
                  {
                     "<INCREMENTO>", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 19)
                  }
               }
            },
            {
               17, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     new ReducedAction("INCDEC", new[] { "Lambda" })
                  }
               }
            },
            {
               18, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE),
                     new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.DESPLAZAMIENTO, 20)
                  }
               }
            },
            {
               19, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                     new ReducedAction("INCDEC", new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador),
                        "<INCREMENTO>"
                     })
                  }
               }
            },
            {
               20, new Dictionary<string, AbstractActionFunction>()
               {
                  { "<CUERTPOINSTRUCCIONES>", new AccionFuncion_TablaAnalisis(AbstractActionFunction.ActionEnum.GOTO, 21) },
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA), new ReducedAction("<CUERTPOINSTRUCCIONES>", new
                        [] { string.Empty })
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
                     "FinCadena", new ReducedAction("<FOR>", new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.FOR),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISABRE),
                        "INSTACIACION",
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA),
                        "CONDICIONF",
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PUNTOYCOMA),
                        "INCDEC",
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA),
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVEABRE),
                        "<CUERTPOINSTRUCCIONES>",
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA)
                     })
                  }
               }
            },
            {
               23, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction("<INCREMENTO>", new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.INCREMENTO)
                     })
                  }
               }
            },
            {
               24, new Dictionary<string, AbstractActionFunction>()
               {
                  {
                     tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.PARENTESISCIERRA), new ReducedAction("<INCREMENTO>", new[]
                     {
                        tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECREMENTO)
                     })
                  }
               }
            }
         };
      }

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

            if (AnalisisFinished) return "<for>";
         }

         return PilaComprobacion.Count.ToString();
      }

      private bool CheckTokenIn_Handler()
      {
         int referenceState = PilaComprobacion.Peek().Item1;
         HandleIdentifierAndType(referenceState);
         if (referenceState == 7 && PilaTokens.GlobalTokens.Peek() != "CONDICIONF")
         {
            string tokenAux = new GramaticaCondicion().EjecutarAnalisis();
            if (!string.IsNullOrEmpty(tokenAux))
               PilaTokens.GlobalTokens.Push(tokenAux);
         }

         if (referenceState == 10)
         {
            int inicioConteo = LexemaCount.CountLexemas + 1;
            var grammar = new GramaticaValores();
            string tokenAux2 = grammar.EjecutarAnalisis();
            if (!string.IsNullOrEmpty(tokenAux2))
            {
               PilaTokens.GlobalTokens.Push(tokenAux2);
               int finalConteo = LexemaCount.CountLexemas + 1;
               HandleValueOfLexema(inicioConteo, finalConteo, grammar._pilaContadores);
            }
         }

         if (referenceState == 20 && PilaTokens.GlobalTokens.Peek() != "cuerpoInstrucciones" && PilaTokens.GlobalTokens.Peek() != tokensNameGlobal
                .selectorString(tokensNameGlobal.tokensGlobals.LLAVECIERRA))
         {
            string tokenAux = new Gramatica_CuerpoInstrucciones().Ejecutar_Analisis();
            if (!string.IsNullOrEmpty(tokenAux))
            {
               PilaTokens.GlobalTokens.Push(tokenAux);
            }
         }

         if (TablaAnalisis[referenceState].ContainsKey(PilaTokens.GlobalTokens.Peek()))
         {
            AbstractActionFunction.ActionEnum actionEnum;
            actionEnum = TablaAnalisis[referenceState][PilaTokens.GlobalTokens.Peek()].Action;
            HandleActions(actionEnum);
            return true;
         }

         return false;
      }

      private void HandleIdentifierAndType(int referenceState)
      {
         switch (referenceState)
         {
            //Si el estado de referencia es el 5, entonces, se añade el tipo encontrado
            case 5:
               tipoEncontrado = TablaLexemaToken.GetLexema(LexemaCount.CountLexemas);
               break;
            case 8:
               identificadorEncontrado = TablaLexemaToken.GetLexema(LexemaCount.CountLexemas);
               CheckTheTypeOfIdentifier();
               break;
            case 16:
               if (PilaTokens.GlobalTokens.Peek() == "<INCREMENTO>")
                  break;
               identificadorEncontrado = TablaLexemaToken.GetLexema(LexemaCount.CountLexemas);
               if (!CheckIdentifiertype())
               {
                  Mensajes_ErroresSemanticos.AddErrorInstanciation(identificadorEncontrado, TablaLexemaToken.LexemaTokensTable[LexemaCount
                     .CountLexemas].Item1);
               }

               break;
         }
      }

      /// <summary>
      /// Comprueba si un identificador tiene un tipo asignado
      /// </summary>
      private bool CheckIdentifiertype()
      {
         return TablaSimbolos.CheckTypeOfLexema(identificadorEncontrado);
      }

      private void CheckTheTypeOfIdentifier()
      {
         if (!TablaSimbolos.CheckTypeOfLexema(identificadorEncontrado))
         {
            int numRow = TablaSimbolos.numRowInTable(identificadorEncontrado);
            TablaSimbolos.GetTypesValues()[numRow] = tipoEncontrado;
            TablaSimbolos.GetDesplazamientos()[numRow] = ContadorDesplazamiento.ConteoDesplazamiento.ToString();
            ContadorDesplazamiento.AddShiftType(tipoEncontrado);
            return;
         }

         ErrorSintaxManager.AddDeclarationError(identificadorEncontrado, TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item1);
      }

      private void HandleValueOfLexema(int incio, int final, Stack<Tuple<int, int>> pilaContadores)
      {
         if (TablaSimbolos.CheckTypeOfLexema(identificadorEncontrado))
         {
            int numRow = TablaSimbolos.numRowInTable(identificadorEncontrado);
            ConversionNotacionInfija_PosFija conversion = new ConversionNotacionInfija_PosFija(pilaContadores);
            EvaluadorNotacion_PosFija evaluacion = new EvaluadorNotacion_PosFija();
            conversion.ExecuteAnalysis(incio, final, tipoEncontrado);
            float resultadoEvaluacion = 0;
            if (CheckType(conversion.typeGlobalOfOperation))
            {
               if (conversion.ColaSalida.Count != 0)
               {
                  evaluacion.lexemaIdentifier = identificadorEncontrado;
                  resultadoEvaluacion = evaluacion.ExecuteEvaluation(conversion.ColaSalida);
                  TablaSimbolos.GetValues()[numRow] = resultadoEvaluacion.ToString();
                  
                  return;
               }
            }
         }

         ErrorSintaxManager.AddDeclarationError(identificadorEncontrado, TablaLexemaToken.LexemaTokensTable[LexemaCount.CountLexemas].Item1);
      }

      private bool CheckType(string type)
      {
         if (type == "int" || type == "float")
            return true;
         return false;
      }
   }
}
using System.Collections.Concurrent;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico;
using Compilador.TablasGlobales;

namespace Compilador.AnalizadorSemantico
{
   public class ConversionNotacionInfija_PosFija
   {
      #region datos privados para convertir

      private int inicioLexema;
      private int finLexema;

      /// <summary>
      /// Secuencia de numeros y operaciones
      /// </summary>
      private string[] stringSplited;

      /// <summary>
      /// Contenedor de los operadores
      /// </summary>
      private Dictionary<string, byte> nivelProcedenciaOperador;

      /// <summary>
      /// Cola que almacena la salida de la conversión de InFijo a PosFijo
      /// </summary>
      private Queue<string> outQueue = new Queue<string>();

      /// <summary>
      /// Pila que almacena los operadores encontrados
      /// </summary>
      private Stack<string> operatorsStack = new Stack<string>();

      private bool ThereAreAString = false;
      private bool ThereAreUnitaryToken = false;
      public string typeGlobalOfOperation = string.Empty;
      public Queue<string> ColaSalida;

      #endregion

      public ConversionNotacionInfija_PosFija()
      {
         nivelProcedenciaOperador = new Dictionary<string, byte>()
         {
            {
               "+", 1
            },
            {
               "-", 1
            },
            {
               "*", 2
            },
            {
               "/", 2
            },
            {
               "(", 0
            },
            {
               ")", 0
            }
         };
      }

      public void ExecuteAnalysis(int inicio, int final, string typeIdent)
      {
         inicioLexema = inicio;
         finLexema = final;
         // if (typeIdent == "string")
         // {
         //    ColaSalida = outQueue;
         //    return;
         // }

         Conversor(typeIdent);
         ColaSalida = outQueue;
      }


      public void EjecutarAnalisis(int inicio, int final)
      {
         inicioLexema = inicio;
         finLexema = final;
         Conversor();
         ColaSalida = outQueue;
      }

      #region Convertion wihtout string operation

      private void Conversor()
      {
         typeGlobalOfOperation = TablaRelacionTipoToken.TablaTokenTipo[TablaLexemaToken.LexemaTokensTable[inicioLexema].Item3];
         if (HandleUnitaryTokens(inicioLexema))
         {
            ThereAreUnitaryToken = true;
         }

         for (int i = inicioLexema; i < finLexema; i++)
         {
            string lexemaIn = TablaLexemaToken.LexemaTokensTable[i].Item2;
            if (int.TryParse(lexemaIn, out _))
            {
               if (HandleIntToken(i))
               {
                  outQueue.Enqueue(lexemaIn);
                  continue;
               }
            }

            if (float.TryParse(lexemaIn, out _))
            {
               if (HandleFloatToken(i))
               {
                  outQueue.Enqueue(lexemaIn);
                  continue;
               }
            }

            if (HandlerCharactersOperator(i))
            {
               if (ThereAreUnitaryToken)
               {
                  var rowLexemaToken = TablaLexemaToken.LexemaTokensTable[i];
                  Mensajes_ErroresSemanticos.AddErrorOperatro(typeGlobalOfOperation, TablaRelacionTipoToken.TablaTokenTipo[rowLexemaToken.Item3],
                     rowLexemaToken.Item1);
                  typeGlobalOfOperation = string.Empty;
                  outQueue.Clear();
                  return;
               }

               continue;
            }

            if (!CheckTypeOfLexema(i))
            {
               var rowLexemaToken = TablaLexemaToken.LexemaTokensTable[i];
               Mensajes_ErroresSemanticos.AddErrorOperatro(typeGlobalOfOperation, TablaRelacionTipoToken.TablaTokenTipo[rowLexemaToken.Item3],
                  rowLexemaToken.Item1);
               typeGlobalOfOperation = string.Empty;
               outQueue.Clear();
               return;
            }

            HandlerCharactersOperator(i);
         }

         if (operatorsStack.Count > 0)
            outQueue.Enqueue(operatorsStack.Pop());
      }

      private void Conversor(string typeIdent)
      {
         typeGlobalOfOperation = typeIdent;
         if (HandleUnitaryTokens(inicioLexema))
         {
            ThereAreUnitaryToken = true;
         }

         for (int i = inicioLexema; i < finLexema; i++)
         {
            string lexemaIn = TablaLexemaToken.LexemaTokensTable[i].Item2;
            if (int.TryParse(lexemaIn, out _))
            {
               if (HandleIntToken(i))
               {
                  outQueue.Enqueue(lexemaIn);
                  continue;
               }
            }

            if (float.TryParse(lexemaIn, out _))
            {
               if (HandleFloatToken(i))
               {
                  outQueue.Enqueue(lexemaIn);
                  continue;
               }
            }

            if (HandlerCharactersOperator(i))
            {
               continue;
            }

            if (HandleStringToken(i))
            {
               typeGlobalOfOperation = "string";
            }

            if (!CheckTypeOfLexema(i))
            {
               var rowLexemaToken = TablaLexemaToken.LexemaTokensTable[i];
               Mensajes_ErroresSemanticos.AddErrorOperatro(typeGlobalOfOperation, TablaRelacionTipoToken.TablaTokenTipo[rowLexemaToken.Item3],
                  rowLexemaToken.Item1);
               typeGlobalOfOperation = string.Empty;
               outQueue.Clear();
               return;
            }
         }

         if (operatorsStack.Count > 0)
            outQueue.Enqueue(operatorsStack.Pop());
      }

      #endregion

      private bool CheckTypeOfLexema(int posicionTabla)
      {
         //Checka si el token, no es del tipo unitario, es decir, solo si es boleano o caracter
         if (HandleUnitaryTokens(posicionTabla))
         {
            typeGlobalOfOperation = TablaRelacionTipoToken.TablaTokenTipo[TablaLexemaToken.LexemaTokensTable[posicionTabla].Item3];
            return true;
         }

         //En caso de que no sea unitario, checa si es del mismo tipo
         if (TablaRelacionTipoToken.TablaTokenTipo.ContainsKey(TablaLexemaToken.LexemaTokensTable[posicionTabla].Item3))
         {
            string typeReference = TablaRelacionTipoToken.TablaTokenTipo[TablaLexemaToken.LexemaTokensTable[posicionTabla].Item3];
            if (typeReference == typeGlobalOfOperation)
            {
               return true;
            }
         }

         //Si no son del mismo tipo, entonces, checa si es un identificador
         if (TablaLexemaToken.LexemaTokensTable[posicionTabla].Item3 == tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.Identificador))
         {
            if (!HandleIdentifier(TablaLexemaToken.LexemaTokensTable[posicionTabla].Item2))
               return false;
            return true;
         }

         return false;
      }


      private bool HandleUnitaryTokens(int posicionTabla)
      {
         if (TablaRelacionTipoToken.TablaTokenTipo.ContainsKey(TablaLexemaToken.LexemaTokensTable[posicionTabla].Item3))
         {
            string typeReference = TablaRelacionTipoToken.TablaTokenTipo[TablaLexemaToken.LexemaTokensTable[posicionTabla].Item3];
            if (typeReference == "bool" || typeReference == "char")
            {
               return true;
            }
         }

         return false;
      }

      private bool HandleIntToken(int posicioinTabla)
      {
         if (TablaRelacionTipoToken.TablaTokenTipo[TablaLexemaToken.LexemaTokensTable[posicioinTabla].Item3] == typeGlobalOfOperation)
         {
            return true;
         }

         return false;
      }

      private bool HandleFloatToken(int posicionTabla)
      {
         string typeReference = TablaRelacionTipoToken.TablaTokenTipo[TablaLexemaToken.LexemaTokensTable[posicionTabla].Item3];
         if (typeReference == typeGlobalOfOperation)
         {
            return true;
         }

         if (typeReference == "int")
         {
            return true;
         }

         return false;
      }

      private bool HandleIdentifier(string identifier)
      {
         if (TablaSimbolos.CheckTypeOfLexema(identifier))
         {
            int numRow = TablaSimbolos.numRowInTable(identifier);
            if (TablaSimbolos.GetValues()[numRow] != string.Empty)
            {
               if (HandleIntFloatOfIdentifier(numRow))
               {
                  string valueOfIdentifier = TablaSimbolos.GetValues()[numRow];
                  if (int.TryParse(valueOfIdentifier, out _))
                  {
                     outQueue.Enqueue(valueOfIdentifier);
                     return true;
                  }

                  if (float.TryParse(valueOfIdentifier, out _))
                  {
                     outQueue.Enqueue(valueOfIdentifier);
                     return true;
                  }
                  
               }

               return true;
            }

            if (TablaRelacionTipoToken.TablaTipoToken.ContainsValue(TablaSimbolos.GetTypeOfLexema(identifier)))
            {
               if(typeGlobalOfOperation == TablaSimbolos.GetTypesValues()[numRow])
                  return true;
               return false;
            }
         }

         return false;
      }

      private bool HandleStringToken(int posicionTabla)
      {
         if (TablaRelacionTipoToken.TablaTokenTipo.ContainsKey(TablaLexemaToken.LexemaTokensTable[posicionTabla].Item3))
         {
            string typeReference = TablaRelacionTipoToken.TablaTokenTipo[TablaLexemaToken.LexemaTokensTable[posicionTabla].Item3];

            if (typeReference == "string")
            {
               return true;
            }
         }

         return false;
      }

      /// <summary>
      /// Maneja las entradas de "(" y cuando la pila no tiene nada, y las reglas de conversion
      /// </summary>
      /// <param name="i"></param>
      private bool HandlerCharactersOperator(int i)
      {
         if (TablaLexemaToken.LexemaTokensTable[i].Item2 == "(")
         {
            operatorsStack.Push(TablaLexemaToken.LexemaTokensTable[i].Item2);
            return true;
         }

         if (operatorsStack.Count == 0 && TablaLexemaToken.LexemaTokensTable[i].Item2.Length == 1)
         {
            operatorsStack.Push(TablaLexemaToken.LexemaTokensTable[i].Item2);
            return true;
         }

         if (nivelProcedenciaOperador.ContainsKey(TablaLexemaToken.LexemaTokensTable[i].Item2))
         {
            if (OperationWithStackAndQueue(i))
            {
               return true;
            }
         }

         return false;
      }

      /// <summary>
      /// Se encarga de ejecutar las reglas de conversión
      /// </summary>
      /// <param name="i">Posición del lexema a analizar</param>
      private bool OperationWithStackAndQueue(int i)
      {
         if (nivelProcedenciaOperador[TablaLexemaToken.LexemaTokensTable[i].Item2] == nivelProcedenciaOperador[operatorsStack.Peek()])
         {
            outQueue.Enqueue(operatorsStack.Pop());
            operatorsStack.Push(TablaLexemaToken.LexemaTokensTable[i].Item2);
            return true;
         }

         if (nivelProcedenciaOperador[TablaLexemaToken.LexemaTokensTable[i].Item2] > nivelProcedenciaOperador[operatorsStack.Peek()])
         {
            operatorsStack.Push(TablaLexemaToken.LexemaTokensTable[i].Item2);
            return true;
         }

         if (nivelProcedenciaOperador[TablaLexemaToken.LexemaTokensTable[i].Item2] < nivelProcedenciaOperador[operatorsStack.Peek()])
         {
            while (operatorsStack.Count > 0 && operatorsStack.Peek() != "(")
            {
               outQueue.Enqueue(operatorsStack.Pop());
            }

            if (operatorsStack.Count > 0 && operatorsStack.Peek() == "(")
            {
               operatorsStack.Pop();
            }

            if (TablaLexemaToken.LexemaTokensTable[i].Item2 != ")")
               operatorsStack.Push(TablaLexemaToken.LexemaTokensTable[i].Item2);
            return true;
         }

         return false;
      }

      private bool HandleIntFloatOfIdentifier(int numRowOfTable)
      {
         if (TablaSimbolos.GetTypesValues()[numRowOfTable] == "int" || TablaSimbolos.GetTypesValues()[numRowOfTable] == "float")
         {
            return true;
         }

         return false;
      }
   }
}
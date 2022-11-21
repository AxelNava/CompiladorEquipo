using System;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Compilador.TablasGlobales;

namespace Compilador
{
   internal class AutomatasLexicos
   {
      #region VariablesParaAutomata

      public AutomatasLexicos(string Alltext)
      {
         VariablesGlobalesAutomatas.CharCodeText = Alltext.ToCharArray();
         //This line is just for get the lenght of text but not asign anything to "LenghtText"
         VariablesGlobalesAutomatas.LengthText = 0;
      }

      public string messasgesErros;

      #endregion

      /// <summary>
      /// The first value is the lexema and the second is the token
      /// </summary>
      List<string[]> tokenTableList = new List<string[]>();

      private int _countLines;
      private int _lexemaCount;
      /// <summary>
      /// Execute the analizer to check all the lexemas and asign their token
      /// </summary>
      /// <returns>A list of lexemas with token</returns>
      public List<string[]> ExecuteAnalizer()
      {
         _lexemaCount = 0;
         TablaLexemaToken.ClearTable();
         tokenTableList.Clear();
         messasgesErros = String.Empty;
         _countLines = 1;
         VariablesGlobalesAutomatas.LengthText = VariablesGlobalesAutomatas.CharCodeText.Length;
         VariablesGlobalesAutomatas.LastIndexFound = 0;
         for (int i = 0; i < VariablesGlobalesAutomatas.LengthText; i++)
         {
            char letter = VariablesGlobalesAutomatas.CharCodeText[i];
            string token;
            //Check if the character is a letter between a-z and A-Z or begins with "_"
            if (letter >= 65 && letter <= 90 || letter >= 97 && letter <= 122 || letter == '_')
            {
               token = Q25(i);
               string lexema = subcadena(i, VariablesGlobalesAutomatas.LastIndexFound);
               string tokenFromSymbolTable = TablaSimbolos.GetTokenName(lexema);
               _lexemaCount++;
               if (tokenFromSymbolTable == string.Empty)
               {
                  tokenTableList.Add(new string[] { lexema, token });
                  TablaSimbolos.AddLexema(lexema, token, _countLines);
                  i = VariablesGlobalesAutomatas.LastIndexFound;
                  TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount, _countLines, lexema, token);
                  continue;
               }
               tokenTableList.Add(new string[] { lexema, tokenFromSymbolTable });
               i = VariablesGlobalesAutomatas.LastIndexFound;
               TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount, _countLines, lexema, tokenFromSymbolTable);
               continue;
            }

            if (char.IsDigit(letter))
            {
               token = Q26(i);
               string lexema = subcadena(i, VariablesGlobalesAutomatas.LastIndexFound);
               if (token != string.Empty)
               {
                  _lexemaCount++;
                  tokenTableList.Add(new string[] { lexema, token });
                  i = VariablesGlobalesAutomatas.LastIndexFound;
                  TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount, _countLines, lexema, token);
                  continue;
               }
            }
            else
            {
               string lexema;
               //Find the first state of each automat, except the numbers and identifiers
               switch (letter)
               {
                  case '/':
                     token = Q8(i);
                     if (token == "Operador")
                     {
                        _lexemaCount++;
                        tokenTableList.Add(new string[] { letter.ToString(), token });
                        
                        //Agrega el lexema encontrado a la tabla que contiene los lexemas y los tokens con sus números de líneas
                        TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount, _countLines, "/", token);
                     }
                     break;
                  case '-':
                     token = Q14(i);
                     _lexemaCount++;
                     if (token != "Operador")
                     {
                        lexema = string.Concat(VariablesGlobalesAutomatas.CharCodeText[i],
                           VariablesGlobalesAutomatas.CharCodeText[VariablesGlobalesAutomatas.LastIndexFound]);
                        tokenTableList.Add(new []
                        {
                          lexema,
                           token
                        });
                        TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount, _countLines, lexema, token);
                        
                     }
                     else
                     {
                        TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount, _countLines, "-", token);
                        tokenTableList.Add(new string[] { letter.ToString(), token });
                        
                     }
                     
                     break;
                  case '*':
                  case '%':
                  case '^':
                     _lexemaCount++;
                     //Add to the diccionary the lexema and the token
                     TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount,_countLines, letter.ToString(), "Operador");
                     tokenTableList.Add(new string[] { letter.ToString(), "Operador" });
                     continue;
                  case '+':
                     token = Q16(i);
                     _lexemaCount++;
                     if (token != "Operador")
                     {
                        lexema = string.Concat(VariablesGlobalesAutomatas.CharCodeText[i],
                           VariablesGlobalesAutomatas.CharCodeText[VariablesGlobalesAutomatas.LastIndexFound]);
                        tokenTableList.Add(new string[]
                        {
                           lexema,
                           token
                        });
                      TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount, _countLines, lexema, token);  
                     }
                     else
                     {
                        tokenTableList.Add(new string[] { letter.ToString(), token });
                        TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount, _countLines, "+", token);
                     }
                     break;
                  case '(':
                     tokenTableList.Add(new string[] { letter.ToString(), "ParentesisAbre" });
                     _lexemaCount++;
                     TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount, _countLines, "(", "ParentesisAbre");
                     continue;
                  case ')':
                     tokenTableList.Add(new string[] { letter.ToString(), "ParentesisCierra" });
                     _lexemaCount++;
                     TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount, _countLines, ")", "ParentesisCierra");
                     continue;
                  case '{':
                     tokenTableList.Add(new string[] { letter.ToString(), "LlaveAbre" });
                     _lexemaCount++;
                     TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount, _countLines, "{", "LlaveAbre");
                     continue;
                  case '}':
                     tokenTableList.Add(new string[] { letter.ToString(), "LlaveCierra" });
                     _lexemaCount++;
                     TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount, _countLines, "}", "LlaveCierra");
                     continue;
                  case '[':
                     tokenTableList.Add(new string[] { letter.ToString(), "CorcheteAbre" });
                     _lexemaCount++;
                     TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount, _countLines, "[", "CorcheteAbre");
                     continue;
                  case ']':
                     tokenTableList.Add(new string[] { letter.ToString(), "CorcheteCierra" });
                     _lexemaCount++;
                     TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount, _countLines, "]", "CorcheteCierra");
                     continue;
                  case ';':
                     tokenTableList.Add(new string[] { letter.ToString(), "PuntoyComa" });
                     _lexemaCount++;
                     TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount, _countLines, ";", "PuntoyComa");
                     continue;
                  case ',':
                     tokenTableList.Add(new[] { letter.ToString(), "Coma" });
                     _lexemaCount++;
                     TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount, _countLines, ",", "Coma");
                     continue;;
                  case ':':
                     tokenTableList.Add(new[] { letter.ToString(), "DosPuntos" });
                     _lexemaCount++;
                     TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount, _countLines, ":", "DosPuntos");
                     continue;
                  case '\"':
                     token = Q18(i);
                     lexema = subcadena(i, VariablesGlobalesAutomatas.LastIndexFound);
                     tokenTableList.Add(new string[] { lexema, token });
                     _lexemaCount++;
                     TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount, _countLines, lexema, token);
                     break;
                  case '\'':
                     token = Q19(i);
                     lexema = subcadena(i, VariablesGlobalesAutomatas.LastIndexFound);
                     tokenTableList.Add(new string[] { lexema, token });
                     _lexemaCount++;
                     TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount, _countLines, lexema, token);
                     break;
                  case '!':
                     token = Q20(i);
                     lexema = subcadena(i, VariablesGlobalesAutomatas.LastIndexFound);
                     tokenTableList.Add(new string[] { lexema, token });
                     _lexemaCount++;
                     TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount, _countLines, lexema, token);
                     break;
                  case '<':
                  case '>':
                     token = Q21(i);
                     lexema = subcadena(i, VariablesGlobalesAutomatas.LastIndexFound);
                     tokenTableList.Add(new string[] { lexema, token });
                     _lexemaCount++;
                     TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount, _countLines, lexema, token);
                     break;
                  case '=':
                     token = Q22(i);
                     lexema = subcadena(i, VariablesGlobalesAutomatas.LastIndexFound);
                     tokenTableList.Add(new string[] { lexema, token });
                     _lexemaCount++;
                     TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount, _countLines, lexema, token);
                     break;
                  case '&':
                     token = Q23(i);
                     lexema = subcadena(i, VariablesGlobalesAutomatas.LastIndexFound);
                     tokenTableList.Add(new string[] { lexema, token });
                     _lexemaCount++;
                     TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount, _countLines, lexema, token);
                     break;
                  case '|':
                     token = Q24(i);
                     lexema = subcadena(i, VariablesGlobalesAutomatas.LastIndexFound);
                     tokenTableList.Add(new string[] { lexema, token });
                     _lexemaCount++;
                     TablaLexemaToken.AddLexemaTokenToTable(_lexemaCount, _countLines, lexema, token);
                     break;
                  case '\n':
                     _countLines++;
                     continue;
                  case '\r':
                     continue;
                  case ' ':
                     continue;
                  default:
                     messasgesErros += String.Format("Caracter no reconocido: {0}  --- Linea: {1}", VariablesGlobalesAutomatas.CharCodeText[i],
                        _countLines);
                     continue;
                  //lastIndexFound++;
               }
            }

            i = VariablesGlobalesAutomatas.LastIndexFound;
         }

         return tokenTableList;
      }

      #region AutomatasAxel

      //This region covers Q7 to Q12

      #region AutomataComentario_Operador

      /// <summary>
      /// This method analize whether the text is a line comment, if not, call Q10
      /// </summary>
      /// <param name="stringText">Is the text to analice</param>
      /// <returns>The token of line Comment, multi line comment, or operator "/"</returns>
      public string Q8(int indexString)
      {
         if ((indexString + 1) < VariablesGlobalesAutomatas.LengthText)
         {
            if (VariablesGlobalesAutomatas.CharCodeText[++indexString].Equals('/'))
            {
               VariablesGlobalesAutomatas.LastIndexFound = indexString;
               return Q9(++indexString);
            }

            return Q10(indexString);
         }
         else
         {
            VariablesGlobalesAutomatas.LastIndexFound = indexString;
            return "Operador";
         }
      }

      public string Q9(int indexString)
      {
         for (int i = indexString; i < VariablesGlobalesAutomatas.LengthText; i++)
         {
            if (VariablesGlobalesAutomatas.CharCodeText[i].Equals('\n'))
            {
               _countLines++;
               VariablesGlobalesAutomatas.LastIndexFound = indexString;
               return "ComentarioLinea";
            }
         }

         return "ComentarioLinea";
      }

      /// <summary>
      /// Determine if the text begins with "*", if not, is an operator "/"
      /// </summary>
      /// <param name="stringText">Is the text to analice</param>
      /// <returns>The token of Multi line comment or operator "/"</returns>
      public string Q10(int indexString)
      {
         if (VariablesGlobalesAutomatas.CharCodeText[indexString].Equals('*'))
         {
            VariablesGlobalesAutomatas.LastIndexFound = indexString;
            return Q11(++indexString);
         }

         VariablesGlobalesAutomatas.LastIndexFound = --indexString;
         return "Operador";
      }

      /// <summary>
      /// Determine if the text recived begins with "/", that defined the end of the commend
      /// </summary>
      /// <param name="stringText">Is the text to analice</param>
      /// <returns>The token of Multi line comment</returns>
      /// <exception cref="Exception">If the end of the line there aren't any termination of the comment</exception>
      public string Q11(int indexString)
      {
         if (indexString >= VariablesGlobalesAutomatas.LengthText)
         {
            messasgesErros += string.Format("Se esperaba */ -- Linea {0}\n", _countLines);
            return String.Empty;
         }

         for (int i = indexString; i < VariablesGlobalesAutomatas.CharCodeText.Length; i++)
         {
            if (VariablesGlobalesAutomatas.CharCodeText[i].Equals('\n'))
               _countLines++;
            if (VariablesGlobalesAutomatas.CharCodeText[i] == '*')
            {
               VariablesGlobalesAutomatas.LastIndexFound = i;
               try
               {
                  if (Q12(VariablesGlobalesAutomatas.CharCodeText[i + 1]))
                  {
                     return "ComentarioMultilinea";
                  }
                  else
                  {
                     continue;
                  }
               }
               catch (Exception)
               {
               }
            }
         }

         messasgesErros += string.Format("Se esperaba */ -- Linea {0}\n", _countLines);
         return String.Empty;
      }

      /// <summary>
      /// Verify wheter the character is the end of comment
      /// </summary>
      public bool Q12(char character)
      {
         VariablesGlobalesAutomatas.LastIndexFound++;
         return character.Equals('/') ? true : false;
      }

      #endregion

      #region OperadorMinus_OperadorDecremento

      /// <summary>
      /// The state Q14 analice wheter the character is a "-", if not, is an operator
      /// </summary>
      /// <param name="stringText">The text to analice</param>
      /// <returns>The token "Operador" or "Decremento"</returns>
      public string Q14(int indexString)
      {
         if ((indexString + 1) < VariablesGlobalesAutomatas.LengthText)
         {
            if (VariablesGlobalesAutomatas.CharCodeText[++indexString].Equals('-'))
            {
               VariablesGlobalesAutomatas.LastIndexFound = indexString;
               return "Decremento";
            }

            VariablesGlobalesAutomatas.LastIndexFound = --indexString;
            return "Operador";
         }
         else
         {
            VariablesGlobalesAutomatas.LastIndexFound = indexString;
            //This is the case when its the last character
            return "Operador";
         }
      }

      #endregion

      #region Incremento_Suma_Operadores

      /// <summary>
      /// The state Q16 analice wheter the character is a "+", if not, is an operator
      /// </summary>
      /// <param name="stringText">The text to analice</param>
      /// <returns>The token "Operador" or "Incremento"</returns>
      public string Q16(int indexString)
      {
         if ((indexString + 1) < VariablesGlobalesAutomatas.LengthText)
         {
            if (VariablesGlobalesAutomatas.CharCodeText[++indexString].Equals('+'))
            {
               VariablesGlobalesAutomatas.LastIndexFound = indexString;
               return "Incremento";
            }

            VariablesGlobalesAutomatas.LastIndexFound = --indexString;
            return "Operador";
         }
         else
         {
            VariablesGlobalesAutomatas.LastIndexFound = indexString;
            //This is the case when its the last character
            return "Operador";
         }
      }

      #endregion

      #endregion

      #region AutomatasYahir

      //Negacion
      public string Q20(int indexString)
      {
         if (++indexString < VariablesGlobalesAutomatas.LengthText)
         {
            if (VariablesGlobalesAutomatas.CharCodeText[indexString] == '=')
            {
               VariablesGlobalesAutomatas.LastIndexFound = indexString;
               return "Comparador";
            }
            else
            {
               VariablesGlobalesAutomatas.LastIndexFound = indexString - 1;
               return "Negacion";
            }
         }
         else
         {
            VariablesGlobalesAutomatas.LastIndexFound = indexString - 1;
            return "Negacion";
         }
      }

      //Comparador mayor que menor que
      public string Q21(int indexString)
      {
         if (++indexString < VariablesGlobalesAutomatas.LengthText)
         {
            if (VariablesGlobalesAutomatas.CharCodeText[indexString] == '=')
            {
               VariablesGlobalesAutomatas.LastIndexFound = indexString;
               return "Comparador";
            }
            else
            {
               VariablesGlobalesAutomatas.LastIndexFound = indexString - 1;
               return "Comparador";
            }
         }
         else
         {
            VariablesGlobalesAutomatas.LastIndexFound = indexString - 1;
            return "Comparador";
         }
      }

      //Comparador igual y asignador
      public string Q22(int indexString)
      {
         if (++indexString < VariablesGlobalesAutomatas.LengthText)
         {
            if (VariablesGlobalesAutomatas.CharCodeText[indexString] == '=')
            {
               VariablesGlobalesAutomatas.LastIndexFound = indexString;
               return "Comparador";
            }
            else
            {
               VariablesGlobalesAutomatas.LastIndexFound = indexString - 1;
               return "Asignacion";
            }
         }
         else
         {
            VariablesGlobalesAutomatas.LastIndexFound = indexString - 1;
            return "Asignacion";
         }
      }

      //Comparador de &&
      public string Q23(int indexString)
      {
         if (++indexString < VariablesGlobalesAutomatas.LengthText)
         {
            if (VariablesGlobalesAutomatas.CharCodeText[indexString] == '&')
            {
               VariablesGlobalesAutomatas.LastIndexFound = indexString;
               return "AND";
            }
            else
            {
               //Mensaje de error
               messasgesErros += String.Format("Hace falta un : \"&\"  -- Linea: {0}  \n", _countLines);
               VariablesGlobalesAutomatas.LastIndexFound = indexString - 1;
               return string.Empty;
            }
         }
         else
         {
            //Mensaje de error
            messasgesErros += String.Format("Hace falta un : \"&\"  -- Linea: {0}  \n", _countLines);
            VariablesGlobalesAutomatas.LastIndexFound = indexString - 1;
            return string.Empty;
         }
      }

      //comparador de ||
      public string Q24(int indexString)
      {
         if (++indexString < VariablesGlobalesAutomatas.LengthText)
         {
            if (VariablesGlobalesAutomatas.CharCodeText[indexString] == '|')
            {
               VariablesGlobalesAutomatas.LastIndexFound = indexString;
               return "OR";
            }
            else
            {
               //Mensaje de error
               messasgesErros += String.Format("Hace falta un : \"|\"  -- Linea: {0}  \n", _countLines);
               VariablesGlobalesAutomatas.LastIndexFound = indexString - 1;
               return string.Empty;
            }
         }
         else
         {
            //Mensaje de error
            messasgesErros += String.Format("Hace falta un : \"|\"  -- Linea: {0}  \n", _countLines);
            VariablesGlobalesAutomatas.LastIndexFound = indexString - 1;
            return string.Empty;
         }
      }

      //Comparador de identificadores
      public string Q25(int indexString)
      {
         for (int i = indexString; i < VariablesGlobalesAutomatas.LengthText; i++)
         {
            if (!(VariablesGlobalesAutomatas.CharCodeText[i] >= 65 && VariablesGlobalesAutomatas.CharCodeText[i] <= 90 ||
                  VariablesGlobalesAutomatas.CharCodeText[i] >= 97 && VariablesGlobalesAutomatas.CharCodeText[i] <= 122) &&
                VariablesGlobalesAutomatas.CharCodeText[i] != '_' && !char.IsDigit(VariablesGlobalesAutomatas.CharCodeText[i]))
            {
               VariablesGlobalesAutomatas.LastIndexFound = i - 1;
               return "Identificador";
            }
         }

         VariablesGlobalesAutomatas.LastIndexFound = VariablesGlobalesAutomatas.LengthText - 1;
         return "Identificador";
      }

      //Comparador de números
      public string Q26(int indexString)
      {
         for (int i = indexString; i < VariablesGlobalesAutomatas.LengthText; i++)
         {
            if (!char.IsDigit(VariablesGlobalesAutomatas.CharCodeText[i]))
            {
               return Q27(i);
            }
         }

         VariablesGlobalesAutomatas.LastIndexFound = VariablesGlobalesAutomatas.LengthText - 1;
         return "Entero";
      }

      public string Q27(int indexString)
      {
         if (VariablesGlobalesAutomatas.CharCodeText[indexString] == '.')
         {
            return Q28(++indexString);
         }
         else
         {
            VariablesGlobalesAutomatas.LastIndexFound = indexString - 1;
            return "Entero";
         }
      }

      public string Q28(int indexString)
      {
         if (indexString < VariablesGlobalesAutomatas.LengthText)
         {
            if (char.IsDigit(VariablesGlobalesAutomatas.CharCodeText[indexString]))
            {
               return Q29(indexString);
            }
         }

         VariablesGlobalesAutomatas.LastIndexFound = indexString - 1;
         messasgesErros += string.Format("Se esperaba un número después del \'.\' -- Linea: {0}", _countLines);
         return string.Empty;
      }

      public string Q29(int indexString)
      {
         for (int i = indexString; i < VariablesGlobalesAutomatas.LengthText; i++)
         {
            if (!char.IsDigit(VariablesGlobalesAutomatas.CharCodeText[i]))
            {
               if (VariablesGlobalesAutomatas.CharCodeText[i] == '.')
               {
                  messasgesErros += String.Format("Caracter no reconocido : {0} -- Linea: {1}", VariablesGlobalesAutomatas.CharCodeText[i],
                     _countLines);
                  VariablesGlobalesAutomatas.LastIndexFound = i - 1;
                  return string.Empty;
               }

               VariablesGlobalesAutomatas.LastIndexFound = i - 1;
               return "Decimal";
            }
         }

         VariablesGlobalesAutomatas.LastIndexFound = VariablesGlobalesAutomatas.LengthText - 1;
         return "Decimal";
      }

      #endregion

      //Analiza las cadenas
      public string Q18(int indexString)
      {
         for (int i = ++indexString; i < VariablesGlobalesAutomatas.CharCodeText.Length; i++)
         {
            try
            {
               if (VariablesGlobalesAutomatas.CharCodeText[i] == '\"')
               {
                  VariablesGlobalesAutomatas.LastIndexFound = i;
                  return "Cadena";
               }
            }
            catch (Exception)
            {
               throw;
            }
         }

         VariablesGlobalesAutomatas.LastIndexFound = VariablesGlobalesAutomatas.LengthText - 1;
         messasgesErros += String.Format("Se esperaba \" para cerrar cadena -- Linea:{0} \n", _countLines);
         return String.Empty;
      }

      public string subcadena(int inicio, int final)
      {
         string palabra = string.Empty;
         for (int i = inicio; i <= final; i++)
         {
            palabra += VariablesGlobalesAutomatas.CharCodeText[i].ToString();
         }

         return palabra;
      }

      public string Q19(int indexString)
      {
         if (++indexString < VariablesGlobalesAutomatas.LengthText)
         {
            if (VariablesGlobalesAutomatas.CharCodeText[indexString] == '\'')
            {
               VariablesGlobalesAutomatas.LastIndexFound = indexString;
               return "Caracter";
            }

            if (++indexString < VariablesGlobalesAutomatas.LengthText && VariablesGlobalesAutomatas.CharCodeText[indexString] == '\'')
            {
               VariablesGlobalesAutomatas.LastIndexFound = indexString;
               return "Caracter";
            }
            else
            {
               //Mensaje de error
               VariablesGlobalesAutomatas.LastIndexFound = indexString - 1;
               messasgesErros += String.Format("Hace falta cierre de caracter '  -- Linea: {0}  \n", _countLines);
            }
         }
         else
         {
            VariablesGlobalesAutomatas.LastIndexFound = indexString - 1;
            //Mensaje de error
            messasgesErros += String.Format("Hace falta cierre de caracter '  -- Linea: {0}  \n", _countLines);
            return string.Empty;
         }

         return string.Empty;
      }
   }
}
using System;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;

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

      int countLines;

      /// <summary>
      /// Execute the analizer to check all the lexemas and asign their token
      /// </summary>
      /// <returns>A list of lexemas with token</returns>
      public List<string[]> ExecuteAnalizer()
      {
         PilaTokens.numLineToken.Clear();
         tokenTableList.Clear();
         messasgesErros = String.Empty;
         countLines = 1;
         VariablesGlobalesAutomatas.LengthText = VariablesGlobalesAutomatas.CharCodeText.Length;
         Console.WriteLine("Tamaño de texto: {0}", VariablesGlobalesAutomatas.LengthText);
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
               if (tokenFromSymbolTable == string.Empty)
               {
                  tokenTableList.Add(new string[] { lexema, token });
                  PilaTokens.numLineToken.Add(new Tuple<int, string>(countLines, token));
                  TablaSimbolos.AddLexema(lexema, token, countLines);
                  i = VariablesGlobalesAutomatas.LastIndexFound;
                  continue;
               }
               else
               {
                  tokenTableList.Add(new string[] { lexema, tokenFromSymbolTable });
                  PilaTokens.numLineToken.Add(new Tuple<int, string>(countLines, token));
                  i = VariablesGlobalesAutomatas.LastIndexFound;
                  continue;
               }
            }

            if (char.IsDigit(letter))
            {
               token = Q26(i);
               string lexema = subcadena(i, VariablesGlobalesAutomatas.LastIndexFound);
               if (token != string.Empty)
               {
                  PilaTokens.numLineToken.Add(new Tuple<int, string>(countLines, token));
                  tokenTableList.Add(new string[] { lexema, token });
                  i = VariablesGlobalesAutomatas.LastIndexFound;
                  continue;
               }
            }
            else
            {
               //Find the first state of each automat, except the numbers and identifiers
               switch (letter)
               {
                  case '/':
                     token = Q8(i);
                     if (token == "Operador")
                     {
                        tokenTableList.Add(new string[] { letter.ToString(), token });
                        PilaTokens.numLineToken.Add(new Tuple<int, string>(countLines, token));
                     }
                     break;
                  case '-':
                     token = Q14(i);
                     if (token != "Operador")
                     {
                        tokenTableList.Add(new string[]
                        {
                           string.Concat(VariablesGlobalesAutomatas.CharCodeText[i],
                              VariablesGlobalesAutomatas.CharCodeText[VariablesGlobalesAutomatas.LastIndexFound]),
                           token
                        });
                        PilaTokens.numLineToken.Add(new Tuple<int, string>(countLines, token));
                     }
                     else
                     {
                        tokenTableList.Add(new string[] { letter.ToString(), token });
                        PilaTokens.numLineToken.Add(new Tuple<int, string>(countLines, token));
                     }
                     break;
                  case '*':
                  case '%':
                  case '^':
                     //Add to the diccionary the lexema and the token
                     PilaTokens.numLineToken.Add(new Tuple<int, string>(countLines, "Operador"));
                     tokenTableList.Add(new string[] { letter.ToString(), "Operador" });
                     continue;
                  case '+':
                     token = Q16(i);
                     if (token != "Operador")
                     {
                        tokenTableList.Add(new string[]
                        {
                           string.Concat(VariablesGlobalesAutomatas.CharCodeText[i],
                              VariablesGlobalesAutomatas.CharCodeText[VariablesGlobalesAutomatas.LastIndexFound]),
                           token
                        });
                        PilaTokens.numLineToken.Add(new Tuple<int, string>(countLines, token));
                     }
                     else
                     {
                        tokenTableList.Add(new string[] { letter.ToString(), token });
                        PilaTokens.numLineToken.Add(new Tuple<int, string>(countLines,token));
                     }

                     break;
                  case '(':
                     PilaTokens.numLineToken.Add(new Tuple<int, string>(countLines, "ParentesisAbre"));
                     tokenTableList.Add(new string[] { letter.ToString(), "ParentesisAbre" });
                     continue;
                  case ')':
                     PilaTokens.numLineToken.Add(new Tuple<int, string>(countLines, "ParentesisAbre"));
                     tokenTableList.Add(new string[] { letter.ToString(), "ParentesisCierra" });
                     continue;
                  case '{':
                     PilaTokens.numLineToken.Add(new Tuple<int, string>(countLines, "LlaveAbre"));
                     tokenTableList.Add(new string[] { letter.ToString(), "LlaveAbre" });
                     continue;
                  case '}':
                     PilaTokens.numLineToken.Add(new Tuple<int, string>(countLines, "LlaveCierra"));
                     tokenTableList.Add(new string[] { letter.ToString(), "LlaveCierra" });
                     continue;
                  case '[':
                     PilaTokens.numLineToken.Add(new Tuple<int, string>(countLines, "CorcheteAbre"));
                     tokenTableList.Add(new string[] { letter.ToString(), "CorcheteAbre" });
                     continue;
                  case ']':
                     PilaTokens.numLineToken.Add(new Tuple<int, string>(countLines, "CorcheteCierra"));
                     tokenTableList.Add(new string[] { letter.ToString(), "CorcheteCierra" });
                     continue;
                  case ';':
                     PilaTokens.numLineToken.Add(new Tuple<int, string>(countLines, "PuntoyComa"));
                     tokenTableList.Add(new string[] { letter.ToString(), "PuntoyComa" });
                     continue;
                  case '\"':
                     token = Q18(i);
                     tokenTableList.Add(new string[] { subcadena(i, VariablesGlobalesAutomatas.LastIndexFound), token });
                     PilaTokens.numLineToken.Add(new Tuple<int, string>(countLines, token));
                     break;
                  case '\'':
                     token = Q19(i);
                     tokenTableList.Add(new string[] { subcadena(i, VariablesGlobalesAutomatas.LastIndexFound), token });
                     PilaTokens.numLineToken.Add(new Tuple<int, string>(countLines, token));
                     break;
                  case '!':
                     token = Q20(i);
                     tokenTableList.Add(new string[] { subcadena(i, VariablesGlobalesAutomatas.LastIndexFound), token });
                     PilaTokens.numLineToken.Add(new Tuple<int, string>(countLines, token));
                     break;
                  case '<':
                  case '>':
                     token = Q21(i);
                     tokenTableList.Add(new string[] { subcadena(i, VariablesGlobalesAutomatas.LastIndexFound), token });
                     PilaTokens.numLineToken.Add(new Tuple<int, string>(countLines, token));
                     break;
                  case '=':
                     token = Q22(i);
                     tokenTableList.Add(new string[] { subcadena(i, VariablesGlobalesAutomatas.LastIndexFound), token });
                     PilaTokens.numLineToken.Add(new Tuple<int, string>(countLines, token));
                     break;
                  case '&':
                     token = Q23(i);
                     tokenTableList.Add(new string[] { subcadena(i, VariablesGlobalesAutomatas.LastIndexFound), token });
                     PilaTokens.numLineToken.Add(new Tuple<int, string>(countLines, token));
                     break;
                  case '|':
                     token = Q24(i);
                     tokenTableList.Add(new string[] { subcadena(i, VariablesGlobalesAutomatas.LastIndexFound), token });
                     PilaTokens.numLineToken.Add(new Tuple<int, string>(countLines, token));
                     break;
                  case '\n':
                     countLines++;
                     continue;
                  case '\r':
                     continue;
                  case ' ':
                     continue;
                  default:
                     messasgesErros += String.Format("Caracter no reconocido: {0}  --- Linea: {1}", VariablesGlobalesAutomatas.CharCodeText[i],
                        countLines);
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
               countLines++;
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
            messasgesErros += string.Format("Se esperaba */ -- Linea {0}\n", countLines);
            return String.Empty;
         }

         for (int i = indexString; i < VariablesGlobalesAutomatas.CharCodeText.Length; i++)
         {
            if (VariablesGlobalesAutomatas.CharCodeText[i].Equals('\n'))
               countLines++;
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

         messasgesErros += string.Format("Se esperaba */ -- Linea {0}\n", countLines);
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
               messasgesErros += String.Format("Hace falta un : \"&\"  -- Linea: {0}  \n", countLines);
               VariablesGlobalesAutomatas.LastIndexFound = indexString - 1;
               return string.Empty;
            }
         }
         else
         {
            //Mensaje de error
            messasgesErros += String.Format("Hace falta un : \"&\"  -- Linea: {0}  \n", countLines);
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
               messasgesErros += String.Format("Hace falta un : \"|\"  -- Linea: {0}  \n", countLines);
               VariablesGlobalesAutomatas.LastIndexFound = indexString - 1;
               return string.Empty;
            }
         }
         else
         {
            //Mensaje de error
            messasgesErros += String.Format("Hace falta un : \"|\"  -- Linea: {0}  \n", countLines);
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
         messasgesErros += string.Format("Se esperaba un número después del \'.\' -- Linea: {0}", countLines);
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
                     countLines);
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
         messasgesErros += String.Format("Se esperaba \" para cerrar cadena -- Linea:{0} \n", countLines);
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
               messasgesErros += String.Format("Hace falta cierre de caracter '  -- Linea: {0}  \n", countLines);
            }
         }
         else
         {
            VariablesGlobalesAutomatas.LastIndexFound = indexString - 1;
            //Mensaje de error
            messasgesErros += String.Format("Hace falta cierre de caracter '  -- Linea: {0}  \n", countLines);
            return string.Empty;
         }

         return string.Empty;
      }
   }
}
using System;
using System.Collections.Generic;

namespace Compilador {
    internal class AutomatasLexicos {
        char [] charsCodeText;
        public AutomatasLexicos( string Alltext ) {
            this.charsCodeText = Alltext.ToCharArray();
        }
        public string messasgesErros;
        int lastIndexFound;
        /// <summary>
        /// The first value is the lexema and the second is the token
        /// </summary>
        List<string []> tokenTableList = new List<string []>();
        int lengthText;
        int countLines;

        /// <summary>
        /// Execute the analizer to check all the lexemas and asign their token
        /// </summary>
        /// <returns>A list of lexemas with token</returns>
        public List<string []> ExecuteAnalizer() {
            messasgesErros = String.Empty;
            countLines = 1;
            lengthText = charsCodeText.Length;
            lastIndexFound = 0;
            for ( int i = 0 ; i < lengthText ; i++ ) {
                char letter = charsCodeText [i];
                string token;
                //Check if the character is a letter between a-z and A-Z or begins with "_"
                if ( letter >= 65 && letter <= 90 || letter >= 97 && letter <= 122 || letter == '_' ) {
                    token = Q25(i);
                    string lexema = subcadena(i, lastIndexFound);
                    string tokenFromSymbolTable = TablaSimbolos.GetTokenName(lexema);
                    if ( tokenFromSymbolTable == string.Empty ) {
                        tokenTableList.Add(new string [] { lexema, token });
                        TablaSimbolos.AddLexema(lexema, token, countLines);
                        i = lastIndexFound;
                        continue;
                    }
                    else {
                        tokenTableList.Add(new string [] { lexema, tokenFromSymbolTable });
                    }
                }
                /*if ( char.IsDigit(letter) ) {
                    i = lastIndexFound;
                    continue;
                }*/
                else {
                    //Find the first state of each automat
                    switch ( letter ) {
                        case '/':
                            token = Q8(i);
                            if ( token == "Operador" )
                                tokenTableList.Add(new string [] { letter.ToString(), token });
                            break;
                        case '-':
                            token = Q14(i);
                            if ( token != "Operador" ) {
                                tokenTableList.Add(new string [] { string.Concat(charsCodeText [i], charsCodeText [lastIndexFound]), token });
                            }
                            else {
                                tokenTableList.Add(new string [] { letter.ToString(), token });
                            }
                            break;
                        case '*':
                        case '%':
                        case '^':
                            //Add to the diccionary the lexema and the token
                            tokenTableList.Add(new string [] { letter.ToString(), "Operador" });
                            continue;
                        case '+':
                            token = Q16(i);
                            if ( token != "Operador" ) {
                                tokenTableList.Add(new string [] { string.Concat(charsCodeText [i], charsCodeText [lastIndexFound]), token });
                            }
                            else {
                                tokenTableList.Add(new string [] { letter.ToString(), token });
                            }
                            break;
                        case '(':
                            tokenTableList.Add(new string [] { letter.ToString(), "ParentesisAbre" });
                            continue;
                        case ')':

                            tokenTableList.Add(new string [] { letter.ToString(), "ParentesisCierra" });
                            continue;
                        case '{':
                            tokenTableList.Add(new string [] { letter.ToString(), "LlaveAbre" });
                            continue;
                        case '}':
                            tokenTableList.Add(new string [] { letter.ToString(), "LlaveCierra" });
                            continue;
                        case '[':
                            tokenTableList.Add(new string [] { letter.ToString(), "CorcheteAbre" });
                            continue;
                        case ']':
                            tokenTableList.Add(new string [] { letter.ToString(), "CorcheteCierra" });
                            continue;
                        case ';':
                            tokenTableList.Add(new string [] { letter.ToString(), "PuntoyComa" });
                            continue;
                        case '\"':
                            token = Q18(i);
                            tokenTableList.Add(new string [] { subcadena(i, lastIndexFound), token });

                            break;
                        case '\'':
                            token = Q19(i);
                            tokenTableList.Add(new string [] { subcadena(i, lastIndexFound), token });
                            break;
                        case '!':
                            token = Q20(i);
                            tokenTableList.Add(new string [] { subcadena(i, lastIndexFound), token });
                            break;
                        case '<':
                        case '>':
                            token = Q21(i);
                            tokenTableList.Add(new string [] { subcadena(i, lastIndexFound), token });
                            break;
                        case '=':
                            token = Q22(i);
                            tokenTableList.Add(new string [] { subcadena(i, lastIndexFound), token });
                            break;
                        case '&':
                            token = Q23(i);
                            tokenTableList.Add(new string [] { subcadena(i, lastIndexFound), token });
                            break;
                        case '|':
                            token = Q24(i);
                            tokenTableList.Add(new string [] { subcadena(i, lastIndexFound), token });
                            break;
                        case '\n':
                            countLines++;
                            continue;
                        default:
                            continue;
                            //lastIndexFound++;
                    }
                }
                i = lastIndexFound;
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
        public string Q8( int indexString ) {

            if ( (indexString + 1) < lengthText ) {
                if ( charsCodeText [++indexString].Equals('/') ) {
                    lastIndexFound = indexString;
                    return Q9(++indexString);
                }
                return Q10(indexString);
            }
            else {
                lastIndexFound = indexString;
                return "Operador";
            }
        }
        public string Q9( int indexString ) {
            for ( int i = indexString ; i < lengthText ; i++ ) {
                if ( charsCodeText [i].Equals('\n') ) {
                    countLines++;
                    lastIndexFound = indexString;
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
        public string Q10( int indexString ) {
            if ( charsCodeText [indexString].Equals('*') ) {
                lastIndexFound = indexString;
                return Q11(++indexString);
            }
            lastIndexFound = --indexString;
            return "Operador";
        }
        /// <summary>
        /// Determine if the text recived begins with "/", that defined the end of the commend
        /// </summary>
        /// <param name="stringText">Is the text to analice</param>
        /// <returns>The token of Multi line comment</returns>
        /// <exception cref="Exception">If the end of the line there aren't any termination of the comment</exception>
        public string Q11( int indexString ) {
            if ( indexString >= lengthText ) {
                messasgesErros += string.Format("Se esperaba */ -- Linea {0}\n", countLines);
                return String.Empty;
            }
            for ( int i = indexString ; i < charsCodeText.Length ; i++ ) {
                if ( charsCodeText [i].Equals('\n') )
                    countLines++;
                if ( charsCodeText [i] == '*' ) {
                    lastIndexFound = i;
                    try {
                        if ( Q12(charsCodeText [i + 1]) ) {
                            return "ComentarioMultilinea";
                        }
                        else {
                            continue;
                        }
                    }
                    catch ( Exception ) { }
                }
            }
            messasgesErros += string.Format("Se esperaba */ -- Linea {0}\n", countLines);
            return String.Empty;
        }
        /// <summary>
        /// Verify wheter the character is the end of comment
        /// </summary>
        bool Q12( char character ) {
            lastIndexFound++;
            return character.Equals('/') ? true : false;
        }
        #endregion
        #region OperadorMinus_OperadorDecremento
        /// <summary>
        /// The state Q14 analice wheter the character is a "-", if not, is an operator
        /// </summary>
        /// <param name="stringText">The text to analice</param>
        /// <returns>The token "Operador" or "Decremento"</returns>
        public string Q14( int indexString ) {
            if ( (indexString + 1) < lengthText ) {
                if ( charsCodeText [++indexString].Equals('-') ) {
                    lastIndexFound = indexString;
                    return "Decremento";
                }
                lastIndexFound = --indexString;
                return "Operador";
            }
            else {
                lastIndexFound = indexString;
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
        public string Q16( int indexString ) {
            if ( (indexString + 1) < lengthText ) {
                if ( charsCodeText [++indexString].Equals('+') ) {
                    lastIndexFound = indexString;
                    return "Incremento";
                }
                lastIndexFound = --indexString;
                return "Operador";

            }
            else {
                lastIndexFound = indexString;
                //This is the case when its the last character
                return "Operador";
            }
        }
        #endregion
        #endregion
        #region AutomatasYahir
        //Negacion
        public string Q20( int indexString ) {
            if ( ++indexString < lengthText ) {
                if ( charsCodeText [indexString] == '=' ) {
                    lastIndexFound = indexString;
                    return "Comparador";

                }
                else {
                    lastIndexFound = indexString - 1;
                    return "Negacion";
                }
            }
            else {
                lastIndexFound = indexString - 1;
                return "Negacion";
            }
        }
        //Comparador mayor que menor que
        public string Q21( int indexString ) {
            if ( ++indexString < lengthText ) {
                if ( charsCodeText [indexString] == '=' ) {
                    lastIndexFound = indexString;
                    return "Comparador";

                }
                else {
                    lastIndexFound = indexString - 1;
                    return "Comparador";
                }
            }
            else {
                lastIndexFound = indexString - 1;
                return "Comparador";
            }
        }
        //Comparador igual y asignador
        public string Q22( int indexString ) {
            if ( ++indexString < lengthText ) {
                if ( charsCodeText [indexString] == '=' ) {
                    lastIndexFound = indexString;
                    return "Comparador";

                }
                else {
                    lastIndexFound = indexString - 1;
                    return "Asignacion";
                }
            }
            else {
                lastIndexFound = indexString - 1;
                return "Asignacion";
            }
        }
        //Comparador de &&
        public string Q23( int indexString ) {
            if ( ++indexString < lengthText ) {
                if ( charsCodeText [indexString] == '&' ) {
                    lastIndexFound = indexString;
                    return "AND";
                }
                else {
                    //Mensaje de error
                    messasgesErros += String.Format("Hace falta un : \"&\"  -- Linea: {0}  \n", countLines);
                    lastIndexFound = indexString - 1;
                    return string.Empty;
                }
            }
            else {
                //Mensaje de error
                messasgesErros += String.Format("Hace falta un : \"&\"  -- Linea: {0}  \n", countLines);
                lastIndexFound = indexString - 1;
                return string.Empty;
            }
        }
        //comparador de ||
        public string Q24( int indexString ) {
            if ( ++indexString < lengthText ) {
                if ( charsCodeText [indexString] == '|' ) {
                    lastIndexFound = indexString;
                    return "OR";
                }
                else {
                    //Mensaje de error
                    messasgesErros += String.Format("Hace falta un : \"|\"  -- Linea: {0}  \n", countLines);
                    lastIndexFound = indexString - 1;
                    return string.Empty;
                }
            }
            else {
                //Mensaje de error
                messasgesErros += String.Format("Hace falta un : \"|\"  -- Linea: {0}  \n", countLines);
                lastIndexFound = indexString - 1;
                return string.Empty;
            }
        }
        //Comparador de identificadores
        public string Q25( int indexString ) {
            for ( int i = indexString ; i < lengthText ; i++ ) {
                if ( !(charsCodeText [i] >= 65 && charsCodeText [i] <= 90 || charsCodeText [i] >= 97 && charsCodeText [i] <= 122) && charsCodeText [i] != '_' && !char.IsDigit(charsCodeText [i]) ) {
                    lastIndexFound = i - 1;
                    return "Identificador";
                }
            }
            lastIndexFound = lengthText - 1;
            return "Identificador";
        }

        #endregion
        //Analiza las cadenas
        public string Q18( int indexString ) {
            for ( int i = ++indexString ; i < charsCodeText.Length ; i++ ) {
                try {
                    if ( charsCodeText [i] == '\"' ) {
                        lastIndexFound = i;
                        return "Cadena";
                    }
                }
                catch ( Exception ) {
                    throw;
                }
            }
            lastIndexFound = lengthText - 1;
            messasgesErros += String.Format("Se esperaba \" para cerrar cadena -- Linea:{0} \n", countLines);
            return String.Empty;
        }
        public string subcadena( int inicio, int final ) {
            string palabra = string.Empty;
            for ( int i = inicio ; i <= final ; i++ ) {
                palabra += charsCodeText [i].ToString();
            }
            return palabra;
        }
        public string Q19( int indexString ) {
            if ( ++indexString < lengthText ) {
                if ( charsCodeText [indexString] == '\'' ) {
                    lastIndexFound = indexString;
                    return "Caracter";
                }
                if ( ++indexString < lengthText && charsCodeText [indexString] == '\'' ) {
                    lastIndexFound = indexString;
                    return "Caracter";
                }
                else {
                    //Mensaje de error
                    messasgesErros += String.Format("Hace falta cierre de caracter '  -- Linea: {0}  \n", countLines);
                }
            }
            else {
                //Mensaje de error
                messasgesErros += String.Format("Hace falta cierre de caracter '  -- Linea: {0}  \n", countLines);
                return string.Empty;
            }
            return string.Empty;
        }
    }
}
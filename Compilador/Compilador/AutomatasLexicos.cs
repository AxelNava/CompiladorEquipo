using System;
using System.Collections.Generic;


namespace Compilador {
    internal class AutomatasLexicos {
        char [] charsCodeText;
        public AutomatasLexicos( string Alltext ) {
            this.charsCodeText = Alltext.ToCharArray();
        }
        int lastIndexFound;
        /// <summary>
        /// The first value is the lexema and the second is the token
        /// </summary>
        List<string []> tokenTableList = new List<string []>();
        int lengthText;

        public List<string []> ExecuteAnalizer() {
            lengthText = charsCodeText.Length;
            lastIndexFound = 0;
            for ( int i = 0 ; i < lengthText ; i++ ) {
                char letter = charsCodeText [i];
                string token;
                if ( letter >= 65 && letter <= 90 || letter >= 97 && letter <= 122 || letter == '_' ) {
                    token = Q25(i);
                    tokenTableList.Add(new string [] { subcadena(i, lastIndexFound), token });
                }
                if ( char.IsDigit(letter) ) {

                }
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
                        default:
                            continue;
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
            indexString = ((indexString + 1) < lengthText) ? ++indexString : indexString;
            lastIndexFound = indexString;
            return charsCodeText [indexString].Equals('/') ? Q9(++indexString) : Q10(indexString);
        }
        public string Q9( int indexString ) {
            for ( int i = indexString ; i < lengthText ; i++ ) {
                if ( charsCodeText [i].Equals('\n') ) {
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
            return (charsCodeText [indexString].Equals('*')) ? Q11(indexString) : "Operador";
        }
        /// <summary>
        /// Determine if the text recived begins with "/", that defined the end of the commend
        /// </summary>
        /// <param name="stringText">Is the text to analice</param>
        /// <returns>The token of Multi line comment</returns>
        /// <exception cref="Exception">If the end of the line there aren't any termination of the comment</exception>
        public string Q11( int indexString ) {
            for ( int i = indexString ; i < charsCodeText.Length ; i++ ) {
                if ( charsCodeText [i] == '*' ) {
                    lastIndexFound = i;
                    try {
                        if ( Q12(charsCodeText [i + 1]) ) {
                            return "ComentarioMultilinea";
                        }
                    }
                    catch ( Exception ) {
                        throw;
                    }
                }
            }
            throw new Exception("Se esperaba *");
        }
        /// <summary>
        /// Verify wheter the character is the end of comment
        /// </summary>
        bool Q12( char character ) {
            lastIndexFound++;
            return character.Equals('/') ? true : false;
        }
        #endregion

        /// <summary>
        /// Analice wheter the characters are operators of type "*", "%", "^"
        /// </summary>
        /// <param name="stringText">The text to analice</param>
        /// <returns>The token Operator</returns>

        #region OperadorMinus_OperadorDecremento
        /// <summary>
        /// The state Q14 analice wheter the character is a "-", if not, is an operator
        /// </summary>
        /// <param name="stringText">The text to analice</param>
        /// <returns>The token "Operador" or "Decremento"</returns>
        public string Q14( int indexString ) {
            if ( (indexString + 1) < lengthText ) {
                indexString++;
                lastIndexFound = indexString;
                return (charsCodeText [indexString].Equals('-')) ? "Decremento" : "Operador";
            }
            else {
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
                indexString++;
                lastIndexFound = indexString;
                return (charsCodeText [indexString].Equals('+')) ? "Incremento" : "Operador";
            }
            else {
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
        public string Q23( int indexString ) {
            if ( ++indexString < lengthText ) {
                if ( charsCodeText [indexString] == '&' ) {
                    lastIndexFound = indexString;
                    return "AND";
                }
                else {
                    //Mensaje de error
                    lastIndexFound = indexString - 1;
                    return string.Empty;
                }
            }
            else {
                //Mensaje de error
                lastIndexFound = indexString - 1;
                return string.Empty;
            }
        }
        public string Q24( int indexString ) {
            if ( ++indexString < lengthText ) {
                if ( charsCodeText [indexString] == '|' ) {
                    lastIndexFound = indexString;
                    return "OR";
                }
                else {
                    //Mensaje de error
                    lastIndexFound = indexString - 1;
                    return string.Empty;
                }
            }
            else {
                //Mensaje de error
                lastIndexFound = indexString - 1;
                return string.Empty;
            }
        }
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
            throw new Exception("Se esperaba un \"");
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
                }
            }
            else {
                //Mensaje de error
                return string.Empty;
            }
            return string.Empty;
        }     
    }
}
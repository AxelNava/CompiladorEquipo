using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador {
    internal class AutomatasLexicos {        
        char [] charsCodeText;
        public AutomatasLexicos(string Alltext) {
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
            for ( int i = 0 ; i < lengthText ;i++ ) {
                char letter = charsCodeText [i];
                string token;
                //Find the first state of each automat
                switch (letter) {
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
                    default:
                        lastIndexFound++;
                        break;

                    case '(':
                            token = Q18(i);
                        if (token == "ParentesisAbierto")
                            tokenTableList.Add(new string[] { letter.ToString(), token });
                        break;
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
        public string Q8(int indexString) {
            indexString = ((indexString + 1) < lengthText)? ++indexString: indexString;
            lastIndexFound = indexString;
            return charsCodeText [indexString].Equals('/') ? Q9(++indexString) : Q10(indexString);            
        }
        public string Q9( int indexString ) {
            for(int i = indexString ; i < lengthText ; i++ ) {
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
            return (charsCodeText [indexString].Equals('*')) ? Q11(indexString): "Operador";
        }
        /// <summary>
        /// Determine if the text recived begins with "/", that defined the end of the commend
        /// </summary>
        /// <param name="stringText">Is the text to analice</param>
        /// <returns>The token of Multi line comment</returns>
        /// <exception cref="Exception">If the end of the line there aren't any termination of the comment</exception>
        public string Q11(int indexString ) {
            for (int i = indexString ; i < charsCodeText.Length ; i++ ) {
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
        bool Q12(char character) {
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
            if((indexString + 1) < lengthText ) {
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
        public string Q16( int indexString) {
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
        public int GetIndexError() {
            return lastIndexFound;
        }
        #endregion

       
        public string Q18 (int indexString)
        {
            indexString = ((indexString + 1));
        }

    }
}

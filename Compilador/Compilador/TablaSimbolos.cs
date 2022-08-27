using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador {
    /// <summary>
    /// This class save the symbol table.
    /// This class containts all the methods to manipulate the Symbol Table
    /// </summary>
    internal class TablaSimbolos {
        private static TablaSimbolos _tablaSimbolos;
        private static Dictionary<string, Dictionary<int, string>> symbolTable = new Dictionary<string, Dictionary<int, string>>();
        private static int countSymbolTable;
        private TablaSimbolos() {
            countSymbolTable = 6;
            //Lexema diccionary
            Dictionary<int, string> lexemaDiccionary = new Dictionary<int, string>();
            //Token Diccionary
            Dictionary<int, string> tokenDiciconary = new Dictionary<int, string>();
            //Tipe diccionary
            Dictionary<int, string> tipeDiccionary = new Dictionary<int, string>();
            //Number line diccionary
            Dictionary<int, string> numLineDiccioanry = new Dictionary<int, string>();

            lexemaDiccionary.Add(0, "int");
            lexemaDiccionary.Add(1, "char");
            lexemaDiccionary.Add(2, "string");
            lexemaDiccionary.Add(3, "for");
            lexemaDiccionary.Add(4, "if");
            lexemaDiccionary.Add(5, "while");
            lexemaDiccionary.Add(6, "else");

            tokenDiciconary.Add(0, "TIPO");
            tokenDiciconary.Add(1, "TIPO");
            tokenDiciconary.Add(2, "TIPO");
            tokenDiciconary.Add(3, "FOR");
            tokenDiciconary.Add(4, "IF");
            tokenDiciconary.Add(5, "WHILE");
            tokenDiciconary.Add(6, "ELSE");

            tipeDiccionary.Add(0, "int");
            tipeDiccionary.Add(1, "char");
            tipeDiccionary.Add(2, "string");
            tipeDiccionary.Add(3, "reserveWord");
            tipeDiccionary.Add(4, "reserveWord");
            tipeDiccionary.Add(5, "reserveWord");
            tipeDiccionary.Add(6, "reserveWord");

            numLineDiccioanry.Add(0, String.Empty);
            numLineDiccioanry.Add(1, String.Empty);
            numLineDiccioanry.Add(2, String.Empty);
            numLineDiccioanry.Add(3, String.Empty);
            numLineDiccioanry.Add(4, String.Empty);
            numLineDiccioanry.Add(5, String.Empty);
            numLineDiccioanry.Add(6, String.Empty);

            symbolTable.Add("Lexema", lexemaDiccionary);
            symbolTable.Add("Token", tokenDiciconary);
            symbolTable.Add("Tipe", tipeDiccionary);
            symbolTable.Add("NumLine", numLineDiccioanry);

            /*lexemaDiccionary.Clear();
            tokenDiciconary.Clear();
            tipeDiccionary.Clear();
            numLineDiccioanry.Clear();*/
        }
        /// <summary>
        /// This method allow to acces to the first class instance
        /// </summary>
        /// <returns>The first instance of the class</returns>
        public static TablaSimbolos GetInstance() {
            if ( _tablaSimbolos == null )
                _tablaSimbolos = new TablaSimbolos();
            return _tablaSimbolos;
        }
        /// <summary>
        /// This method Adds a lexema to the Symbol Table
        /// </summary>
        /// <param name="title">The name of lexema</param>
        /// <param name="value">The token value for the lexema</param>
        /// <param name="line">The number of line where the lexeama was found</param>

        public static void AddLexema( string title, string value, int line ) {
            countSymbolTable++;
            foreach ( var keysDic in symbolTable.Keys ) {
                Dictionary<int, string> auxDicc = new Dictionary<int, string>();
                symbolTable.TryGetValue(keysDic, out auxDicc);
                switch ( keysDic ) {
                    case "Lexema":
                        auxDicc.Add(countSymbolTable, title);
                        break;
                    case "Token":
                        auxDicc.Add(countSymbolTable, value);
                        break;
                    case "Tipe":
                        auxDicc.Add(countSymbolTable, string.Empty);
                        break;
                    case "Numline":
                        auxDicc.Add(countSymbolTable, line.ToString());
                        break;
                }
            }
        }

        public static Dictionary<string, Dictionary<int, string>> GetSymbolTable() {
            return symbolTable;
        }
        public static Dictionary<int,string> GetLexemasValues() {
            var values = new Dictionary<int, string>();
            symbolTable.TryGetValue("Lexema", out values);
            return values;
        }
        public static Dictionary<int,string> GetTypesValues() {
            var values = new Dictionary<int, string>();
            symbolTable.TryGetValue("Tipe", out values);
            return values;
        }

        public static Dictionary<int,string> GetNumLine() {
            var values = new Dictionary<int, string>();
            symbolTable.TryGetValue("NumLine", out values);
            return values;
        }
        public static Dictionary<int,string> GetTokensValues() {
            var values = new Dictionary<int, string>();
            symbolTable.TryGetValue("Token", out values);
            return values;
        }
    }
}

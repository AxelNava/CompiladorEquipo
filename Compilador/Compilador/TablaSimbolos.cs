using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Compilador
{
   /// <summary>
   /// This class save the symbol table.
   /// This class containts all the methods to manipulate the Symbol Table
   /// </summary>
   internal class TablaSimbolos
   {
      private static TablaSimbolos _tablaSimbolos;
      private static Dictionary<string, Dictionary<int, string>> symbolTable = new Dictionary<string, Dictionary<int, string>>();

      private static int countSymbolTable;

      //Lexema diccionary
      private static Dictionary<int, string> lexemaDiccionary = new Dictionary<int, string>();

      //Token Diccionary
      private static Dictionary<int, string> tokenDiciconary = new Dictionary<int, string>();

      //Tipe diccionary
      private static Dictionary<int, string> tipeDiccionary = new Dictionary<int, string>();

      //Number line diccionary
      private static Dictionary<int, string> numLineDiccioanry = new Dictionary<int, string>();
      
      //Valor del lexema
      private static Dictionary<int, string> valorDictyonary = new Dictionary<int, string>();
      
      //Dezplazamiento
      private static Dictionary<int, string> desplazamientoDictionary = new Dictionary<int, string>();

      private TablaSimbolos()
      {
         FillSymbolTable();
         countSymbolTable = numLineDiccioanry.Count - 1;

         symbolTable.Add("Lexema", lexemaDiccionary);
         symbolTable.Add("Token", tokenDiciconary);
         symbolTable.Add("Tipe", tipeDiccionary);
         symbolTable.Add("NumLine", numLineDiccioanry);
         symbolTable.Add("Valor", valorDictyonary);
         symbolTable.Add("Desplazamiento", desplazamientoDictionary);
      }

      /// <summary>
      /// This method allow to acces to the first class instance
      /// </summary>
      /// <returns>The first instance of the class</returns>
      public static TablaSimbolos GetInstance()
      {
         if (_tablaSimbolos == null)
            _tablaSimbolos = new TablaSimbolos();
         return _tablaSimbolos;
      }

      /// <summary>
      /// This method Adds a lexema to the Symbol Table
      /// </summary>
      /// <param name="lexemaName">The name of lexema</param>
      /// <param name="tokenName">The token value for the lexema</param>
      /// <param name="line">The number of line where the lexeama was found</param>
      public static void AddLexema(string lexemaName, string tokenName, int line)
      {
         countSymbolTable++;
         foreach (var keysDic in symbolTable.Keys)
         {
            Dictionary<int, string> auxDicc;
            symbolTable.TryGetValue(keysDic, out auxDicc);
            switch (keysDic)
            {
               case "Lexema":
                  auxDicc.Add(countSymbolTable, lexemaName);
                  break;
               case "Token":
                  auxDicc.Add(countSymbolTable, tokenName);
                  break;
               case "Tipe":
                  auxDicc.Add(countSymbolTable, string.Empty);
                  break;
               case "NumLine":
                  auxDicc.Add(countSymbolTable, line.ToString());
                  break;
               case "Valor":
                  auxDicc.Add(countSymbolTable, string.Empty);
                  break;
               case "Desplazamiento":
                  auxDicc.Add(countSymbolTable, string.Empty);
                  break;
            }
         }
      }

      /// <summary>
      /// Obtain all the symbol Table
      /// </summary>
      /// <returns>Symbol Table</returns>
      public static Dictionary<string, Dictionary<int, string>> GetSymbolTable()
      {
         return symbolTable;
      }

      public static Dictionary<int, string> GetLexemasValues()
      {
         var values = new Dictionary<int, string>();
         symbolTable.TryGetValue("Lexema", out values);
         return values;
      }

      public static Dictionary<int, string> GetTypesValues()
      {
         var values = new Dictionary<int, string>();
         symbolTable.TryGetValue("Tipe", out values);
         return values;
      }

      public static Dictionary<int, string> GetNumLine()
      {
         var values = new Dictionary<int, string>();
         symbolTable.TryGetValue("NumLine", out values);
         return values;
      }

      public static Dictionary<int, string> GetTokensValues()
      {
         var values = new Dictionary<int, string>();
         symbolTable.TryGetValue("Token", out values);
         return values;
      }

      public static Dictionary<int, string> GetValues()
      {
         var values = new Dictionary<int, string>();
         symbolTable.TryGetValue("Valor", out values);
         return values;
      }

      public static Dictionary<int, string> GetDesplazamientos()
      {
         var values = new Dictionary<int, string>();
         symbolTable.TryGetValue("Desplazamiento", out values);
         return values;
      }

      /// <summary>
      /// Check if there is a identifier already exists
      /// </summary>
      /// <param name="lexemaName"></param>
      /// <returns>The token from the symbol table
      /// A empty string if there aren't 
      /// </returns>
      public static string GetTokenName(string lexemaName)
      {
         foreach (var dics in symbolTable["Lexema"])
         {
            if (dics.Value == lexemaName)
            {
               string token;
               symbolTable["Token"].TryGetValue(dics.Key, out token);
               return token;
            }
         }

         return string.Empty;
      }

      /// <summary>
      /// Analize if the lexema is in the table
      /// </summary>
      /// <param name="lexemaName">Lexema to search</param>
      /// <returns>True if the lexema is in the table</returns>
      public static bool CheckLexema(string lexemaName)
      {
         var lexemas = GetLexemasValues();
         if (lexemas.ContainsValue(lexemaName))
         {
            return true;
         }

         return false;
      }

      /// <summary>
      /// Retorna el número de fila de la tabla de símbolos con el lexema
      /// </summary>
      /// <param name="lexema"></param>
      /// <returns>Numero de fila en la tabla de símbolos</returns>
      public static int numRowInTable(string lexema)
      {
         var lexemas = GetLexemasValues();
         foreach (var lexema1 in lexemas)
         {
            if (lexema1.Value == lexema) return lexema1.Key;
         }

         return 0;
      }

      public static void ClearSymbolTable()
      {
         FillSymbolTable();
      }

      public static void FillSymbolTable()
      {
         lexemaDiccionary.Clear();
         tokenDiciconary.Clear();
         tipeDiccionary.Clear();
         numLineDiccioanry.Clear();

         lexemaDiccionary.Add(0, "int");
         lexemaDiccionary.Add(1, "char");
         lexemaDiccionary.Add(2, "string");
         lexemaDiccionary.Add(3, "for");
         lexemaDiccionary.Add(4, "if");
         lexemaDiccionary.Add(5, "while");
         lexemaDiccionary.Add(6, "else");
         lexemaDiccionary.Add(7, "using");
         lexemaDiccionary.Add(8, "do");
         lexemaDiccionary.Add(9, "class");
         lexemaDiccionary.Add(10, "or");
         lexemaDiccionary.Add(11, "and");
         lexemaDiccionary.Add(12, "void");
         lexemaDiccionary.Add(13, "true");
         lexemaDiccionary.Add(14, "switch");
         lexemaDiccionary.Add(15, "false");
         lexemaDiccionary.Add(16, "case");
         lexemaDiccionary.Add(17, "default");
         

         tokenDiciconary.Add(0, "TIPO");
         tokenDiciconary.Add(1, "TIPO");
         tokenDiciconary.Add(2, "TIPO");
         tokenDiciconary.Add(3, "FOR");
         tokenDiciconary.Add(4, "IF");
         tokenDiciconary.Add(5, "WHILE");
         tokenDiciconary.Add(6, "ELSE");
         tokenDiciconary.Add(7, "USING");
         tokenDiciconary.Add(8, "DO");
         tokenDiciconary.Add(9, "CLASS");
         tokenDiciconary.Add(10, "OR");
         tokenDiciconary.Add(11, "AND");
         tokenDiciconary.Add(12, "VOID");
         tokenDiciconary.Add(13, "BOOL");
         tokenDiciconary.Add(14, "SWITCH");
         tokenDiciconary.Add(15, "BOOL");
         tokenDiciconary.Add(16, "CASE");
         tokenDiciconary.Add(17, "DEFAULT");
         

         tipeDiccionary.Add(0, "int");
         tipeDiccionary.Add(1, "char");
         tipeDiccionary.Add(2, "string");
         tipeDiccionary.Add(3, "reserveWord");
         tipeDiccionary.Add(4, "reserveWord");
         tipeDiccionary.Add(5, "reserveWord");
         tipeDiccionary.Add(6, "reserveWord");
         tipeDiccionary.Add(7, "reserveWord");
         tipeDiccionary.Add(8, "reserveWord");
         tipeDiccionary.Add(9, "reserveWord");
         tipeDiccionary.Add(10, "reserveWord");
         tipeDiccionary.Add(11, "reserveWord");
         tipeDiccionary.Add(12, "reserveWord");
         tipeDiccionary.Add(13, "bool");
         tipeDiccionary.Add(14, "reserveWord");
         tipeDiccionary.Add(15, "bool");
         tipeDiccionary.Add(16, "reserveWord");
         tipeDiccionary.Add(17, "reserveWord");
         

         numLineDiccioanry.Add(0, String.Empty);
         numLineDiccioanry.Add(1, String.Empty);
         numLineDiccioanry.Add(2, String.Empty);
         numLineDiccioanry.Add(3, String.Empty);
         numLineDiccioanry.Add(4, String.Empty);
         numLineDiccioanry.Add(5, String.Empty);
         numLineDiccioanry.Add(6, String.Empty);
         numLineDiccioanry.Add(7, String.Empty);
         numLineDiccioanry.Add(8, String.Empty);
         numLineDiccioanry.Add(9, String.Empty);
         numLineDiccioanry.Add(10, String.Empty);
         numLineDiccioanry.Add(11, String.Empty);
         numLineDiccioanry.Add(12, String.Empty);
         numLineDiccioanry.Add(13, String.Empty);
         numLineDiccioanry.Add(14, String.Empty);
         numLineDiccioanry.Add(15, String.Empty);
         numLineDiccioanry.Add(16, String.Empty);
         numLineDiccioanry.Add(17, String.Empty);
         
         
         valorDictyonary.Add(0, String.Empty);
         valorDictyonary.Add(1, String.Empty);
         valorDictyonary.Add(2, String.Empty);
         valorDictyonary.Add(3, String.Empty);
         valorDictyonary.Add(4, String.Empty);
         valorDictyonary.Add(5, String.Empty);
         valorDictyonary.Add(6, String.Empty);
         valorDictyonary.Add(7, String.Empty);
         valorDictyonary.Add(8, String.Empty);
         valorDictyonary.Add(9, String.Empty);
         valorDictyonary.Add(10, String.Empty);
         valorDictyonary.Add(11, String.Empty);
         valorDictyonary.Add(12, String.Empty);
         valorDictyonary.Add(13, String.Empty);
         valorDictyonary.Add(14, String.Empty);
         valorDictyonary.Add(15, String.Empty);
         valorDictyonary.Add(16, String.Empty);
         valorDictyonary.Add(17, String.Empty);
         
         
         desplazamientoDictionary.Add(0, String.Empty);
         desplazamientoDictionary.Add(1, String.Empty);
         desplazamientoDictionary.Add(2, String.Empty);
         desplazamientoDictionary.Add(3, String.Empty);
         desplazamientoDictionary.Add(4, String.Empty);
         desplazamientoDictionary.Add(5, String.Empty);
         desplazamientoDictionary.Add(6, String.Empty);
         desplazamientoDictionary.Add(7, String.Empty);
         desplazamientoDictionary.Add(8, String.Empty);
         desplazamientoDictionary.Add(9, String.Empty);
         desplazamientoDictionary.Add(10, String.Empty);
         desplazamientoDictionary.Add(11, String.Empty);
         desplazamientoDictionary.Add(12, String.Empty);
         desplazamientoDictionary.Add(13, String.Empty);
        desplazamientoDictionary.Add(14, String.Empty);
         desplazamientoDictionary.Add(15, String.Empty);
         desplazamientoDictionary.Add(16, String.Empty);
         desplazamientoDictionary.Add(17, String.Empty);
         
      }
   }
}
using System;
using System.Collections.Generic;

namespace Compilador.TablasGlobales
{
   public class TablaLexemaToken
   {
      /// <summary>
      /// Contiene la relación de lexema-Token con su número de línea
      /// La tupla es, 1 - Numero de línea
      /// 2 - lexema
      /// 3 - token
      /// </summary>
      private static Dictionary<int, Tuple<int, string, string>> _lexemaTokensTable = new Dictionary<int, Tuple<int, string, string>>();

      public TablaLexemaToken()
      {
         LexemaTokensTable = _lexemaTokensTable;
      }

      public static Dictionary<int, Tuple<int, string, string>> LexemaTokensTable
      {
         get => _lexemaTokensTable;
         private set => _lexemaTokensTable = value;
      }

      /// <summary>
      /// Agrega el Lexema-Token encontrado y su numero de línea
      /// </summary>
      /// <param name="numLexema">Numero de lexema encontrado</param>
      /// <param name="numLine">Numero de línea encontrado</param>
      /// <param name="Lexema">Lexema encontrado</param>
      /// <param name="Token">Token encontrado</param>
      public static void AddLexemaTokenToTable(int numLexema, int numLine, string Lexema, string Token)
      {
         LexemaTokensTable.Add(numLexema, new Tuple<int, string, string>(numLine, Lexema, Token));
      }

      public static string GetLexema(int numLexema)
      {
         return _lexemaTokensTable[numLexema].Item2;
      }

      public static void ClearTable()
      {
         LexemaTokensTable.Clear();
      }
   }
}
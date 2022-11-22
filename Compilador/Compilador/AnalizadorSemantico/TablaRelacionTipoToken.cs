using System.Collections.Generic;
using Compilador.AnalizadorSintactico;


namespace Compilador.AnalizadorSemantico
{
   public class TablaRelacionTipoToken
   {
      /// <summary>
      /// La tabla contiene la relación entre los tipos de un identificador con sus tokens
      /// Por ejemplo: int - Entero; char - Caracter; string - Cadena
      /// La llave es el tipo del identificador, el valor es su token correspondiente
      /// </summary>
      public static Dictionary<string, string> TablaTipoToken = new Dictionary<string, string>()
      {
         {
            "int", tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO)
         },
         {
            "char", tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER)
         },
         {
            "string", tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA)
         },
         {
            "float", tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL)
         },
         {
            "bool", tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL)
         }
      };

      /// <summary>
      /// La tabla contiene la relación entre los tipos de un identificador con sus tokens
      /// Por ejemplo: entero - int, caracter - char, string - cadena
      /// La llave es el token, el valor es su tipo correspondiente
      /// </summary>
      public static Dictionary<string, string> TablaTokenTipo = new Dictionary<string, string>()
      {
         {
            tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.ENTERO),"int"
         },
         {
            tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CARACTER),"char"
         },
         {
            tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.CADENA),"string"
         },
         {
            tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.DECIMAL),"float"
         },
         {
            tokensNameGlobal.selectorString(tokensNameGlobal.tokensGlobals.BOOL), "bool"
         }
      };
   }
}
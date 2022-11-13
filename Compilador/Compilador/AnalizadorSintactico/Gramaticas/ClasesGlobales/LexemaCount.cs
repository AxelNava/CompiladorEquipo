namespace Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales
{
   public class LexemaCount
   {
      private static int countLexemas;

      public static int CountLexemas
      {
         get => countLexemas;
         set => countLexemas = value;
      }
   }
}
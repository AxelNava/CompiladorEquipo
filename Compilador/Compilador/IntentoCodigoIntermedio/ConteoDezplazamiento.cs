namespace Compilador.IntentoCodigoIntermedio
{
   public class ConteoDezplazamiento
   {
      private static int _countShift = 0;

      public static int CountShift
      {
         get => _countShift;
         set => _countShift = value;
      }
   }
}
using System;

namespace Compilador.IntentoCodigoIntermedio
{
   public class tablaInstrucciones
   {
      public enum InstruccionesCodigoIntermedio
      {
         InstruccionIf,
         InstruccionMayor,
         InstruccionMenor,
         InstruccionIgual,
         InstruccionSwitch,
         InstruccionWhile,
         InstruccionCase,
         InstruccionDefault,
         InstruccionFor,
         InstruccionDeclaracion,
         InstruccionInicializacion,
         InstruccionBreak,
         InstruccionLLamar,
         InstruccionReturn,
         InstruccionOr,
         InstruccionAnd
      }

      private static string[] instruccionesString =
      {
         "If",
         "Mayor",
         "Menor",
         "Igual",
         "Switch",
         "While",
         "Case",
         "Default",
         "For",
         "Declaracion",
         "Inicializacion",
         "Break",
         "Llamar",
         "Return",
         "Or",
         "And"
      };

      public static string SelectInstruction(InstruccionesCodigoIntermedio Instruccion)
      {
         return instruccionesString.GetValue((int)Convert.ChangeType(Instruccion, Instruccion.GetTypeCode())).ToString();
      }
   }
}
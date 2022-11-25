using System;
using System.Collections.Generic;

namespace Compilador.IntentoCodigoIntermedio
{
   public class tablaInstrucciones
   {
        public static Dictionary<InstruccionesCodigoIntermedio, Tuple<string, string>> Tabla_Instrucciones = new Dictionary<InstruccionesCodigoIntermedio, Tuple<string, string>>()
        {
            
        };
      public enum InstruccionesCodigoIntermedio
      {
         
         InstruccionMayor,
         InstruccionMenor,
         InstruccionIgual,
         InstruccionMayorIgual,
         InstruccionMenorIgual,
         InstruccionDiferente,
         InstruccionNegacion,
         InstruccionAsignacion,
         InstruccionSum,
         InstruccionRes,
         InstruccionMulti,
         InstruccionDiv,
         InstruccionDeclaracion,
         InstruccionLLamar,
         InstruccionReturn,
        
      }

      private static string[] instruccionesString =
      {
         
         "SI_MAYOR",
         "SI_MENOR",
         "SI_IGUAL",
         "SI_MAYORIGUAL",
         "SI_MENORIGUAL",
         "SI_DIFERENTE",
         "SI_NEGACION",
         "ASIGNACION",
         "SUM",
         "RES",
         "MULTI",
         "DIV",
         "Declaracion",
         "Llamar",
         "Return",
         
      };

      public static string SelectInstruction(InstruccionesCodigoIntermedio Instruccion)
      {
         return instruccionesString.GetValue((int)Convert.ChangeType(Instruccion, Instruccion.GetTypeCode())).ToString();
      }
   }
}
using System;
using System.Collections.Generic;

namespace Compilador.IntentoCodigoIntermedio
{
   public class tablaInstrucciones
   {
      public static Dictionary<InstruccionesCodigoIntermedio, Tuple<string, string>> Tabla_Instrucciones = new Dictionary<InstruccionesCodigoIntermedio, Tuple<string, string>>();
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
         InstruccionSalto
        
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
         "SALTO"
         
      };

      public static string SelectInstruction(InstruccionesCodigoIntermedio Instruccion)
      {
         return instruccionesString.GetValue((int)Convert.ChangeType(Instruccion, Instruccion.GetTypeCode())).ToString();
      }

        public static void AgregarInstruccion(string Parametro1, string Parametro2, InstruccionesCodigoIntermedio instruccion)
        {
            if(instruccion != InstruccionesCodigoIntermedio.InstruccionSalto && instruccion != InstruccionesCodigoIntermedio.InstruccionReturn && instruccion != InstruccionesCodigoIntermedio.InstruccionNegacion)
            {
                Tabla_Instrucciones.Add(instruccion, new Tuple<string, string>(Parametro1, Parametro2));
                ContadorInstrucciones++;
                return;
            }
            

        
        }
        public static void AgregarInstruccion(string Parametro1, InstruccionesCodigoIntermedio instruccion)
        {
            switch (instruccion)
            {
                case InstruccionesCodigoIntermedio.InstruccionNegacion:
                    Tabla_Instrucciones.Add(instruccion, new Tuple<string, string>(Parametro1, "FFV"));
                    break;
                case InstruccionesCodigoIntermedio.InstruccionReturn:
                    Tabla_Instrucciones.Add(instruccion, new Tuple<string, string>(string.Empty, string.Empty));
                    break;
                case InstruccionesCodigoIntermedio.InstruccionSalto:
                    Tabla_Instrucciones.Add(instruccion, new Tuple<string, string>(Parametro1,string.Empty));
                    break;
            }
        }

        private static int ContadorInstrucciones = 0;
        public static void ReiniciarInstrucciones()
        {
            ContadorInstrucciones= 0;
        }

        public static void LimpiarTablaInstrucciones()
        {
            Tabla_Instrucciones.Clear();
        }


   }
}
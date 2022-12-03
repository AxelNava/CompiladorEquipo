using System;
using System.Collections.Generic;

namespace Compilador.IntentoCodigoIntermedio
{
   public class tablaInstrucciones
   {
      public static Dictionary<int, Tuple<InstruccionesCodigoIntermedio, string, string>> tablaINstrucciones =
         new Dictionary<int, Tuple<InstruccionesCodigoIntermedio, string, string>>();

      public static Stack<int> PilaNumerosInstruccionSaltoAmodificar = new Stack<int>();
      public static int GetNumInstruccion = ContadorInstrucciones;
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
         InstruccionSalto,
         InstruccionIncremento,
         InstruccionDecremento
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
         "SALTO",
         "INCREMENTO",
         "DECREMENTO"
      };

      public static string SelectInstruction(InstruccionesCodigoIntermedio Instruccion)
      {
         return instruccionesString.GetValue((int)Convert.ChangeType(Instruccion, Instruccion.GetTypeCode())).ToString();
      }

      public static void AgregarLlamadaMetodo(InstruccionesCodigoIntermedio instrucciones)
      {
         tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(instrucciones, string.Empty, string
         .Empty));
         ContadorInstrucciones += 1;
      }

      public static void AgregarInstruccion(string Parametro1, string Parametro2, InstruccionesCodigoIntermedio instruccion)
      {
         if (instruccion == InstruccionesCodigoIntermedio.InstruccionSalto || instruccion == InstruccionesCodigoIntermedio.InstruccionReturn ||
             instruccion == InstruccionesCodigoIntermedio.InstruccionNegacion) return;
         if (instruccion == InstruccionesCodigoIntermedio.InstruccionIgual || instruccion == InstruccionesCodigoIntermedio.InstruccionDiferente ||
             instruccion == InstruccionesCodigoIntermedio.InstruccionMayorIgual || instruccion == InstruccionesCodigoIntermedio.InstruccionMenorIgual
             || instruccion == InstruccionesCodigoIntermedio.InstruccionMenor || instruccion == InstruccionesCodigoIntermedio.InstruccionMayor)
         {
            tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccion, Parametro1, Parametro2));
            ContadorInstrucciones += 1;
            tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(InstruccionesCodigoIntermedio
            .InstruccionSalto, Parametro1, 
            Parametro2));
            ContadorInstrucciones += 1;
            PilaNumerosInstruccionSaltoAmodificar.Push(ContadorInstrucciones);
            return;
         }
         tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccion, Parametro1, Parametro2));
         ContadorInstrucciones++;
      }

      public static void AgregarInstruccion(string Parametro1, InstruccionesCodigoIntermedio instruccion)
      {
         switch (instruccion)
         {
            case InstruccionesCodigoIntermedio.InstruccionNegacion:
               tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccion, Parametro1, "FFV"));
               return;
            case InstruccionesCodigoIntermedio.InstruccionReturn:
               tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccion, string.Empty, 
               string.Empty));
               return;
            case InstruccionesCodigoIntermedio.InstruccionSalto:
               tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccion, Parametro1, 
                  string.Empty));
               return;
               case InstruccionesCodigoIntermedio.InstruccionLLamar:
                  tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccion, Parametro1, 
                  string.Empty));
                  break;
         }

         ContadorInstrucciones++;
      }
      // private static bool HandleEstrucutresControl(InstruccionesCodigoIntermedio instruccionesCodigoIntermedio, string )

      private static int ContadorInstrucciones = 0;

      public static void ReiniciarInstrucciones()
      {
         ContadorInstrucciones = 0;
      }

      public static void LimpiarTablaInstrucciones()
      {
         tablaINstrucciones.Clear();
      }
   }
}
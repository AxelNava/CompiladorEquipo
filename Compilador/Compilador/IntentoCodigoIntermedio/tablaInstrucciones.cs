using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;

namespace Compilador.IntentoCodigoIntermedio
{
   public class tablaInstrucciones
   {
      public static Dictionary<int, Tuple<InstruccionesCodigoIntermedio, string, string>> tablaINstrucciones =
         new Dictionary<int, Tuple<InstruccionesCodigoIntermedio, string, string>>();

      private static Stack<int> PilaNumerosInstruccionSaltoCondicionesAmodificar = new Stack<int>();
      public static Stack<int> PilaSaltosTerminales = new Stack<int>();
      public static int GetNumInstruccion => ContadorInstrucciones;

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
         InstruccionDecremento,
         IntruccionFinPrograma
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
         "DECREMENTO",
         "FINPROGRAMA"
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

      public static void AgregarInstruccionFloat(InstruccionesCodigoIntermedio instruccionesCodigoIntermedio, string paraetro1, string parametro2)
      {
         int desplazaminetoSeparado = int.Parse(paraetro1);
         string[] valoresFloat = parametro2.Split('.');
         tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccionesCodigoIntermedio, 
         valoresFloat[0], (desplazaminetoSeparado - 2).ToString()));
         ContadorInstrucciones++;
         tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccionesCodigoIntermedio, 
            valoresFloat[1], (desplazaminetoSeparado).ToString()));
         ContadorInstrucciones++;
      }
      public static void AgregarInstruccion(string Parametro1, string Parametro2, InstruccionesCodigoIntermedio instruccion)
      {
         if (instruccion == InstruccionesCodigoIntermedio.InstruccionSalto || instruccion == InstruccionesCodigoIntermedio.InstruccionReturn ||
             instruccion == InstruccionesCodigoIntermedio.InstruccionNegacion) return;
         if (instruccion == InstruccionesCodigoIntermedio.InstruccionIgual || instruccion == InstruccionesCodigoIntermedio.InstruccionDiferente ||
             instruccion == InstruccionesCodigoIntermedio.InstruccionMayorIgual || instruccion == InstruccionesCodigoIntermedio.InstruccionMenorIgual
             || instruccion == InstruccionesCodigoIntermedio.InstruccionMenor || instruccion == InstruccionesCodigoIntermedio.InstruccionMayor)
         {
            tablaINstrucciones.Add(ContadorInstrucciones,
               new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccion, Parametro1, Parametro2));
            ContadorInstrucciones++;
            tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(InstruccionesCodigoIntermedio
                  .InstruccionSalto, string.Empty,
               string.Empty));
            PilaNumerosInstruccionSaltoCondicionesAmodificar.Push(ContadorInstrucciones);
            ContadorInstrucciones++;
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
               tablaINstrucciones.Add(ContadorInstrucciones,
                  new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccion, Parametro1, "FFV"));
               break;
            case InstruccionesCodigoIntermedio.InstruccionReturn:
               tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccion, string.Empty,
                  string.Empty));
               break;
            case InstruccionesCodigoIntermedio.InstruccionSalto:
               tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccion, Parametro1,
                  string.Empty));
               PilaSaltosTerminales.Push(ContadorInstrucciones);
               break;
            case InstruccionesCodigoIntermedio.InstruccionLLamar:
               tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccion, Parametro1,
                  string.Empty));
               break;
            case InstruccionesCodigoIntermedio.InstruccionIncremento:
            case InstruccionesCodigoIntermedio.InstruccionDecremento:
               tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccion, Parametro1,
                  string.Empty));
               break;
         }

         ContadorInstrucciones++;
      }
      // private static bool HandleEstrucutresControl(InstruccionesCodigoIntermedio instruccionesCodigoIntermedio, string )

      private static int ContadorInstrucciones = 0;

      public static void AgregarSaltoInverso(int NumeroInstruccionSalto, InstruccionesCodigoIntermedio instruccionesCodigoIntermedio)
      {
         string valorNegativo = (NumeroInstruccionSalto - (ContadorInstrucciones + 2)).ToString();
         tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccionesCodigoIntermedio,
            valorNegativo, string.Empty));
         ContadorInstrucciones++;
         ModificarInstruccionSaltoCondicion();
      }

      public static void ModificarInstruccionSaltoCondicion()
      {
         int NumeroSaltoInstruccion = PilaNumerosInstruccionSaltoCondicionesAmodificar.Pop();
         int ProximoSalto = ContadorInstrucciones - NumeroSaltoInstruccion;
         if (tablaINstrucciones.ContainsKey(NumeroSaltoInstruccion))
         {
            tablaINstrucciones[NumeroSaltoInstruccion] = new Tuple<InstruccionesCodigoIntermedio, string, string>(InstruccionesCodigoIntermedio
               .InstruccionSalto, ProximoSalto.ToString(), string.Empty);
         }
      }

      public static void ModificarInstruccionSaltoTerminal()
      {
         int NumeroSaltoInstruccion = PilaSaltosTerminales.Pop();
         int ProximoSalto = ContadorInstrucciones - NumeroSaltoInstruccion;
         if (tablaINstrucciones.ContainsKey(NumeroSaltoInstruccion))
         {
            tablaINstrucciones[NumeroSaltoInstruccion] = new Tuple<InstruccionesCodigoIntermedio, string, string>(InstruccionesCodigoIntermedio
               .InstruccionSalto, ProximoSalto.ToString(), string.Empty);
         }
      }

      public static void ReiniciarInstrucciones()
      {
         ContadorInstrucciones = 0;
      }

      public static void AgregarFinPrograma()
      {
         tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(InstruccionesCodigoIntermedio
         .IntruccionFinPrograma, string.Empty,string.Empty));
      }
      public static void LimpiarTablaInstrucciones()
      {
         ContadorInstrucciones = 0;
         tablaINstrucciones.Clear();
      }

      public static string ConstruirCodigoIntermedio()
      {
         StringBuilder Codigo = new StringBuilder();
         foreach (var instruccion in tablaINstrucciones)
         {
            if (string.IsNullOrEmpty(instruccion.Value.Item3))
            {
               Codigo.AppendFormat($"{SelectInstruction(instruccion.Value.Item1)} {instruccion.Value.Item2}\n");
               continue;
            }

            if (instruccion.Value.Item1 == InstruccionesCodigoIntermedio.IntruccionFinPrograma)
            {
               Codigo.Append($"{SelectInstruction(instruccion.Value.Item1)}");
               continue;
            }
            Codigo.AppendFormat($"{SelectInstruction(instruccion.Value.Item1)} {instruccion.Value.Item2}, {instruccion.Value.Item3}\n");
         }

         return Codigo.ToString();
      }
   }
}
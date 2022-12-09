using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security;
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

      public static void AgregarLlamadaMetodo(InstruccionesCodigoIntermedio instrucciones, string nombreMetodo)
      {
         tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(instrucciones, nombreMetodo, string
            .Empty));
         ContadorInstrucciones += 1;
      }

      public static void AgregarInstruccionFloat(InstruccionesCodigoIntermedio instruccionesCodigoIntermedio, string paraetro1, string parametro2)
      {
         //Desplazamiento original
         int desplazaminetoSeparado = int.Parse(paraetro1, NumberStyles.HexNumber);
         //Desplazamiento parte entera
         string desplazamiento1 = ConversorDecimalAHexadecimal((desplazaminetoSeparado - 2).ToString());
         //Desplazamiento parte decimal
         string desplazamientoMantisa = ConversorDecimalAHexadecimal(paraetro1);
         string[] valoresFloat = parametro2.Split('.');
         //Valores enteros y decimales
         string parametroDecimalHex = ConversorDecimalAHexadecimal($"{valoresFloat[0]}V");
         string parametroMantissaHex = ConversorDecimalAHexadecimal($"{valoresFloat[1]}V");

         if (valoresFloat.Length == 1)
         {
            tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccionesCodigoIntermedio
               ,desplazamiento1, parametroDecimalHex));
            ContadorInstrucciones++;
            return;
         }

         tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccionesCodigoIntermedio
            , desplazamiento1, parametroDecimalHex));
         ContadorInstrucciones++;
         tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccionesCodigoIntermedio
            , desplazamientoMantisa,parametroMantissaHex));
         ContadorInstrucciones++;
      }

      public static void AgregarInstruccion(string Parametro1, string Parametro2, InstruccionesCodigoIntermedio instruccion)
      {
         if (instruccion == InstruccionesCodigoIntermedio.InstruccionSalto || instruccion == InstruccionesCodigoIntermedio.InstruccionReturn ||
             instruccion == InstruccionesCodigoIntermedio.InstruccionNegacion) return;
         string parametro1Hex = ConversorDecimalAHexadecimal(Parametro1);
         string parametro2Hex = ConversorDecimalAHexadecimal(Parametro2);
         if (instruccion == InstruccionesCodigoIntermedio.InstruccionIgual || instruccion == InstruccionesCodigoIntermedio.InstruccionDiferente ||
             instruccion == InstruccionesCodigoIntermedio.InstruccionMayorIgual || instruccion == InstruccionesCodigoIntermedio.InstruccionMenorIgual
             || instruccion == InstruccionesCodigoIntermedio.InstruccionMenor || instruccion == InstruccionesCodigoIntermedio.InstruccionMayor)
         {
            tablaINstrucciones.Add(ContadorInstrucciones,
               new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccion, parametro1Hex, parametro2Hex));
            ContadorInstrucciones++;
            tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(InstruccionesCodigoIntermedio
                  .InstruccionSalto, string.Empty,
               string.Empty));
            PilaNumerosInstruccionSaltoCondicionesAmodificar.Push(ContadorInstrucciones);
            ContadorInstrucciones++;
            return;
         }

         tablaINstrucciones.Add(ContadorInstrucciones,
            new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccion, parametro1Hex, parametro2Hex));
         ContadorInstrucciones++;
      }

      public static void AgregarInstruccion(string parametro1, InstruccionesCodigoIntermedio instruccion)
      {
         string parametro1Hex = ConversorDecimalAHexadecimal(parametro1);
         switch (instruccion)
         {
            case InstruccionesCodigoIntermedio.InstruccionNegacion:
               tablaINstrucciones.Add(ContadorInstrucciones,
                  new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccion, parametro1Hex, "FFV"));
               break;
            case InstruccionesCodigoIntermedio.InstruccionReturn:
               tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccion, string.Empty,
                  string.Empty));
               break;
            case InstruccionesCodigoIntermedio.InstruccionSalto:
               tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccion, parametro1,
                  string.Empty));
               PilaSaltosTerminales.Push(ContadorInstrucciones);
               break;
            case InstruccionesCodigoIntermedio.InstruccionLLamar:
               tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccion, parametro1,
                  string.Empty));
               break;
            case InstruccionesCodigoIntermedio.InstruccionIncremento:
            case InstruccionesCodigoIntermedio.InstruccionDecremento:
               tablaINstrucciones.Add(ContadorInstrucciones, new Tuple<InstruccionesCodigoIntermedio, string, string>(instruccion, parametro1Hex,
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
            .IntruccionFinPrograma, string.Empty, string.Empty));
      }

      public static void LimpiarTablaInstrucciones()
      {
         ContadorInstrucciones = 0;
         tablaINstrucciones.Clear();
      }
/// <summary>
/// Devuelve toda la cadena del código intermedio
/// </summary>
/// <returns>Cadena que contiene el código intermedio formateado</returns>
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
/// <summary>
/// Formatea el número hexadecimal para que tenga el siguiente formato 0000 0000 0000 0000
/// </summary>
/// <param name="hexValue">Valor número hexadecimal a convertir</param>
/// <returns></returns>
      private static string FormateadorHexadecimal(string hexValue)
      {
         int lengthHex = hexValue.Length;
         StringBuilder fullStringHex = new StringBuilder();
         if (lengthHex <= 16)
         {
            //Agrega 0's hasta llegar a los 15 0's, el limite es 19 por que esta contando los espacios y excluye el último valor
            for (int i = 0; i < 20-lengthHex; i++)
            {
               if (i % 5 == 0 && i!=0)
               {
                  fullStringHex.Append(" ");
                  continue;
               }
               fullStringHex.Append("0");
            }
            for (var i = 0; i < lengthHex; i++)
            {
               if (fullStringHex.Length % 5 == 0 && fullStringHex.Length != 20)
               {
                  fullStringHex.Append(" ");
                  continue;
               }
               fullStringHex.AppendFormat(hexValue[i].ToString());
            }
            // fullStringHex.Append(decimalValue);
            // int format = int.Parse(fullStringHex.ToString(), NumberStyles.HexNumber);
               // string intento = format.ToString("X");
            // return string.Format($"{format:0000 0000 0000 0000}");
            return fullStringHex.ToString();
         }

         return hexValue;
      }
/// <summary>
/// Convierte los valores decimales a hexadecimales, así como también los valores para los char y string
/// </summary>
/// <param name="decimalValue">El valor decimal o el caracter o el string que va a convertir a hexadecimal</param>
/// <returns></returns>
      private static string ConversorDecimalAHexadecimal(string decimalValue)
      {
         StringBuilder Hex = new StringBuilder();
         if (decimalValue[decimalValue.Length - 1].Equals('V'))
         {
            string decimalValueWithoutV = decimalValue.Split('V')[0];
            if (int.TryParse(decimalValueWithoutV, out var DecimalValueIntV))
            {
               Hex.AppendFormat(FormateadorHexadecimal($"{DecimalValueIntV:X}"));
               Hex.Append("V");
               return Hex.ToString();
            }

            if (float.TryParse(decimalValueWithoutV, out var DecimalValueFloatV))
            {
               Hex.AppendFormat(FormateadorHexadecimal($"{DecimalValueFloatV:X}"));
               Hex.Append("V");
               return Hex.ToString();
            }


            var hexString1 = GetHexString(decimalValueWithoutV);
            var valueHex = FormateadorHexadecimal(hexString1);
            Hex.Append(valueHex);
            Hex.Append("V");
            return Hex.ToString();
         }

         if (int.TryParse(decimalValue, out var DecimalValueInt))
         {
            Hex.AppendFormat(FormateadorHexadecimal($"{DecimalValueInt:X}"));
            return Hex.ToString();
         }

         if (float.TryParse(decimalValue, out var DecimalValueFloat))
         {
            Hex.AppendFormat(FormateadorHexadecimal($"{DecimalValueFloat:X}"));
            return Hex.ToString();
         }

         var hexString = GetHexString(decimalValue);
         Hex.Append(hexString);
         return Hex.ToString();
      }
/// <summary>
/// Obtiene el valor hexadecimal de un caracter o una cadena
/// </summary>
/// <param name="decimalValue">Valor a convertir, sea cadena o caracter</param>
/// <returns></returns>
      private static string GetHexString(string decimalValue)
      {
         string pureString = decimalValue.Trim('\"', '\'');
         Byte[] byesOfSssstring = Encoding.Default.GetBytes(pureString);
         var hexString = BitConverter.ToString(byesOfSssstring);
         hexString = hexString.Replace("-", "");
         return hexString;
      }
   }
}
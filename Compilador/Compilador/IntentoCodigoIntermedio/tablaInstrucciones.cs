using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Compilador.IntentoCodigoIntermedio
{
   public static class TablaInstrucciones
   {
      public static readonly Dictionary<int, Tuple<IntermidiateCodeInstructions, string, string>> TablaINstrucciones =
         new Dictionary<int, Tuple<IntermidiateCodeInstructions, string, string>>();

      private static Stack<int> PilaNumerosInstruccionSaltoCondicionesAmodificar = new Stack<int>();
      public static Stack<int> PilaSaltosTerminales = new Stack<int>();
      public static int GetNumInstruccion => _contadorInstrucciones;

      public enum IntermidiateCodeInstructions
      {
         InstructionGreater,
         InstructionLower,
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

      private static readonly string[] InstruccionesString =
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

      public static string SelectInstruction(IntermidiateCodeInstructions instruccion)
      {
         return InstruccionesString.GetValue((int)Convert.ChangeType(instruccion, instruccion.GetTypeCode())).ToString();
      }

      public static void AddCallMethod(IntermidiateCodeInstructions instrucciones, string nombreMetodo)
      {
         TablaINstrucciones.Add(_contadorInstrucciones, new Tuple<IntermidiateCodeInstructions, string, string>(instrucciones, nombreMetodo, string
            .Empty));
         _contadorInstrucciones += 1;
      }

      public static void AgregarInstruccionFloat(IntermidiateCodeInstructions intermidiateCodeInstructions, string paraetro1, string parametro2)
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
            TablaINstrucciones.Add(_contadorInstrucciones, new Tuple<IntermidiateCodeInstructions, string, string>(intermidiateCodeInstructions
               ,desplazamiento1, parametroDecimalHex));
            _contadorInstrucciones++;
            return;
         }

         TablaINstrucciones.Add(_contadorInstrucciones, new Tuple<IntermidiateCodeInstructions, string, string>(intermidiateCodeInstructions
            , desplazamiento1, parametroDecimalHex));
         _contadorInstrucciones++;
         TablaINstrucciones.Add(_contadorInstrucciones, new Tuple<IntermidiateCodeInstructions, string, string>(intermidiateCodeInstructions
            , desplazamientoMantisa,parametroMantissaHex));
         _contadorInstrucciones++;
      }

      public static void AgregarInstruccion(string parametro1, string parametro2, IntermidiateCodeInstructions instruccion)
      {
         if (instruccion == IntermidiateCodeInstructions.InstruccionSalto || instruccion == IntermidiateCodeInstructions.InstruccionReturn ||
             instruccion == IntermidiateCodeInstructions.InstruccionNegacion) return;
         string parametro1Hex = ConversorDecimalAHexadecimal(parametro1);
         string parametro2Hex = ConversorDecimalAHexadecimal(parametro2);
         if (instruccion == IntermidiateCodeInstructions.InstruccionIgual || instruccion == IntermidiateCodeInstructions.InstruccionDiferente ||
             instruccion == IntermidiateCodeInstructions.InstruccionMayorIgual || instruccion == IntermidiateCodeInstructions.InstruccionMenorIgual
             || instruccion == IntermidiateCodeInstructions.InstructionLower || instruccion == IntermidiateCodeInstructions.InstructionGreater)
         {
            TablaINstrucciones.Add(_contadorInstrucciones,
               new Tuple<IntermidiateCodeInstructions, string, string>(instruccion, parametro1Hex, parametro2Hex));
            _contadorInstrucciones++;
            TablaINstrucciones.Add(_contadorInstrucciones, new Tuple<IntermidiateCodeInstructions, string, string>(IntermidiateCodeInstructions
                  .InstruccionSalto, string.Empty,
               string.Empty));
            PilaNumerosInstruccionSaltoCondicionesAmodificar.Push(_contadorInstrucciones);
            _contadorInstrucciones++;
            return;
         }

         TablaINstrucciones.Add(_contadorInstrucciones,
            new Tuple<IntermidiateCodeInstructions, string, string>(instruccion, parametro1Hex, parametro2Hex));
         _contadorInstrucciones++;
      }

      public static void AgregarInstruccion(string parametro1, IntermidiateCodeInstructions instruccion)
      {
         string parametro1Hex = ConversorDecimalAHexadecimal(parametro1);
         switch (instruccion)
         {
            case IntermidiateCodeInstructions.InstruccionNegacion:
               TablaINstrucciones.Add(_contadorInstrucciones,
                  new Tuple<IntermidiateCodeInstructions, string, string>(instruccion, parametro1Hex, "FFV"));
               break;
            case IntermidiateCodeInstructions.InstruccionReturn:
               TablaINstrucciones.Add(_contadorInstrucciones, new Tuple<IntermidiateCodeInstructions, string, string>(instruccion, string.Empty,
                  string.Empty));
               break;
            case IntermidiateCodeInstructions.InstruccionSalto:
               TablaINstrucciones.Add(_contadorInstrucciones, new Tuple<IntermidiateCodeInstructions, string, string>(instruccion, parametro1,
                  string.Empty));
               PilaSaltosTerminales.Push(_contadorInstrucciones);
               break;
            case IntermidiateCodeInstructions.InstruccionLLamar:
               TablaINstrucciones.Add(_contadorInstrucciones, new Tuple<IntermidiateCodeInstructions, string, string>(instruccion, parametro1,
                  string.Empty));
               break;
            case IntermidiateCodeInstructions.InstruccionIncremento:
            case IntermidiateCodeInstructions.InstruccionDecremento:
               TablaINstrucciones.Add(_contadorInstrucciones, new Tuple<IntermidiateCodeInstructions, string, string>(instruccion, parametro1Hex,
                  string.Empty));
               break;
         }

         _contadorInstrucciones++;
      }
      // private static bool HandleEstrucutresControl(InstruccionesCodigoIntermedio instruccionesCodigoIntermedio, string )

      private static int _contadorInstrucciones;

      public static void AgregarSaltoInverso(int numeroInstruccionSalto, IntermidiateCodeInstructions intermidiateCodeInstructions)
      {
         string valorNegativo = (numeroInstruccionSalto - (_contadorInstrucciones + 2)).ToString();
         TablaINstrucciones.Add(_contadorInstrucciones, new Tuple<IntermidiateCodeInstructions, string, string>(intermidiateCodeInstructions,
            valorNegativo, string.Empty));
         _contadorInstrucciones++;
         ModificarInstruccionSaltoCondicion();
      }

      public static void ModificarInstruccionSaltoCondicion()
      {
         int numJumpsInstruction = PilaNumerosInstruccionSaltoCondicionesAmodificar.Pop();
         int nextJump = _contadorInstrucciones - numJumpsInstruction;
         if (TablaINstrucciones.ContainsKey(numJumpsInstruction))
         {
            TablaINstrucciones[numJumpsInstruction] = new Tuple<IntermidiateCodeInstructions, string, string>(IntermidiateCodeInstructions
               .InstruccionSalto, nextJump.ToString(), string.Empty);
         }
      }

      public static void ModificarInstruccionSaltoTerminal()
      {
         int numJumpsInstruction = PilaSaltosTerminales.Pop();
         int nextJump = _contadorInstrucciones - numJumpsInstruction;
         if (TablaINstrucciones.ContainsKey(numJumpsInstruction))
         {
            TablaINstrucciones[numJumpsInstruction] = new Tuple<IntermidiateCodeInstructions, string, string>(IntermidiateCodeInstructions
               .InstruccionSalto, nextJump.ToString(), string.Empty);
         }
      }

      public static void ReiniciarInstrucciones()
      {
         _contadorInstrucciones = 0;
      }

      public static void AgregarFinPrograma()
      {
         TablaINstrucciones.Add(_contadorInstrucciones, new Tuple<IntermidiateCodeInstructions, string, string>(IntermidiateCodeInstructions
            .IntruccionFinPrograma, string.Empty, string.Empty));
      }

      public static void LimpiarTablaInstrucciones()
      {
         _contadorInstrucciones = 0;
         TablaINstrucciones.Clear();
      }
/// <summary>
/// Devuelve toda la cadena del código intermedio
/// </summary>
/// <returns>Cadena que contiene el código intermedio formateado</returns>
      public static string ConstruirCodigoIntermedio()
      {
         StringBuilder code = new StringBuilder();
         foreach (var instruccion in TablaINstrucciones)
         {
            if (string.IsNullOrEmpty(instruccion.Value.Item3))
            {
               code.AppendFormat($"{SelectInstruction(instruccion.Value.Item1)} {instruccion.Value.Item2}\n");
               continue;
            }

            if (instruccion.Value.Item1 == IntermidiateCodeInstructions.IntruccionFinPrograma)
            {
               code.Append($"{SelectInstruction(instruccion.Value.Item1)}");
               continue;
            }

            code.AppendFormat($"{SelectInstruction(instruccion.Value.Item1)} {instruccion.Value.Item2}, {instruccion.Value.Item3}\n");
         }

         return code.ToString();
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
         StringBuilder hex = new StringBuilder();
         if (decimalValue[decimalValue.Length - 1].Equals('V'))
         {
            string decimalValueWithoutV = decimalValue.Split('V')[0];
            if (int.TryParse(decimalValueWithoutV, out var decimalValueIntV))
            {
               hex.AppendFormat(FormateadorHexadecimal($"{decimalValueIntV:X}"));
               hex.Append("V");
               return hex.ToString();
            }

            if (float.TryParse(decimalValueWithoutV, result: out var decimalValueFloatV))
            {
               hex.AppendFormat(FormateadorHexadecimal($"{decimalValueFloatV:X}"));
               hex.Append("V");
               return hex.ToString();
            }


            var hexString1 = GetHexString(decimalValueWithoutV);
            var valueHex = FormateadorHexadecimal(hexString1);
            hex.Append(valueHex);
            hex.Append("V");
            return hex.ToString();
         }

         if (int.TryParse(decimalValue, result: out var decimalValueInt))
         {
            hex.AppendFormat(FormateadorHexadecimal($"{decimalValueInt:X}"));
            return hex.ToString();
         }

         if (float.TryParse(decimalValue, out var decimalValueFloat))
         {
            hex.AppendFormat(FormateadorHexadecimal($"{decimalValueFloat:X}"));
            return hex.ToString();
         }

         var hexString = GetHexString(decimalValue);
         hex.Append(hexString);
         return hex.ToString();
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
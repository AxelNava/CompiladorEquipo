using System;
using System.Text;
using Xunit.Sdk;

namespace Compilador.AnalizadorSemantico
{
   public class Mensajes_ErroresSemanticos
   {
      private static StringBuilder _mensajeError = new StringBuilder();

      public static StringBuilder MensajeError => _mensajeError;

      public static void Reset_ErrorMes()
      {
         _mensajeError.Clear();
      }

      public static void AddErrorTypes(string tipoEsperado, string tipoRecivido, int numLinea)
      {
         MensajeError.AppendFormat($"No se puede asignar un tipo {tipoRecivido} a un tipo {tipoEsperado} -- Línea {numLinea}\n");
      }

      public static void AddErrorInstanciation(string identifier, int numLinea)
      {
         MensajeError.AppendFormat($"El identificador {identifier}, no ha sido declarado  -- Línea {numLinea}\n");
      }

      public static void AddErrorDobleDeclaracion(string identifier, int numLIne)
      {
         MensajeError.AppendFormat($"El identificador {identifier}, ya ha sido declarado  -- Línea {numLIne}\n");
      }
      public static void AddErrorOperatro(string tipoEsperado, string tipoRecibido, int numLinea)
      {
         MensajeError.AppendFormat($"No se puede operar un tipo {tipoEsperado} con un {tipoRecibido}-- Línea {numLinea}\n");
      }

      public static void AddErrorOverflowMaxValue(string tipo, int numLinea)
      {
         MensajeError.AppendFormat($"Se ha excedido el valor máximo del tipo {tipo}  -- Línea {numLinea}");
      }

      public static void AddErrorOverflowMinValue(string tipo, int numLinea)
      {
         MensajeError.AppendFormat($"Se ha excedido el valo mínimo del tipo {tipo} -- Línea {numLinea}\n");
      }

      public static void AddErrorOverflowMaxMinValue(string lexema, string tipo, int numLinea)
      {
         MensajeError.AppendFormat($"El lexema ${lexema} se ha excedido el valo mínimo del tipo {tipo} -- Línea {numLinea}\n");
      }

      public static void AddErrorOperatorWithString(string operatorLexema, int numLine)
      {
         MensajeError.AppendFormat($"No se puede aplicar un operador ${operatorLexema} a un string -- Línea {numLine}\n");
      }

      public static void AddErrorWithBoolOrChar(string type, int numLine)
      {
         MensajeError.AppendFormat($"No se puede aplicar un operador a un {type} -- Línea: {numLine}\n");
      }
   }
}
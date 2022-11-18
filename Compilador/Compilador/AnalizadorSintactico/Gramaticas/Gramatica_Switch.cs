using System;
using Compilador.AnalizadorSintactico.Gramaticas.AnalysisTables;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using System.Collections.Generic;
using System.Threading;
using Compilador.AnalizadorSemantico;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Compilador.Gramaticas;
using Compilador.TablasGlobales;

namespace Compilador.AnalizadorSintactico.Gramaticas
{
   public class Gramatica_Switch : AbstractAnalisisTable
   {
      public Gramatica_Switch()
      {
         tablaAnalisis = AnalysisTable_Switch.GlobalDictionarySwitch;
         PilaComprobacion = new Stack<Tuple<int, string>>();
         PilaComprobacion.Push(new Tuple<int, string>(0, "0"));
      }

      public string Ejecutar_Analisis()
      {
         analisisFinished = false;
         while (PilaTokens.GlobalTokens.Count >= 1)
         {
            if (!CheckTokenIn_Handler())
            {
               PilaTokens.GlobalTokens.Push("Lambda");
               if (!CheckTokenIn_Handler())
               {
                  PilaTokens.GlobalTokens.Pop();
                  PilaTokens.GlobalTokens.Push("FinCadena");
                  if (!CheckTokenIn_Handler())
                  {
                     PilaTokens.GlobalTokens.Pop();
                     return string.Empty;
                  }
               }
            }

            if (analisisFinished) return "<Switch>";
         }

         return string.Empty;
      }

      private bool CheckTokenIn_Handler()
      {
         int referenceState = PilaComprobacion.Peek().Item1;
         if (referenceState == 3)
         {
            string tokenAux = new GramaticaValores().EjecutarAnalisis();
            if (!string.IsNullOrEmpty(tokenAux))
               PilaTokens.GlobalTokens.Push(tokenAux);
         }

         if (referenceState == 17 || referenceState == 18)
         {
            //Cambiar por cuerpoInstrucciones
            // string tokenAux = new GramaticaValores().EjecutarAnalisis();
            // if (!string.IsNullOrEmpty(tokenAux))
            //    PilaTokens.GlobalTokens.Push(tokenAux);
         }

         if (tablaAnalisis[referenceState].ContainsKey(PilaTokens.GlobalTokens.Peek()))
         {
            // PilaTokens.numLineToken.RemoveAt(0);
            AbstractActionFunction.ActionEnum actionEnum;
            actionEnum = tablaAnalisis[referenceState][PilaTokens.GlobalTokens.Peek()].Action;
            HandleActions(actionEnum);
            return true;
         }

         return false;
      }
   }
}
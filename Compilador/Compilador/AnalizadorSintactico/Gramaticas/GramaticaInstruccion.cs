using System;
using Compilador.AnalizadorSintactico.Gramaticas.AnalysisTables;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using Compilador.Gramaticas;

namespace Compilador.AnalizadorSintactico.Gramaticas
{
   public class GramaticaInstruccion : AbstractAnalisisTable
   {
      public GramaticaInstruccion()
      {
         tablaAnalisis = AnalisysTable_Instrucciones.GlobalDictionaryInstrucciones;
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
            if (analisisFinished) return "Instruccion";
         }
         return string.Empty;
      }
      private bool CheckTokenIn_Handler()
      {
         int referenceState = PilaComprobacion.Peek().Item1;
         if (referenceState == 9 || referenceState == 11)
         {
            string tokenAux = new GramaticaValores().EjecutarAnalisis();
            if (!string.IsNullOrEmpty(tokenAux))
               PilaTokens.GlobalTokens.Push(tokenAux);
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
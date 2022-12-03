using System;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesBase;
using System.Collections.Generic;
using Compilador.AnalizadorSintactico.Gramaticas.AnalysisTables;
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;

namespace Compilador.AnalizadorSintactico.Gramaticas
{
   public class GramaticaParametrosMetodo : AbstractAnalisisTable
   {
      
      public GramaticaParametrosMetodo()
      {
         TablaAnalisis = AnalysisTable_ParametrosFuncion.GlobalDictionaryParametros;
         PilaComprobacion = new Stack<Tuple<int, string>>();
         PilaComprobacion.Push(new Tuple<int, string>(0, "0"));
      }
      public string Ejecutar_Analisis()
      {
         AnalisisFinished = false;
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
            if (AnalisisFinished) return "ParametrosMetodo";
         }
         return string.Empty;
      }
      private bool CheckTokenIn_Handler()
      {
         int referenceState = PilaComprobacion.Peek().Item1;
         if (referenceState == 0 || referenceState == 6)
         {
            var grammar = new GramaticaValores();
            string tokenAux = grammar.EjecutarAnalisis();
            if (!string.IsNullOrEmpty(tokenAux))
            {
               PilaTokens.GlobalTokens.Push(tokenAux);
            }
         }
         if (TablaAnalisis[referenceState].ContainsKey(PilaTokens.GlobalTokens.Peek()))
         {
            AbstractActionFunction.ActionEnum actionEnum;
            actionEnum = TablaAnalisis[referenceState][PilaTokens.GlobalTokens.Peek()].Action;
            HandleActions(actionEnum);
            return true;
         }
         return false;
      }
   }
}
using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Compilador.AnalizadorSemantico;
using Compilador.AnalizadorSintactico;
using Compilador.AnalizadorSintactico.Gramaticas;
using Compilador.Gramaticas;
using Compilador.IntentoCodigoIntermedio;
using Compilador.TablasGlobales;

namespace Compilador
{
   public partial class Form1 : Form
   {
      private int _countLines;

      public Form1()
      {
         _countLines = 1;
         TablaSimbolos tablesymbol = TablaSimbolos.GetInstance();
         InitializeComponent();
         //Fill the table
         var lexemas = TablaSimbolos.GetLexemasValues();
         var tokens = TablaSimbolos.GetTokensValues();
         var types = TablaSimbolos.GetTypesValues();
         var numLines = TablaSimbolos.GetNumLine();
         var values = TablaSimbolos.GetValues();
         var desplazamientos = TablaSimbolos.GetDesplazamientos();
         foreach (var item in TablaSimbolos.GetLexemasValues().Keys)
         {
            dataGridTableSymbols.Rows.Add(lexemas[item], tokens[item], types[item], numLines[item], values[item], desplazamientos[item]);
         }
      }

      private void button1_Click(object sender, EventArgs e)
      {
         TablaSimbolos.ClearSymbolTable();
         ClearAllStructuresData();
         AutomatasLexicos auLex = new AutomatasLexicos(EntradaCompiladorTextBox.Text);
         dataGridLexema.Rows.Clear();
         dataGridTableToken.Rows.Clear();
         dataGridTableSymbols.Rows.Clear();
         try
         {
            var map = auLex.ExecuteAnalizer();
            foreach (var todo in map)
            {
               dataGridLexema.Rows.Add(todo[0]);
               dataGridTableToken.Rows.Add(todo[0], todo[1]);
            }
            fillTableVisual();
            AlmacenarTokens_EnStack(map);

            #region Analis sintactico_semantico_codigoIntermedio

            Gramatica_ArchivoClase pruebaValores = new Gramatica_ArchivoClase();
            // Gramatica_CuerpoClase pruebaValores = new Gramatica_CuerpoClase();
            MessageBox.Show(pruebaValores.EjecutarAnalisis());

            #endregion

            fillTableVisual();
            string errores = ConstructuError(auLex.messasgesErros);
            textBoxErrores.Text = errores;
            textBoxErrores.ForeColor = Color.Red;
            if (string.IsNullOrEmpty(errores))
            {
               string codigoIntermedio = TablaInstrucciones.ConstruirCodigoIntermedio();
               // MessageBox.Show(codigoIntermedio);
               Convertidor_string_a_txt.Convertidor(codigoIntermedio);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show("Ha habido un error:\n" + ex.Message);
            MessageBox.Show("Ha habido un error:\n" + ex.StackTrace);
         }
      }

      private void ClearAllStructuresData()
      {
         ErrorSintaxManager.ClearMessage();
         Mensajes_ErroresSemanticos.Reset_ErrorMes();
         ContadorDesplazamiento.ConteoDesplazamiento = 0;
         LexemaCount.CountLexemas = 0;
         TablaLexemaToken.ClearTable();
         TablaInstrucciones.ReiniciarInstrucciones();
         TablaInstrucciones.LimpiarTablaInstrucciones();
      }

      private void EnterPressedEvent(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
         {
            _countLines++;
            if (_countLines == 10)
               countLinesBox.Size = new Size(60, 360);
            if (_countLines == 100)
            {
               countLinesBox.Size = new Size(72, 360);
            }

            countLinesBox.Text += "\n" + _countLines;
         }
      }

      private void AlmacenarTokens_EnStack(List<string[]> lexemaTokens)
      {
         PilaTokens.GlobalTokens.Clear();
         PilaTokens.GlobalTokens.Push("FinCadena");
         lexemaTokens.Reverse();
         foreach (var token in lexemaTokens)
         {
            PilaTokens.GlobalTokens.Push(token[1]);
         }
      }

      private void fillTableVisual()
      {
         dataGridTableSymbols.Rows.Clear();
         var lexemas = TablaSimbolos.GetLexemasValues();
         var tokens = TablaSimbolos.GetTokensValues();
         var types = TablaSimbolos.GetTypesValues();
         var numLines = TablaSimbolos.GetNumLine();
         var values = TablaSimbolos.GetValues();
         var desplazamientos = TablaSimbolos.GetDesplazamientos();
         foreach (var item in TablaSimbolos.GetLexemasValues().Keys)
         {
            dataGridTableSymbols.Rows.Add(lexemas[item], tokens[item], types[item], numLines[item], values[item], desplazamientos[item]);
         }
      }

      private string ConstructuError(string errorLexico)
      {
         StringBuilder errores = new StringBuilder();
         StringBuilder ErroresLexico = new StringBuilder(errorLexico);
         StringBuilder errorSintactico = new StringBuilder(ErrorSintaxManager.GetMessageError());
         StringBuilder erroresSemanticos = new StringBuilder(Mensajes_ErroresSemanticos.MensajeError.ToString());
         errores.AppendFormat($"{ErroresLexico}\n");
         errores.AppendFormat($"{errorSintactico}\n");
         errores.AppendFormat($"{erroresSemanticos}\n");
         if (string.IsNullOrEmpty(ErroresLexico.ToString()) && string.IsNullOrEmpty(errorSintactico.ToString()) && string.IsNullOrEmpty(erroresSemanticos.ToString()))
         {
            return string.Empty;
         }
         return errores.ToString();
      }
   }
}
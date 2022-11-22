﻿using Compilador.AnalizadorSintactico.Gramaticas.ClasesGlobales;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Compilador.AnalizadorSintactico.Gramaticas;
using Compilador.Gramaticas;

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
            GramaticaInstruccion pruebaValores = new GramaticaInstruccion();
            // Gramatica_Switch pruebaValores = new Gramatica_Switch();
            // Gramatica_IF pruebaValores = new Gramatica_IF();
            MessageBox.Show(pruebaValores.Ejecutar_Analisis());
            fillTableVisual();

            textBoxErrores.Text = auLex.messasgesErros;
            textBoxErrores.ForeColor = Color.Red;
         }
         catch (Exception ex)
         {
            MessageBox.Show("Ha habido un error:\n" + ex.Message);
         }
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
         var lexemas = TablaSimbolos.GetLexemasValues();
         var tokens = TablaSimbolos.GetTokensValues();
         var types = TablaSimbolos.GetTypesValues();
         var numLines = TablaSimbolos.GetNumLine();
         var values = TablaSimbolos.GetValues();
         var desplazamientos = TablaSimbolos.GetDesplazamientos();
         foreach (var item in TablaSimbolos.GetLexemasValues().Keys)
         {
            dataGridTableSymbols.Rows.Add(lexemas[item], tokens[item], types[item], numLines[item], values[item],desplazamientos[item]);
         }
         
      }
   }
}
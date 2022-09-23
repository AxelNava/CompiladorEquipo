﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Compilador {
    public partial class Form1 : Form {
        int countLines;
        public Form1() {
            countLines = 1;
            TablaSimbolos tablesymbol = TablaSimbolos.GetInstance();
            InitializeComponent();
            //Fill the table
            var lexemas = TablaSimbolos.GetLexemasValues();
            var tokens = TablaSimbolos.GetTokensValues();
            var types = TablaSimbolos.GetTypesValues();
            var numLines = TablaSimbolos.GetNumLine();
            foreach ( var item in TablaSimbolos.GetLexemasValues().Keys ) {
                dataGridTableSymbols.Rows.Add(lexemas [item], tokens [item], types [item], numLines [item]);
            }
        }

        private void button1_Click( object sender, EventArgs e ) {
            TablaSimbolos.ClearSymbolTable();
            AutomatasLexicos auLex = new AutomatasLexicos(EntradaCompiladorTextBox.Text);
            dataGridLexema.Rows.Clear();
            dataGridTableToken.Rows.Clear();
            dataGridTableSymbols.Rows.Clear();
            try {
                var map = auLex.ExecuteAnalizer();
                foreach ( var todo in map ) {
                    dataGridLexema.Rows.Add(todo [0]);
                    dataGridTableToken.Rows.Add(todo [0], todo [1]);
                }
                var lexemas = TablaSimbolos.GetLexemasValues();
                var tokens = TablaSimbolos.GetTokensValues();
                var types = TablaSimbolos.GetTypesValues();
                var numLines = TablaSimbolos.GetNumLine();
                foreach ( var item in TablaSimbolos.GetLexemasValues().Keys ) {
                    dataGridTableSymbols.Rows.Add(lexemas [item], tokens [item], types [item], numLines [item]);
                }
                textBoxErrores.Text = auLex.messasgesErros;
                textBoxErrores.ForeColor = Color.Red;
            }
            catch ( Exception ex ) {
                MessageBox.Show("Ha habido un error:\n" + ex.Message);
            }
        }

        private void EnterPressedEvent( object sender, KeyEventArgs e ) {
            if ( e.KeyCode == Keys.Enter ) {
                countLines++;
                if ( countLines == 10 )
                    countLinesBox.Size = new Size(60, 360);
                if ( countLines == 100 ) {
                    countLinesBox.Size = new Size(72, 360);
                }
                countLinesBox.Text += "\n" + countLines;
            }
        }
    }
}

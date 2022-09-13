using System;
using System.Drawing;
using System.Windows.Forms;

namespace Compilador {
    public partial class Form1 : Form {
        int countLines;
        public Form1() {
            countLines = 1;
            TablaSimbolos tablesymbol = TablaSimbolos.GetInstance();
            InitializeComponent();
            foreach ( var item in TablaSimbolos.GetLexemasValues().Keys ) {
                dataGridTableSymbols.Rows.Add(TablaSimbolos.GetLexemasValues() [item], TablaSimbolos.GetTokensValues() [item], TablaSimbolos.GetTypesValues() [item], TablaSimbolos.GetNumLine() [item]);
            }
        }

        private void button1_Click( object sender, EventArgs e ) {
            AutomatasLexicos auLex = new AutomatasLexicos(EntradaCompiladorTextBox.Text);
            dataGridLexema.Rows.Clear();
            dataGridTableToken.Rows.Clear();
            try {
                var map = auLex.ExecuteAnalizer();
                foreach ( var todo in map ) {
                    if ( todo [1] == "Identificador" ) {
                        dataGridTableSymbols.Rows.Add(todo [0], todo [0], String.Empty, String.Empty, String.Empty);
                    }
                    dataGridTableToken.Rows.Add(todo [0], todo [1]);
                    dataGridLexema.Rows.Add(todo [0]);
                }
            }
            catch ( Exception ex ) {
                MessageBox.Show("Ha habido un eror " + ex.Message);
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

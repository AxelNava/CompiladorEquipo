using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador {
    public partial class Form1 : Form {
        public Form1() {
            TablaSimbolos tablesymbol = TablaSimbolos.GetInstance();
            InitializeComponent();
        }

        private void button1_Click( object sender, EventArgs e ) {
            AutomatasLexicos auLex = new AutomatasLexicos(EntradaCompiladorTextBox.Text);
            Dictionary<string, string> map = auLex.ExecuteAnalizer();
            foreach(var todo in map ) {
                MessageBox.Show(String.Concat("Lexema: ",todo.Key, "\nToken: ",todo.Value));
            }
        }

    }
}

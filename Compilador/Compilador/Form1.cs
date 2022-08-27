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
            string message = "";
            foreach ( var values in TablaSimbolos.GetTokensValues() ) {
                message += String.Format("values: {0}\n", values.ToString());
            }
            MessageBox.Show(message);
        }
    }
}

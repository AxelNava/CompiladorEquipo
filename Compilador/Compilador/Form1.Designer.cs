namespace Compilador {
    partial class Form1 {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && (components != null) ) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.button1 = new System.Windows.Forms.Button();
            this.EntradaCompiladorTextBox = new System.Windows.Forms.TextBox();
            this.labeLineas = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(356, 60);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "Analizar lexico";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EntradaCompiladorTextBox
            // 
            this.EntradaCompiladorTextBox.Location = new System.Drawing.Point(72, 42);
            this.EntradaCompiladorTextBox.Multiline = true;
            this.EntradaCompiladorTextBox.Name = "EntradaCompiladorTextBox";
            this.EntradaCompiladorTextBox.Size = new System.Drawing.Size(257, 350);
            this.EntradaCompiladorTextBox.TabIndex = 1;
            this.EntradaCompiladorTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterPressedEvent);
            // 
            // labeLineas
            // 
            this.labeLineas.AutoSize = true;
            this.labeLineas.Font = new System.Drawing.Font("JetBrains Mono", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeLineas.Location = new System.Drawing.Point(12, 42);
            this.labeLineas.MaximumSize = new System.Drawing.Size(72, 350);
            this.labeLineas.Name = "labeLineas";
            this.labeLineas.Size = new System.Drawing.Size(26, 29);
            this.labeLineas.TabIndex = 2;
            this.labeLineas.Text = "9";
            this.labeLineas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 853);
            this.Controls.Add(this.labeLineas);
            this.Controls.Add(this.EntradaCompiladorTextBox);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("JetBrains Mono", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox EntradaCompiladorTextBox;
        private System.Windows.Forms.Label labeLineas;
    }
}


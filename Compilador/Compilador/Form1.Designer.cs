﻿namespace Compilador {
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.EntradaCompiladorTextBox = new System.Windows.Forms.TextBox();
            this.dataGridTableSymbols = new System.Windows.Forms.DataGridView();
            this.countLinesBox = new System.Windows.Forms.TextBox();
            this.dataGridTableToken = new System.Windows.Forms.DataGridView();
            this.Lexema_TableToken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Token_TableToken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridLexema = new System.Windows.Forms.DataGridView();
            this.LexemaEncontrado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxErrores = new System.Windows.Forms.TextBox();
            this.Desplazamiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Token = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lexema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTableSymbols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTableToken)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLexema)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "Analizar lexico";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EntradaCompiladorTextBox
            // 
            this.EntradaCompiladorTextBox.Location = new System.Drawing.Point(70, 32);
            this.EntradaCompiladorTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.EntradaCompiladorTextBox.Multiline = true;
            this.EntradaCompiladorTextBox.Name = "EntradaCompiladorTextBox";
            this.EntradaCompiladorTextBox.Size = new System.Drawing.Size(198, 441);
            this.EntradaCompiladorTextBox.TabIndex = 1;
            this.EntradaCompiladorTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterPressedEvent);
            // 
            // dataGridTableSymbols
            // 
            this.dataGridTableSymbols.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTableSymbols.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.Lexema, this.Token, this.Tipo, this.NumeroLinea, this.Valor, this.Desplazamiento });
            this.dataGridTableSymbols.Location = new System.Drawing.Point(388, 34);
            this.dataGridTableSymbols.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridTableSymbols.Name = "dataGridTableSymbols";
            this.dataGridTableSymbols.RowHeadersWidth = 51;
            this.dataGridTableSymbols.RowTemplate.Height = 24;
            this.dataGridTableSymbols.Size = new System.Drawing.Size(835, 426);
            this.dataGridTableSymbols.TabIndex = 3;
            // 
            // countLinesBox
            // 
            this.countLinesBox.Enabled = false;
            this.countLinesBox.Location = new System.Drawing.Point(9, 32);
            this.countLinesBox.Margin = new System.Windows.Forms.Padding(2);
            this.countLinesBox.MaximumSize = new System.Drawing.Size(77, 441);
            this.countLinesBox.Multiline = true;
            this.countLinesBox.Name = "countLinesBox";
            this.countLinesBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.countLinesBox.Size = new System.Drawing.Size(40, 441);
            this.countLinesBox.TabIndex = 4;
            this.countLinesBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.countLinesBox.Visible = false;
            // 
            // dataGridTableToken
            // 
            this.dataGridTableToken.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTableToken.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.Lexema_TableToken, this.Token_TableToken });
            this.dataGridTableToken.Location = new System.Drawing.Point(388, 485);
            this.dataGridTableToken.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridTableToken.Name = "dataGridTableToken";
            this.dataGridTableToken.RowHeadersWidth = 51;
            this.dataGridTableToken.RowTemplate.Height = 24;
            this.dataGridTableToken.Size = new System.Drawing.Size(344, 113);
            this.dataGridTableToken.TabIndex = 5;
            // 
            // Lexema_TableToken
            // 
            this.Lexema_TableToken.HeaderText = "Lexema";
            this.Lexema_TableToken.MinimumWidth = 6;
            this.Lexema_TableToken.Name = "Lexema_TableToken";
            this.Lexema_TableToken.Width = 125;
            // 
            // Token_TableToken
            // 
            this.Token_TableToken.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Token_TableToken.HeaderText = "Token";
            this.Token_TableToken.MinimumWidth = 6;
            this.Token_TableToken.Name = "Token_TableToken";
            // 
            // dataGridLexema
            // 
            this.dataGridLexema.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLexema.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.LexemaEncontrado });
            this.dataGridLexema.Location = new System.Drawing.Point(9, 493);
            this.dataGridLexema.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridLexema.Name = "dataGridLexema";
            this.dataGridLexema.RowHeadersWidth = 51;
            this.dataGridLexema.RowTemplate.Height = 24;
            this.dataGridLexema.ShowRowErrors = false;
            this.dataGridLexema.Size = new System.Drawing.Size(259, 113);
            this.dataGridLexema.TabIndex = 6;
            // 
            // LexemaEncontrado
            // 
            this.LexemaEncontrado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LexemaEncontrado.HeaderText = "Lexema";
            this.LexemaEncontrado.MinimumWidth = 6;
            this.LexemaEncontrado.Name = "LexemaEncontrado";
            // 
            // textBoxErrores
            // 
            this.textBoxErrores.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxErrores.Enabled = false;
            this.textBoxErrores.Font = new System.Drawing.Font("JetBrains Mono", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxErrores.ForeColor = System.Drawing.Color.Red;
            this.textBoxErrores.Location = new System.Drawing.Point(752, 485);
            this.textBoxErrores.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxErrores.Multiline = true;
            this.textBoxErrores.Name = "textBoxErrores";
            this.textBoxErrores.Size = new System.Drawing.Size(471, 115);
            this.textBoxErrores.TabIndex = 7;
            // 
            // Desplazamiento
            // 
            this.Desplazamiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Desplazamiento.HeaderText = "Desplazamiento";
            this.Desplazamiento.Name = "Desplazamiento";
            // 
            // Valor
            // 
            this.Valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Valor.HeaderText = "Valor";
            this.Valor.MinimumWidth = 6;
            this.Valor.Name = "Valor";
            // 
            // NumeroLinea
            // 
            this.NumeroLinea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NumeroLinea.HeaderText = "Numero de Linea";
            this.NumeroLinea.MinimumWidth = 6;
            this.NumeroLinea.Name = "NumeroLinea";
            // 
            // Tipo
            // 
            this.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.MinimumWidth = 6;
            this.Tipo.Name = "Tipo";
            // 
            // Token
            // 
            this.Token.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Token.HeaderText = "Token";
            this.Token.MinimumWidth = 6;
            this.Token.Name = "Token";
            // 
            // Lexema
            // 
            this.Lexema.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Lexema.HeaderText = "Lexema";
            this.Lexema.MinimumWidth = 6;
            this.Lexema.Name = "Lexema";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 647);
            this.Controls.Add(this.textBoxErrores);
            this.Controls.Add(this.dataGridLexema);
            this.Controls.Add(this.dataGridTableToken);
            this.Controls.Add(this.countLinesBox);
            this.Controls.Add(this.dataGridTableSymbols);
            this.Controls.Add(this.EntradaCompiladorTextBox);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("JetBrains Mono", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTableSymbols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTableToken)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLexema)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn Desplazamiento;

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox EntradaCompiladorTextBox;
        private System.Windows.Forms.DataGridView dataGridTableSymbols;
        private System.Windows.Forms.TextBox countLinesBox;
        private System.Windows.Forms.DataGridView dataGridTableToken;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexema_TableToken;
        private System.Windows.Forms.DataGridViewTextBoxColumn Token_TableToken;
        private System.Windows.Forms.DataGridView dataGridLexema;
        private System.Windows.Forms.DataGridViewTextBoxColumn LexemaEncontrado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexema;
        private System.Windows.Forms.DataGridViewTextBoxColumn Token;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroLinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.TextBox textBoxErrores;
    }
}


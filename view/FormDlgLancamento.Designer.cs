
namespace FinanceControlX
{
    partial class FormDlgLancamento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxTipo = new System.Windows.Forms.GroupBox();
            this.radioButtonReceita = new System.Windows.Forms.RadioButton();
            this.radioButtonDespesa = new System.Windows.Forms.RadioButton();
            this.textBoxDescricao = new System.Windows.Forms.TextBox();
            this.textBoxObservacao = new System.Windows.Forms.TextBox();
            this.comboBoxCategoria = new System.Windows.Forms.ComboBox();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.textBoxValor = new System.Windows.Forms.TextBox();
            this.btnExcluirCategoria = new System.Windows.Forms.LinkLabel();
            this.groupBoxTipo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Valor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Descrição";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Categoria";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(173, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Observação";
            // 
            // groupBoxTipo
            // 
            this.groupBoxTipo.Controls.Add(this.radioButtonReceita);
            this.groupBoxTipo.Controls.Add(this.radioButtonDespesa);
            this.groupBoxTipo.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTipo.Name = "groupBoxTipo";
            this.groupBoxTipo.Size = new System.Drawing.Size(391, 63);
            this.groupBoxTipo.TabIndex = 0;
            this.groupBoxTipo.TabStop = false;
            this.groupBoxTipo.Text = "Tipo";
            // 
            // radioButtonReceita
            // 
            this.radioButtonReceita.AutoSize = true;
            this.radioButtonReceita.Location = new System.Drawing.Point(104, 29);
            this.radioButtonReceita.Name = "radioButtonReceita";
            this.radioButtonReceita.Size = new System.Drawing.Size(62, 17);
            this.radioButtonReceita.TabIndex = 1;
            this.radioButtonReceita.TabStop = true;
            this.radioButtonReceita.Text = "Receita";
            this.radioButtonReceita.UseVisualStyleBackColor = true;
            // 
            // radioButtonDespesa
            // 
            this.radioButtonDespesa.AutoSize = true;
            this.radioButtonDespesa.Location = new System.Drawing.Point(15, 29);
            this.radioButtonDespesa.Name = "radioButtonDespesa";
            this.radioButtonDespesa.Size = new System.Drawing.Size(67, 17);
            this.radioButtonDespesa.TabIndex = 0;
            this.radioButtonDespesa.TabStop = true;
            this.radioButtonDespesa.Text = "Despesa";
            this.radioButtonDespesa.UseVisualStyleBackColor = true;
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.Location = new System.Drawing.Point(18, 107);
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.Size = new System.Drawing.Size(268, 20);
            this.textBoxDescricao.TabIndex = 1;
            // 
            // textBoxObservacao
            // 
            this.textBoxObservacao.Location = new System.Drawing.Point(176, 164);
            this.textBoxObservacao.Name = "textBoxObservacao";
            this.textBoxObservacao.Size = new System.Drawing.Size(218, 20);
            this.textBoxObservacao.TabIndex = 4;
            // 
            // comboBoxCategoria
            // 
            this.comboBoxCategoria.FormattingEnabled = true;
            this.comboBoxCategoria.Location = new System.Drawing.Point(18, 164);
            this.comboBoxCategoria.Name = "comboBoxCategoria";
            this.comboBoxCategoria.Size = new System.Drawing.Size(138, 21);
            this.comboBoxCategoria.TabIndex = 3;
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(61)))), ((int)(((byte)(82)))));
            this.buttonSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalvar.ForeColor = System.Drawing.Color.White;
            this.buttonSalvar.Location = new System.Drawing.Point(319, 224);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(75, 23);
            this.buttonSalvar.TabIndex = 5;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonCancelar.Location = new System.Drawing.Point(238, 224);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 6;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // textBoxValor
            // 
            this.textBoxValor.Location = new System.Drawing.Point(306, 107);
            this.textBoxValor.Name = "textBoxValor";
            this.textBoxValor.Size = new System.Drawing.Size(88, 20);
            this.textBoxValor.TabIndex = 2;
            // 
            // btnExcluirCategoria
            // 
            this.btnExcluirCategoria.AutoSize = true;
            this.btnExcluirCategoria.Location = new System.Drawing.Point(118, 188);
            this.btnExcluirCategoria.Name = "btnExcluirCategoria";
            this.btnExcluirCategoria.Size = new System.Drawing.Size(38, 13);
            this.btnExcluirCategoria.TabIndex = 7;
            this.btnExcluirCategoria.TabStop = true;
            this.btnExcluirCategoria.Text = "Excluir";
            this.btnExcluirCategoria.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnExcluirCategoria_MouseClick);
            // 
            // FormDlgLancamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 259);
            this.Controls.Add(this.btnExcluirCategoria);
            this.Controls.Add(this.textBoxValor);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(this.comboBoxCategoria);
            this.Controls.Add(this.textBoxObservacao);
            this.Controls.Add(this.textBoxDescricao);
            this.Controls.Add(this.groupBoxTipo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "FormDlgLancamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDlgLancamento_FormClosing);
            this.groupBoxTipo.ResumeLayout(false);
            this.groupBoxTipo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBoxTipo;
        private System.Windows.Forms.RadioButton radioButtonReceita;
        private System.Windows.Forms.RadioButton radioButtonDespesa;
        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.TextBox textBoxObservacao;
        private System.Windows.Forms.ComboBox comboBoxCategoria;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.TextBox textBoxValor;
        private System.Windows.Forms.LinkLabel btnExcluirCategoria;
    }
}
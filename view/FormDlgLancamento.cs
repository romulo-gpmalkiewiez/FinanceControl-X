using FinanceControlX.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceControlX
{
    public partial class FormDlgLancamento : Form
    {
        private Lancamento _lancamento;
        private Form _sourceForm;

        public FormDlgLancamento(Form sourceForm)
        {
            _sourceForm = sourceForm;
            _lancamento = new Lancamento();
            InitializeComponent();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormDlgLancamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ConfirmExit())
            {
                _sourceForm.Enabled = true;
            } 
            else
            {
                e.Cancel = true;
            }
        }

        private bool ConfirmExit()
        {
            return MessageBox.Show(
                "Dados não salvos serão perdidos!\nDeseja realmente fechar?",
                "Atenção",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            ) == DialogResult.Yes;
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateLancamentoFromScreenData();
                Lancamento.Save(_lancamento);
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show(argEx.Message, "Campos não preenchidos.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateLancamentoFromScreenData()
        {
            _lancamento.Tipo = radioButtonDespesa.Checked ? "DESPESA" : "RECEITA";
            if (!String.IsNullOrEmpty(textBoxValor.Text))
            {
                _lancamento.Valor = decimal.Parse(textBoxValor.Text);
            }
            _lancamento.Descricao = textBoxDescricao.Text;
            _lancamento.Observacao = textBoxObservacao.Text;
            _lancamento.CategoriaId = comboBoxCategoria.SelectedValue != null ? 4 : 4;
        }
    }
}

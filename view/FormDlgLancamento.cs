using FinanceControlX.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FinanceControlX
{
    public partial class FormDlgLancamento : Form
    {
        private Lancamento _lancamento;
        private List<Categoria> _categorias;
        private Action _onSaveCallback;
        private Form _sourceForm;

        public FormDlgLancamento(Form sourceForm, int lancamentoId, Action onSaveCallback)
        {
            InitializeComponent();

            _sourceForm = sourceForm;
            _lancamento = lancamentoId == 0 ? new Lancamento(): Lancamento.GetLancamentoById(lancamentoId);
            _categorias = Categoria.GetCategorias();
            _onSaveCallback = onSaveCallback;

            PopulateLancamentoScreenFields();

            this.Text = _lancamento.Id == null ? "Adicionar Lançamento" : "Editar Lançamento";
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private Boolean HasChanges()
        {
            return false;

            //ConvertScreenDataToLancamento();

            //return _lancamento.CategoriaId != null
            //    || (_lancamento.Valor != null && _lancamento.Valor > 0)
            //    || (_lancamento.Descricao != null && _lancamento.Descricao.Length > 0)
            //    || (_lancamento.Observacao != null && _lancamento.Observacao.Length > 0);
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
            if (!HasChanges())
            {
                return true;
            }
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
                ConvertScreenDataToLancamento();

                // verificar categoria
                Categoria.Save(_lancamento.categoria);
                UpdateCategorias();
                Lancamento.Save(_lancamento);

                _onSaveCallback();
                this.Close();

                MessageBox.Show("Lançamento salvo com sucesso!");
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show(argEx.Message, "Campos não preenchidos.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ConvertScreenDataToLancamento()
        {
            _lancamento.Tipo = radioButtonDespesa.Checked ? "DESPESA" : "RECEITA";
            if (!String.IsNullOrEmpty(textBoxValor.Text))
            {
                _lancamento.Valor = decimal.Parse(textBoxValor.Text);
            }
            _lancamento.Descricao = textBoxDescricao.Text;
            _lancamento.Observacao = textBoxObservacao.Text;

            if (comboBoxCategoria.SelectedValue != null)
            {
                _lancamento.CategoriaId = (int)comboBoxCategoria.SelectedValue;
                _lancamento.categoria = comboBoxCategoria.SelectedItem as Categoria;
            } else
            {
                _lancamento.categoria = new Categoria(comboBoxCategoria.Text);
            }
        }

        private void PopulateLancamentoScreenFields()
        {
            radioButtonDespesa.Checked = _lancamento.Tipo == "DESPESA";
            radioButtonReceita.Checked = _lancamento.Tipo == "RECEITA";
            textBoxValor.Text = _lancamento.Valor.ToString();
            textBoxDescricao.Text = _lancamento.Descricao;
            textBoxObservacao.Text = _lancamento.Observacao;
            PopulateCategorias();
        }

        private void PopulateCategorias()
        {
            comboBoxCategoria.DataSource = _categorias;
            comboBoxCategoria.ValueMember = "Id";
            comboBoxCategoria.DisplayMember = "Nome";

            if (_lancamento.CategoriaId != null)
            {
                comboBoxCategoria.SelectedItem = _categorias.Find(c => c.Id == _lancamento.CategoriaId);
            }
        }

        private List<Categoria> UpdateCategorias()
        {
            _categorias = Categoria.GetCategorias();
            PopulateCategorias();
            return _categorias;
        }

        private void btnExcluirCategoria_MouseClick(object sender, MouseEventArgs e)
        {
            var categoriaId = (int)comboBoxCategoria.SelectedValue;

            if (Categoria.Delete(categoriaId))
            {
                UpdateCategorias();
                MessageBox.Show("Categoria excluída com sucesso!");
            }
        }
    }
}

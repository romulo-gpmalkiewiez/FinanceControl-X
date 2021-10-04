using FinanceControlX.model;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FinanceControlX
{
    public partial class FormMain : Form
    {
        private DataTable dataTableLancamentos = new DataTable();

        public FormMain()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            UpdateDataTableLancamentos();
            ConfigurarDataTableViewLancamentos();
        }

        private void ConfigurarDataTableViewLancamentos()
        {
            dataGridViewLancamentos.DefaultCellStyle.Font = new Font("Arial", 9);
            dataGridViewLancamentos.RowHeadersWidth = 25;

            dataGridViewLancamentos.Columns["id"].HeaderText = "ID";
            dataGridViewLancamentos.Columns["id"].Visible = false;

            dataGridViewLancamentos.Columns["tipo"].HeaderText = "Tipo";
            dataGridViewLancamentos.Columns["tipo"].Width = 110;

            dataGridViewLancamentos.Columns["nome_categoria"].HeaderText = "Categoria";
            dataGridViewLancamentos.Columns["nome_categoria"].Width = 130;

            dataGridViewLancamentos.Columns["valor"].HeaderText = "Valor (R$)";
            dataGridViewLancamentos.Columns["valor"].Width = 150;
            dataGridViewLancamentos.Columns["valor"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewLancamentos.Columns["valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridViewLancamentos.Columns["descricao"].HeaderText = "Descrição";
            dataGridViewLancamentos.Columns["descricao"].Width = 200;

            dataGridViewLancamentos.Columns["observacao"].HeaderText = "Observação";
            dataGridViewLancamentos.Columns["observacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void OpenLancamentoDlg(int lancamentoId)
        {
            this.Enabled = false;
            FormDlgLancamento formDlgLancamento = new FormDlgLancamento(this, lancamentoId, this.UpdateDataTableLancamentos);
            formDlgLancamento.ShowDialog();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            OpenLancamentoDlg(0);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            OpenLancamentoDlg(GetSelectedLancamentoId());
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int selectedLancamentoId = GetSelectedLancamentoId();

            if (Lancamento.Delete(selectedLancamentoId))
            {
                UpdateDataTableLancamentos();
                MessageBox.Show("Lançamento removido com sucesso!");
            }
        }

        private int GetSelectedLancamentoId()
        {
            DataGridViewRow selectedRow = dataGridViewLancamentos.SelectedRows[0];
            return (int)selectedRow.Cells["ID"].Value;
        }

        private void UpdateDataTableLancamentos()
        {
            dataTableLancamentos = Lancamento.GetDataTableLancamentos();
            dataGridViewLancamentos.DataSource = dataTableLancamentos;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateDataTableLancamentos();
        }
    }
}

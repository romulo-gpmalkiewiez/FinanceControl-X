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
    public partial class FormMain : Form
    {
        private DataTable dt = new DataTable();

        public FormMain()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            dt = Lancamento.GetLancamentos();
            dataGridViewLancamentos.DataSource = dt;

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
            dataGridViewLancamentos.Columns["tipo"].Width = 130;

            dataGridViewLancamentos.Columns["valor"].HeaderText = "Valor (R$)";
            dataGridViewLancamentos.Columns["valor"].Width = 150;
            dataGridViewLancamentos.Columns["valor"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewLancamentos.Columns["valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridViewLancamentos.Columns["descricao"].HeaderText = "Descrição";
            dataGridViewLancamentos.Columns["descricao"].Width = 200;

            dataGridViewLancamentos.Columns["observacao"].HeaderText = "Observação";
            dataGridViewLancamentos.Columns["observacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            FormDlgLancamento formDlgLancamento = new FormDlgLancamento(this);
            formDlgLancamento.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

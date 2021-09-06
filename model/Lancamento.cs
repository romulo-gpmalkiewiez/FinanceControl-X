using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceControlX.model
{
    class Lancamento
    {
        public int? Id { get; set; }
        public string Tipo { get; set; }
        public decimal? Valor { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public int? CategoriaId { get; set; }

        public static DataTable GetLancamentos()
        {
            var dt = new DataTable();

            var sql = "" +
                "SELECT " +
                "   lancamento.id, " +
                "   lancamento.tipo, " +
                "   categoria.nome AS nome_categoria, " +
                "   lancamento.descricao, " +
                "   lancamento.valor, " +
                "   lancamento.observacao " +
                "FROM lancamento, categoria " +
                "WHERE lancamento.categoria_id = categoria.id";

            try
            {
                using (var cn= new MySqlConnection(Conn.connectionString))
                {
                    cn.Open();
                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dt;
        }

        public static Lancamento Save(Lancamento lancamento)
        {
            return lancamento.Id == null ? Insert(lancamento) : Update(lancamento);
        }

        private static Lancamento Update(Lancamento lancamento)
        {
            var updateSQL = "" +
                $"UPDATE lancamento " +
                $"SET " +
                $"  tipo = {lancamento.Tipo}, " +
                $"  valor = {lancamento.Valor} " +
                $"  descricao = {lancamento.Descricao} " +
                $"  observacao = {lancamento.Observacao} " +
                $"  categoria_id = {lancamento.CategoriaId} " +
                $"WHERE id = {lancamento.Id}";

            MessageBox.Show(updateSQL);

            return lancamento;
        }

        private static Lancamento Insert(Lancamento lancamento)
        {
            ValidaLancamento(lancamento);

            var insertSQL = "" +
                "INSERT INTO lancamento (tipo, valor, descricao, observacao, categoria_id " +
                "VALUES (" +
                $"  {lancamento.Tipo}, " +
                $"  {lancamento.Valor}, " +
                $"  {lancamento.Descricao}, " +
                $"  {lancamento.Observacao}, " +
                $"  {lancamento.CategoriaId}" +
                ")";

            MessageBox.Show(insertSQL);

            return lancamento;
        }

        private static void ValidaLancamento(Lancamento lancamento)
        {
            if (lancamento.Tipo == null)
            {
                throw new ArgumentException("Você deve informar o tipo.");
            }
            if (lancamento.Valor == null)
            {
                throw new ArgumentException("Você deve informar o valor.");
            }
            if (lancamento.CategoriaId == null)
            {
                throw new ArgumentException("Você deve informar a categoria.");
            }
        }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Data;
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
        public Categoria categoria { get; set; }

        public static DataTable GetDataTableLancamentos()
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
                using (var cn = new MySqlConnection(Conn.connectionString))
                {
                    cn.Open();
                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return dt;
        }

        public static Lancamento GetLancamentoById(int lancamentoId)
        {
            if (lancamentoId == 0)
            {
                return null;
            }

            Lancamento lancamento = null;

            var sql = "" +
                $"SELECT " +
                $"  lancamento.id, " +
                $"  lancamento.tipo, " +
                $"  lancamento.valor, " +
                $"  lancamento.descricao, " +
                $"  lancamento.observacao, " +
                $"  lancamento.categoria_id " +
                $"FROM lancamento " +
                $"WHERE lancamento.id = {lancamentoId}";

            try
            {
                using (var cn = new MySqlConnection(Conn.connectionString))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    lancamento = new Lancamento();
                                    lancamento.Id = Convert.ToInt32(dr["id"]);
                                    lancamento.Tipo = dr["tipo"].ToString();
                                    lancamento.Descricao = dr["descricao"].ToString();
                                    lancamento.Observacao = dr["observacao"].ToString();
                                    lancamento.Valor = Convert.ToDecimal(dr["valor"]);
                                    lancamento.CategoriaId = Convert.ToInt32(dr["categoria_id"]);

                                    return lancamento;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar lançamento {lancamentoId}. {ex.Message}");
            }

            return lancamento;
        }

        public static Boolean Delete(int lancamentoId) {
            var deleteSQL = $"DELETE FROM lancamento WHERE id = {lancamentoId}";

            try
            {
                using (var cn = new MySqlConnection(Conn.connectionString))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(deleteSQL, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, deleteSQL);
                return false;
            }

            return true;
        }

        public static void Save(Lancamento lancamento)
        {
            ValidaLancamento(lancamento);

            var sql = lancamento.Id == null || lancamento.Id == 0
                    ? "INSERT INTO lancamento (tipo, valor, descricao, observacao, categoria_id) VALUES (@tipo, @valor, @descricao, @observacao, @categoria_id)"
                    : $"UPDATE lancamento SET tipo=@tipo, valor=@valor, descricao=@descricao, observacao=@observacao, categoria_id=@categoria_id WHERE id={lancamento.Id}";

            try
            {
                using (var cn = new MySqlConnection(Conn.connectionString))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@tipo", lancamento.Tipo);
                        cmd.Parameters.AddWithValue("@valor", lancamento.Valor);
                        cmd.Parameters.AddWithValue("@descricao", lancamento.Descricao);
                        cmd.Parameters.AddWithValue("@observacao", lancamento.Observacao);
                        cmd.Parameters.AddWithValue("@categoria_id", lancamento.CategoriaId);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
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

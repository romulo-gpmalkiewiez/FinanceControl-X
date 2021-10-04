using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FinanceControlX.model
{
    class Categoria
    {
        public int? Id { get; set; }
        public string Nome { get; set; }

        public Categoria() {}

        public Categoria(String nome)
        {
            this.Nome = nome;
        }

        public static List<Categoria> GetCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();

            String sql = "SELECT id, nome FROM categoria";
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
                                while (dr.Read())
                                {
                                    Categoria categoria = new Categoria();
                                    categoria.Id = Convert.ToInt32(dr["id"]);
                                    categoria.Nome = dr["nome"].ToString();

                                    categorias.Add(categoria);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar categorias. {ex.Message}");
            }

            return categorias;
        }

        public static Categoria Save(Categoria categoria)
        {
            ValidaCategoria(categoria);

            var sql = categoria.Id == null || categoria.Id == 0
                    ? "INSERT INTO categoria (nome) VALUES (@nome)"
                    : $"UPDATE categoria SET nome=@nome WHERE id={categoria.Id}";

            try
            {
                using (var cn = new MySqlConnection(Conn.connectionString))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@nome", categoria.Nome);
                        cmd.ExecuteNonQuery();
                        categoria.Id = Convert.ToInt32(cmd.LastInsertedId);

                        return categoria;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public static Boolean Delete(int categoriaId)
        {
            var deleteSQL = $"DELETE FROM categoria WHERE id = {categoriaId}";

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

        private static void ValidaCategoria(Categoria categoria)
        {
            if (categoria.Nome == null || categoria.Nome.Length == 0)
            {
                throw new ArgumentException("Infome o nome da categoria");
            }
        }
    }

}

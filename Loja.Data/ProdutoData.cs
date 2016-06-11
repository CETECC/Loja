using Loja.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Data
{
    public class ProdutoData
    {
        // String de conexão ao banco de dados
        private const string StrConn = "Password=c3t3cc;Persist Security Info=True;User ID=cetecc;Initial Catalog=Cetecc;Data Source=MARCIO-DELL";

        public IEnumerable<Produto> Listar()
        {
            // SqlConnection -> conexão com o banco de dados
            using (IDbConnection conn = new SqlConnection(StrConn))
            {
                // SqlCommand -> 
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT ProdutoID, Nome, Descricao, Preco FROM Produto";

                    conn.Open();
                    IDataReader dr = cmd.ExecuteReader();

                    IEnumerable<Produto> list = MapList(dr);
                    return list;
                }
            }
        }

        public void Adicionar(Produto produto)
        {
            string strCmd = @"INSERT INTO Produto
                               (Nome
                               ,Descricao
                               ,Preco)
                         VALUES
                               (@Nome
                               ,@Descricao
                               ,@Preco)";

            using (IDbConnection conn = new SqlConnection(StrConn))
            {
                using (IDbCommand cmd = new SqlCommand(strCmd, (SqlConnection)conn))
                {
                    // Adicionar pela interface IDbCommand
                    IDbDataParameter p1 = new SqlParameter("@Nome", produto.Nome);
                    cmd.Parameters.Add(p1);

                    // OU Adicionar pela classe SqlCommand
                    ((SqlCommand)cmd).Parameters.AddWithValue("@Descricao", produto.Descricao);
                    ((SqlCommand)cmd).Parameters.AddWithValue("@Preco", produto.Preco);

                    // Abrir a conexão
                    conn.Open();

                    // Executar o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Modificar(Produto produto)
        {
        }

        public void Excluir(int produtoID)
        {
        }

        private IEnumerable<Produto> MapList(IDataReader dr)
        {
            List<Produto> list = new List<Produto>();

            while (dr.Read())
            {
                Produto p = Map(dr);
                list.Add(p);
            }

            return list;
        }

        private Produto MapSingle(IDataReader dr)
        {
            Produto result = null;

            if (dr.Read())
            {
                result = Map(dr);
            }

            return result;
        }

        private Produto Map(IDataReader dr)
        {
            Produto result = new Produto();
            result.ProdutoID = (int)dr["ProdutoID"];
            result.Nome = (string)dr["Nome"];
            result.Descricao = (string)dr["Descricao"];
            result.Preco = (decimal)dr["Preco"];

            return result;
        }
    }
}

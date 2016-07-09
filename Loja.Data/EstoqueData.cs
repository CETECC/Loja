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
    public class EstoqueData : BaseData
    {
        private ProdutoData _produtoData;

        public EstoqueData()
        {
            _produtoData = new ProdutoData();
        }

        public Estoque ObterPorProduto(int produtoID)
        {
            // SqlConnection -> conexão com o banco de dados
            using (IDbConnection conn = new SqlConnection(StrConn))
            {
                // SqlCommand -> 
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT EstoqueID, ProdutoID, Quantidade 
                                          FROM Estoque
                                         WHERE ProdutoID = @ProdutoID";

                    ((SqlCommand)cmd).Parameters.AddWithValue("@ProdutoID", produtoID);

                    conn.Open();
                    IDataReader dr = cmd.ExecuteReader();

                    Estoque result = MapSingle(dr);
                    return result;
                }
            }
        }

        public IEnumerable<Estoque> Listar()
        {
            // SqlConnection -> conexão com o banco de dados
            using (IDbConnection conn = new SqlConnection(StrConn))
            {
                // SqlCommand -> 
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT EstoqueID, ProdutoID, Quantidade FROM Estoque";

                    conn.Open();
                    IDataReader dr = cmd.ExecuteReader();

                    IEnumerable<Estoque> result = MapList(dr);
                    return result;
                }
            }
        }

        public void Adicionar(Estoque estoque)
        {
            string strCmd = @"INSERT INTO Estoque
                               (ProdutoID
                               ,Quantidade)
                         VALUES
                               (@ProdutoID
                               ,@Quantidade)";

            using (IDbConnection conn = new SqlConnection(StrConn))
            {
                using (IDbCommand cmd = new SqlCommand(strCmd, (SqlConnection)conn))
                {
                    // Adicionar pela interface IDbCommand
                    IDbDataParameter p1 = new SqlParameter("@ProdutoID", estoque.Produto.ProdutoID);
                    cmd.Parameters.Add(p1);

                    // OU Adicionar pela classe SqlCommand
                    ((SqlCommand)cmd).Parameters.AddWithValue("@Quantidade", estoque.Quantidade);

                    // Abrir a conexão
                    conn.Open();

                    // Executar o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Modificar(Estoque estoque)
        {
            string strCmd = @"UPDATE Estoque
                                 SET Quantidade = @Quantidade
                               WHERE ProdutoID = @ProdutoID";

            using (IDbConnection conn = new SqlConnection(StrConn))
            {
                using (IDbCommand cmd = new SqlCommand(strCmd, (SqlConnection)conn))
                {
                    ((SqlCommand)cmd).Parameters.AddWithValue("@ProdutoID", estoque.Produto.ProdutoID);

                    // Abrir a conexão
                    conn.Open();

                    // Executar o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ExcluirPorProduto(int produtoID)
        {
            string strCmd = @"DELETE Estoque
                               WHERE ProdutoID = @ProdutoID";

            using (IDbConnection conn = new SqlConnection(StrConn))
            {
                using (IDbCommand cmd = new SqlCommand(strCmd, (SqlConnection)conn))
                {
                    ((SqlCommand)cmd).Parameters.AddWithValue("@ProdutoID", produtoID);

                    // Abrir a conexão
                    conn.Open();

                    // Executar o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private IEnumerable<Estoque> MapList(IDataReader dr)
        {
            List<Estoque> list = new List<Estoque>();

            while (dr.Read())
            {
                Estoque e = Map(dr);
                list.Add(e);
            }

            return list;
        }

        private Estoque MapSingle(IDataReader dr)
        {
            Estoque result = null;

            if (dr.Read())
            {
                result = Map(dr);
            }

            return result;
        }

        private Estoque Map(IDataReader dr)
        {
            Estoque result = new Estoque();
            int produtoID = (int)dr["ProdutoID"];
            Produto produto = _produtoData.Obter(produtoID);

            result.Produto = produto;
            result.EstoqueID = (int)dr["EstoqueID"];
            result.Quantidade = (int)dr["Quantidade"];

            return result;
        }
    }
}

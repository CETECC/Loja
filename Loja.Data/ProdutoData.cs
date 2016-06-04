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
        public IEnumerable<Produto> Listar()
        {
            string strConn = "Password=c3t3cc;Persist Security Info=True;User ID=cetecc;Initial Catalog=Cetecc;Data Source=MARCIO-DELL";

            using (IDbConnection conn = new SqlConnection(strConn))
            {
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

        /*
        A PARTIR DAQUI...

        Fazer os métodos
        public void Adicionar(Produto produto)
        {
        }

        public void Modificar(Produto produto)
        {
        }

        public void Excluir(int produtoID)
        {
        }

        UTILIZAR PARAMETROS !!!
        Pesquisar por utilização de Parametros
        no SqlCommand (IDbCommand)
        */

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

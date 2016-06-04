using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Data;
using Loja.Model;

namespace Loja.Business
{
    public class ProdutoBusiness
    {
        private ProdutoData _produtoData;

        public ProdutoBusiness()
        {
            _produtoData = new ProdutoData();
        }

        public IEnumerable<Produto> Listar()
        {
            return _produtoData.Listar();
        }
    }
}

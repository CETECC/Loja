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
        private EstoqueData _estoqueData;

        public ProdutoBusiness()
        {
            _produtoData = new ProdutoData();
            _estoqueData = new EstoqueData();
        }

        public IEnumerable<Produto> Listar()
        {
            return _produtoData.Listar();
        }

        public void Salvar(Produto produto)
        {
            if (produto.ProdutoID == 0)
                _produtoData.Adicionar(produto);
            else
                _produtoData.Modificar(produto);
        }

        public bool Excluir(int produtoID)
        {
            Estoque estoque = _estoqueData.ObterPorProduto(produtoID);

            if (estoque != null && estoque.Quantidade > 0)
                return false;

            _estoqueData.ExcluirPorProduto(produtoID);
            _produtoData.Excluir(produtoID);

            return true;
        }
    }
}

using Loja.Data;
using Loja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Business
{
    public class EstoqueBusiness
    {
        private EstoqueData _estoqueData;

        public EstoqueBusiness()
        {
            _estoqueData = new EstoqueData();
        }

        public IEnumerable<Estoque> Listar()
        {
            return _estoqueData.Listar();
        }

        public Estoque ObterPorProduto(int produtoID)
        {
            return _estoqueData.ObterPorProduto(produtoID);
        }

        public void Salvar(Estoque estoque)
        {
            if (estoque.EstoqueID == 0)
                _estoqueData.Adicionar(estoque);
            else
                _estoqueData.Modificar(estoque);
        }
    }
}

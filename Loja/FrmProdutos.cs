using Loja.Business;
using Loja.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loja
{
    public partial class FrmProdutos : Form
    {
        private ProdutoBusiness _produtoBusiness;

        public FrmProdutos()
        {
            InitializeComponent();
            _produtoBusiness = new ProdutoBusiness();
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            IEnumerable<Produto> produtos = _produtoBusiness.Listar();

            if (produtos != null)
            {
                foreach (Produto produto in produtos)
                {
                    ListViewItem item = new ListViewItem(produto.ProdutoID.ToString());
                    item.SubItems.Add(produto.Nome);
                    item.SubItems.Add(produto.Preco.ToString("C"));
                    item.SubItems.Add(produto.Descricao);

                    lstProdutos.Items.Add(item);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new FrmProdutoNovo();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                lstProdutos.Clear();
                FrmProdutos_Load(this, EventArgs.Empty);
            }
        }
    }
}

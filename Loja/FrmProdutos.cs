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
        private IEnumerable<Produto> _produtos;

        public FrmProdutos()
        {
            InitializeComponent();
            _produtoBusiness = new ProdutoBusiness();
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            _produtos = _produtoBusiness.Listar();

            if (_produtos != null)
            {
                foreach (Produto produto in _produtos)
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
                lstProdutos.Items.Clear();
                FrmProdutos_Load(this, EventArgs.Empty);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Valida se há itens selecionados
            if (lstProdutos.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione um produto para editar", "DÃÃÃ!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obter o ID do produto pela linha selecionada
            string strID = lstProdutos.SelectedItems[0].SubItems[0].Text;
            int id = int.Parse(strID);

            // Language INtegrated Query (expresões lambda)
            Produto produto = _produtos.SingleOrDefault(p => p.ProdutoID == id);
            FrmProdutoNovo frm = new FrmProdutoNovo(produto);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                lstProdutos.Items.Clear();
                FrmProdutos_Load(this, EventArgs.Empty);
            }
        }

        private void lstProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProdutos.SelectedItems.Count > 0)
                btnEditar.Enabled = true;
        }
    }
}

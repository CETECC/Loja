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
        private EstoqueBusiness _estoqueBusiness;
        private IEnumerable<Estoque> _estoque;

        public FrmProdutos()
        {
            InitializeComponent();
            _estoqueBusiness = new EstoqueBusiness();
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            _estoque = _estoqueBusiness.Listar();

            if (_estoque != null)
            {
                foreach (Estoque estoque in _estoque)
                {
                    ListViewItem item = new ListViewItem(estoque.Produto.ProdutoID.ToString());
                    item.SubItems.Add(estoque.Produto.Nome);
                    item.SubItems.Add(estoque.Produto.Preco.ToString("C"));
                    item.SubItems.Add(estoque.Produto.Descricao);
                    item.SubItems.Add(estoque.Quantidade.ToString());

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
            Estoque estoque = _estoque.SingleOrDefault(est => est.Produto.ProdutoID == id);
            FrmProdutoNovo frm = new FrmProdutoNovo(estoque);

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

        private void btnRemover_Click(object sender, EventArgs e)
        {

        }
    }
}

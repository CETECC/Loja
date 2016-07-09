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
    public partial class FrmProdutoNovo : Form
    {
        private Estoque _estoque;

        public FrmProdutoNovo()
        {
            InitializeComponent();
        }

        public FrmProdutoNovo(Estoque estoque) : this()
        {
            _estoque = estoque;
            txtNome.Text = _estoque.Produto.Nome;
            txtDescricao.Text = _estoque.Produto.Descricao;
            txtPreco.Text = _estoque.Produto.Preco.ToString("F2").PadLeft(2, '0');
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                // Adicionar o Produto
                ProdutoBusiness produtoB = new ProdutoBusiness();
                if (_estoque.Produto == null)
                    _estoque.Produto = new Produto();
                _estoque.Produto.Nome = txtNome.Text;
                _estoque.Produto.Descricao = txtDescricao.Text;
                _estoque.Produto.Preco = Convert.ToDecimal(txtPreco.Text.Replace('.', ','));

                produtoB.Salvar(_estoque.Produto);

                EstoqueBusiness estoqueB = new EstoqueBusiness();
                estoqueB.Salvar(_estoque);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Preencha o campo Nome", "Seu lixo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MessageBox.Show("Preencha o campo Descrição", "Seu lixo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPreco.Text))
            {
                MessageBox.Show("Preencha o campo Preço", "Seu lixo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}

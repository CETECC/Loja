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
        private Produto _produto;

        public FrmProdutoNovo()
        {
            InitializeComponent();
        }

        public FrmProdutoNovo(Produto produto) : this()
        {
            _produto = produto;
            txtNome.Text = _produto.Nome;
            txtDescricao.Text = _produto.Descricao;
            txtPreco.Text = _produto.Preco.ToString("F2").PadLeft(2, '0');
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                // Adicionar o Produto
                ProdutoBusiness produtoB = new ProdutoBusiness();
                if (_produto == null)
                    _produto = new Produto();
                _produto.Nome = txtNome.Text;
                _produto.Descricao = txtDescricao.Text;
                _produto.Preco = Convert.ToDecimal(txtPreco.Text.Replace('.', ','));

                produtoB.Salvar(_produto);

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

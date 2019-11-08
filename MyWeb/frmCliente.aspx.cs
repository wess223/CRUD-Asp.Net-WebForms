using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWeb
{
    public partial class frmCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarClientes();
            }

        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            //SqlConnection cnx = new SqlConnection(new ClsFuncoes().conexao);
            //cnx.Open();
            //string sqltxt = string.Format("INSERT INTO CLIENTE (CLI_NOME, CLI_EMAIL, CLI_NUMERO) VALUES ('{0}', '{1}', '{2}')", txtNome.Text,txtEmail.Text,txtNumero.Text);
            //SqlCommand cmd = new SqlCommand(sqltxt, cnx);

            //cmd.ExecuteNonQuery();

            //txtNome.Text = "";
            //txtEmail.Text = "";
            //txtNumero.Text = "";
            //CarregarClientes();
            if (txtNome.Text == "" || txtEmail.Text == "" || txtNumero.Text == "")
            {
                lbMenssagemRX.Text = "Todos os Campos São Obrigatórios !!";
            }
            else
            {
                Incluir();
            }

        }

        public void CarregarClientes()
        {
            gvw_cliente.DataSource = new ClsFuncoes().AbrirTabela("SELECT * FROM CLIENTE");
            gvw_cliente.DataBind();

        }

        public void Incluir()
        {
            ClsFuncoes lFuncoes = new ClsFuncoes();
            SqlConnection cnx = lFuncoes.Conexao();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO CLIENTE (CLI_NOME, CLI_EMAIL, CLI_NUMERO) VALUES (@NOME, @EMAIL, @NUMERO) ", cnx);
                //cnx.Open();
                cmd.Parameters.AddWithValue("@ID", txtId.Text);
                cmd.Parameters.AddWithValue("@NOME", txtNome.Text);
                cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
                cmd.Parameters.AddWithValue("@NUMERO", txtNumero.Text);

                cmd.ExecuteNonQuery();

                txtId.Text = "";
                txtNome.Text = "";
                txtEmail.Text = "";
                txtNumero.Text = "";
                CarregarClientes();
                lbMenssagem.Text = "Sucesso ao inserir o Registro !!";
            }
            catch (Exception ex)
            {
                lbMenssagemRX.Text = "Erro ao Incluir !!";
            }
            finally
            {
                cnx.Close();
            }
        }

        protected void gvw_cliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var index = Convert.ToInt32(e.CommandArgument.ToString());

            if (e.CommandName == "selecionar")
            {
                txtId.Text = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument.ToString())].Cells[0].Text;
                txtNome.Text = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument.ToString())].Cells[1].Text;
                txtEmail.Text = ((GridView)sender).Rows[index].Cells[2].Text;
                txtNumero.Text = ((GridView)sender).Rows[index].Cells[3].Text;

            }else if(e.CommandName == "deletar")
            {
                Deletar(((GridView)sender).Rows[index].Cells[0].Text);
                CarregarClientes();

            }
        }
        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        public void LimparCampos()
        {
            if (txtNome.Text == "" || txtEmail.Text == "" || txtNumero.Text == "")
            {
                lbMenssagem.Text = "Os Campos ja estão Limpos !";
            }
            else
            {
                txtId.Text = "";
                txtNome.Text = "";
                txtEmail.Text = "";
                txtNumero.Text = "";
            }
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "" || txtEmail.Text == "" || txtNumero.Text == "")
            {
                lbMenssagemRX.Text = "Sem campos preeechidos para Alteração";

            }
            else
            {
                Alterar();
                LimparCampos();
                CarregarClientes();
            }
        }

        public void Alterar()
        {
            try
            {
                ClsFuncoes lFuncoes = new ClsFuncoes();
                SqlConnection cnx = lFuncoes.Conexao();

                SqlCommand cmd = new SqlCommand("UPDATE CLIENTE SET CLI_NOME=@NOME, CLI_EMAIL=@EMAIL, CLI_NUMERO=@NUMERO WHERE ID=@COD", cnx);
                cmd.Parameters.AddWithValue("@COD", txtId.Text);
                cmd.Parameters.AddWithValue("@NOME", txtNome.Text);
                cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
                cmd.Parameters.AddWithValue("@NUMERO", txtNumero.Text);

                cmd.ExecuteNonQuery();
                cnx.Close();

                lbMenssagem.Text = "Sucesso ao Alterar o Registro !!";

            }
            catch (Exception)
            {

                lbMenssagemRX.Text = "Erro ao Alterar Registro !!";
            }
        }

        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "" || txtEmail.Text == "" || txtNumero.Text == "")
            {
                lbMenssagemRX.Text = "Nada Selecionado !";

            }
            else
            {
                Deletar(txtId.Text);
                LimparCampos();
                CarregarClientes();
            }
        }

        public void Deletar(string cod)
        {
            try
            {
                ClsFuncoes lFuncoes = new ClsFuncoes();
                SqlConnection cnx = lFuncoes.Conexao();

                SqlCommand cmd = new SqlCommand("DELETE FROM CLIENTE WHERE ID=@COD", cnx);
                cmd.Parameters.AddWithValue("@COD", cod);

                cmd.ExecuteNonQuery();

                cnx.Close();


                lbMenssagem.Text = "Deletado com Sucesso !!";
            }
            catch (Exception ex)
            {
                lbMenssagemRX.Text = "Erro ao Deletar Registro !!";

            }
            
        }

        protected void gvw_cliente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvw_cliente.PageIndex = e.NewPageIndex;
            gvw_cliente.DataBind();
        }

        
    }
}
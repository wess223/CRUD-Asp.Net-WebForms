using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyWeb
{
    public class ClsFuncoes
    {
        public string conexao = @"Data Source=PAT6714\WESLEY;Initial Catalog = CadastroDeClientes; User ID = sa; Password=1q2w3e!Q@W#E";

        public DataSet AbrirTabela(string sqltxt)
        {
            SqlConnection cnx = new SqlConnection(conexao);
            cnx.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sqltxt, cnx);
            DataSet dst = new DataSet();
            adp.Fill(dst);
            return dst;
        }


        /// <summary>
        ///O método abre a conexao com o banco de dados
        /// </summary>
        /// <returns></returns>
        public SqlConnection Conexao()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = conexao;
            cnx.Open();

            return cnx;
        }

        public void desconectar()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.Close();
        }

    }
}
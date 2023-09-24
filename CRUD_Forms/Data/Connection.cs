using System.Windows.Forms;
using System;
using MySqlConnector;

namespace CRUD_Forms
{
    public class Connection
    {
        // String de conexão com o banco de dados MySQL
        readonly string connection = "SERVER=localhost; DATABASE=crud_forms; UID=root; PWD=";

        // Objeto MySqlConnection para gerenciar a conexão
        public MySqlConnection con = null;

        // Método para abrir a conexão com o banco de dados
        public void AbrirConexao()
        {
            try
            {
                // Inicializa a conexão com base na string de conexão
                con = new MySqlConnection(connection);
                con.Open(); // Abre a conexão
            }
            catch (Exception ex)
            {
                // Em caso de erro, exibe uma mensagem de erro em uma caixa de diálogo
                MessageBox.Show("Erro ao conectar" + ex.Message);
            }
        }

        // Método para fechar a conexão com o banco de dados
        public void CloseConnection()
        {
            try
            {
                // Inicializa a conexão com base na string de conexão
                con = new MySqlConnection(connection);
                con.Close(); // Fecha a conexão
            }
            catch (Exception ex)
            {
                // Em caso de erro, exibe uma mensagem de erro em uma caixa de diálogo
                MessageBox.Show("Erro ao fechar conexão" + ex.Message);
            }
        }
    }
}

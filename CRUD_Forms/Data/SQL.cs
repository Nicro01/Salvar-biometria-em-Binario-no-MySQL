using MySqlConnector;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRUD_Forms.Data
{
    public class SQL
    {
        MySqlCommand sql;

        private void SQLConnection(string cmd)
        {
            // Cria uma instância da classe Connection para gerenciar a conexão com o banco de dados
            Connection con = new Connection();
            con.AbrirConexao(); // Abre a conexão com o banco de dados
            sql = new MySqlCommand(cmd, con.con); // Cria um comando MySqlCommand com a consulta SQL
            MySqlDataAdapter da = new MySqlDataAdapter(); // Cria um adaptador para executar o comando
            sql.ExecuteNonQuery(); // Executa a consulta no banco de dados
            con.CloseConnection(); // Fecha a conexão com o banco de dados
        }

        // Método para adicionar usuário ao banco de dados
        public DataTable Insert(Model.User user)
        {
            byte[] ByteFIR = user.TemplateByte.Data;

            // Cria uma instância da classe Connection para gerenciar a conexão com o banco de dados
            Connection con = new Connection();
            con.AbrirConexao(); // Abre a conexão com o banco de dados
            sql = new MySqlCommand("INSERT INTO profile (id, name, cpf, TemplateByte, TemplateString) values('" + user.id + "' ,'" + user.name + "' , '" + user.cpf + "' , @TemplateByte, @TemplateString)", con.con); // Cria um comando MySqlCommand com a consulta SQL de inserção
            sql.Parameters.AddWithValue("@TemplateByte", ByteFIR); // Adiciona um parâmetro para a representação binária da impressão digital
            sql.Parameters.AddWithValue("@TemplateString", user.template); // Adiciona um parâmetro para a representação de texto da impressão digital
            MySqlDataAdapter da = new MySqlDataAdapter(); // Cria um adaptador para executar o comando
            da.SelectCommand = sql; // Define o adaptador com o comando SQL
            con.CloseConnection(); // Fecha a conexão com o banco de dados
            DataTable dt = new DataTable();
            da.Fill(dt); // Preenche um DataTable com os resultados da consulta

            return dt; // Retorna o DataTable com os resultados
        }

        // Método para atualizar usuário no banco de dados
        public void Update(int id, string name, string cpf)
        {
            SQLConnection("UPDATE profile SET name = '" + name + "', cpf = '" + cpf + "' WHERE id = " + id);
        }

        // Método para remover usuário do banco de dados
        public void Remove(int id)
        {
            try
            {
                SQLConnection("DELETE FROM profile WHERE id =" + id);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        // Método para listar banco de dados no DataGridView
        public DataTable Listar(DataGridView dgv)
        {
            // Cria uma instância da classe Connection para gerenciar a conexão com o banco de dados
            Connection con = new Connection();
            con.AbrirConexao(); // Abre a conexão com o banco de dados
            var listar = new MySqlCommand("SELECT * FROM profile", con.con); // Cria um comando MySqlCommand para selecionar todos os registros da tabela "profile"
            MySqlDataAdapter adapter = new MySqlDataAdapter(listar); // Cria um adaptador para executar o comando
            DataTable data = new DataTable(); // Cria um DataTable para armazenar os resultados
            adapter.Fill(data); // Preenche o DataTable com os resultados da consulta
            listar.ExecuteNonQuery(); // Executa o comando SQL
            dgv.DataSource = data; // Define o DataGridView com os resultados
            con.CloseConnection(); // Fecha a conexão com o banco de dados
            return data; // Retorna o DataTable com os resultados
        }

        public DataTable ListarTemplate(int id)
        {
            // Cria uma instância da classe Connection para gerenciar a conexão com o banco de dados
            Connection con = new Connection();
            con.AbrirConexao(); // Abre a conexão com o banco de dados
            var sql = new MySqlCommand("SELECT id, name, TemplateString, TemplateByte FROM profile WHERE id = '" + id + "'", con.con); // Cria um comando MySqlCommand para selecionar registros específicos da tabela "profile"
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql); // Cria um adaptador para executar o comando
            DataTable data = new DataTable(); // Cria um DataTable para armazenar os resultados
            adapter.Fill(data); // Preenche o DataTable com os resultados da consulta
            sql.ExecuteNonQuery(); // Executa o comando SQL
            con.CloseConnection(); // Fecha a conexão com o banco de dados
            return data; // Retorna o DataTable com os resultados
        }
    }
}

using MySqlConnector;
using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using NITGEN.SDK.NBioBSP;
using static NITGEN.SDK.NBioBSP.NBioAPI;
using CRUD_Forms.Entity;
using CRUD_Forms.Data;

namespace CRUD_Forms
{
    public partial class Form1 : Form
    {
        // Instância da classe Biometria para lidar com operações biométricas
        Biometria bio = new Biometria();

        // Instância da classe User para armazenar informações do usuário
        Model.User user = new Model.User();

        // Instância da classe SQL para operações no banco de dados
        SQL sql = new SQL();

        // Instância da classe Validacao para validações
        Validation.Validacao val = new Validation.Validacao();

        public Form1()
        {
            InitializeComponent();
            Dgv.DataSource = sql.Listar(); // Lista os dados do banco de dados no DataGridView
            sql.ListarBinario();

        }

        // Método para limpar os campos de entrada
        private void EsvaziarInputs()
        {
            IdTb.Text = string.Empty;
            NameTb.Text = string.Empty;
            CpfTb.Text = string.Empty;
        }

        // Método para controlar a visibilidade do botão "Leave"
        private void SairEdit()
        {
            if (UpTb.Enabled)
            {
                LeaveButton.Visible = true;
                return;
            }
            LeaveButton.Visible = false;
        }

        private void AddBt_Click(object sender, EventArgs e)
        {
            // Registra a impressão digital do usuário
            bio.Registrar(user);

            // Obtém os dados do usuário dos campos de entrada
            user.id = Convert.ToInt32(IdTb.Text);
            user.name = NameTb.Text;
            user.cpf = CpfTb.Text;

            // Valida o modelo do usuário
            if (user.template != "erro")
            {
                if (val.ValidarModelo(user))
                {
                    // Insere os dados do usuário no banco de dados
                    sql.Insert(user);

                    // Limpa os campos de entrada
                    EsvaziarInputs();

                    // Atualiza o DataGridView com os dados do banco de dados
                    Dgv.DataSource = sql.Listar();

                    // Exibe uma mensagem de sucesso
                    MessageBox.Show("Registro salvo com sucesso !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Exibe uma mensagem de erro de captura biométrica
                MessageBox.Show("Erro de captura", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RemoveTb_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == string.Empty)
            {
                MessageBox.Show("Digite o ID do usuário que deseja remover");
                return;
            }
            // Remove o usuário do banco de dados
            sql.Remove(Convert.ToInt32(IdTb.Text));

            // Limpa os campos de entrada
            EsvaziarInputs();

            // Atualiza o DataGridView com os dados do banco de dados
            Dgv.DataSource = sql.Listar();

            MessageBox.Show("Usuário removido com sucesso!");
        }

        private void UpTb_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdTb.Text == string.Empty)
                {
                    MessageBox.Show("Digite o ID do usuário que deseja atualizar");
                    return;
                }
                // Atualiza os dados do usuário no banco de dados
                sql.Update(Convert.ToInt32(IdTb.Text), NameTb.Text, CpfTb.Text);
                MessageBox.Show("Usuário atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar usuário.\n\n" + ex.ToString());
                return;
            }

            IdTb.Enabled = true;
            UpTb.Enabled = false;

            // Limpa os campos de entrada
            EsvaziarInputs();

            // Atualiza o DataGridView com os dados do banco de dados
            Dgv.DataSource = sql.Listar();
        }

        private void verifyBtn_Click(object sender, EventArgs e)
        {
            int idParameter = Convert.ToInt32(IdTb.Text);
            DataTable digital = sql.ListarTemplate(Convert.ToInt32(IdTb.Text));
            string Template = digital.Rows[0]["TemplateString"].ToString();
            int id = Convert.ToInt32(digital.Rows[0]["id"]);
            string name = digital.Rows[0]["name"].ToString();

            // Verifica a correspondência biométrica do usuário
            if (bio.CompararBinario(idParameter))
            {
                returnLb.Text = "Return: Usuário encontrado!";
                returnId.Text = "ID: " + id;
                returnUE.Text = "Nome: " + name;
            }
            else
            {
                returnLb.Text = "Return: Usuário não encontrado!";
            }

            // Limpa os campos de entrada
            EsvaziarInputs();
        }

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Preenche os campos de entrada com os dados do usuário selecionado no DataGridView
            IdTb.Enabled = false;
            UpTb.Enabled = true;
            IdTb.Text = Dgv.CurrentRow.Cells[0].Value.ToString();
            NameTb.Text = Dgv.CurrentRow.Cells[1].Value.ToString();
            CpfTb.Text = Dgv.CurrentRow.Cells[2].Value.ToString();

            // Controla a visibilidade do botão "Leave"
            SairEdit();
        }

        private void LeaveButton_Click(object sender, EventArgs e)
        {
            // Controla a visibilidade do botão "Leave" e limpa os campos de entrada
            var message = MessageBox.Show("Deseja sair? ", "", MessageBoxButtons.OKCancel);
            if (message == DialogResult.OK)
            {
                IdTb.Enabled = true;
                UpTb.Enabled = false;
                LeaveButton.Visible = false;
                EsvaziarInputs();
                return;
            }
            return;
        }

        private void IndexButton_Click(object sender, EventArgs e)
        {
            indexResult.Text = bio.IndexSearch();
        }
    }
}

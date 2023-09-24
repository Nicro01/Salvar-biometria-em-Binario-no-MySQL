using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace CRUD_Forms.Validation
{
    public class Validacao
    {
        // Método para obter os erros de validação de um objeto
        public static IEnumerable<ValidationResult> getValidationErros(object obj)
        {
            var resultadoValidacao = new List<ValidationResult>();
            var contexto = new ValidationContext(obj, null, null);
            Validator.TryValidateObject(obj, contexto, resultadoValidacao, true);
            return resultadoValidacao;
        }

        // Método para validar um modelo de objeto e exibir mensagens de erro em uma caixa de diálogo
        public Boolean ValidarModelo(object obj)
        {
            var erros = Validacao.getValidationErros(obj);
            string strErros = "";

            foreach (var error in erros)
            {
                strErros += error.ErrorMessage + Environment.NewLine;
            }

            if (strErros.Length > 0)
            {
                strErros = "Corrija os problemas abaixo: " + Environment.NewLine + Environment.NewLine + strErros;
                MessageBox.Show(strErros, "Erros", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Método para validar o nome de um objeto
        public static Boolean ValidarNome(object obj)
        {
            var nameError = Validacao.getValidationErros(obj).Where(x => x.MemberNames.Contains("name")).FirstOrDefault();

            if (nameError == null)
            {
                return true;
            }

            return false;
        }

        // Método para validar o CPF de um objeto
        public static Boolean ValidarCPF(object obj)
        {
            var nameError = Validacao.getValidationErros(obj).Where(x => x.MemberNames.Contains("cpf")).FirstOrDefault();

            if (nameError == null)
            {
                return true;
            }

            return false;
        }

        // Método para realizar validações e exibir mensagens de erro em rótulos (Labels)
        public void Validation_Function(Model.User user, Label nameRequired, Label cpfRequired)
        {
            if (ValidarNome(user) == false && ValidarCPF(user) == false)
            {
                nameRequired.Visible = true;
                cpfRequired.Visible = true;
            }
            else if (Validacao.ValidarCPF(user) == false)
            {
                cpfRequired.Visible = true;
                nameRequired.Visible = false;
            }
            else if (Validacao.ValidarNome(user) == false)
            {
                cpfRequired.Visible = false;
                nameRequired.Visible = true;
            }
            else
            {
                cpfRequired.Visible = false;
                nameRequired.Visible = false;
            }
        }
    }
}

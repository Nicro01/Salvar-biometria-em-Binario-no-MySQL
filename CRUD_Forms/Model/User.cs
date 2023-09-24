using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NITGEN.SDK.NBioBSP;

namespace CRUD_Forms.Model
{
    public class User
    {
        // Propriedade para armazenar o ID do usuário
        [Required(ErrorMessage = "Id is required")]
        public int id { get; set; }

        // Propriedade para armazenar o nome do usuário
        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }

        // Propriedade para armazenar o CPF do usuário
        [Required(ErrorMessage = "CPF is required")]
        public string cpf { get; set; }

        // Propriedade para armazenar a representação de texto da impressão digital
        public string template { get; set; }

        // Propriedade para armazenar a representação binária da impressão digital
        public NBioAPI.Type.FIR TemplateByte { get; set; }
    }
}

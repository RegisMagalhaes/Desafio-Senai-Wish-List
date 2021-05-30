using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wish_list_senai.webApi.ViewModels
{
    public class UsuarioViewModel
    {
        public string Email { get; set; }
        [StringLength(30, MinimumLength = 8, ErrorMessage = "A senha deve conter de 8 a 30 caracteres")]
        public string Senha { get; set; }
    }
}

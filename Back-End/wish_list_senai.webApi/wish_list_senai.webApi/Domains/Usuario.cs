using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace wish_list_senai.webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Desejos = new HashSet<Desejo>();
        }

        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Email é Obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é Obrigatória")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "A senha deve conter de 8 a 30 caracteres")]
        public string Senha { get; set; }

        public virtual ICollection<Desejo> Desejos { get; set; }
    }
}

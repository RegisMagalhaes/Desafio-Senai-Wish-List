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
        [Required(ErrorMessage = "Senha é Obrigatório")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Email é Obrigatório")]
        public string Email { get; set; }

        public virtual ICollection<Desejo> Desejos { get; set; }
    }
}

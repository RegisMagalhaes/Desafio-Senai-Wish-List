using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace wish_list_senai.webApi.Domains
{
    public partial class Desejo
    {
        public int IdDesejo { get; set; }
        [Required (ErrorMessage = "Digite o Usuario que deseja cadastrar o desejo")]
        public int? IdUsuario { get; set; }
        [Required (ErrorMessage = "Digite algum desejo")]
        public string Descricao { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wish_list_senai.webApi.Domains;

namespace wish_list_senai.webApi.Interfaces
{
    interface IUsuarioRepository
    {

        //CRUD

        //Create
        void CadastrarUsuario(Usuario novoUsuario);

        //Read
        List<Usuario> ListarDesejos();

        // Update
        void AtualizarUsuario(int idUsuario);

        //Delete
        void DeletarUsuario(int idUsuario);
    }
}

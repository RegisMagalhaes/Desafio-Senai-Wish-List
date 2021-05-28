using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wish_list_senai.webApi.Domains;

namespace wish_list_senai.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Busca um usuário através do Id
        /// </summary>
        /// <param name="id">Id do usuário que será buscado</param>
        /// <returns>Um usuário encontrado</returns>
        Usuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario com as informações</param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">Id do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto usuarioAtualizado com as novas informações</param>
        void Atualizar(int id, Usuario usuarioAtualizado);
        
        /// <summary>
        /// Deleta um usuário existente através do Id
        /// </summary>
        /// <param name="id">Id do usuário que será deletado</param>
        void Deletar(int id);
    }
}

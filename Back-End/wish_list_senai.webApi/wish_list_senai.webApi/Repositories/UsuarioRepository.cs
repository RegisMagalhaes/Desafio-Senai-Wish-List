using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wish_list_senai.webApi.Context;
using wish_list_senai.webApi.Domains;
using wish_list_senai.webApi.Interfaces;

namespace wish_list_senai.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        wishListContext ctx = new wishListContext();

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">Id do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto usuarioAtualizado com as novas informações</param>
        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario user = BuscarPorId(id);

            if (usuarioAtualizado.Email != null)
            {
                user.Email = usuarioAtualizado.Email;
            }

            if (usuarioAtualizado.Senha != null)
            {
                user.Senha = usuarioAtualizado.Senha;
            }

            ctx.Usuarios.Update(user);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um usuário pelo e-mail
        /// </summary>
        /// <param name="email">E-mail do usuário que será buscado</param>
        /// <returns>Um usuário encontrado</returns>
        public Usuario BuscarPorEmail(string email)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        /// <summary>
        /// Busca um usuário através do Id
        /// </summary>
        /// <param name="id">Id do usuário que será buscado</param>
        /// <returns>Um usuário encontrado</returns>
        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.Include(u => u.Desejos).FirstOrDefault(u => u.IdUsuario == id);
        }

        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario com as informações</param>
        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um usuário existente através do Id
        /// </summary>
        /// <param name="id">Id do usuário que será deletado</param>
        public void Deletar(int id)
        {
            ctx.Usuarios.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        public List<Usuario> Listar()
        {
            return ctx.Usuarios.Include(u => u.Desejos).ToList();
        }
    }
}

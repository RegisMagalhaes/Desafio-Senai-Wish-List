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

        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.Include(u => u.Desejos).FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.Include(u => u.Desejos).ToList();
        }
    }
}

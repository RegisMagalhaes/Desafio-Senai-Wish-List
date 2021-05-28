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
    public class DesejoRepository : IDesejoRepository
    {

        wishListContext ctx = new wishListContext();

        public void AtualizarDesejo(int idDesejo, Desejo desejoAtt)
        {

            Desejo desejo = new Desejo();

            desejo = ctx.Desejos.Find(idDesejo);

            if (desejoAtt.Descricao != null)
            {
                
                desejo.Descricao = desejoAtt.Descricao;

            }

            if (desejoAtt.IdUsuario != null)
            {

                desejo.IdUsuario = desejoAtt.IdUsuario;
            
            }

            ctx.Desejos.Update(desejo);

            ctx.SaveChanges();
        }

        public Desejo BuscarDesejo(int idDesejo)
        {
            return ctx.Desejos.Select(filtro => new Desejo
            {
                IdDesejo = filtro.IdDesejo,
                Descricao = filtro.Descricao,
                IdUsuarioNavigation = filtro.IdUsuarioNavigation
            }).FirstOrDefault(d => d.IdDesejo == idDesejo);
        }

        public Desejo BuscarDesejoNome(string nomeDesejo)
        {
            return ctx.Desejos.FirstOrDefault( n => n.Descricao == nomeDesejo);
        }

        public void CadastrarDesejo(Desejo novoDesejo)
        {

            ctx.Desejos.Add(novoDesejo);

            ctx.SaveChanges();

        }

        public void DeletarDesejo(int idDesejo)
        {

            ctx.Desejos.Remove(ctx.Desejos.Find(idDesejo));

            ctx.SaveChanges();

        }

        public List<Desejo> ListarDesejos()
        {

            return ctx.Desejos.Select( filtro => new Desejo { 
                IdDesejo = filtro.IdDesejo, 
                Descricao = filtro.Descricao, 
                IdUsuarioNavigation = filtro.IdUsuarioNavigation } )
                .ToList() ;

        }
    }
}

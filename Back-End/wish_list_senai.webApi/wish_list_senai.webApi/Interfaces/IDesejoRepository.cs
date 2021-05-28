using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wish_list_senai.webApi.Domains;

namespace wish_list_senai.webApi.Interfaces
{
    interface IDesejoRepository
    {
        //CRUD

        //Create
        void CadastrarDesejo (Desejo novoDesejo);

        //Read
        List<Desejo> ListarDesejos();

        // Update
        void AtualizarDesejo(int idDesejo, Desejo DesejoAtt);

        //Delete
        void DeletarDesejo(int idDesejo);

        //Buscar

        Desejo BuscarDesejo(int idDesejo);

        //Buscar Nome
        Desejo BuscarDesejoNome(string nomeDesejo);
    }
}

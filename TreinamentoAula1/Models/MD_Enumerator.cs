using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreinamentoAula1.Models
{
    public enum ActiveFiler : int
    {
        //Usuário Ativos
        ATIVOS = 0,
        //Usuários Inativos
        INATIVOS = 1,
        //Todos Usuários
        TODOS = -1
    }
}
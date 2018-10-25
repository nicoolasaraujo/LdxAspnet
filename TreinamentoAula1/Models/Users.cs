using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TreinamentoAula1.Models.Entity;
using TreinamentoAula1.Models.MetaData;

namespace TreinamentoAula1.Models.Entity
{
    [MetadataType(typeof(UserMetaData))]
    public partial class users{}
}
using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class TipoDocumento : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public bool Deleted { get; set; }

        public ICollection<Persona> Personas { get; set; }
    }
}

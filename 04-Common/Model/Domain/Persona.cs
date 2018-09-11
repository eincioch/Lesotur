using Common;
using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Persona : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Apellido Paterno")]
        [StringLength(80, ErrorMessage = "Apellido Paterno no puede tener más de 80 caracteres.")]
        public string ApePaterno { get; set; }
        [Required]
        [DisplayName("Apellido Materno")]
        [StringLength(80, ErrorMessage = "Apellido Materno no puede tener más de 80 caracteres.")]
        public string ApeMaterno { get; set; }
        [Required]
        [DisplayName("Nombre(s)")]
        [StringLength(110, ErrorMessage = "Nombre(s) no puede tener más de 110 caracteres.")]
        public string Nombres { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha Nacimiento")]
        public DateTime Birthday { get; set; }
        public Enums.Gender Genero { get; set; }
        public int TipoDocumentoId { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        [Required]
        [DisplayName("Número")]
        [StringLength(15, ErrorMessage = "Número documento no puede tener más de 15 caracteres.")]
        public string NumeroDocumento { get; set; }
        public Enums.Status CurrentStatus { get; set; }
        public DateTime? LastVisit { get; set; }

        public bool Deleted { get; set; }


    }
}

using System;
using System.ComponentModel;

namespace Model.Custom
{
    public class PersonaForGridView
    {
        [DisplayName("Código")]
        public int Id { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public string Nombres { get; set; }
        [DisplayName("Apellidos y Nombres")]
        public int IdDocumento { get; set; }
        public string NameCompleto { get; set; }
        [DisplayName("Tipo Documento")]
        public string TipoDocumento { get; set; }
        [DisplayName("Número")]
        public string NroDocumento { get; set; }
        [DisplayName("Género")]
        public string Sexo { get; set; }
        [DisplayName("Fecha Nacimiento")]
        public DateTime Birthday { get; set; }
        [DisplayName("Creado por")]
        public string CreatedBy { get; set; }
    }
}

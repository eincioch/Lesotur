using Model.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Persistence.DatabaseContext.Mapping
{
    public class PersonaMapping : EntityTypeConfiguration<Persona>
    {
        public PersonaMapping()
        {
            Property(m => m.ApePaterno).IsRequired().HasMaxLength(80);
            Property(m => m.ApeMaterno).IsRequired().HasMaxLength(80);
            Property(m => m.Nombres).IsRequired().HasMaxLength(120);
            Property(m => m.NumeroDocumento).IsRequired().HasMaxLength(15);
        }
    }
}

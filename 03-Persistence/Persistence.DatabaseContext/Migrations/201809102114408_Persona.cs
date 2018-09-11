namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Persona : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoDocumentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_TipoDocumento_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            AddColumn("dbo.Personas", "TipoDocumentoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Personas", "TipoDocumentoId");
            AddForeignKey("dbo.Personas", "TipoDocumentoId", "dbo.TipoDocumentoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TipoDocumentoes", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Personas", "TipoDocumentoId", "dbo.TipoDocumentoes");
            DropForeignKey("dbo.TipoDocumentoes", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.TipoDocumentoes", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.TipoDocumentoes", new[] { "DeletedBy" });
            DropIndex("dbo.TipoDocumentoes", new[] { "UpdatedBy" });
            DropIndex("dbo.TipoDocumentoes", new[] { "CreatedBy" });
            DropIndex("dbo.Personas", new[] { "TipoDocumentoId" });
            DropColumn("dbo.Personas", "TipoDocumentoId");
            DropTable("dbo.TipoDocumentoes",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_TipoDocumento_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}

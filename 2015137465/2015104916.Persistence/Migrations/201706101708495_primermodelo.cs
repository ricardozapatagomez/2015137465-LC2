namespace _2015104916.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primermodelo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asientos",
                c => new
                    {
                        CodigoAsiento = c.Int(nullable: false, identity: true),
                        NumeroSerie = c.String(),
                        CodigoCarro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoAsiento)
                .ForeignKey("dbo.Carros", t => t.CodigoCarro, cascadeDelete: true)
                .Index(t => t.CodigoCarro);
            
            CreateTable(
                "dbo.Carros",
                c => new
                    {
                        CodigoCarro = c.Int(nullable: false),
                        NumserieCarro = c.String(),
                        NumserieChasis = c.String(),
                        CodigoEsambladora = c.Int(nullable: false),
                        TipoCarro = c.Int(nullable: false),
                        TipoAuto = c.Int(),
                        TipoBus = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CodigoCarro)
                .ForeignKey("dbo.Ensambladoras", t => t.CodigoEsambladora, cascadeDelete: true)
                .ForeignKey("dbo.Parabrisas", t => t.CodigoCarro)
                .ForeignKey("dbo.Propietarios", t => t.CodigoCarro)
                .ForeignKey("dbo.Volantes", t => t.CodigoCarro)
                .Index(t => t.CodigoCarro)
                .Index(t => t.CodigoEsambladora);
            
            CreateTable(
                "dbo.Ensambladoras",
                c => new
                    {
                        CodigoEsambladora = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.CodigoEsambladora);
            
            CreateTable(
                "dbo.Llantas",
                c => new
                    {
                        CodigoLlanta = c.Int(nullable: false, identity: true),
                        NumeroSerie = c.String(),
                        CodigoCarro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoLlanta)
                .ForeignKey("dbo.Carros", t => t.CodigoCarro, cascadeDelete: true)
                .Index(t => t.CodigoCarro);
            
            CreateTable(
                "dbo.Parabrisas",
                c => new
                    {
                        CodigoParabrisas = c.Int(nullable: false, identity: true),
                        NumeroSerie = c.String(),
                    })
                .PrimaryKey(t => t.CodigoParabrisas);
            
            CreateTable(
                "dbo.Propietarios",
                c => new
                    {
                        CodigoPropietario = c.Int(nullable: false, identity: true),
                        Dni = c.String(),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        Licencia = c.String(),
                    })
                .PrimaryKey(t => t.CodigoPropietario);
            
            CreateTable(
                "dbo.Volantes",
                c => new
                    {
                        CodigoVolante = c.Int(nullable: false, identity: true),
                        NumeroSerie = c.String(),
                    })
                .PrimaryKey(t => t.CodigoVolante);
            
            CreateTable(
                "dbo.Cinturones",
                c => new
                    {
                        CodigoCinturon = c.Int(nullable: false, identity: true),
                        NumeroSerie = c.String(),
                        Metraje = c.Int(nullable: false),
                        CodigoAsiento = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoCinturon)
                .ForeignKey("dbo.Asientos", t => t.CodigoAsiento, cascadeDelete: true)
                .Index(t => t.CodigoAsiento);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cinturones", "CodigoAsiento", "dbo.Asientos");
            DropForeignKey("dbo.Asientos", "CodigoCarro", "dbo.Carros");
            DropForeignKey("dbo.Carros", "CodigoCarro", "dbo.Volantes");
            DropForeignKey("dbo.Carros", "CodigoCarro", "dbo.Propietarios");
            DropForeignKey("dbo.Carros", "CodigoCarro", "dbo.Parabrisas");
            DropForeignKey("dbo.Llantas", "CodigoCarro", "dbo.Carros");
            DropForeignKey("dbo.Carros", "CodigoEsambladora", "dbo.Ensambladoras");
            DropIndex("dbo.Cinturones", new[] { "CodigoAsiento" });
            DropIndex("dbo.Llantas", new[] { "CodigoCarro" });
            DropIndex("dbo.Carros", new[] { "CodigoEsambladora" });
            DropIndex("dbo.Carros", new[] { "CodigoCarro" });
            DropIndex("dbo.Asientos", new[] { "CodigoCarro" });
            DropTable("dbo.Cinturones");
            DropTable("dbo.Volantes");
            DropTable("dbo.Propietarios");
            DropTable("dbo.Parabrisas");
            DropTable("dbo.Llantas");
            DropTable("dbo.Ensambladoras");
            DropTable("dbo.Carros");
            DropTable("dbo.Asientos");
        }
    }
}

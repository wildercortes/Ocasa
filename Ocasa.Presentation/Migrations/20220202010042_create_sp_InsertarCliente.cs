using Microsoft.EntityFrameworkCore.Migrations;

namespace Ocasa.Presentation.Migrations
{
    public partial class create_sp_InsertarCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[sp_InsertarCliente]
                    @RazonSocial varchar(50),
                    @Direccion varchar(200)
                AS
                BEGIN
                    SET NOCOUNT ON;
                    insert into clientes(RazonSocial, Direccion) values (@RazonSocial, @Direccion)
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE [dbo].[sp_InsertarCliente]";

            migrationBuilder.Sql(sp);

        }
    }
}

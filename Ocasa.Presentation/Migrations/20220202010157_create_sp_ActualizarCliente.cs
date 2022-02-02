using Microsoft.EntityFrameworkCore.Migrations;

namespace Ocasa.Presentation.Migrations
{
    public partial class create_sp_ActualizarCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[sp_ActualizarCliente]
                    @IdCliente int,
                    @RazonSocial varchar(50),
                    @Direccion varchar(200)
                AS
                BEGIN
                    SET NOCOUNT ON;
                    update  clientes set  RazonSocial = @RazonSocial, Direccion = @Direccion where IdCliente = @IdCliente
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE [dbo].[sp_ActualizarCliente]";

            migrationBuilder.Sql(sp);
        }
    }
}

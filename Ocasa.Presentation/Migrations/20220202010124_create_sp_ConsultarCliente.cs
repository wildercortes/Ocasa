using Microsoft.EntityFrameworkCore.Migrations;

namespace Ocasa.Presentation.Migrations
{
    public partial class create_sp_ConsultarCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[sp_ConsultarCliente]
                    @IdCliente int
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select IdCliente, RazonSocial, Direccion from clientes where IdCliente = @IdCliente; 
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE [dbo].[sp_ConsultarCliente]";

            migrationBuilder.Sql(sp);

        }
    }
}

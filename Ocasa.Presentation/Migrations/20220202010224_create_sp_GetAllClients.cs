using Microsoft.EntityFrameworkCore.Migrations;

namespace Ocasa.Presentation.Migrations
{
    public partial class create_sp_GetAllClients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[sp_GetAllClients]
                AS
                BEGIN
                    SET NOCOUNT ON;
             select * from clientes;
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE [dbo].[sp_GetAllClients]";

            migrationBuilder.Sql(sp);

        }
    }
}

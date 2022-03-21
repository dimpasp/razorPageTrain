using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPages.Services.Migrations
{
    public partial class spGetEmployeeById : Migration
    {
                    //Using stored procedure
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create Procedure spGetEmployeeById
                            @Id int
                            as
                            Begin
                             Select * from Employees
                             Where Id = @Id
                            End";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spGetEmployeeById";
            migrationBuilder.Sql(procedure);

        }
    }
}

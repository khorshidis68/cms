using Microsoft.EntityFrameworkCore.Migrations;

namespace CmsProject.DataLayer.Migrations
{
    public partial class ChangeTypeDefualtPayInGradeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "DefualtPay",
                table: "Grades",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DefualtPay",
                table: "Grades",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}

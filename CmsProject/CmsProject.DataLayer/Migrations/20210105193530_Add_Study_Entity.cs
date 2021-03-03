using Microsoft.EntityFrameworkCore.Migrations;

namespace CmsProject.DataLayer.Migrations
{
    public partial class Add_Study_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Studys",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    TheoreticalHour = table.Column<int>(nullable: false),
                    PracticalHour = table.Column<int>(nullable: false),
                    TheoreticalCount = table.Column<int>(nullable: false),
                    PracticalCount = table.Column<int>(nullable: false),
                    LessonType = table.Column<string>(maxLength: 50, nullable: false),
                    LessonTypeCode = table.Column<int>(nullable: false),
                    GradeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studys", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Studys");
        }
    }
}

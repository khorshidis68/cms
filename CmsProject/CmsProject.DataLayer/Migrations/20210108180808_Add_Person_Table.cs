using Microsoft.EntityFrameworkCore.Migrations;

namespace CmsProject.DataLayer.Migrations
{
    public partial class Add_Person_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    LName = table.Column<string>(maxLength: 150, nullable: false),
                    FName = table.Column<string>(maxLength: 150, nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(maxLength: 300, nullable: false),
                    NationCode = table.Column<string>(maxLength: 11, nullable: false),
                    BirthDate = table.Column<string>(maxLength: 11, nullable: true),
                    BirthYear = table.Column<int>(maxLength: 11, nullable: true),
                    BirthMonth = table.Column<int>(nullable: true),
                    BirthDay = table.Column<int>(nullable: true),
                    IdNo = table.Column<string>(maxLength: 11, nullable: true),
                    Mobile = table.Column<string>(maxLength: 11, nullable: true),
                    DefaultPaymentId = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}

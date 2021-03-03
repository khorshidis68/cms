using Microsoft.EntityFrameworkCore.Migrations;

namespace CmsProject.DataLayer.Migrations
{
    public partial class Add_8_Entities_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankReports",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOf = table.Column<string>(maxLength: 50, nullable: false),
                    TimeOf = table.Column<string>(maxLength: 50, nullable: true),
                    Branch = table.Column<string>(maxLength: 500, nullable: true),
                    BranchCode = table.Column<int>(nullable: false),
                    Discription = table.Column<string>(maxLength: 2000, nullable: false),
                    CreditorName = table.Column<string>(maxLength: 50, nullable: false),
                    PaymentNo = table.Column<long>(nullable: true),
                    Evidenc = table.Column<int>(nullable: false),
                    DebtorORCreditor = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankReports", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HamavaInfos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnterYear = table.Column<int>(nullable: false),
                    TimeOf = table.Column<int>(nullable: false),
                    LessonCode = table.Column<string>(maxLength: 50, nullable: false),
                    LessonStatus = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false),
                    TeacherNationCode = table.Column<string>(maxLength: 50, nullable: false),
                    TeacherName = table.Column<string>(maxLength: 200, nullable: false),
                    ActionNumber = table.Column<int>(nullable: false),
                    TrainingCenterCode = table.Column<string>(maxLength: 50, nullable: false),
                    StudentCount = table.Column<int>(nullable: false),
                    AllowStudentCount = table.Column<int>(nullable: false),
                    AcceptTeacherId = table.Column<int>(nullable: true),
                    IsAcceptTeacher = table.Column<bool>(maxLength: 50, nullable: false),
                    NumberOfQuestions = table.Column<int>(nullable: false),
                    HStatus = table.Column<int>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HamavaInfos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HamavaInfoSchedules",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HamavaInfoId = table.Column<int>(nullable: false),
                    WeeklyScheduleDay = table.Column<string>(maxLength: 200, nullable: false),
                    WeeklyScheduleFromTime = table.Column<string>(maxLength: 200, nullable: false),
                    WeeklyScheduleToTime = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HamavaInfoSchedules", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Personels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonCode = table.Column<int>(nullable: false),
                    TrainingCenterId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    NationCode = table.Column<string>(maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StudentPayables",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnterYear = table.Column<int>(nullable: false),
                    EnterPaymet = table.Column<int>(nullable: false),
                    Payable = table.Column<long>(nullable: false),
                    PaymentNo = table.Column<long>(nullable: false),
                    StudentNo = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPayables", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentNo = table.Column<long>(maxLength: 150, nullable: false),
                    PaymentNo = table.Column<long>(nullable: false),
                    Major = table.Column<int>(nullable: false),
                    Grade = table.Column<int>(nullable: false),
                    Quotas = table.Column<string>(maxLength: 150, nullable: false),
                    TimeOf = table.Column<int>(nullable: false),
                    EnterYear = table.Column<int>(nullable: false),
                    NationCode = table.Column<string>(maxLength: 20, nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(maxLength: 500, nullable: false),
                    TrainingCenterCode = table.Column<string>(maxLength: 50, nullable: false),
                    TrainingCenterId = table.Column<int>(nullable: false),
                    Mobile = table.Column<string>(maxLength: 50, nullable: false),
                    Tel = table.Column<string>(maxLength: 50, nullable: false),
                    StudyGroup = table.Column<string>(maxLength: 50, nullable: false),
                    DurationType = table.Column<string>(maxLength: 50, nullable: false),
                    AvargeNumber = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(maxLength: 50, nullable: false),
                    TeachNo = table.Column<string>(maxLength: 200, nullable: false),
                    AccountNo = table.Column<long>(nullable: true),
                    BankName = table.Column<string>(maxLength: 200, nullable: false),
                    DefualtGrade = table.Column<int>(nullable: true),
                    TrainingCenterId = table.Column<int>(nullable: false),
                    NationCode = table.Column<string>(maxLength: 50, nullable: false),
                    TrainingCenterCode = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TeachGradePrices",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachGradePrices", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankReports");

            migrationBuilder.DropTable(
                name: "HamavaInfos");

            migrationBuilder.DropTable(
                name: "HamavaInfoSchedules");

            migrationBuilder.DropTable(
                name: "Personels");

            migrationBuilder.DropTable(
                name: "StudentPayables");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "TeachGradePrices");
        }
    }
}

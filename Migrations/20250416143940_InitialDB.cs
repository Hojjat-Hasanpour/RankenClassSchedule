using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RankenClassSchedule.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    DayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.DayId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    MilitaryTime = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    DayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_Classes_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "DayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Classes_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Days",
                columns: new[] { "DayId", "Name" },
                values: new object[,]
                {
                    { 1, "Monday" },
                    { 2, "Tuesday" },
                    { 3, "Wednesday" },
                    { 4, "Thursday" },
                    { 5, "Friday" },
                    { 6, "Saturday" },
                    { 7, "Sunday" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Hojjat", "Hasanpour" },
                    { 2, "Evan", "Gudmestad" },
                    { 3, "Arthur", "Morgan" },
                    { 4, "Charles", "Smith" },
                    { 5, "Hosea", "Matthews" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "DayId", "MilitaryTime", "Number", "TeacherId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "0800", 100, 1, "Intro to C#" },
                    { 2, 2, "1000", 101, 1, "Intro to Web Dev" },
                    { 3, 1, "1000", 200, 1, "Intro to Python" },
                    { 4, 1, "0800", 300, 3, "JavaScript Intermediat" },
                    { 5, 1, "1000", 300, 3, "JavaScript Advanced" },
                    { 6, 4, "1200", 400, 1, "Django Framework" },
                    { 7, 4, "1400", 501, 4, "Learn Database" },
                    { 8, 4, "1400", 502, 1, "Python Advanced" },
                    { 9, 1, "1200", 402, 2, "HTML CSS" },
                    { 10, 3, "1400", 502, 2, "ASP.NET Core" },
                    { 11, 5, "1600", 202, 5, "Desktop Support" },
                    { 12, 4, "1400", 301, 5, "Entity Framework" },
                    { 13, 4, "1600", 301, 5, "NodeJs" },
                    { 14, 1, "1000", 201, 4, "Java Language" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_DayId",
                table: "Classes",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_TeacherId",
                table: "Classes",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}

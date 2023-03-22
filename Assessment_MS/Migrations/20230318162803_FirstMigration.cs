using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assessment_MS.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SurveyRecord",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrightnessAcceptance = table.Column<bool>(type: "bit", nullable: true),
                    BrightnessLevel = table.Column<int>(type: "int", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyRecord", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SurveyRecord",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "BrightnessAcceptance", "BrightnessLevel", "County", "EmailAddress", "FullName", "Postcode", "Town" },
                values: new object[] { "2", "3 the lane", "", true, 5, "Cambs", "Billy.Nomates@notsure.com", "Billy Nomates", "PE01 8PE", "Peterborough" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyRecord");
        }
    }
}

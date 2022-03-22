using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb4_API.Migrations
{
    public partial class MadenullableinPersonInterestLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonInterestLinks_Interests_InterestId",
                table: "PersonInterestLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInterestLinks_Persons_PersonId",
                table: "PersonInterestLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInterestLinks_Websites_WebsiteId",
                table: "PersonInterestLinks");

            migrationBuilder.AlterColumn<int>(
                name: "WebsiteId",
                table: "PersonInterestLinks",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "PersonInterestLinks",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InterestId",
                table: "PersonInterestLinks",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInterestLinks_Interests_InterestId",
                table: "PersonInterestLinks",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "InterestId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInterestLinks_Persons_PersonId",
                table: "PersonInterestLinks",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInterestLinks_Websites_WebsiteId",
                table: "PersonInterestLinks",
                column: "WebsiteId",
                principalTable: "Websites",
                principalColumn: "WebsiteId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonInterestLinks_Interests_InterestId",
                table: "PersonInterestLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInterestLinks_Persons_PersonId",
                table: "PersonInterestLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInterestLinks_Websites_WebsiteId",
                table: "PersonInterestLinks");

            migrationBuilder.AlterColumn<int>(
                name: "WebsiteId",
                table: "PersonInterestLinks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "PersonInterestLinks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InterestId",
                table: "PersonInterestLinks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInterestLinks_Interests_InterestId",
                table: "PersonInterestLinks",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "InterestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInterestLinks_Persons_PersonId",
                table: "PersonInterestLinks",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInterestLinks_Websites_WebsiteId",
                table: "PersonInterestLinks",
                column: "WebsiteId",
                principalTable: "Websites",
                principalColumn: "WebsiteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

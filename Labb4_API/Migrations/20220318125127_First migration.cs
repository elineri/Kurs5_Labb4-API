using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb4_API.Migrations
{
    public partial class Firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Websites",
                columns: table => new
                {
                    WebsiteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkDescription = table.Column<string>(nullable: false),
                    Link = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Websites", x => x.WebsiteId);
                });

            migrationBuilder.CreateTable(
                name: "PersonInterestLinks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: false),
                    InterestId = table.Column<int>(nullable: false),
                    WebsiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInterestLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonInterestLinks_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInterestLinks_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInterestLinks_Websites_WebsiteId",
                        column: x => x.WebsiteId,
                        principalTable: "Websites",
                        principalColumn: "WebsiteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestId", "Description", "InterestName" },
                values: new object[,]
                {
                    { 1, "Floorball is a type of floor hockey with five players and a goalkeeper in each team", "Floorball" },
                    { 2, "The dog or domestic dog is a domesticated descendant of the wolf which is characterized by an upturning tail", "Dogs" },
                    { 3, "Valheim is a survival and sandbox video game by the Swedish developer Iron Gate Studio", "Valheim" },
                    { 4, "World of Warcraft is a massively multiplayer online role-playing game released in 2004 by Blizzard Entertainment", "World of Warcraft" },
                    { 5, "Interior design is the art and science of enhancing the interior of a building to achieve a healthier and more aesthetically pleasing environment for the people using the space", "Interior Design" },
                    { 6, "Carpenters are skilled artisans who construct, erect, install and renovate structures made of wood and other materials, ranging from kitchen cabinets to building frameworks", "Carpenter" },
                    { 7, "Fashion is a form of self-expression and autonomy at a particular period and place and in a specific context, of clothing, footwear, lifestyle, accessories, makeup, hairstyle, and body posture", "Fashion" },
                    { 8, "Counter-Strike is a series of multiplayer first-person shooter video games in which teams of terrorists battle to perpetrate an act of terror while counter-terrorists try to prevent it", "Counter-Strike" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 6, "Amanda", "Ask", "0701234123" },
                    { 4, "Siv", "Skog", "0742927172" },
                    { 5, "Peter", "Bok", "0701635567" },
                    { 2, "Göran", "Svensson", "0713456789" },
                    { 1, "Elin", "Ericstam", "0701234567" },
                    { 3, "Klas", "Johansson", "0739834572" }
                });

            migrationBuilder.InsertData(
                table: "Websites",
                columns: new[] { "WebsiteId", "Link", "LinkDescription" },
                values: new object[,]
                {
                    { 11, "https://www.vogue.com/", "Vogue" },
                    { 1, "https://floorball.sport/", "International Floorball Federation" },
                    { 2, "https://www.nationalgeographic.com/animals/mammals/facts/domestic-dog", "National Geographic Dog facts" },
                    { 3, "https://dogtime.com/dog-breeds/profiles", "Dog breeds" },
                    { 4, "https://valheim.fandom.com/wiki/Valheim_Wiki", "Valheim wiki" },
                    { 5, "https://www.valheimgame.com/", "Valheims website" },
                    { 6, "https://wowpedia.fandom.com/wiki/Wowpedia", "WoW wiki" },
                    { 7, "https://interiordesign.net/", "Interior design" },
                    { 8, "https://www.dezeen.com/interiors/", "Dezeen interior design" },
                    { 9, "https://www.webfactory.co.uk/portfolio-sectors?i=19&c=Carpenter", "Carpenter Website Design Examples" },
                    { 10, "https://www.elle.se/", "Elle" },
                    { 12, "https://csgostash.com/", "CS:GO Stash" }
                });

            migrationBuilder.InsertData(
                table: "PersonInterestLinks",
                columns: new[] { "Id", "InterestId", "PersonId", "WebsiteId" },
                values: new object[,]
                {
                    { 3, 1, 2, 1 },
                    { 1, 2, 1, 2 },
                    { 2, 2, 1, 3 },
                    { 4, 3, 3, 4 },
                    { 5, 3, 3, 5 },
                    { 6, 4, 4, 6 },
                    { 7, 5, 5, 7 },
                    { 8, 5, 5, 8 },
                    { 9, 6, 6, 9 },
                    { 10, 7, 4, 10 },
                    { 11, 7, 4, 11 },
                    { 12, 8, 2, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterestLinks_InterestId",
                table: "PersonInterestLinks",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterestLinks_PersonId",
                table: "PersonInterestLinks",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterestLinks_WebsiteId",
                table: "PersonInterestLinks",
                column: "WebsiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonInterestLinks");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Websites");
        }
    }
}

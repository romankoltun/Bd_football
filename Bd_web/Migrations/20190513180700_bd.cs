using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bd_web.Migrations
{
    public partial class bd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name_club = table.Column<string>(nullable: true),
                    Adres = table.Column<string>(nullable: true),
                    Sector = table.Column<int>(nullable: false),
                    Row = table.Column<int>(nullable: false),
                    Seat = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalEnums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Proffesion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalEnums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sponsors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Footballers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Amplya = table.Column<string>(nullable: true),
                    clubId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footballers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Footballers_Clubs_clubId",
                        column: x => x.clubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Peoples",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    personalEnumId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Peoples_PersonalEnums_personalEnumId",
                        column: x => x.personalEnumId,
                        principalTable: "PersonalEnums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Costs_s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    clubId = table.Column<int>(nullable: true),
                    Name_C = table.Column<string>(nullable: true),
                    ShopeTypeId = table.Column<int>(nullable: true),
                    Money_C = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costs_s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Costs_s_Shops_ShopeTypeId",
                        column: x => x.ShopeTypeId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Costs_s_Clubs_clubId",
                        column: x => x.clubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name_M = table.Column<string>(nullable: true),
                    Max_Sector = table.Column<string>(nullable: true),
                    Shop_TId = table.Column<int>(nullable: true),
                    max_row = table.Column<int>(nullable: false),
                    max_sition = table.Column<int>(nullable: false),
                    Club_gameId = table.Column<int>(nullable: true),
                    Ticet_string = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Clubs_Club_gameId",
                        column: x => x.Club_gameId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Shops_Shop_TId",
                        column: x => x.Shop_TId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    clubId = table.Column<int>(nullable: true),
                    Name_P = table.Column<string>(nullable: true),
                    ShopeTypeId = table.Column<int>(nullable: true),
                    Money_p = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profits_Shops_ShopeTypeId",
                        column: x => x.ShopeTypeId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profits_Clubs_clubId",
                        column: x => x.clubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Club_Sponsors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    clubId = table.Column<int>(nullable: true),
                    SponsorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club_Sponsors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Club_Sponsors_Sponsors_SponsorId",
                        column: x => x.SponsorId,
                        principalTable: "Sponsors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Club_Sponsors_Clubs_clubId",
                        column: x => x.clubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name_T = table.Column<string>(nullable: true),
                    sector = table.Column<string>(nullable: true),
                    row = table.Column<int>(nullable: false),
                    position = table.Column<int>(nullable: false),
                    Match_TId = table.Column<int>(nullable: true),
                    Date_t = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Matches_Match_TId",
                        column: x => x.Match_TId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Club_Sponsors_SponsorId",
                table: "Club_Sponsors",
                column: "SponsorId");

            migrationBuilder.CreateIndex(
                name: "IX_Club_Sponsors_clubId",
                table: "Club_Sponsors",
                column: "clubId");

            migrationBuilder.CreateIndex(
                name: "IX_Costs_s_ShopeTypeId",
                table: "Costs_s",
                column: "ShopeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Costs_s_clubId",
                table: "Costs_s",
                column: "clubId");

            migrationBuilder.CreateIndex(
                name: "IX_Footballers_clubId",
                table: "Footballers",
                column: "clubId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Club_gameId",
                table: "Matches",
                column: "Club_gameId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Shop_TId",
                table: "Matches",
                column: "Shop_TId");

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_personalEnumId",
                table: "Peoples",
                column: "personalEnumId");

            migrationBuilder.CreateIndex(
                name: "IX_Profits_ShopeTypeId",
                table: "Profits",
                column: "ShopeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Profits_clubId",
                table: "Profits",
                column: "clubId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Match_TId",
                table: "Tickets",
                column: "Match_TId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Club_Sponsors");

            migrationBuilder.DropTable(
                name: "Costs_s");

            migrationBuilder.DropTable(
                name: "Footballers");

            migrationBuilder.DropTable(
                name: "Peoples");

            migrationBuilder.DropTable(
                name: "Profits");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Sponsors");

            migrationBuilder.DropTable(
                name: "PersonalEnums");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}

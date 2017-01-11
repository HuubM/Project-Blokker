using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectBlokker.Data.Migrations
{
    public partial class Jurk2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Afspraak");

            migrationBuilder.DropColumn(
                name: "Naam",
                table: "Afspraak");

            migrationBuilder.DropColumn(
                name: "Nieuwsbrief",
                table: "Afspraak");

            migrationBuilder.DropColumn(
                name: "TelNr",
                table: "Afspraak");

            migrationBuilder.DropColumn(
                name: "TrouwDatum",
                table: "Afspraak");

            migrationBuilder.CreateTable(
                name: "Artikel",
                columns: table => new
                {
                    ArtikelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikel", x => x.ArtikelID);
                });

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    CategorieID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.CategorieID);
                });

            migrationBuilder.CreateTable(
                name: "Kleur",
                columns: table => new
                {
                    KleurID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kleur", x => x.KleurID);
                });

            migrationBuilder.CreateTable(
                name: "Merk",
                columns: table => new
                {
                    MerkID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merk", x => x.MerkID);
                });

            migrationBuilder.CreateTable(
                name: "Neklijn",
                columns: table => new
                {
                    NeklijnID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neklijn", x => x.NeklijnID);
                });

            migrationBuilder.CreateTable(
                name: "Silhouette",
                columns: table => new
                {
                    SilhouetteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Silhouette", x => x.SilhouetteID);
                });

            migrationBuilder.CreateTable(
                name: "Stijl",
                columns: table => new
                {
                    StijlID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stijl", x => x.StijlID);
                });

            migrationBuilder.CreateTable(
                name: "Jurk",
                columns: table => new
                {
                    JurkID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategorieID = table.Column<int>(nullable: true),
                    KleurID = table.Column<int>(nullable: true),
                    MerkID = table.Column<int>(nullable: true),
                    NeklijnID = table.Column<int>(nullable: true),
                    Omschrijving = table.Column<string>(nullable: true),
                    Prijs = table.Column<int>(nullable: false),
                    SilhouetteID = table.Column<int>(nullable: true),
                    StijlID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jurk", x => x.JurkID);
                    table.ForeignKey(
                        name: "FK_Jurk_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "CategorieID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jurk_Kleur_KleurID",
                        column: x => x.KleurID,
                        principalTable: "Kleur",
                        principalColumn: "KleurID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jurk_Merk_MerkID",
                        column: x => x.MerkID,
                        principalTable: "Merk",
                        principalColumn: "MerkID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jurk_Neklijn_NeklijnID",
                        column: x => x.NeklijnID,
                        principalTable: "Neklijn",
                        principalColumn: "NeklijnID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jurk_Silhouette_SilhouetteID",
                        column: x => x.SilhouetteID,
                        principalTable: "Silhouette",
                        principalColumn: "SilhouetteID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jurk_Stijl_StijlID",
                        column: x => x.StijlID,
                        principalTable: "Stijl",
                        principalColumn: "StijlID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<DateTime>(
                name: "AfspraakTijd",
                table: "Afspraak",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Jurk_CategorieID",
                table: "Jurk",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_Jurk_KleurID",
                table: "Jurk",
                column: "KleurID");

            migrationBuilder.CreateIndex(
                name: "IX_Jurk_MerkID",
                table: "Jurk",
                column: "MerkID");

            migrationBuilder.CreateIndex(
                name: "IX_Jurk_NeklijnID",
                table: "Jurk",
                column: "NeklijnID");

            migrationBuilder.CreateIndex(
                name: "IX_Jurk_SilhouetteID",
                table: "Jurk",
                column: "SilhouetteID");

            migrationBuilder.CreateIndex(
                name: "IX_Jurk_StijlID",
                table: "Jurk",
                column: "StijlID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AfspraakTijd",
                table: "Afspraak");

            migrationBuilder.DropTable(
                name: "Artikel");

            migrationBuilder.DropTable(
                name: "Jurk");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Kleur");

            migrationBuilder.DropTable(
                name: "Merk");

            migrationBuilder.DropTable(
                name: "Neklijn");

            migrationBuilder.DropTable(
                name: "Silhouette");

            migrationBuilder.DropTable(
                name: "Stijl");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Afspraak",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Naam",
                table: "Afspraak",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Nieuwsbrief",
                table: "Afspraak",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TelNr",
                table: "Afspraak",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TrouwDatum",
                table: "Afspraak",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

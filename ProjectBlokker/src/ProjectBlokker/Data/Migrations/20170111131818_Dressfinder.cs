using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectBlokker.Data.Migrations
{
    public partial class Dressfinder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jurk_Categorie_CategorieID",
                table: "Jurk");

            migrationBuilder.DropForeignKey(
                name: "FK_Jurk_Kleur_KleurID",
                table: "Jurk");

            migrationBuilder.DropForeignKey(
                name: "FK_Jurk_Merk_MerkID",
                table: "Jurk");

            migrationBuilder.DropForeignKey(
                name: "FK_Jurk_Neklijn_NeklijnID",
                table: "Jurk");

            migrationBuilder.DropForeignKey(
                name: "FK_Jurk_Silhouette_SilhouetteID",
                table: "Jurk");

            migrationBuilder.DropForeignKey(
                name: "FK_Jurk_Stijl_StijlID",
                table: "Jurk");

            migrationBuilder.DropIndex(
                name: "IX_Jurk_CategorieID",
                table: "Jurk");

            migrationBuilder.DropIndex(
                name: "IX_Jurk_KleurID",
                table: "Jurk");

            migrationBuilder.DropIndex(
                name: "IX_Jurk_MerkID",
                table: "Jurk");

            migrationBuilder.DropIndex(
                name: "IX_Jurk_NeklijnID",
                table: "Jurk");

            migrationBuilder.DropIndex(
                name: "IX_Jurk_SilhouetteID",
                table: "Jurk");

            migrationBuilder.DropIndex(
                name: "IX_Jurk_StijlID",
                table: "Jurk");

            migrationBuilder.DropColumn(
                name: "CategorieID",
                table: "Jurk");

            migrationBuilder.DropColumn(
                name: "KleurID",
                table: "Jurk");

            migrationBuilder.DropColumn(
                name: "MerkID",
                table: "Jurk");

            migrationBuilder.DropColumn(
                name: "NeklijnID",
                table: "Jurk");

            migrationBuilder.DropColumn(
                name: "SilhouetteID",
                table: "Jurk");

            migrationBuilder.DropColumn(
                name: "StijlID",
                table: "Jurk");

            migrationBuilder.DropColumn(
                name: "AfspraakTijd",
                table: "Afspraak");

            migrationBuilder.AddColumn<int>(
                name: "Categorie",
                table: "Jurk",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Kleur",
                table: "Jurk",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Merk",
                table: "Jurk",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Neklijn",
                table: "Jurk",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Silhouette",
                table: "Jurk",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stijl",
                table: "Jurk",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Afspraak",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Naam",
                table: "Afspraak",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Nieuwsbrief",
                table: "Afspraak",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TelNr",
                table: "Afspraak",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TrouwDatum",
                table: "Afspraak",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Jurk_Categorie",
                table: "Jurk",
                column: "Categorie");

            migrationBuilder.CreateIndex(
                name: "IX_Jurk_Kleur",
                table: "Jurk",
                column: "Kleur");

            migrationBuilder.CreateIndex(
                name: "IX_Jurk_Merk",
                table: "Jurk",
                column: "Merk");

            migrationBuilder.CreateIndex(
                name: "IX_Jurk_Neklijn",
                table: "Jurk",
                column: "Neklijn");

            migrationBuilder.CreateIndex(
                name: "IX_Jurk_Silhouette",
                table: "Jurk",
                column: "Silhouette");

            migrationBuilder.CreateIndex(
                name: "IX_Jurk_Stijl",
                table: "Jurk",
                column: "Stijl");

            migrationBuilder.AddForeignKey(
                name: "FK_Jurk_Categorie_Categorie",
                table: "Jurk",
                column: "Categorie",
                principalTable: "Categorie",
                principalColumn: "CategorieID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jurk_Kleur_Kleur",
                table: "Jurk",
                column: "Kleur",
                principalTable: "Kleur",
                principalColumn: "KleurID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jurk_Merk_Merk",
                table: "Jurk",
                column: "Merk",
                principalTable: "Merk",
                principalColumn: "MerkID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jurk_Neklijn_Neklijn",
                table: "Jurk",
                column: "Neklijn",
                principalTable: "Neklijn",
                principalColumn: "NeklijnID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jurk_Silhouette_Silhouette",
                table: "Jurk",
                column: "Silhouette",
                principalTable: "Silhouette",
                principalColumn: "SilhouetteID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jurk_Stijl_Stijl",
                table: "Jurk",
                column: "Stijl",
                principalTable: "Stijl",
                principalColumn: "StijlID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jurk_Categorie_Categorie",
                table: "Jurk");

            migrationBuilder.DropForeignKey(
                name: "FK_Jurk_Kleur_Kleur",
                table: "Jurk");

            migrationBuilder.DropForeignKey(
                name: "FK_Jurk_Merk_Merk",
                table: "Jurk");

            migrationBuilder.DropForeignKey(
                name: "FK_Jurk_Neklijn_Neklijn",
                table: "Jurk");

            migrationBuilder.DropForeignKey(
                name: "FK_Jurk_Silhouette_Silhouette",
                table: "Jurk");

            migrationBuilder.DropForeignKey(
                name: "FK_Jurk_Stijl_Stijl",
                table: "Jurk");

            migrationBuilder.DropIndex(
                name: "IX_Jurk_Categorie",
                table: "Jurk");

            migrationBuilder.DropIndex(
                name: "IX_Jurk_Kleur",
                table: "Jurk");

            migrationBuilder.DropIndex(
                name: "IX_Jurk_Merk",
                table: "Jurk");

            migrationBuilder.DropIndex(
                name: "IX_Jurk_Neklijn",
                table: "Jurk");

            migrationBuilder.DropIndex(
                name: "IX_Jurk_Silhouette",
                table: "Jurk");

            migrationBuilder.DropIndex(
                name: "IX_Jurk_Stijl",
                table: "Jurk");

            migrationBuilder.DropColumn(
                name: "Categorie",
                table: "Jurk");

            migrationBuilder.DropColumn(
                name: "Kleur",
                table: "Jurk");

            migrationBuilder.DropColumn(
                name: "Merk",
                table: "Jurk");

            migrationBuilder.DropColumn(
                name: "Neklijn",
                table: "Jurk");

            migrationBuilder.DropColumn(
                name: "Silhouette",
                table: "Jurk");

            migrationBuilder.DropColumn(
                name: "Stijl",
                table: "Jurk");

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

            migrationBuilder.AddColumn<int>(
                name: "CategorieID",
                table: "Jurk",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KleurID",
                table: "Jurk",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MerkID",
                table: "Jurk",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NeklijnID",
                table: "Jurk",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SilhouetteID",
                table: "Jurk",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StijlID",
                table: "Jurk",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Jurk_Categorie_CategorieID",
                table: "Jurk",
                column: "CategorieID",
                principalTable: "Categorie",
                principalColumn: "CategorieID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jurk_Kleur_KleurID",
                table: "Jurk",
                column: "KleurID",
                principalTable: "Kleur",
                principalColumn: "KleurID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jurk_Merk_MerkID",
                table: "Jurk",
                column: "MerkID",
                principalTable: "Merk",
                principalColumn: "MerkID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jurk_Neklijn_NeklijnID",
                table: "Jurk",
                column: "NeklijnID",
                principalTable: "Neklijn",
                principalColumn: "NeklijnID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jurk_Silhouette_SilhouetteID",
                table: "Jurk",
                column: "SilhouetteID",
                principalTable: "Silhouette",
                principalColumn: "SilhouetteID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jurk_Stijl_StijlID",
                table: "Jurk",
                column: "StijlID",
                principalTable: "Stijl",
                principalColumn: "StijlID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

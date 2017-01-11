using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectBlokker.Data.Migrations
{
    public partial class Jurk10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jurk_Artikel_Artikel",
                table: "Jurk");

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
                name: "IX_Jurk_Artikel",
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
                name: "Artikel",
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

            migrationBuilder.CreateIndex(
                name: "IX_Jurk_ArtikelID",
                table: "Jurk",
                column: "ArtikelID");

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
                name: "FK_Jurk_Artikel_ArtikelID",
                table: "Jurk",
                column: "ArtikelID",
                principalTable: "Artikel",
                principalColumn: "ArtikelID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jurk_Categorie_CategorieID",
                table: "Jurk",
                column: "CategorieID",
                principalTable: "Categorie",
                principalColumn: "CategorieID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jurk_Kleur_KleurID",
                table: "Jurk",
                column: "KleurID",
                principalTable: "Kleur",
                principalColumn: "KleurID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jurk_Merk_MerkID",
                table: "Jurk",
                column: "MerkID",
                principalTable: "Merk",
                principalColumn: "MerkID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jurk_Neklijn_NeklijnID",
                table: "Jurk",
                column: "NeklijnID",
                principalTable: "Neklijn",
                principalColumn: "NeklijnID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jurk_Silhouette_SilhouetteID",
                table: "Jurk",
                column: "SilhouetteID",
                principalTable: "Silhouette",
                principalColumn: "SilhouetteID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jurk_Stijl_StijlID",
                table: "Jurk",
                column: "StijlID",
                principalTable: "Stijl",
                principalColumn: "StijlID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jurk_Artikel_ArtikelID",
                table: "Jurk");

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
                name: "IX_Jurk_ArtikelID",
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

            migrationBuilder.AddColumn<int>(
                name: "Artikel",
                table: "Jurk",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Jurk_Artikel",
                table: "Jurk",
                column: "Artikel");

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
                name: "FK_Jurk_Artikel_Artikel",
                table: "Jurk",
                column: "Artikel",
                principalTable: "Artikel",
                principalColumn: "ArtikelID",
                onDelete: ReferentialAction.Restrict);

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
    }
}

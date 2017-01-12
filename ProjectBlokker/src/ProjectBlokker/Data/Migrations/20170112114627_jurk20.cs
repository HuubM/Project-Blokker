using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectBlokker.Data.Migrations
{
    public partial class jurk20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jurk_Categorie_CategorieID",
                table: "Jurk");

            migrationBuilder.AddColumn<int>(
                name: "CategorieID",
                table: "Artikel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CategorieID",
                table: "Jurk",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artikel_CategorieID",
                table: "Artikel",
                column: "CategorieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Artikel_Categorie_CategorieID",
                table: "Artikel",
                column: "CategorieID",
                principalTable: "Categorie",
                principalColumn: "CategorieID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jurk_Categorie_CategorieID",
                table: "Jurk",
                column: "CategorieID",
                principalTable: "Categorie",
                principalColumn: "CategorieID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artikel_Categorie_CategorieID",
                table: "Artikel");

            migrationBuilder.DropForeignKey(
                name: "FK_Jurk_Categorie_CategorieID",
                table: "Jurk");

            migrationBuilder.DropIndex(
                name: "IX_Artikel_CategorieID",
                table: "Artikel");

            migrationBuilder.DropColumn(
                name: "CategorieID",
                table: "Artikel");

            migrationBuilder.AlterColumn<int>(
                name: "CategorieID",
                table: "Jurk",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Jurk_Categorie_CategorieID",
                table: "Jurk",
                column: "CategorieID",
                principalTable: "Categorie",
                principalColumn: "CategorieID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

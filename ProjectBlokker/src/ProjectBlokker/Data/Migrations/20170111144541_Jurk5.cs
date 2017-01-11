using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectBlokker.Data.Migrations
{
    public partial class Jurk5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtikelID",
                table: "Jurk",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategorieID",
                table: "Jurk",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KleurID",
                table: "Jurk",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MerkID",
                table: "Jurk",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NeklijnID",
                table: "Jurk",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SilhouetteID",
                table: "Jurk",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StijlID",
                table: "Jurk",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArtikelID",
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
        }
    }
}

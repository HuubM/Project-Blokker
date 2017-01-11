using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectBlokker.Data.Migrations
{
    public partial class jurk12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image1_location",
                table: "Jurk",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "image2_location",
                table: "Jurk",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "image3_location",
                table: "Jurk",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "image4_location",
                table: "Jurk",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image1_location",
                table: "Jurk");

            migrationBuilder.DropColumn(
                name: "image2_location",
                table: "Jurk");

            migrationBuilder.DropColumn(
                name: "image3_location",
                table: "Jurk");

            migrationBuilder.DropColumn(
                name: "image4_location",
                table: "Jurk");
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectBlokker.Data.Migrations
{
    public partial class AfspraakTijd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AfspraakTijd",
                table: "Afspraak",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "TelNr",
                table: "Afspraak",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "Afspraak",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Afspraak",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AfspraakTijd",
                table: "Afspraak");

            migrationBuilder.AlterColumn<int>(
                name: "TelNr",
                table: "Afspraak",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "Afspraak",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Afspraak",
                nullable: true);
        }
    }
}

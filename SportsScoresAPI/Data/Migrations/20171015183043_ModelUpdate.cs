using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SportsScoresAPI.Data.Migrations
{
    public partial class ModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "IsInProgress",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JerseyNumber",
                table: "PlayerToTeamAssignments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Players",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayerPositionId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "HomeTeamGoals",
                table: "Games",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AwayTeamGoals",
                table: "Games",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "HalfAwayTeamGoals",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HalfHomeTeamGoals",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Nationality",
                table: "Competitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "Competitions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    NationalityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlagURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.NationalityId);
                });

            migrationBuilder.CreateTable(
                name: "PlayerPositions",
                columns: table => new
                {
                    PlayerPositionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerPositions", x => x.PlayerPositionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_NationalityId",
                table: "Players",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerPositionId",
                table: "Players",
                column: "PlayerPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_NationalityId",
                table: "Competitions",
                column: "NationalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Nationalities_NationalityId",
                table: "Competitions",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Nationalities_NationalityId",
                table: "Players",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "NationalityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PlayerPositions_PlayerPositionId",
                table: "Players",
                column: "PlayerPositionId",
                principalTable: "PlayerPositions",
                principalColumn: "PlayerPositionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Nationalities_NationalityId",
                table: "Competitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Nationalities_NationalityId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayerPositions_PlayerPositionId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "PlayerPositions");

            migrationBuilder.DropIndex(
                name: "IX_Players_NationalityId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_PlayerPositionId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Competitions_NationalityId",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerPositionId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "HalfAwayTeamGoals",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "HalfHomeTeamGoals",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "Competitions");

            migrationBuilder.AlterColumn<int>(
                name: "JerseyNumber",
                table: "PlayerToTeamAssignments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Players",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Nationality",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "HomeTeamGoals",
                table: "Games",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AwayTeamGoals",
                table: "Games",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInProgress",
                table: "Games",
                nullable: false,
                defaultValue: false);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergyMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class AuditFieldsAndRemoveOwnerFromSolarPanels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolarPanels_AspNetUsers_OwnerId",
                table: "SolarPanels");

            migrationBuilder.DropForeignKey(
                name: "FK_SolarPlants_AspNetUsers_OwnerId",
                table: "SolarPlants");

            migrationBuilder.DropIndex(
                name: "IX_SolarPlants_OwnerId",
                table: "SolarPlants");

            migrationBuilder.DropIndex(
                name: "IX_SolarPanels_OwnerId",
                table: "SolarPanels");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "SolarPlants");

            migrationBuilder.DropColumn(
                name: "InstallationDate",
                table: "SolarPanels");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "SolarPanels");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SolarPlants",
                type: "datetime2",
                nullable: false,
                comment: "Fecha de creación del registro",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "SolarPlants",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SolarPlants",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "",
                comment: "Usuario que creó el registro");

            migrationBuilder.AddColumn<DateTime>(
                name: "InstallationDate",
                table: "SolarPlants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Fecha de instalación del sistema");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "SolarPlants",
                type: "datetime2",
                nullable: true,
                comment: "Fecha de última modificación");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "SolarPlants",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                comment: "Usuario que modificó el registro");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "SolarPanels",
                type: "int",
                nullable: false,
                comment: "Cantidad de paneles del mismo modelo",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PowerWatts",
                table: "SolarPanels",
                type: "int",
                nullable: false,
                comment: "Potencia nominal en watts",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "Potencia nominal en watts");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SolarPanels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Fecha de creación del registro");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SolarPanels",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "",
                comment: "Usuario que creó el registro");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "SolarPanels",
                type: "datetime2",
                nullable: true,
                comment: "Fecha de última modificación");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "SolarPanels",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                comment: "Usuario que modificó el registro");

            migrationBuilder.CreateIndex(
                name: "IX_SolarPlants_ApplicationUserId",
                table: "SolarPlants",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolarPlants_AspNetUsers_ApplicationUserId",
                table: "SolarPlants",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolarPlants_AspNetUsers_ApplicationUserId",
                table: "SolarPlants");

            migrationBuilder.DropIndex(
                name: "IX_SolarPlants_ApplicationUserId",
                table: "SolarPlants");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "SolarPlants");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SolarPlants");

            migrationBuilder.DropColumn(
                name: "InstallationDate",
                table: "SolarPlants");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "SolarPlants");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "SolarPlants");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SolarPanels");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SolarPanels");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "SolarPanels");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "SolarPanels");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SolarPlants",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Fecha de creación del registro");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "SolarPlants",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "SolarPanels",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Cantidad de paneles del mismo modelo");

            migrationBuilder.AlterColumn<decimal>(
                name: "PowerWatts",
                table: "SolarPanels",
                type: "decimal(18,2)",
                nullable: false,
                comment: "Potencia nominal en watts",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Potencia nominal en watts");

            migrationBuilder.AddColumn<DateTime>(
                name: "InstallationDate",
                table: "SolarPanels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "SolarPanels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SolarPlants_OwnerId",
                table: "SolarPlants",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_SolarPanels_OwnerId",
                table: "SolarPanels",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolarPanels_AspNetUsers_OwnerId",
                table: "SolarPanels",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolarPlants_AspNetUsers_OwnerId",
                table: "SolarPlants",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

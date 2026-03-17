using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergyMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class divices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_AspNetUsers_CreatedByUserId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_CreatedByUserId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Devices");

            migrationBuilder.AlterColumn<double>(
                name: "RatedPowerWatts",
                table: "Devices",
                type: "float",
                nullable: true,
                comment: "Potencia nominal",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true,
                oldComment: "Potencia nominal");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Devices",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Devices",
                type: "uniqueidentifier",
                nullable: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Devices",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.MinValue,
                comment: "Fecha de creación del registro");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Devices",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "",
                comment: "Usuario que creó el registro");

            migrationBuilder.AddColumn<Guid>(
                name: "SolarPlantId",
                table: "Devices",
                type: "uniqueidentifier",
                nullable: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Devices",
                type: "datetime2",
                nullable: true,
                comment: "Fecha de última modificación");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Devices",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                comment: "Usuario que modificó el registro");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_CompanyId",
                table: "Devices",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_SolarPlantId",
                table: "Devices",
                column: "SolarPlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Company_CompanyId",
                table: "Devices",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_SolarPlants_SolarPlantId",
                table: "Devices",
                column: "SolarPlantId",
                principalTable: "SolarPlants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Company_CompanyId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_SolarPlants_SolarPlantId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_CompanyId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_SolarPlantId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "SolarPlantId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Devices");

            migrationBuilder.AlterColumn<decimal>(
                name: "RatedPowerWatts",
                table: "Devices",
                type: "decimal(18,2)",
                nullable: true,
                comment: "Potencia nominal",
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true,
                oldComment: "Potencia nominal");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Devices",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Devices",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Devices",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_CreatedByUserId",
                table: "Devices",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_AspNetUsers_CreatedByUserId",
                table: "Devices",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

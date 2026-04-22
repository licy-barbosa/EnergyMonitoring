using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergyMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDeviceMeasurements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "DeviceMeasurements");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "DeviceMeasurements");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "DeviceMeasurements",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                comment: "Fecha de creación del registro");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "DeviceMeasurements",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "",
                comment: "Usuario que creó el registro");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "DeviceMeasurements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "DeviceMeasurements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "DeviceMeasurements",
                type: "datetime2",
                nullable: true,
                comment: "Fecha de última modificación");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "DeviceMeasurements",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                comment: "Usuario que modificó el registro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "DeviceMeasurements");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DeviceMeasurements");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "DeviceMeasurements");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "DeviceMeasurements");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "DeviceMeasurements");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "DeviceMeasurements");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "DeviceMeasurements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "DeviceMeasurements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Fecha de medición");
        }
    }
}

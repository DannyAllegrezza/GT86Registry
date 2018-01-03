using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GT86Registry.Infrastructure.Data.Migrations
{
    public partial class FixVehiclesImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Image_Image_ImageId",
                table: "Vehicle_Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Image_Vehicle_VehicleVIN",
                table: "Vehicle_Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle_Image",
                table: "Vehicle_Image");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_Image_VehicleVIN",
                table: "Vehicle_Image");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Vehicle_Image");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleVIN",
                table: "Vehicle_Image",
                type: "nvarchar(17)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle_Image",
                table: "Vehicle_Image",
                columns: new[] { "VehicleVIN", "ImageId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Image_Image_ImageId",
                table: "Vehicle_Image",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Image_Vehicle_VehicleVIN",
                table: "Vehicle_Image",
                column: "VehicleVIN",
                principalTable: "Vehicle",
                principalColumn: "VIN",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Image_Image_ImageId",
                table: "Vehicle_Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Image_Vehicle_VehicleVIN",
                table: "Vehicle_Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle_Image",
                table: "Vehicle_Image");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleVIN",
                table: "Vehicle_Image",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(17)");

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Vehicle_Image",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle_Image",
                table: "Vehicle_Image",
                columns: new[] { "VehicleId", "ImageId" });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Image_VehicleVIN",
                table: "Vehicle_Image",
                column: "VehicleVIN");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Image_Image_ImageId",
                table: "Vehicle_Image",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Image_Vehicle_VehicleVIN",
                table: "Vehicle_Image",
                column: "VehicleVIN",
                principalTable: "Vehicle",
                principalColumn: "VIN",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

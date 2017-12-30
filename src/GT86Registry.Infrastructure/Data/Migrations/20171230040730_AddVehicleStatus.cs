using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GT86Registry.Infrastructure.Data.Migrations
{
    public partial class AddVehicleStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VehicleStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    StatusCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_StatusId",
                table: "Vehicle",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_VehicleStatus_StatusId",
                table: "Vehicle",
                column: "StatusId",
                principalTable: "VehicleStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_VehicleStatus_StatusId",
                table: "Vehicle");

            migrationBuilder.DropTable(
                name: "VehicleStatus");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_StatusId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Vehicle");
        }
    }
}

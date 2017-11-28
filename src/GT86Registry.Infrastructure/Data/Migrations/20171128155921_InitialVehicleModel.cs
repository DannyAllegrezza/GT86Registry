using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GT86Registry.Infrastructure.Data.Migrations
{
    public partial class InitialVehicleModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActiveEndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ActiveStartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transmission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Model_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Model_Year",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model_Year", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Model_Year_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Model_Color",
                columns: table => new
                {
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    ModelYearId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model_Color", x => new { x.ColorId, x.ModelYearId });
                    table.ForeignKey(
                        name: "FK_Model_Color_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Model_Color_Model_Year_ModelYearId",
                        column: x => x.ModelYearId,
                        principalTable: "Model_Year",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Model_Transmission",
                columns: table => new
                {
                    ModelYearId = table.Column<int>(type: "int", nullable: false),
                    TransmissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model_Transmission", x => new { x.ModelYearId, x.TransmissionId });
                    table.ForeignKey(
                        name: "FK_Model_Transmission_Model_Year_ModelYearId",
                        column: x => x.ModelYearId,
                        principalTable: "Model_Year",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Model_Transmission_Transmission_TransmissionId",
                        column: x => x.TransmissionId,
                        principalTable: "Transmission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    VIN = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    FacebookUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelYearId = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ProfilePhotoId = table.Column<int>(type: "int", nullable: false),
                    TransmissionId = table.Column<int>(type: "int", nullable: false),
                    UserIdentityGuid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleLocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VIN);
                    table.ForeignKey(
                        name: "FK_Vehicle_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_Model_Year_ModelYearId",
                        column: x => x.ModelYearId,
                        principalTable: "Model_Year",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_Image_ProfilePhotoId",
                        column: x => x.ProfilePhotoId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_Transmission_TransmissionId",
                        column: x => x.TransmissionId,
                        principalTable: "Transmission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TimeStamp = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    VehicleVIN = table.Column<string>(type: "nvarchar(17)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Vehicle_VehicleVIN",
                        column: x => x.VehicleVIN,
                        principalTable: "Vehicle",
                        principalColumn: "VIN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle_Image",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    VehicleVIN = table.Column<string>(type: "nvarchar(17)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle_Image", x => new { x.VehicleId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_Vehicle_Image_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_Image_Vehicle_VehicleVIN",
                        column: x => x.VehicleVIN,
                        principalTable: "Vehicle",
                        principalColumn: "VIN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Location_VehicleVIN",
                table: "Location",
                column: "VehicleVIN");

            migrationBuilder.CreateIndex(
                name: "IX_Model_ManufacturerId",
                table: "Model",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Model_Color_ModelYearId",
                table: "Model_Color",
                column: "ModelYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Model_Transmission_TransmissionId",
                table: "Model_Transmission",
                column: "TransmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Model_Year_ModelId",
                table: "Model_Year",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ColorId",
                table: "Vehicle",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ModelYearId",
                table: "Vehicle",
                column: "ModelYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ProfilePhotoId",
                table: "Vehicle",
                column: "ProfilePhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_TransmissionId",
                table: "Vehicle",
                column: "TransmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleLocationId",
                table: "Vehicle",
                column: "VehicleLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Image_ImageId",
                table: "Vehicle_Image",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Image_VehicleVIN",
                table: "Vehicle_Image",
                column: "VehicleVIN");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Location_VehicleLocationId",
                table: "Vehicle",
                column: "VehicleLocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Vehicle_VehicleVIN",
                table: "Location");

            migrationBuilder.DropTable(
                name: "Model_Color");

            migrationBuilder.DropTable(
                name: "Model_Transmission");

            migrationBuilder.DropTable(
                name: "Vehicle_Image");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Model_Year");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Transmission");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "Manufacturer");
        }
    }
}

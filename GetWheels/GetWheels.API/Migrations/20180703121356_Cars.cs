using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GetWheels.API.Migrations
{
    public partial class Cars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Lang = table.Column<double>(nullable: false),
                    Lat = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TripsCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    PlateNo = table.Column<string>(nullable: false),
                    Model = table.Column<string>(maxLength: 60, nullable: true),
                    OwnerId = table.Column<Guid>(nullable: false),
                    ReleaseYear = table.Column<int>(nullable: false),
                    TripsCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.PlateNo);
                    table.ForeignKey(
                        name: "FK_Cars_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarPlateNo = table.Column<string>(nullable: true),
                    FromId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: false),
                    ToId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_Locations_FromId",
                        column: x => x.FromId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trips_Users_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trips_Locations_ToId",
                        column: x => x.ToId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_OwnerId",
                table: "Cars",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_FromId",
                table: "Trips",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_TenantId",
                table: "Trips",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_ToId",
                table: "Trips",
                column: "ToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mantenimientoProsisApi.Migrations
{
    public partial class TableTodos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.CreateTable(
                name: "DTCHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgreementNum = table.Column<int>(nullable: false),
                    ManagerName = table.Column<string>(maxLength: 20, nullable: false),
                    Position = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DTCHeaders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SparePartsCatalogs",
                columns: table => new
                {
                    NumPart = table.Column<string>(maxLength: 50, nullable: false),
                    TypeService = table.Column<string>(maxLength: 25, nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Brand = table.Column<string>(maxLength: 25, nullable: false),
                    Price = table.Column<float>(nullable: false),
                    Unit = table.Column<int>(nullable: false),
                    PieceYear = table.Column<string>(maxLength: 5, nullable: false),
                    SparePartImage = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SparePartsCatalogs", x => x.NumPart);
                });

            migrationBuilder.CreateTable(
                name: "SquaresCatalogs",
                columns: table => new
                {
                    SquareNum = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SquareName = table.Column<string>(maxLength: 20, nullable: false),
                    Delegation = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SquaresCatalogs", x => x.SquareNum);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 80, nullable: true),
                    Email = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LanesCatalogs",
                columns: table => new
                {
                    CapufeLaneNum = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lane = table.Column<string>(maxLength: 4, nullable: false),
                    LaneType = table.Column<string>(maxLength: 15, nullable: false),
                    SquareCatalogId = table.Column<int>(nullable: false),
                    SquaresCatalogSquareNum = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanesCatalogs", x => x.CapufeLaneNum);
                    table.ForeignKey(
                        name: "FK_LanesCatalogs_SquaresCatalogs_SquaresCatalogSquareNum",
                        column: x => x.SquaresCatalogSquareNum,
                        principalTable: "SquaresCatalogs",
                        principalColumn: "SquareNum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DTCTechnicians",
                columns: table => new
                {
                    ReferenceNum = table.Column<string>(maxLength: 10, nullable: false),
                    LanesCatalogId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    DTCHeaderId = table.Column<int>(nullable: false),
                    SparePartsCatalogId = table.Column<string>(maxLength: 50, nullable: false),
                    AxaNum = table.Column<string>(maxLength: 8, nullable: true),
                    FailureNum = table.Column<int>(nullable: false),
                    Status = table.Column<string>(maxLength: 30, nullable: true),
                    FailureDate = table.Column<DateTime>(nullable: false),
                    IncidentDate = table.Column<DateTime>(nullable: false),
                    ElaborationDate = table.Column<DateTime>(nullable: false),
                    ShippingDate = table.Column<DateTime>(nullable: false),
                    OpinionType = table.Column<string>(maxLength: 30, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Diagnostic = table.Column<string>(maxLength: 30, nullable: true),
                    Observation = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DTCTechnicians", x => x.ReferenceNum);
                    table.ForeignKey(
                        name: "FK_DTCTechnicians_DTCHeaders_DTCHeaderId",
                        column: x => x.DTCHeaderId,
                        principalTable: "DTCHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DTCTechnicians_LanesCatalogs_LanesCatalogId",
                        column: x => x.LanesCatalogId,
                        principalTable: "LanesCatalogs",
                        principalColumn: "CapufeLaneNum",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DTCTechnicians_SparePartsCatalogs_SparePartsCatalogId",
                        column: x => x.SparePartsCatalogId,
                        principalTable: "SparePartsCatalogs",
                        principalColumn: "NumPart",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DTCTechnicians_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DTCMovements",
                columns: table => new
                {
                    DTCTechnicianId = table.Column<string>(maxLength: 10, nullable: false),
                    ModificationDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DTCTechnicianReferenceNum = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DTCMovements", x => x.DTCTechnicianId);
                    table.ForeignKey(
                        name: "FK_DTCMovements_DTCTechnicians_DTCTechnicianReferenceNum",
                        column: x => x.DTCTechnicianReferenceNum,
                        principalTable: "DTCTechnicians",
                        principalColumn: "ReferenceNum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DTCMovements_DTCTechnicianReferenceNum",
                table: "DTCMovements",
                column: "DTCTechnicianReferenceNum");

            migrationBuilder.CreateIndex(
                name: "IX_DTCTechnicians_DTCHeaderId",
                table: "DTCTechnicians",
                column: "DTCHeaderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DTCTechnicians_LanesCatalogId",
                table: "DTCTechnicians",
                column: "LanesCatalogId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DTCTechnicians_SparePartsCatalogId",
                table: "DTCTechnicians",
                column: "SparePartsCatalogId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DTCTechnicians_UserId",
                table: "DTCTechnicians",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LanesCatalogs_SquaresCatalogSquareNum",
                table: "LanesCatalogs",
                column: "SquaresCatalogSquareNum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DTCMovements");

            migrationBuilder.DropTable(
                name: "DTCTechnicians");

            migrationBuilder.DropTable(
                name: "DTCHeaders");

            migrationBuilder.DropTable(
                name: "LanesCatalogs");

            migrationBuilder.DropTable(
                name: "SparePartsCatalogs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SquaresCatalogs");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });
        }
    }
}

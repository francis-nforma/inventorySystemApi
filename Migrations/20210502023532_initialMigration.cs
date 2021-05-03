using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace inventoryApi.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "challenge");

            migrationBuilder.CreateTable(
                name: "Car",
                schema: "challenge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Make = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Series = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    Created_By = table.Column<string>(type: "text", nullable: false, defaultValue: "francistrinh"),
                    Created_Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 5, 2, 12, 35, 31, 474, DateTimeKind.Local).AddTicks(2500)),
                    Last_Updated_Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dealer",
                schema: "challenge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Dealer_Name = table.Column<string>(type: "text", nullable: false),
                    Address_Line1 = table.Column<string>(type: "text", nullable: true),
                    Address_Line2 = table.Column<string>(type: "text", nullable: true),
                    Address_Suburb = table.Column<string>(type: "text", nullable: true),
                    Address_State = table.Column<string>(type: "text", nullable: true),
                    Address_Postcode = table.Column<int>(type: "integer", nullable: true),
                    Contact_Number = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    Created_By = table.Column<string>(type: "text", nullable: false, defaultValue: "francistrinh"),
                    Created_Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 5, 2, 12, 35, 31, 459, DateTimeKind.Local).AddTicks(5400)),
                    Last_Updated_Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                schema: "challenge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CarId = table.Column<int>(type: "integer", nullable: false),
                    DealerId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Created_By = table.Column<string>(type: "text", nullable: false, defaultValue: "francistrinh"),
                    Created_Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 5, 2, 12, 35, 31, 474, DateTimeKind.Local).AddTicks(9570)),
                    Last_Updated_Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK__CarDealer__Car",
                        column: x => x.CarId,
                        principalSchema: "challenge",
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__CarDealer__Dealer",
                        column: x => x.DealerId,
                        principalSchema: "challenge",
                        principalTable: "Dealer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryTransactions",
                schema: "challenge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CarId = table.Column<int>(type: "integer", nullable: false),
                    DealerId = table.Column<int>(type: "integer", nullable: false),
                    Event = table.Column<string>(type: "text", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    Created_By = table.Column<string>(type: "text", nullable: false, defaultValue: "francistrinh"),
                    Created_Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 5, 2, 12, 35, 31, 475, DateTimeKind.Local).AddTicks(5470))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK__InventoryTransactions__Car",
                        column: x => x.CarId,
                        principalSchema: "challenge",
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__InventoryTransactions__Dealer",
                        column: x => x.DealerId,
                        principalSchema: "challenge",
                        principalTable: "Dealer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_CarId",
                schema: "challenge",
                table: "Inventory",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_DealerId",
                schema: "challenge",
                table: "Inventory",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransactions_CarId",
                schema: "challenge",
                table: "InventoryTransactions",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransactions_DealerId",
                schema: "challenge",
                table: "InventoryTransactions",
                column: "DealerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory",
                schema: "challenge");

            migrationBuilder.DropTable(
                name: "InventoryTransactions",
                schema: "challenge");

            migrationBuilder.DropTable(
                name: "Car",
                schema: "challenge");

            migrationBuilder.DropTable(
                name: "Dealer",
                schema: "challenge");
        }
    }
}

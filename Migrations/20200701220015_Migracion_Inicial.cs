using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistroPedidosSuplidor.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    OrdenId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    SuplidorId = table.Column<int>(nullable: false),
                    Monto = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.OrdenId);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(nullable: true),
                    Costo = table.Column<double>(nullable: false),
                    Invetario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Suplidores",
                columns: table => new
                {
                    SuplidoreId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suplidores", x => x.SuplidoreId);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesDetalle",
                columns: table => new
                {
                    OrdenId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Costo = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesDetalle", x => x.OrdenId);
                    table.ForeignKey(
                        name: "FK_OrdenesDetalle_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Ordenes",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Invetario" },
                values: new object[] { 1, 1500.5, "Es un producto 1", 10 });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Invetario" },
                values: new object[] { 2, 5000.0, "Es un producto 2", 10 });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Invetario" },
                values: new object[] { 3, 3000.0, "Es un producto 3", 10 });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Invetario" },
                values: new object[] { 4, 120.0, "Es un producto 4", 10 });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Invetario" },
                values: new object[] { 5, 4560.0, "Es un producto 5", 10 });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Invetario" },
                values: new object[] { 6, 2000.0, "Es un producto 6", 10 });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Invetario" },
                values: new object[] { 7, 1000.0, "Es un producto 7", 10 });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "SuplidoreId", "Nombres" },
                values: new object[] { 1, "Victor" });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "SuplidoreId", "Nombres" },
                values: new object[] { 2, "Johan" });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "SuplidoreId", "Nombres" },
                values: new object[] { 3, "Palma" });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "SuplidoreId", "Nombres" },
                values: new object[] { 4, "Rodríguez" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenesDetalle");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Suplidores");

            migrationBuilder.DropTable(
                name: "Ordenes");
        }
    }
}

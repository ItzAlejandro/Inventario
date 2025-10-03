using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioTransaccione.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class updateTransaccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrecioTotal",
                table: "Transacciones",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecioTotal",
                table: "Transacciones");
        }
    }
}

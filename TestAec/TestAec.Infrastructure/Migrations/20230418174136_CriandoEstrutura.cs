using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAec.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CriandoEstrutura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Cards",
                schema: "dbo",
                columns: table => new
                {
                    cardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    autor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataPublicao = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.cardId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards",
                schema: "dbo");
        }
    }
}

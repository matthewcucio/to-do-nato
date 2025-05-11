using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todoapp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "ToDoItemModels");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ToDoItemModels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ToDoItemModels");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "ToDoItemModels",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todoapp.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryAndPriorityToToDoItemModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "ToDoItemModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "ToDoItemModels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "ToDoItemModels");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "ToDoItemModels");
        }
    }
}

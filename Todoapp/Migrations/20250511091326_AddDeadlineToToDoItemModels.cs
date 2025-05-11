using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todoapp.Migrations
{
    /// <inheritdoc />
    public partial class AddDeadlineToToDoItemModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "ToDoItemModels",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "ToDoItemModels");
        }
    }
}

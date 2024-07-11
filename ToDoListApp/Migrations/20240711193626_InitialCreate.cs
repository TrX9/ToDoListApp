using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoListApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    Level = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.Level);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDoItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriorityId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoItems_Priorities_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priorities",
                        principalColumn: "Level",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDoItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Priorities",
                column: "Level",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4,
                    5
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Alice" },
                    { 2, "Bob" },
                    { 3, "Charlie" },
                    { 4, "David" },
                    { 5, "Eve" }
                });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "Description", "DueDate", "IsCompleted", "PriorityId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Description for Task 1", new DateTime(2024, 7, 12, 22, 36, 25, 76, DateTimeKind.Local).AddTicks(8922), false, 1, "Task 1", 1 },
                    { 2, "Description for Task 2", new DateTime(2024, 7, 13, 22, 36, 25, 76, DateTimeKind.Local).AddTicks(8940), true, 2, "Task 2", 2 },
                    { 3, "Description for Task 3", new DateTime(2024, 7, 14, 22, 36, 25, 76, DateTimeKind.Local).AddTicks(8943), false, 3, "Task 3", 3 },
                    { 4, "Description for Task 4", new DateTime(2024, 7, 15, 22, 36, 25, 76, DateTimeKind.Local).AddTicks(8944), true, 4, "Task 4", 4 },
                    { 5, "Description for Task 5", new DateTime(2024, 7, 16, 22, 36, 25, 76, DateTimeKind.Local).AddTicks(8946), false, 5, "Task 5", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_PriorityId",
                table: "ToDoItems",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_UserId",
                table: "ToDoItems",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoItems");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

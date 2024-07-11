using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListApp.Migrations
{
    /// <inheritdoc />
    public partial class AddRowVersionToToDoItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2024, 7, 12, 23, 22, 18, 429, DateTimeKind.Local).AddTicks(5247));

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2024, 7, 13, 23, 22, 18, 429, DateTimeKind.Local).AddTicks(5263));

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2024, 7, 14, 23, 22, 18, 429, DateTimeKind.Local).AddTicks(5265));

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "DueDate",
                value: new DateTime(2024, 7, 15, 23, 22, 18, 429, DateTimeKind.Local).AddTicks(5267));

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "DueDate",
                value: new DateTime(2024, 7, 16, 23, 22, 18, 429, DateTimeKind.Local).AddTicks(5269));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2024, 7, 12, 22, 36, 25, 76, DateTimeKind.Local).AddTicks(8922));

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2024, 7, 13, 22, 36, 25, 76, DateTimeKind.Local).AddTicks(8940));

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2024, 7, 14, 22, 36, 25, 76, DateTimeKind.Local).AddTicks(8943));

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "DueDate",
                value: new DateTime(2024, 7, 15, 22, 36, 25, 76, DateTimeKind.Local).AddTicks(8944));

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "DueDate",
                value: new DateTime(2024, 7, 16, 22, 36, 25, 76, DateTimeKind.Local).AddTicks(8946));
        }
    }
}

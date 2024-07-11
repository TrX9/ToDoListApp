using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListApp.Migrations
{
    /// <inheritdoc />
    public partial class AddRowVersionToToDoItem2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ToDoItems",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2024, 7, 12, 23, 35, 13, 607, DateTimeKind.Local).AddTicks(8267));

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2024, 7, 13, 23, 35, 13, 607, DateTimeKind.Local).AddTicks(8283));

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2024, 7, 14, 23, 35, 13, 607, DateTimeKind.Local).AddTicks(8285));

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "DueDate",
                value: new DateTime(2024, 7, 15, 23, 35, 13, 607, DateTimeKind.Local).AddTicks(8287));

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "DueDate",
                value: new DateTime(2024, 7, 16, 23, 35, 13, 607, DateTimeKind.Local).AddTicks(8289));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ToDoItems");

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
    }
}

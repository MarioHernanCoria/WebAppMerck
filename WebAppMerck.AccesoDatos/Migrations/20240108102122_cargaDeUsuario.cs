using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAppMerck.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class cargaDeUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Clave",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Clave", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "admin", null, "admin@admin.com", true, false, null, null, null, null, null, true, null, false, null },
                    { "2", 0, "usuario", null, "usuario@gmail.com", true, false, null, null, null, null, null, true, null, false, null }
                });

            migrationBuilder.UpdateData(
                table: "Consultas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaYhora",
                value: new DateTime(2024, 1, 8, 7, 21, 22, 106, DateTimeKind.Local).AddTicks(7171));

            migrationBuilder.UpdateData(
                table: "Consultas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaYhora",
                value: new DateTime(2024, 1, 8, 7, 21, 22, 106, DateTimeKind.Local).AddTicks(7228));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DropColumn(
                name: "Clave",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.UpdateData(
                table: "Consultas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaYhora",
                value: new DateTime(2024, 1, 8, 6, 47, 12, 997, DateTimeKind.Local).AddTicks(5147));

            migrationBuilder.UpdateData(
                table: "Consultas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaYhora",
                value: new DateTime(2024, 1, 8, 6, 47, 12, 997, DateTimeKind.Local).AddTicks(5202));
        }
    }
}

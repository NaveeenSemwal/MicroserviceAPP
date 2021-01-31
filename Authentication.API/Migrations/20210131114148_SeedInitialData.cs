using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationService.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Administrator", "Admin" },
                    { 2, "Employee", "Employee" },
                    { 3, "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "ContactNo", "CreatedDate", "Name", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "New Delhi", "978776654", new DateTime(2021, 1, 31, 17, 11, 46, 602, DateTimeKind.Local).AddTicks(2920), "Administrator", "123", "admin" },
                    { 2, "New Delhi", "978776654", new DateTime(2021, 1, 31, 17, 11, 46, 602, DateTimeKind.Local).AddTicks(3014), "Employee", "123", "emp" },
                    { 3, "New Delhi", "978776654", new DateTime(2021, 1, 31, 17, 11, 46, 602, DateTimeKind.Local).AddTicks(3023), "User", "123", "user" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 3, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);
        }
    }
}

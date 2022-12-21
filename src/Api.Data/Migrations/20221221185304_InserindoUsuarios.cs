using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InserindoUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("f29ebb27-1591-4b9e-ab2c-354094870175"), new DateTime(2022, 12, 21, 15, 53, 4, 71, DateTimeKind.Local).AddTicks(8297), "adm@mail.com", "Administrador", new DateTime(2022, 12, 21, 15, 53, 4, 72, DateTimeKind.Local).AddTicks(9131) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("75a68fc9-98b6-4537-bc9d-9cc5d71b71b0"), new DateTime(2022, 12, 21, 15, 53, 4, 72, DateTimeKind.Local).AddTicks(9453), "vino@mail.com", "Vinicius", new DateTime(2022, 12, 21, 15, 53, 4, 72, DateTimeKind.Local).AddTicks(9461) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("75a68fc9-98b6-4537-bc9d-9cc5d71b71b0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f29ebb27-1591-4b9e-ab2c-354094870175"));
        }
    }
}

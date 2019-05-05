using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BricABrac.Data.Migrations
{
    public partial class FixeTODO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserIdTodo",
                table: "todo",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "todo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "todo");

            migrationBuilder.AlterColumn<string>(
                name: "UserIdTodo",
                table: "todo",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 45,
                oldNullable: true);
        }
    }
}

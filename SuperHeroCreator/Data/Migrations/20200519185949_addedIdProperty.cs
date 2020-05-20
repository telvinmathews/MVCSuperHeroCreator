using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperHeroCreator.Data.Migrations
{
    public partial class addedIdProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Heros",
                table: "Heros");

            migrationBuilder.RenameTable(
                name: "Heros",
                newName: "Heroes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Heroes",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Heroes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Heroes",
                table: "Heroes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Heroes",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Heroes");

            migrationBuilder.RenameTable(
                name: "Heroes",
                newName: "Heros");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Heros",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Heros",
                table: "Heros",
                column: "Name");
        }
    }
}

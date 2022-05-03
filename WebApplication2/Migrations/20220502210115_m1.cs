using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerAccounts",
                columns: table => new
                {
                    Account_ID = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    IsMd5Password = table.Column<bool>(nullable: false),
                    IsAutoConvertMd5 = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerAccounts", x => x.Account_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerAccounts");
        }
    }
}

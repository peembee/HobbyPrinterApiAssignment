using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HobbyPrinterApi.Migrations
{
    /// <inheritdoc />
    public partial class namevariablewrong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hobbys_People_FK_PeopleID",
                table: "Hobbys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "Peoples");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Peoples",
                table: "Peoples",
                column: "PeopleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hobbys_Peoples_FK_PeopleID",
                table: "Hobbys",
                column: "FK_PeopleID",
                principalTable: "Peoples",
                principalColumn: "PeopleID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hobbys_Peoples_FK_PeopleID",
                table: "Hobbys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Peoples",
                table: "Peoples");

            migrationBuilder.RenameTable(
                name: "Peoples",
                newName: "People");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "PeopleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hobbys_People_FK_PeopleID",
                table: "Hobbys",
                column: "FK_PeopleID",
                principalTable: "People",
                principalColumn: "PeopleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

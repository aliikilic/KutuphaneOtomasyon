using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KutuphaneOtomasyon.Migrations
{
    public partial class addstockcolumnbookstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15d48cda-eb0a-4d6f-bc79-0fa0b3d2f0ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a22be29-8bc1-480e-b667-843ef712e90f");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "22643c4f-d9a5-4445-b80a-41283a9b14aa", "4eae55eb-b6fa-4cdb-a91b-cd617cc71afa", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2a246482-e283-4979-91a9-33e769f6ffe0", "0d71690a-b249-41d2-9531-a823897ccbe8", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22643c4f-d9a5-4445-b80a-41283a9b14aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a246482-e283-4979-91a9-33e769f6ffe0");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Books");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "15d48cda-eb0a-4d6f-bc79-0fa0b3d2f0ff", "5dce50aa-818e-4fa5-ba32-52d71004ac70", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5a22be29-8bc1-480e-b667-843ef712e90f", "b46ff068-0d58-4b1c-b57a-6c497aef402d", "Admin", "ADMIN" });
        }
    }
}

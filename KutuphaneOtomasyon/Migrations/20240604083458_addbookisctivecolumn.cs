using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KutuphaneOtomasyon.Migrations
{
    public partial class addbookisctivecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89c78118-8f33-4b3f-80c0-2829623eff87");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec429267-5fc4-4394-a8d0-dddb0b191fc6");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "15d48cda-eb0a-4d6f-bc79-0fa0b3d2f0ff", "5dce50aa-818e-4fa5-ba32-52d71004ac70", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5a22be29-8bc1-480e-b667-843ef712e90f", "b46ff068-0d58-4b1c-b57a-6c497aef402d", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15d48cda-eb0a-4d6f-bc79-0fa0b3d2f0ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a22be29-8bc1-480e-b667-843ef712e90f");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Books");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "89c78118-8f33-4b3f-80c0-2829623eff87", "80d9ff7a-674f-4fba-a7b8-cf841ee4f754", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ec429267-5fc4-4394-a8d0-dddb0b191fc6", "42fa6975-c736-4641-8e64-1216847a43f5", "User", "USER" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class Initialcc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeBank_Employee_EmployeeId",
                table: "EmployeeBank");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeBank_EmployeeId",
                table: "EmployeeBank");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "EmployeeBank",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BankID",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_BankID",
                table: "Employee",
                column: "BankID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeeBank_BankID",
                table: "Employee",
                column: "BankID",
                principalTable: "EmployeeBank",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeBank_BankID",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_BankID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "BankID",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "EmployeeBank",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBank_EmployeeId",
                table: "EmployeeBank",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeBank_Employee_EmployeeId",
                table: "EmployeeBank",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

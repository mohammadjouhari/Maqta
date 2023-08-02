using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeBank_BankID",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "EmployeeBank");

            migrationBuilder.DropIndex(
                name: "IX_Employee_BankID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "BankID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CreationUserID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DeleteUserID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ModifyUserID",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Employee",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employee",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "BankID",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreationUserID",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeleteUserID",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Employee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Employee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyUserID",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeBank",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationUserID = table.Column<int>(type: "int", nullable: false),
                    DeleteUserID = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Iban = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUserID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeBank", x => x.ID);
                });

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
    }
}

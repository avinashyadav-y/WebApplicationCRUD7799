using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationCRUD.Migrations
{
    /// <inheritdoc />
    public partial class Newly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_departments_DepartmentDept_id",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_DepartmentDept_id",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "DepartmentDept_id",
                table: "employees");

            migrationBuilder.RenameColumn(
                name: "Dept_id",
                table: "departments",
                newName: "Dept_Id");

            migrationBuilder.CreateIndex(
                name: "IX_employees_Dept_Id",
                table: "employees",
                column: "Dept_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_departments_Dept_Id",
                table: "employees",
                column: "Dept_Id",
                principalTable: "departments",
                principalColumn: "Dept_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_departments_Dept_Id",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_Dept_Id",
                table: "employees");

            migrationBuilder.RenameColumn(
                name: "Dept_Id",
                table: "departments",
                newName: "Dept_id");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentDept_id",
                table: "employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_employees_DepartmentDept_id",
                table: "employees",
                column: "DepartmentDept_id");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_departments_DepartmentDept_id",
                table: "employees",
                column: "DepartmentDept_id",
                principalTable: "departments",
                principalColumn: "Dept_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

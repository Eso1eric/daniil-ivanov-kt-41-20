using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace daniil_ivanov_kt_41_20.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTeachers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "cd_teachers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "idx_cd_teachers_fk_f_department_id",
                table: "cd_teachers",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "fk_f_department_id",
                table: "cd_teachers",
                column: "DepartmentId",
                principalTable: "cs_departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_f_department_id",
                table: "cd_teachers");

            migrationBuilder.DropIndex(
                name: "idx_cd_teachers_fk_f_department_id",
                table: "cd_teachers");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "cd_teachers");
        }
    }
}

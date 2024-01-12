using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace daniil_ivanov_kt_41_20.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTeachersDepartments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_f_headteacher_id",
                table: "cs_departments");

            migrationBuilder.DropIndex(
                name: "idx_cs_departments_fk_f_headteacher_id",
                table: "cs_departments");

            migrationBuilder.DropColumn(
                name: "HeadTeacherId",
                table: "cs_departments");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "cs_positions");

            migrationBuilder.RenameTable(
                name: "Degrees",
                newName: "cs_degrees");

            migrationBuilder.AddColumn<bool>(
                name: "b_isHeadTeacher",
                table: "cd_teachers",
                type: "bool",
                nullable: false,
                defaultValue: false,
                comment: "Заведующий кафедры");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "b_isHeadTeacher",
                table: "cd_teachers");

            migrationBuilder.RenameTable(
                name: "cs_positions",
                newName: "Positions");

            migrationBuilder.RenameTable(
                name: "cs_degrees",
                newName: "Degrees");

            migrationBuilder.AddColumn<int>(
                name: "HeadTeacherId",
                table: "cs_departments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "idx_cs_departments_fk_f_headteacher_id",
                table: "cs_departments",
                column: "HeadTeacherId");

            migrationBuilder.AddForeignKey(
                name: "fk_f_headteacher_id",
                table: "cs_departments",
                column: "HeadTeacherId",
                principalTable: "cd_teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace daniil_ivanov_kt_41_20.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Degrees",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор ученой степени")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Название ученой степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cs_degrees_degree_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор должности")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Название должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cs_positions_position_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cd_teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Имя"),
                    c_surname = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Фамилия"),
                    c_lastname = table.Column<string>(type: "varchar", maxLength: 50, nullable: true, comment: "Отчество"),
                    DegreeId = table.Column<int>(type: "integer", nullable: false),
                    PositionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_teachers_teacher_id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_f_degree_id",
                        column: x => x.DegreeId,
                        principalTable: "Degrees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_position_id",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cs_departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_shortname = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, comment: "Краткое наименование"),
                    c_fullname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Полное наименование"),
                    d_createdate = table.Column<DateTime>(type: "timestamp", nullable: false, comment: "Дата основания"),
                    HeadTeacherId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cs_departments_department_id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_f_headteacher_id",
                        column: x => x.HeadTeacherId,
                        principalTable: "cd_teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cs_subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Название дисциплины"),
                    TeacherId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cs_subjects_subject_id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_f_teacher_id",
                        column: x => x.TeacherId,
                        principalTable: "cd_teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_workloads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    n_hours = table.Column<int>(type: "int4", nullable: false, comment: "Кол-во часов"),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    TeacherId = table.Column<int>(type: "integer", nullable: false),
                    SubjectId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_workloads_workload_id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_f_department_id",
                        column: x => x.DepartmentId,
                        principalTable: "cs_departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_subject_id",
                        column: x => x.SubjectId,
                        principalTable: "cs_subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_teacher_id",
                        column: x => x.TeacherId,
                        principalTable: "cd_teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_teachers_fk_f_degree_id",
                table: "cd_teachers",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teachers_fk_f_position_id",
                table: "cd_teachers",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "idx_cd_workloads_fk_f_department_id",
                table: "cd_workloads",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "idx_cd_workloads_fk_f_subject_id",
                table: "cd_workloads",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "idx_cd_workloads_fk_f_teacher_id",
                table: "cd_workloads",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "idx_cs_departments_fk_f_headteacher_id",
                table: "cs_departments",
                column: "HeadTeacherId");

            migrationBuilder.CreateIndex(
                name: "idx_cs_subjects_fk_f_teacher_id",
                table: "cs_subjects",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_workloads");

            migrationBuilder.DropTable(
                name: "cs_departments");

            migrationBuilder.DropTable(
                name: "cs_subjects");

            migrationBuilder.DropTable(
                name: "cd_teachers");

            migrationBuilder.DropTable(
                name: "Degrees");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}

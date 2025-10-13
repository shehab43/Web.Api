using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateUserRemoveClinicId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_Users_DoctorId1",
                table: "Clinics");

            migrationBuilder.DropIndex(
                name: "IX_Clinics_DoctorId1",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "Clinics");

            migrationBuilder.AlterColumn<int>(
                name: "ClinicId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_DoctorId",
                table: "Clinics",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_Users_DoctorId",
                table: "Clinics",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_Users_DoctorId",
                table: "Clinics");

            migrationBuilder.DropIndex(
                name: "IX_Clinics_DoctorId",
                table: "Clinics");

            migrationBuilder.AlterColumn<int>(
                name: "ClinicId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId1",
                table: "Clinics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_DoctorId1",
                table: "Clinics",
                column: "DoctorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_Users_DoctorId1",
                table: "Clinics",
                column: "DoctorId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

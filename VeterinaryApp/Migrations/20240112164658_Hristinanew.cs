using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeterinaryApp.Migrations
{
    /// <inheritdoc />
    public partial class Hristinanew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetVaccine_Vaccines_VaccinesVaccineId",
                table: "PetVaccine");

            migrationBuilder.RenameColumn(
                name: "VaccineId",
                table: "Vaccines",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "VaccinesVaccineId",
                table: "PetVaccine",
                newName: "VaccinesId");

            migrationBuilder.RenameIndex(
                name: "IX_PetVaccine_VaccinesVaccineId",
                table: "PetVaccine",
                newName: "IX_PetVaccine_VaccinesId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Vaccines",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Owners",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Owners",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_PetVaccine_Vaccines_VaccinesId",
                table: "PetVaccine",
                column: "VaccinesId",
                principalTable: "Vaccines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetVaccine_Vaccines_VaccinesId",
                table: "PetVaccine");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vaccines",
                newName: "VaccineId");

            migrationBuilder.RenameColumn(
                name: "VaccinesId",
                table: "PetVaccine",
                newName: "VaccinesVaccineId");

            migrationBuilder.RenameIndex(
                name: "IX_PetVaccine_VaccinesId",
                table: "PetVaccine",
                newName: "IX_PetVaccine_VaccinesVaccineId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Vaccines",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddForeignKey(
                name: "FK_PetVaccine_Vaccines_VaccinesVaccineId",
                table: "PetVaccine",
                column: "VaccinesVaccineId",
                principalTable: "Vaccines",
                principalColumn: "VaccineId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

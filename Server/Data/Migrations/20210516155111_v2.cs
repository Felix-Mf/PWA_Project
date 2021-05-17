using Microsoft.EntityFrameworkCore.Migrations;

namespace PWA_Project.Server.Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Input_InputEntryId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Input_InputEntryId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Test_Input_InputEntryId",
                table: "Test");

            migrationBuilder.RenameColumn(
                name: "InputEntryId",
                table: "Test",
                newName: "InputId");

            migrationBuilder.RenameIndex(
                name: "IX_Test_InputEntryId",
                table: "Test",
                newName: "IX_Test_InputId");

            migrationBuilder.RenameColumn(
                name: "InputEntryId",
                table: "Question",
                newName: "InputId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_InputEntryId",
                table: "Question",
                newName: "IX_Question_InputId");

            migrationBuilder.RenameColumn(
                name: "EntryId",
                table: "Input",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "InputEntryId",
                table: "Answer",
                newName: "InputId");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_InputEntryId",
                table: "Answer",
                newName: "IX_Answer_InputId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Input_InputId",
                table: "Answer",
                column: "InputId",
                principalTable: "Input",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Input_InputId",
                table: "Question",
                column: "InputId",
                principalTable: "Input",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Input_InputId",
                table: "Test",
                column: "InputId",
                principalTable: "Input",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Input_InputId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Input_InputId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Test_Input_InputId",
                table: "Test");

            migrationBuilder.RenameColumn(
                name: "InputId",
                table: "Test",
                newName: "InputEntryId");

            migrationBuilder.RenameIndex(
                name: "IX_Test_InputId",
                table: "Test",
                newName: "IX_Test_InputEntryId");

            migrationBuilder.RenameColumn(
                name: "InputId",
                table: "Question",
                newName: "InputEntryId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_InputId",
                table: "Question",
                newName: "IX_Question_InputEntryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Input",
                newName: "EntryId");

            migrationBuilder.RenameColumn(
                name: "InputId",
                table: "Answer",
                newName: "InputEntryId");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_InputId",
                table: "Answer",
                newName: "IX_Answer_InputEntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Input_InputEntryId",
                table: "Answer",
                column: "InputEntryId",
                principalTable: "Input",
                principalColumn: "EntryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Input_InputEntryId",
                table: "Question",
                column: "InputEntryId",
                principalTable: "Input",
                principalColumn: "EntryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Input_InputEntryId",
                table: "Test",
                column: "InputEntryId",
                principalTable: "Input",
                principalColumn: "EntryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

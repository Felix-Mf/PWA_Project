using Microsoft.EntityFrameworkCore.Migrations;

namespace PWA_Project.Server.Data.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Input_InputId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Input_InputId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Test_Course_CourseId",
                table: "Test");

            migrationBuilder.DropForeignKey(
                name: "FK_Test_Input_InputId",
                table: "Test");

            migrationBuilder.DropIndex(
                name: "IX_Test_InputId",
                table: "Test");

            migrationBuilder.DropIndex(
                name: "IX_Question_InputId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Answer_InputId",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "InputId",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "InputId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "InputId",
                table: "Answer");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Test",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Input_AnswerId",
                table: "Input",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Input_QuestionId",
                table: "Input",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Input_TestId",
                table: "Input",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Input_Answer_AnswerId",
                table: "Input",
                column: "AnswerId",
                principalTable: "Answer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Input_Question_QuestionId",
                table: "Input",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Input_Test_TestId",
                table: "Input",
                column: "TestId",
                principalTable: "Test",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Course_CourseId",
                table: "Test",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Input_Answer_AnswerId",
                table: "Input");

            migrationBuilder.DropForeignKey(
                name: "FK_Input_Question_QuestionId",
                table: "Input");

            migrationBuilder.DropForeignKey(
                name: "FK_Input_Test_TestId",
                table: "Input");

            migrationBuilder.DropForeignKey(
                name: "FK_Test_Course_CourseId",
                table: "Test");

            migrationBuilder.DropIndex(
                name: "IX_Input_AnswerId",
                table: "Input");

            migrationBuilder.DropIndex(
                name: "IX_Input_QuestionId",
                table: "Input");

            migrationBuilder.DropIndex(
                name: "IX_Input_TestId",
                table: "Input");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Test",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "InputId",
                table: "Test",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InputId",
                table: "Question",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InputId",
                table: "Answer",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Test_InputId",
                table: "Test",
                column: "InputId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_InputId",
                table: "Question",
                column: "InputId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_InputId",
                table: "Answer",
                column: "InputId");

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
                name: "FK_Test_Course_CourseId",
                table: "Test",
                column: "CourseId",
                principalTable: "Course",
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
    }
}

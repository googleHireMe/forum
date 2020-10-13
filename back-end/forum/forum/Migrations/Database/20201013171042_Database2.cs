using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace forum.Migrations.Database
{
    public partial class Database2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Topic_TopicId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Topic_User_AuthorId",
                table: "Topic");

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthorId",
                table: "Topic",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TopicId",
                table: "Message",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Topic_TopicId",
                table: "Message",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_User_AuthorId",
                table: "Topic",
                column: "AuthorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Topic_TopicId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Topic_User_AuthorId",
                table: "Topic");

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthorId",
                table: "Topic",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "TopicId",
                table: "Message",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Topic_TopicId",
                table: "Message",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_User_AuthorId",
                table: "Topic",
                column: "AuthorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

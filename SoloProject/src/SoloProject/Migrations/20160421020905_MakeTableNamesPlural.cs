using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace SoloProject.Migrations
{
    public partial class MakeTableNamesPlural : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Comment_Post_PostId", table: "Comment");
            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts");
            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");
            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Comment_Post_PostId", table: "Comments");
            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_PostId",
                table: "Comment",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post");
            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");
        }
    }
}

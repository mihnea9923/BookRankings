using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookRankings.DataAccess.Migrations
{
    public partial class lazyloading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AddedById",
                table: "Books",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AddedById",
                table: "Books",
                column: "AddedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_AddedById",
                table: "Books",
                column: "AddedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_AddedById",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AddedById",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "Books");
        }
    }
}

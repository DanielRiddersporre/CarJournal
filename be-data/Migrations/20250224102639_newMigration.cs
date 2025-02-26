using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace be_data.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "JournalEntries",
                newName: "Category");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "JournalEntries",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "JournalEntries",
                newName: "Type");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "JournalEntries",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}

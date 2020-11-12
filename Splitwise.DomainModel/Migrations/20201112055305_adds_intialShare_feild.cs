﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Splitwise.DomainModel.Migrations
{
    public partial class adds_intialShare_feild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PayerInitialShare",
                table: "Payers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PayeeInitialShare",
                table: "Payees",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayerInitialShare",
                table: "Payers");

            migrationBuilder.DropColumn(
                name: "PayeeInitialShare",
                table: "Payees");
        }
    }
}

﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenericProductAPI.Server.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    FabricationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupplierCode = table.Column<long>(type: "bigint", nullable: false),
                    SupplierDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierCNPJ = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

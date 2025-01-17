﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTfull.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TestCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FIO = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 127, nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", maxLength: 127, nullable: false),
                    TeacherId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Group = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StudyUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClassId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendings_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendings_Users_StudyUserId",
                        column: x => x.StudyUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendings_ClassId",
                table: "Attendings",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendings_StudyUserId",
                table: "Attendings",
                column: "StudyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Group_Start",
                table: "Classes",
                columns: new[] { "Group", "Start" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_TeacherId_Start",
                table: "Classes",
                columns: new[] { "TeacherId", "Start" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendings");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

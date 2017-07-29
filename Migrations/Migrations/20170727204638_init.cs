using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Migrations.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn("Name","User","Login");
            migrationBuilder.DropColumn("Age", "User");
            migrationBuilder.AddColumn<string>("Password", "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

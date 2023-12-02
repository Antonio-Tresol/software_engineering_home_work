using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForestWebApp.Migrations;

/// <inheritdoc />
public partial class forest : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Forest",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                CountryOfOrigin = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                TypeOfVegetation = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                AreaKm2 = table.Column<int>(type: "int", nullable: false),
                OldGrowthForest = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_Forest", x => x.Id); });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Forest");
    }
}
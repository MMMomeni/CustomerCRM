using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerCRM.Infrastructure.Migrations
{
    public partial class CustomerTableModifiedRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Varchar(30)", nullable: false),
                    Title = table.Column<string>(type: "Varchar(30)", nullable: false),
                    Address = table.Column<string>(type: "Varchar(80)", nullable: false),
                    City = table.Column<string>(type: "Varchar(20)", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "Varchar(20)", nullable: false),
                    Phone = table.Column<string>(type: "Varchar(15)", nullable: false),
                    Photo = table.Column<string>(type: "Varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_RegionId",
                table: "Customer",
                column: "RegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMarkReport.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_l1 = table.Column<int>(nullable: false),
                    id_l2 = table.Column<int>(nullable: false),
                    id_sublayer1 = table.Column<int>(nullable: false),
                    id_technology_card = table.Column<int>(nullable: false),
                    technology_card_name = table.Column<string>(nullable: true),
                    id_subcontractor = table.Column<int>(nullable: false),
                    subcontractor_name = table.Column<string>(nullable: true),
                    id_status = table.Column<int>(nullable: false),
                    lag_days_count = table.Column<int>(nullable: false),
                    accept_quantity = table.Column<int>(nullable: false),
                    dev_count = table.Column<int>(nullable: false),
                    id_employee = table.Column<int>(nullable: false),
                    call_count = table.Column<int>(nullable: false),
                    is_have_ct3 = table.Column<bool>(nullable: false),
                    is_only_ct3 = table.Column<bool>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    datev2 = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Structures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_l1 = table.Column<int>(nullable: false),
                    id_l2 = table.Column<int>(nullable: false),
                    id_sublayer1 = table.Column<int>(nullable: false),
                    l1_name = table.Column<string>(nullable: true),
                    l2_name = table.Column<string>(nullable: true),
                    sublayer1_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Structures", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Structures");
        }
    }
}

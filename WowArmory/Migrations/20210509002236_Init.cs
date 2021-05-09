using Microsoft.EntityFrameworkCore.Migrations;

namespace WowArmory.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    classid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    c_name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    c_color = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    c_icon = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.classid);
                });

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    levelid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    level1 = table.Column<int>(type: "int", nullable: true),
                    level2 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.levelid);
                });

            migrationBuilder.CreateTable(
                name: "Profession",
                columns: table => new
                {
                    professionid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    p_name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    i_icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profession", x => x.professionid);
                });

            migrationBuilder.CreateTable(
                name: "Source",
                columns: table => new
                {
                    sourceid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    s_category = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    s_name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    s_faction = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    s_cost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Source", x => x.sourceid);
                });

            migrationBuilder.CreateTable(
                name: "Talent",
                columns: table => new
                {
                    talentid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    t_name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talent", x => x.talentid);
                });

            migrationBuilder.CreateTable(
                name: "Spec",
                columns: table => new
                {
                    specid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    s_name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    s_icon = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ClassModelClassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spec", x => x.specid);
                    table.ForeignKey(
                        name: "FK_Spec_Class_ClassModelClassId",
                        column: x => x.ClassModelClassId,
                        principalTable: "Class",
                        principalColumn: "classid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zone",
                columns: table => new
                {
                    zoneid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    z_name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    z_category = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    z_territory = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LevelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.zoneid);
                    table.ForeignKey(
                        name: "FK_Zone_Level_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Level",
                        principalColumn: "levelid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Data",
                columns: table => new
                {
                    dataid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemid = table.Column<int>(type: "int", nullable: false),
                    d_name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    d_icon = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    d_class = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    d_subclass = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    d_sellprice = table.Column<int>(type: "int", nullable: false),
                    d_quality = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    d_itemlevel = table.Column<int>(type: "int", nullable: false),
                    d_requiredlevel = table.Column<int>(type: "int", nullable: false),
                    d_slot = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    d_vendorprice = table.Column<int>(type: "int", nullable: false),
                    SourceId = table.Column<int>(type: "int", nullable: true),
                    d_uniquename = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    d_contentphase = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Data", x => x.dataid);
                    table.ForeignKey(
                        name: "FK_Data_Source_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Source",
                        principalColumn: "sourceid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quest",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    questid = table.Column<int>(type: "int", nullable: false),
                    q_name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    q_faction = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SourceModelSourceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quest", x => x.id);
                    table.ForeignKey(
                        name: "FK_Quest_Source_SourceModelSourceId",
                        column: x => x.SourceModelSourceId,
                        principalTable: "Source",
                        principalColumn: "sourceid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tooltip",
                columns: table => new
                {
                    tooltipid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    t_label = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    t_format = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DataModelDataId = table.Column<int>(type: "int", nullable: true),
                    TalentModelTalentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tooltip", x => x.tooltipid);
                    table.ForeignKey(
                        name: "FK_Tooltip_Data_DataModelDataId",
                        column: x => x.DataModelDataId,
                        principalTable: "Data",
                        principalColumn: "dataid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tooltip_Talent_TalentModelTalentId",
                        column: x => x.TalentModelTalentId,
                        principalTable: "Talent",
                        principalColumn: "talentid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Data_SourceId",
                table: "Data",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Quest_SourceModelSourceId",
                table: "Quest",
                column: "SourceModelSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Spec_ClassModelClassId",
                table: "Spec",
                column: "ClassModelClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Tooltip_DataModelDataId",
                table: "Tooltip",
                column: "DataModelDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Tooltip_TalentModelTalentId",
                table: "Tooltip",
                column: "TalentModelTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_Zone_LevelId",
                table: "Zone",
                column: "LevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profession");

            migrationBuilder.DropTable(
                name: "Quest");

            migrationBuilder.DropTable(
                name: "Spec");

            migrationBuilder.DropTable(
                name: "Tooltip");

            migrationBuilder.DropTable(
                name: "Zone");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Data");

            migrationBuilder.DropTable(
                name: "Talent");

            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.DropTable(
                name: "Source");
        }
    }
}

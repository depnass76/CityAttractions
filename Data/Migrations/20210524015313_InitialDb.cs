using Microsoft.EntityFrameworkCore.Migrations;

namespace CityAttractions.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    rId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    latitude = table.Column<double>(nullable: false),
                    longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.rId);
                });

            migrationBuilder.CreateTable(
                name: "Medium",
                columns: table => new
                {
                    rId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(nullable: true),
                    width = table.Column<int>(nullable: false),
                    height = table.Column<int>(nullable: false),
                    bytes = table.Column<int>(nullable: false),
                    format = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medium", x => x.rId);
                });

            migrationBuilder.CreateTable(
                name: "Original",
                columns: table => new
                {
                    rId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(nullable: true),
                    width = table.Column<int>(nullable: false),
                    height = table.Column<int>(nullable: false),
                    bytes = table.Column<int>(nullable: false),
                    format = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Original", x => x.rId);
                });

            migrationBuilder.CreateTable(
                name: "root",
                columns: table => new
                {
                    rId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    more = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_root", x => x.rId);
                });

            migrationBuilder.CreateTable(
                name: "Thumbnail",
                columns: table => new
                {
                    rId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(nullable: true),
                    width = table.Column<int>(nullable: false),
                    height = table.Column<int>(nullable: false),
                    bytes = table.Column<int>(nullable: false),
                    format = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thumbnail", x => x.rId);
                });

            migrationBuilder.CreateTable(
                name: "result",
                columns: table => new
                {
                    rId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<string>(nullable: true),
                    parent_id = table.Column<string>(nullable: true),
                    coordinatesrId = table.Column<int>(nullable: true),
                    score = table.Column<double>(nullable: false),
                    country_id = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    snippet = table.Column<string>(nullable: true),
                    RootrId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_result", x => x.rId);
                    table.ForeignKey(
                        name: "FK_result_root_RootrId",
                        column: x => x.RootrId,
                        principalTable: "root",
                        principalColumn: "rId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_result_Coordinates_coordinatesrId",
                        column: x => x.coordinatesrId,
                        principalTable: "Coordinates",
                        principalColumn: "rId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    rId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    originalrId = table.Column<int>(nullable: true),
                    mediumrId = table.Column<int>(nullable: true),
                    thumbnailrId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.rId);
                    table.ForeignKey(
                        name: "FK_Sizes_Medium_mediumrId",
                        column: x => x.mediumrId,
                        principalTable: "Medium",
                        principalColumn: "rId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sizes_Original_originalrId",
                        column: x => x.originalrId,
                        principalTable: "Original",
                        principalColumn: "rId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sizes_Thumbnail_thumbnailrId",
                        column: x => x.thumbnailrId,
                        principalTable: "Thumbnail",
                        principalColumn: "rId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attribution",
                columns: table => new
                {
                    rId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    format = table.Column<string>(nullable: true),
                    attribution_text = table.Column<string>(nullable: true),
                    attribution_link = table.Column<string>(nullable: true),
                    license_text = table.Column<string>(nullable: true),
                    license_link = table.Column<string>(nullable: true),
                    source_id = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    ResultrId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribution", x => x.rId);
                    table.ForeignKey(
                        name: "FK_Attribution_result_ResultrId",
                        column: x => x.ResultrId,
                        principalTable: "result",
                        principalColumn: "rId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "image",
                columns: table => new
                {
                    rId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    source_id = table.Column<string>(nullable: true),
                    source_url = table.Column<string>(nullable: true),
                    owner = table.Column<string>(nullable: true),
                    owner_url = table.Column<string>(nullable: true),
                    license = table.Column<string>(nullable: true),
                    caption = table.Column<string>(nullable: true),
                    attributionrId = table.Column<int>(nullable: true),
                    sizesrId = table.Column<int>(nullable: true),
                    ResultrId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_image", x => x.rId);
                    table.ForeignKey(
                        name: "FK_image_result_ResultrId",
                        column: x => x.ResultrId,
                        principalTable: "result",
                        principalColumn: "rId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_image_Attribution_attributionrId",
                        column: x => x.attributionrId,
                        principalTable: "Attribution",
                        principalColumn: "rId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_image_Sizes_sizesrId",
                        column: x => x.sizesrId,
                        principalTable: "Sizes",
                        principalColumn: "rId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attribution_ResultrId",
                table: "Attribution",
                column: "ResultrId");

            migrationBuilder.CreateIndex(
                name: "IX_image_ResultrId",
                table: "image",
                column: "ResultrId");

            migrationBuilder.CreateIndex(
                name: "IX_image_attributionrId",
                table: "image",
                column: "attributionrId");

            migrationBuilder.CreateIndex(
                name: "IX_image_sizesrId",
                table: "image",
                column: "sizesrId");

            migrationBuilder.CreateIndex(
                name: "IX_result_RootrId",
                table: "result",
                column: "RootrId");

            migrationBuilder.CreateIndex(
                name: "IX_result_coordinatesrId",
                table: "result",
                column: "coordinatesrId");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_mediumrId",
                table: "Sizes",
                column: "mediumrId");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_originalrId",
                table: "Sizes",
                column: "originalrId");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_thumbnailrId",
                table: "Sizes",
                column: "thumbnailrId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "image");

            migrationBuilder.DropTable(
                name: "Attribution");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "result");

            migrationBuilder.DropTable(
                name: "Medium");

            migrationBuilder.DropTable(
                name: "Original");

            migrationBuilder.DropTable(
                name: "Thumbnail");

            migrationBuilder.DropTable(
                name: "root");

            migrationBuilder.DropTable(
                name: "Coordinates");
        }
    }
}

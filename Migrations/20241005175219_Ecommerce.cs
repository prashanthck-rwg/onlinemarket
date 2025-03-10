using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShoping.Migrations
{
    /// <inheritdoc />
    public partial class Ecommerce : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    disc_int_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    disc_str_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    disc_mny_price = table.Column<decimal>(type: "money", nullable: false),
                    disc_created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.disc_int_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    usr_int_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usr_str_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usr_str_pwd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usr_username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usr_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usr_phnumber_id = table.Column<int>(type: "int", nullable: false),
                    usr_create_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.usr_int_id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Prod_int_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prod_str_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prod_mny_Price = table.Column<decimal>(type: "money", nullable: false),
                    Prod_int_DiscId = table.Column<int>(type: "int", nullable: false),
                    Prod_Created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())"),
                    Prod_Modified_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Prod_int_ID);
                    table.ForeignKey(
                        name: "FK_Products_Discounts_Prod_int_DiscId",
                        column: x => x.Prod_int_DiscId,
                        principalTable: "Discounts",
                        principalColumn: "disc_int_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    crt_int_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    crt_int_usrid = table.Column<int>(type: "int", nullable: false),
                    crt_int_prod_id = table.Column<int>(type: "int", nullable: false),
                    crt_int_quanty = table.Column<int>(type: "int", nullable: false),
                    crt_total = table.Column<decimal>(type: "money", nullable: false),
                    crt_create_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.crt_int_Id);
                    table.ForeignKey(
                        name: "FK_Cart_Products_crt_int_prod_id",
                        column: x => x.crt_int_prod_id,
                        principalTable: "Products",
                        principalColumn: "Prod_int_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_Users_crt_int_usrid",
                        column: x => x.crt_int_usrid,
                        principalTable: "Users",
                        principalColumn: "usr_int_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orderdetails",
                columns: table => new
                {
                    ordetail_int_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ordetail_user_id = table.Column<int>(type: "int", nullable: false),
                    ordetail_int_total = table.Column<decimal>(type: "money", nullable: false),
                    ordetail_int_pmdid = table.Column<int>(type: "int", nullable: false),
                    ordetail_created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())"),
                    ordetail_modified_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderdetails", x => x.ordetail_int_id);
                    table.ForeignKey(
                        name: "FK_Orderdetails_Users_ordetail_user_id",
                        column: x => x.ordetail_user_id,
                        principalTable: "Users",
                        principalColumn: "usr_int_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orderitems",
                columns: table => new
                {
                    ord_int_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ord_int_orderdetailid = table.Column<int>(type: "int", nullable: false),
                    ord_product_id = table.Column<int>(type: "int", nullable: false),
                    ord_created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())"),
                    ord_modified_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderitems", x => x.ord_int_id);
                    table.ForeignKey(
                        name: "FK_Orderitems_Orderdetails_ord_int_orderdetailid",
                        column: x => x.ord_int_orderdetailid,
                        principalTable: "Orderdetails",
                        principalColumn: "ordetail_int_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orderitems_Products_ord_product_id",
                        column: x => x.ord_product_id,
                        principalTable: "Products",
                        principalColumn: "Prod_int_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paymentdetails",
                columns: table => new
                {
                    pmd_int_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pmd_int_orderid = table.Column<int>(type: "int", nullable: false),
                    pmd_mny_amount = table.Column<decimal>(type: "money", nullable: false),
                    pmd_str_status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pmd_created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())"),
                    pmd_modified_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paymentdetails", x => x.pmd_int_id);
                    table.ForeignKey(
                        name: "FK_Paymentdetails_Orderdetails_pmd_int_orderid",
                        column: x => x.pmd_int_orderid,
                        principalTable: "Orderdetails",
                        principalColumn: "ordetail_int_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_crt_int_prod_id",
                table: "Cart",
                column: "crt_int_prod_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_crt_int_usrid",
                table: "Cart",
                column: "crt_int_usrid");

            migrationBuilder.CreateIndex(
                name: "IX_Orderdetails_ordetail_int_pmdid",
                table: "Orderdetails",
                column: "ordetail_int_pmdid");

            migrationBuilder.CreateIndex(
                name: "IX_Orderdetails_ordetail_user_id",
                table: "Orderdetails",
                column: "ordetail_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orderitems_ord_int_orderdetailid",
                table: "Orderitems",
                column: "ord_int_orderdetailid");

            migrationBuilder.CreateIndex(
                name: "IX_Orderitems_ord_product_id",
                table: "Orderitems",
                column: "ord_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Paymentdetails_pmd_int_orderid",
                table: "Paymentdetails",
                column: "pmd_int_orderid");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Prod_int_DiscId",
                table: "Products",
                column: "Prod_int_DiscId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderdetails_Paymentdetails_ordetail_int_pmdid",
                table: "Orderdetails",
                column: "ordetail_int_pmdid",
                principalTable: "Paymentdetails",
                principalColumn: "pmd_int_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orderdetails_Users_ordetail_user_id",
                table: "Orderdetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderdetails_Paymentdetails_ordetail_int_pmdid",
                table: "Orderdetails");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Orderitems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Paymentdetails");

            migrationBuilder.DropTable(
                name: "Orderdetails");
        }
    }
}

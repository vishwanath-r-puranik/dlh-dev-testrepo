using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TestPermitMicroAPI.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tp_test_permit",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tp_prmt_no = table.Column<string>(type: "character varying(17)", maxLength: 17, nullable: true),
                    tp_prmt_type_cd = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    tp_stat_cd = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    tp_cl_sex_cd = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    tp_nchrg_srv_flg = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    tp_sale_type_cd = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    tp_test_rslt_cd = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    tp_sale_blk_flg = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    tp_acc_pit = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    tp_defn_pit = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    tp_defn_mvid = table.Column<int>(type: "integer", nullable: false),
                    tp_upd_srv_tx_no = table.Column<string>(type: "character varying(17)", maxLength: 17, nullable: true),
                    tp_upd_reas_cd = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    tp_sale_defn_pit = table.Column<DateTime>(type: "timestamp without time zone", maxLength: 1, nullable: false),
                    tp_sale_defn_mvid = table.Column<int>(type: "integer", nullable: false),
                    tp_sale_srv_tx_no = table.Column<string>(type: "character varying(17)", maxLength: 17, nullable: true),
                    tp_sale_off_id = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    tp_prch_mvid = table.Column<int>(type: "integer", nullable: false),
                    tp_drx_id = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    tp_ocl_cd = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    tp_rslt_defn_pit = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    tp_rslt_defn_mvid = table.Column<int>(type: "integer", nullable: false),
                    tp_rslt_op_srv_tx_no = table.Column<string>(type: "character varying(17)", maxLength: 17, nullable: true),
                    tp_test_dt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    tp_cl_mvid = table.Column<int>(type: "integer", nullable: false),
                    tp_cl_dob = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    tp_cl_name = table.Column<string>(type: "character varying(47)", maxLength: 47, nullable: true),
                    tp_cl_city = table.Column<string>(type: "character varying(21)", maxLength: 21, nullable: true),
                    tp_cl_pcode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    tp_adv_road_test_ind = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tp_test_permit", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_tp_test_permit_tp_prmt_no",
                table: "tp_test_permit",
                column: "tp_prmt_no",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tp_test_permit");
        }
    }
}

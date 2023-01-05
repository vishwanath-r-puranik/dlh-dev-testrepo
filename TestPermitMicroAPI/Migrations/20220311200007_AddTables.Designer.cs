﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestPermitMicroAPI.Data;

namespace TestPermitMicroAPI.Migrations
{
    [DbContext(typeof(TestPermitMicroAPIContext))]
    [Migration("20220311200007_AddTables")]
    partial class AddTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("TestPermitMicroAPI.Models.TPTestPermit", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("AccPit")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("tp_acc_pit");

                    b.Property<string>("AdvRoadTestInd")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("tp_adv_road_test_ind");

                    b.Property<string>("CLCity")
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)")
                        .HasColumnName("tp_cl_city");

                    b.Property<DateTime>("CLDoB")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("tp_cl_dob");

                    b.Property<int>("CLMVID")
                        .HasColumnType("integer")
                        .HasColumnName("tp_cl_mvid");

                    b.Property<string>("CLName")
                        .HasMaxLength(47)
                        .HasColumnType("character varying(47)")
                        .HasColumnName("tp_cl_name");

                    b.Property<string>("CLPCode")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("tp_cl_pcode");

                    b.Property<string>("CLSexCD")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("tp_cl_sex_cd");

                    b.Property<int>("DefnMVID")
                        .HasColumnType("integer")
                        .HasColumnName("tp_defn_mvid");

                    b.Property<DateTime>("DefnPit")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("tp_defn_pit");

                    b.Property<string>("DrxID")
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("tp_drx_id");

                    b.Property<string>("NChrgSrvFlag")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("tp_nchrg_srv_flg");

                    b.Property<string>("OclCD")
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)")
                        .HasColumnName("tp_ocl_cd");

                    b.Property<int>("PrchMVID")
                        .HasColumnType("integer")
                        .HasColumnName("tp_prch_mvid");

                    b.Property<string>("PrmtNo")
                        .HasMaxLength(17)
                        .HasColumnType("character varying(17)")
                        .HasColumnName("tp_prmt_no");

                    b.Property<string>("PrmtTypeCD")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("tp_prmt_type_cd");

                    b.Property<int>("RsltDefnMVID")
                        .HasColumnType("integer")
                        .HasColumnName("tp_rslt_defn_mvid");

                    b.Property<DateTime>("RsltDefnPit")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("tp_rslt_defn_pit");

                    b.Property<string>("RsltOpSrvTxNo")
                        .HasMaxLength(17)
                        .HasColumnType("character varying(17)")
                        .HasColumnName("tp_rslt_op_srv_tx_no");

                    b.Property<string>("SaleBlkFlag")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("tp_sale_blk_flg");

                    b.Property<int>("SaleDefnMVID")
                        .HasColumnType("integer")
                        .HasColumnName("tp_sale_defn_mvid");

                    b.Property<DateTime>("SaleDefnPit")
                        .HasMaxLength(1)
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("tp_sale_defn_pit");

                    b.Property<string>("SaleOffID")
                        .HasMaxLength(4)
                        .HasColumnType("character varying(4)")
                        .HasColumnName("tp_sale_off_id");

                    b.Property<string>("SaleSrvTxNo")
                        .HasMaxLength(17)
                        .HasColumnType("character varying(17)")
                        .HasColumnName("tp_sale_srv_tx_no");

                    b.Property<string>("SaleTypeCD")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("tp_sale_type_cd");

                    b.Property<string>("StatCD")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("tp_stat_cd");

                    b.Property<DateTime>("TestDt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("tp_test_dt");

                    b.Property<string>("TestRstlCD")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("tp_test_rslt_cd");

                    b.Property<string>("UpdReasCD")
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("tp_upd_reas_cd");

                    b.Property<string>("UpdSrvTxNo")
                        .HasMaxLength(17)
                        .HasColumnType("character varying(17)")
                        .HasColumnName("tp_upd_srv_tx_no");

                    b.HasKey("ID")
                        .HasName("pk_tp_test_permit");

                    b.HasIndex("PrmtNo")
                        .IsUnique()
                        .HasDatabaseName("ix_tp_test_permit_tp_prmt_no");

                    b.ToTable("tp_test_permit");
                });
#pragma warning restore 612, 618
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestPermitMicroAPI.Models
{
    [Table("tp_test_permit")]
    [Index(nameof(PrmtNo), IsUnique = true)]
    public class TPTestPermit
    {

        public int ID { get; set; }

        [Column("tp_prmt_no")]
        [MaxLength(17)]
        public string PrmtNo { get; set; }

        [Column("tp_prmt_type_cd")]
        [MaxLength(1)]
        public string PrmtTypeCD { get; set; }

        [Column("tp_stat_cd")]
        [MaxLength(1)]
        public string StatCD { get; set; }

        [Column("tp_cl_sex_cd")]
        [MaxLength(1)]
        public string CLSexCD { get; set; }

        [Column("tp_nchrg_srv_flg")]
        [MaxLength(1)]
        public string NChrgSrvFlag { get; set; }

        [Column("tp_sale_type_cd")]
        [MaxLength(1)]
        public string SaleTypeCD { get; set; }

        [Column("tp_test_rslt_cd")]
        [MaxLength(1)]
        public string TestRstlCD { get; set; }

        [Column("tp_sale_blk_flg")]
        [MaxLength(1)]
        public string SaleBlkFlag { get; set; }

        [Column("tp_acc_pit")]
        public DateTime AccPit { get; set; }

        [Column("tp_defn_pit")]
        public DateTime DefnPit { get; set; }

        [Column("tp_defn_mvid")]
        public int DefnMVID { get; set; }

        [Column("tp_upd_srv_tx_no")]
        [MaxLength(17)]
        public string UpdSrvTxNo { get; set; }

        [Column("tp_upd_reas_cd")]
        [MaxLength(25)]
        public string UpdReasCD { get; set; }

        [Column("tp_sale_defn_pit")]
        [MaxLength(1)]
        public DateTime SaleDefnPit { get; set; }

        [Column("tp_sale_defn_mvid")]
        public int SaleDefnMVID { get; set; }

        [Column("tp_sale_srv_tx_no")]
        [MaxLength(17)]
        public string SaleSrvTxNo { get; set; }

        [Column("tp_sale_off_id")]
        [MaxLength(4)]
        public string SaleOffID { get; set; }

        [Column("tp_prch_mvid")]
        public int PrchMVID { get; set; }

        [Column("tp_drx_id")]
        [MaxLength(5)]
        public string DrxID { get; set; }

        [Column("tp_ocl_cd")]
        [MaxLength(8)]
        public string OclCD { get; set; }

        [Column("tp_rslt_defn_pit")]
        public DateTime RsltDefnPit { get; set; }

        [Column("tp_rslt_defn_mvid")]
        public int RsltDefnMVID { get; set; }

        [Column("tp_rslt_op_srv_tx_no")]
        [MaxLength(17)]
        public string RsltOpSrvTxNo { get; set; }

        [Column("tp_test_dt")]
        public DateTime TestDt { get; set; }

        [Column("tp_cl_mvid")]
        public int CLMVID { get; set; }

        [Column("tp_cl_dob")]
        public DateTime CLDoB { get; set; }

        [Column("tp_cl_name")]
        [MaxLength(47)]
        public string CLName { get; set; }

        [Column("tp_cl_city")]
        [MaxLength(21)]
        public string CLCity { get; set; }

        [Column("tp_cl_pcode")]
        [MaxLength(10)]
        public string CLPCode { get; set; }

        [Column("tp_adv_road_test_ind")]
        [MaxLength(1)]
        public string AdvRoadTestInd { get; set; }
    }
}

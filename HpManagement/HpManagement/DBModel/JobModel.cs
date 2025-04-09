namespace HpManagement.DBModel
{
    /// <summary>
    /// 환자이송 호출 I/F 테이블
    /// </summary>
    public class JobModel
    {
        public DateTime? CALLDATE { get; set; }
        public string? CALLDEPT { get; set; }
        public string? CALLID { get; set; }
        public string? GUBUN { get; set; }
        public string? OBJNO { get; set; }
        public string? OBJNAME { get; set; }
        public int SEQNO { get; set; }
        public string? FROMDEPT { get; set; }
        public string? FROMDEPTNM { get; set; }
        public string? FROMLOC { get; set; }
        public string? TODEPT { get; set; }
        public string? TODEPTNM { get; set; }
        public string? TOLOC { get; set; }
        public string? ORDCD { get; set; }
        public string? ORDNAME { get; set; }
        public string? ETCMEMO { get; set; }
        public string? JOBTP { get; set; }
        public string? VEHICLECD { get; set; }
        public string? PROCSTAT { get; set; }
        public DateTime? RSVTIME { get; set; }
        public DateTime? CALLTIME { get; set; }
        public DateTime? ASSIGNTIME { get; set; }
        public DateTime? ASCOFMTIME { get; set; }
        public string? AGENTID { get; set; }
        public DateTime? STARTTIME { get; set; }
        public DateTime? ENDTIME { get; set; }
        public DateTime? ACCTIME { get; set; }
        public DateTime? CANTIME { get; set; }
        public string? CANCOMMENT { get; set; }
        public int? DELAYTIME { get; set; }
        public string? DELAYCD { get; set; }
        public string? REGID { get; set; }
        public DateTime? REGTIME { get; set; }
        public string? EDITID { get; set; }
        public DateTime? EDITTIME { get; set; }
        public string? JOBTPKEY { get; set; }
        public string? COMOBJ { get; set; }
        public string? COMOBJCOMMENT { get; set; }
        public string? CAUT { get; set; }
        public string? CAUTCOMMENT { get; set; }
        public string? RETURNOBJ { get; set; }
        public string? RETURNOBJCOMMENT { get; set; }
        public DateTime? ASSTIME { get; set; }
        public DateTime? UPDATEDT { get; set; }
        public string? JOBFLAG { get; set; }
        public string? RESVTP { get; set; }
        public
    }
}

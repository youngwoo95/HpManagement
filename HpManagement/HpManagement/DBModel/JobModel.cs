namespace HpManagement.DBModel
{
    /// <summary>
    /// 환자이송 호출 I/F 테이블
    /// </summary>
    public class JobModel
    {
        /// <summary>
        /// 호출일자
        /// </summary>
        public DateOnly? CALLDATE { get; set; }

        /// <summary>
        /// 호출부서
        /// </summary>
        public string? CALLDEPT { get; set; }

        /// <summary>
        /// 호출자ID
        /// </summary>
        public string? CALLID { get; set; }

        /// <summary>
        /// 업무구분
        /// </summary>
        public string? GUBUN { get; set; }

        /// <summary>
        /// 환자번호
        /// </summary>
        public string? OBJNO { get; set; }

        /// <summary>
        /// 환자명
        /// </summary>
        public string? OBJNAME { get; set; }

        /// <summary>
        /// 순번
        /// </summary>
        public int? SEQNO { get; set; }

        /// <summary>
        /// 출발부서코드
        /// </summary>
        public string? FROMDEPT { get; set; }

        /// <summary>
        /// 출발부서명
        /// </summary>
        public string? FROMDEPTNM { get; set; }

        /// <summary>
        /// 출발호실
        /// </summary>
        public string? FROMLOC { get; set; }

        /// <summary>
        /// 도착부서코드
        /// </summary>
        public string? TODEPT { get; set; }

        /// <summary>
        /// 도착부서명
        /// </summary>
        public string? TODEPTNM { get; set; }

        /// <summary>
        /// 도착호실
        /// </summary>
        public string? TOLOC { get; set; }

        /// <summary>
        /// 처방코드
        /// </summary>
        public string? ORDCD { get; set; }

        /// <summary>
        /// 처방명
        /// </summary>
        public string? ORDNAME { get; set; }
        
        /// <summary>
        /// 기타(특이)사항
        /// </summary>
        public string? ETCMEMO { get; set; }

        /// <summary>
        /// 이송업무구분
        /// </summary>
        public string? JOBTP { get; set; }

        /// <summary>
        /// 이송수단
        /// </summary>
        public string? VEHICLECD { get; set; }

        /// <summary>
        /// 현재상태
        /// </summary>
        public string? PROCSTAT { get; set; }

        /// <summary>
        /// 예약시간
        /// </summary>
        public DateTime? RSVTIME { get; set; }

        /// <summary>
        /// 호출시간
        /// </summary>
        public DateTime? CALLTIME { get; set; }

        /// <summary>
        /// 도착예정시간
        /// </summary>
        public DateTime? ASSIGNTIME { get; set; }

        /// <summary>
        /// 완료예정시간
        /// </summary>
        public DateTime? ASCOFMTIME { get; set; }

        /// <summary>
        /// 이송요원ID
        /// </summary>
        public string? AGENTID { get; set; }

        /// <summary>
        /// 시작시간
        /// </summary>
        public DateTime? STARTTIME { get; set; }

        /// <summary>
        /// 종료시간
        /// </summary>
        public DateTime? ENDTIME { get; set; }

        /// <summary>
        /// 이송요원 접수시간
        /// </summary>
        public DateTime? ACCTIME { get; set; }
        
        /// <summary>
        /// 취소시간
        /// </summary>
        public DateTime? CANTIME { get; set; }

        /// <summary>
        /// 취소사유
        /// </summary>
        public string? CANCOMMENT { get; set; }

        /// <summary>
        /// 지연시간
        /// </summary>
        public int? DELAYTIME { get; set; }

        /// <summary>
        /// 지연사유
        /// </summary>
        public string? DELAYCD { get; set; }

        /// <summary>
        /// 등록자
        /// </summary>
        public string? REGID { get; set; }

        /// <summary>
        /// 등록시간
        /// </summary>
        public DateTime? REGTIME { get; set; }

        /// <summary>
        /// 수정자
        /// </summary>
        public string? EDITID { get; set; }

        /// <summary>
        /// 수정시간
        /// </summary>
        public DateTime? EDITTIME { get; set; }

        /// <summary>
        /// 연계및묶음일때 KEY 값
        /// </summary>
        public string? JOBTPKEY { get; set; }

        /// <summary>
        /// 동반물품
        /// </summary>
        public string? COMOBJ { get; set; }

        /// <summary>
        /// 동반물품기타
        /// </summary>
        public string? COMOBJCOMMENT { get; set; }

        /// <summary>
        /// 주의사항
        /// </summary>
        public string? CAUT { get; set; }

        /// <summary>
        /// 주의사항 기타
        /// </summary>
        public string? CAUTCOMMENT { get; set; }
        
        /// <summary>
        /// 복귀물품
        /// </summary>
        public string? RETURNOBJ { get; set; }

        /// <summary>
        /// 복귀물품기타
        /// </summary>
        public string? RETURNOBJCOMMENT { get; set; }

        /// <summary>
        /// 배정시간
        /// </summary>
        public DateTime? ASSTIME { get; set; }

        /// <summary>
        /// 수정일자
        /// </summary>
        public DateTime? UPDATEDT { get; set; }


        public string? JOBFLAG { get; set; }

        /// <summary>
        /// 예약호출구분
        /// </summary>
        public string? RESVTP { get; set; }
        public int? ORESEQ { get; set; }
        public string? JOINYN { get; set; }
        public string? OXYMETHOD { get; set; }
        public string? OXYLM { get; set; }
        public string? AMBU { get; set; }
        public string? TRANSOBJ { get; set; }
        public string? TRANSOBJCOMMENT { get; set; }
        public string? MEDISTAFFYN { get; set; }
        public string? MEMO { get; set; }
    }
}

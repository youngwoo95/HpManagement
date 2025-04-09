/*M!999999\- enable the sandbox mode */ 
-- MariaDB dump 10.19  Distrib 10.6.21-MariaDB, for Win64 (AMD64)
--
-- Host: 192.168.10.76    Database: dsmc
-- ------------------------------------------------------
-- Server version	8.0.41

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `stss_admin`
--

DROP TABLE IF EXISTS `stss_admin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `stss_admin` (
  `USERID` varchar(15) COLLATE utf8mb4_general_ci NOT NULL COMMENT '사용자ID',
  `PASSWD` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '패스워드',
  `USERNM` varchar(30) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '사용자명',
  `PHNNO` varchar(15) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '전화번호',
  `PERMISSION` varchar(2) COLLATE utf8mb4_general_ci DEFAULT 'X' COMMENT '관리자유형',
  `RDATE` date DEFAULT NULL COMMENT '등록일자',
  `CDATE` date DEFAULT NULL COMMENT '해지일자',
  `SECTOR` varchar(20) COLLATE utf8mb4_general_ci DEFAULT 'X' COMMENT '관리자',
  PRIMARY KEY (`USERID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='이송관리자';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stss_admin`
--

LOCK TABLES `stss_admin` WRITE;
/*!40000 ALTER TABLE `stss_admin` DISABLE KEYS */;
INSERT INTO `stss_admin` VALUES ('admin','e66860546f18cdbbcd86b35e18b525bffc67f772c650cedfe3ff7a0026fa1dee','용용이','010-0000-0000','M','2025-04-04','2025-04-08','adminStec');
/*!40000 ALTER TABLE `stss_admin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stss_agent`
--

DROP TABLE IF EXISTS `stss_agent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `stss_agent` (
  `AGENTID` varchar(15) COLLATE utf8mb4_general_ci NOT NULL COMMENT '사원번호',
  `PASSWD` varchar(15) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '패스워드',
  `AGENTNM` varchar(30) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '사원명',
  `PHNNO` varchar(15) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '전화번호',
  `PERMISSION` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '권한',
  `SHIFT` varchar(6) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '근무조',
  `START_TIME` varchar(4) COLLATE utf8mb4_general_ci DEFAULT '0000' COMMENT '등록시간',
  `END_TIME` varchar(4) COLLATE utf8mb4_general_ci DEFAULT '2359' COMMENT '종료시간',
  `RDATE` datetime DEFAULT NULL COMMENT '등록일',
  `CDATE` datetime DEFAULT NULL COMMENT '종료일',
  `ISWORK` varchar(1) COLLATE utf8mb4_general_ci DEFAULT 'N' COMMENT '현재상태',
  `STATUS` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '사용여부',
  `APPKEY` varchar(1000) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'AppKey',
  `REGU_YN` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `LAST_WORK` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '마지막JOB',
  `LAST_TIME` datetime DEFAULT NULL COMMENT '마지막JOBTIME',
  `LAST_LOC` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '마지막위치',
  `LAST_LOGIN_DT` datetime DEFAULT NULL COMMENT '마지막로그인시간',
  `SECTOR` varchar(2) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '근무지',
  `BIZTYPE` varchar(2) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '근무유형',
  `FIRST_LOGIN_DT` datetime DEFAULT NULL COMMENT '일별최초로그인시간',
  `LOGOUT_DT` datetime DEFAULT NULL COMMENT '로그아웃시간',
  PRIMARY KEY (`AGENTID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='이송요원정보';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stss_agent`
--

LOCK TABLES `stss_agent` WRITE;
/*!40000 ALTER TABLE `stss_agent` DISABLE KEYS */;
/*!40000 ALTER TABLE `stss_agent` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stss_agent_extime`
--

DROP TABLE IF EXISTS `stss_agent_extime`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `stss_agent_extime` (
  `RDATE` date NOT NULL COMMENT '근무일자',
  `AGENTID` varchar(20) COLLATE utf8mb4_general_ci NOT NULL COMMENT '사원ID',
  `ESTART_TIME` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '연장근무시작시간',
  `EEND_TIME` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '연장근무종료시간',
  PRIMARY KEY (`RDATE`,`AGENTID`) COMMENT '근무일자'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='이송요원연장근무정보';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stss_agent_extime`
--

LOCK TABLES `stss_agent_extime` WRITE;
/*!40000 ALTER TABLE `stss_agent_extime` DISABLE KEYS */;
/*!40000 ALTER TABLE `stss_agent_extime` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stss_agent_rest`
--

DROP TABLE IF EXISTS `stss_agent_rest`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `stss_agent_rest` (
  `RDATE` date DEFAULT NULL COMMENT '근무일자',
  `AGENTID` varchar(15) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '사원ID',
  `STARTTIME` datetime DEFAULT NULL COMMENT '휴식시작시간',
  `ENDTIME` datetime DEFAULT NULL COMMENT '휴식종료시간',
  `RESTCD` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '휴식코드'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='이송요원휴식정보';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stss_agent_rest`
--

LOCK TABLES `stss_agent_rest` WRITE;
/*!40000 ALTER TABLE `stss_agent_rest` DISABLE KEYS */;
/*!40000 ALTER TABLE `stss_agent_rest` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stss_ave`
--

DROP TABLE IF EXISTS `stss_ave`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `stss_ave` (
  `SEQ` int DEFAULT NULL COMMENT '순번',
  `SECTOR` varchar(2) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '섹터코드',
  `DEPTCD` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '부서코드',
  `USERID` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '등록자',
  `RDATE` date DEFAULT NULL COMMENT '등록일'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='집결지정보';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stss_ave`
--

LOCK TABLES `stss_ave` WRITE;
/*!40000 ALTER TABLE `stss_ave` DISABLE KEYS */;
/*!40000 ALTER TABLE `stss_ave` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stss_biztp`
--

DROP TABLE IF EXISTS `stss_biztp`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `stss_biztp` (
  `BIZTYPE` varchar(2) COLLATE utf8mb4_general_ci NOT NULL COMMENT '업무유형코드',
  `BIZNM` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '업무유형명',
  `AUTOACC` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '자동배정여부',
  `ORD` varchar(2) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '순번',
  `USERID` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '등록자',
  `RDATE` date DEFAULT NULL COMMENT '등록일'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='이송업무유형정보';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stss_biztp`
--

LOCK TABLES `stss_biztp` WRITE;
/*!40000 ALTER TABLE `stss_biztp` DISABLE KEYS */;
/*!40000 ALTER TABLE `stss_biztp` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stss_code`
--

DROP TABLE IF EXISTS `stss_code`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `stss_code` (
  `GRPCODE` varchar(6) COLLATE utf8mb4_general_ci NOT NULL COMMENT '그룹코드',
  `CODE` varchar(6) COLLATE utf8mb4_general_ci NOT NULL COMMENT '코드',
  `CODENM` varchar(30) COLLATE utf8mb4_general_ci NOT NULL COMMENT '코드명',
  `DESCRIPTION` varchar(200) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '코드설명',
  `ORD` varchar(6) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '순번',
  `STATUS` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '사용여부',
  `RDATE` date DEFAULT NULL COMMENT '등록일',
  PRIMARY KEY (`GRPCODE`,`CODE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='코드정보';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stss_code`
--

LOCK TABLES `stss_code` WRITE;
/*!40000 ALTER TABLE `stss_code` DISABLE KEYS */;
/*!40000 ALTER TABLE `stss_code` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stss_dept`
--

DROP TABLE IF EXISTS `stss_dept`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `stss_dept` (
  `DPRT_CD` varchar(6) COLLATE utf8mb4_general_ci NOT NULL COMMENT '부서코드',
  `STSS_DPRT_NM` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `KORN_DPRT_NM` varchar(200) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '부서명',
  `ABRV_DPRT_CD` varchar(6) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '약어부서코드',
  `PHNNO` varchar(15) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '연락처',
  `MDCR_GRP_DVSN_CD` varchar(10) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '조직구분코드',
  `LCDV_CD` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '건물코드',
  `FLOR_NO` varchar(10) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '층',
  `DRCN_CD` varchar(10) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '방향코드',
  `MCDP_SEQ` varchar(10) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '순번',
  `LAST_UPDT_DT` date DEFAULT NULL COMMENT '수정일',
  `USE_YN` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '사용여부',
  PRIMARY KEY (`DPRT_CD`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='부서정보';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stss_dept`
--

LOCK TABLES `stss_dept` WRITE;
/*!40000 ALTER TABLE `stss_dept` DISABLE KEYS */;
/*!40000 ALTER TABLE `stss_dept` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stss_dept_detail`
--

DROP TABLE IF EXISTS `stss_dept_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `stss_dept_detail` (
  `UP_DPRT_CD` varchar(6) COLLATE utf8mb4_general_ci NOT NULL COMMENT '상위부서코드',
  `MID_DPRT_CD` varchar(6) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '임시부서코드',
  `DPRT_CD` varchar(6) COLLATE utf8mb4_general_ci NOT NULL COMMENT '부서코드',
  `FROM_YN` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '출발지여부',
  `TO_YN` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '도착지여부',
  `SEQ` varchar(2) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '정렬순서',
  PRIMARY KEY (`UP_DPRT_CD`,`DPRT_CD`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='세부부서정보';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stss_dept_detail`
--

LOCK TABLES `stss_dept_detail` WRITE;
/*!40000 ALTER TABLE `stss_dept_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `stss_dept_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stss_dept_ex`
--

DROP TABLE IF EXISTS `stss_dept_ex`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `stss_dept_ex` (
  `SEQ` int DEFAULT NULL COMMENT '순번',
  `SECTOR` varchar(2) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '섹터코드',
  `DEPTCD` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '부서코드',
  `USERID` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '등록자',
  `RDATE` date DEFAULT NULL COMMENT '등록일'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='예외부서정보';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stss_dept_ex`
--

LOCK TABLES `stss_dept_ex` WRITE;
/*!40000 ALTER TABLE `stss_dept_ex` DISABLE KEYS */;
/*!40000 ALTER TABLE `stss_dept_ex` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stss_dist`
--

DROP TABLE IF EXISTS `stss_dist`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `stss_dist` (
  `FROMDEPT` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '출발지',
  `TODEPT` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '도착지',
  `LTIME` int DEFAULT NULL COMMENT '소요시간'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='부서간거리정보';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stss_dist`
--

LOCK TABLES `stss_dist` WRITE;
/*!40000 ALTER TABLE `stss_dist` DISABLE KEYS */;
/*!40000 ALTER TABLE `stss_dist` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stss_grpcode`
--

DROP TABLE IF EXISTS `stss_grpcode`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `stss_grpcode` (
  `GRPCODE` varchar(6) COLLATE utf8mb4_general_ci NOT NULL COMMENT '그룹코드',
  `GRPCODENM` varchar(30) COLLATE utf8mb4_general_ci NOT NULL COMMENT '그룹코드명',
  `STATUS` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '사용여부',
  `RDATE` date DEFAULT NULL COMMENT '등록일',
  PRIMARY KEY (`GRPCODE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='그룹코드정보';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stss_grpcode`
--

LOCK TABLES `stss_grpcode` WRITE;
/*!40000 ALTER TABLE `stss_grpcode` DISABLE KEYS */;
INSERT INTO `stss_grpcode` VALUES ('TC','테스트코드','Y','2025-04-08');
/*!40000 ALTER TABLE `stss_grpcode` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stss_holiday`
--

DROP TABLE IF EXISTS `stss_holiday`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `stss_holiday` (
  `DT` date NOT NULL COMMENT '휴일일자',
  `DT_DESC` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '휴일설명',
  `REG_DT` date DEFAULT NULL COMMENT '등록일자',
  `REG_ID` varchar(30) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '등록자'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='휴일정보';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stss_holiday`
--

LOCK TABLES `stss_holiday` WRITE;
/*!40000 ALTER TABLE `stss_holiday` DISABLE KEYS */;
/*!40000 ALTER TABLE `stss_holiday` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stss_job`
--

DROP TABLE IF EXISTS `stss_job`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `stss_job` (
  `CALLDATE` date DEFAULT NULL COMMENT '호출일자',
  `CALLDEPT` varchar(6) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '호출부서',
  `CALLID` varchar(15) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '호출자ID',
  `GUBUN` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '업무구분',
  `OBJNO` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '환자번호',
  `OBJNAME` varchar(40) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '환자명',
  `SEQNO` int DEFAULT NULL COMMENT '순번',
  `FROMDEPT` varchar(6) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '출발부서코드',
  `FROMDEPTNM` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '출발부서명',
  `FROMLOC` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '출발호실',
  `TODEPT` varchar(6) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '도착부서코드',
  `TODEPTNM` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '도착부서명',
  `TOLOC` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '도착호실',
  `ORDCD` varchar(40) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '처방코드',
  `ORDNAME` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '처방명',
  `ETCMEMO` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '기타(특이)사항',
  `JOBTP` varchar(2) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '이송업무구분',
  `VEHICLECD` varchar(10) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '이동수단',
  `PROCSTAT` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '현재상태',
  `RSVTIME` datetime DEFAULT NULL COMMENT '예약시간',
  `CALLTIME` datetime DEFAULT NULL COMMENT '호출시간',
  `ASSIGNTIME` datetime DEFAULT NULL COMMENT '도착예정시간',
  `ASCOFMTIME` datetime DEFAULT NULL COMMENT '완료예정시간',
  `AGENTID` varchar(30) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '이송요원ID',
  `STARTTIME` datetime DEFAULT NULL COMMENT '시작시간',
  `ENDTIME` datetime DEFAULT NULL COMMENT '종료시간',
  `ACCTIME` datetime DEFAULT NULL COMMENT '이송요원접수시간',
  `CANTIME` datetime DEFAULT NULL COMMENT '취소시간',
  `CANCOMMENT` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '취소사유',
  `DELAYTIME` int DEFAULT NULL COMMENT '지연시간',
  `DELAYCD` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '지연사유',
  `REGID` varchar(6) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '등록자',
  `REGTIME` datetime DEFAULT NULL COMMENT '등록시간',
  `EDITID` varchar(6) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '수정자',
  `EDITTIME` datetime DEFAULT NULL COMMENT '수정시간',
  `JOBTPKEY` varchar(30) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '연계및묶음일때KEY값',
  `COMOBJ` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '동반물품',
  `COMOBJCOMMENT` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '동반물품기타',
  `CAUT` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '주의사항',
  `CAUTCOMMENT` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '주의사항기타',
  `RETURNOBJ` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '복귀물품',
  `RETURNOBJCOMMENT` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '복귀물품기타',
  `ASSTIME` datetime DEFAULT NULL COMMENT '배정시간',
  `UPDATEDT` datetime DEFAULT NULL COMMENT '수정일자',
  `JOBFLAG` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `RESVTP` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '예약호출구분',
  `ORDSEQ` int DEFAULT NULL,
  `JOINYN` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `OXYMETHOD` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `OXYLM` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `AMBU` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `TRANSOBJ` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `TRANSOBJCOMMENT` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `MEDISTAFFYN` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `MEMO` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='환자이송 호출 I/F 테이블';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stss_job`
--

LOCK TABLES `stss_job` WRITE;
/*!40000 ALTER TABLE `stss_job` DISABLE KEYS */;
/*!40000 ALTER TABLE `stss_job` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stss_job_wait`
--

DROP TABLE IF EXISTS `stss_job_wait`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `stss_job_wait` (
  `JOBKEY` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'STSS_JOB_ROWID',
  `WAIT_CD` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '대기코드',
  `START_TIME` datetime DEFAULT NULL COMMENT '대기시작시간',
  `END_TIME` datetime DEFAULT NULL COMMENT '대기종료시간'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='이송대기정보';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stss_job_wait`
--

LOCK TABLES `stss_job_wait` WRITE;
/*!40000 ALTER TABLE `stss_job_wait` DISABLE KEYS */;
/*!40000 ALTER TABLE `stss_job_wait` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stss_notice`
--

DROP TABLE IF EXISTS `stss_notice`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `stss_notice` (
  `IDX` int NOT NULL COMMENT '색인번호',
  `FLAG` varchar(1) COLLATE utf8mb4_general_ci NOT NULL COMMENT '우선순위',
  `TITLE` varchar(200) COLLATE utf8mb4_general_ci NOT NULL COMMENT '제목',
  `CONTENTS` varchar(4000) COLLATE utf8mb4_general_ci NOT NULL COMMENT '내용',
  `CDATE` datetime DEFAULT NULL COMMENT '등록일자',
  `USERID` varchar(30) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '작성자',
  PRIMARY KEY (`IDX`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='공지사항';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stss_notice`
--

LOCK TABLES `stss_notice` WRITE;
/*!40000 ALTER TABLE `stss_notice` DISABLE KEYS */;
INSERT INTO `stss_notice` VALUES (1,'1','공지사항테스트','123','2025-04-08 16:57:23','admin'),(2,'2','일반게시테스트','일반테스트','2025-04-08 16:57:48','admin');
/*!40000 ALTER TABLE `stss_notice` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stss_ordcd`
--

DROP TABLE IF EXISTS `stss_ordcd`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `stss_ordcd` (
  `ORD_CD` varchar(20) COLLATE utf8mb4_general_ci NOT NULL COMMENT '처방코드',
  `ORD_NM` varchar(20) COLLATE utf8mb4_general_ci NOT NULL COMMENT '처방명',
  `ORD_SEQ` int DEFAULT NULL COMMENT '업무우선순위',
  `STATUS` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '사용여부',
  `RDATE` date DEFAULT NULL COMMENT '등록일',
  PRIMARY KEY (`ORD_CD`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='처방정보';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stss_ordcd`
--

LOCK TABLES `stss_ordcd` WRITE;
/*!40000 ALTER TABLE `stss_ordcd` DISABLE KEYS */;
/*!40000 ALTER TABLE `stss_ordcd` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stss_schedule_agent`
--

DROP TABLE IF EXISTS `stss_schedule_agent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `stss_schedule_agent` (
  `SCHD_DATE` date NOT NULL COMMENT '근무일',
  `AGENTID` varchar(15) COLLATE utf8mb4_general_ci NOT NULL COMMENT '사원ID',
  `START_TIME` varchar(4) COLLATE utf8mb4_general_ci NOT NULL COMMENT '시작시간(0:음력, 1:양력)',
  `END_TIME` varchar(4) COLLATE utf8mb4_general_ci NOT NULL COMMENT '종료시간',
  `SHIFT` varchar(6) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '근무조',
  `REGID` varchar(6) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '등록자',
  `REGTIME` datetime DEFAULT NULL COMMENT '등록시간',
  `EDITID` varchar(6) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '수정자',
  `EDITTIME` datetime DEFAULT NULL COMMENT '수정시간',
  `CONT_START_YN` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `CONT_END_YN` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='이송요원 근무정보';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stss_schedule_agent`
--

LOCK TABLES `stss_schedule_agent` WRITE;
/*!40000 ALTER TABLE `stss_schedule_agent` DISABLE KEYS */;
/*!40000 ALTER TABLE `stss_schedule_agent` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stss_schedule_shift`
--

DROP TABLE IF EXISTS `stss_schedule_shift`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `stss_schedule_shift` (
  `SCHD_DATE` date NOT NULL COMMENT '근무일',
  `SHIFT` varchar(6) COLLATE utf8mb4_general_ci NOT NULL COMMENT '근무조',
  `TIME_TP` varchar(2) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '근무시간구분',
  `START_TIME` varchar(4) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '시작시간',
  `END_TIME` varchar(4) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '종료시간'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='조별 근무 정보';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stss_schedule_shift`
--

LOCK TABLES `stss_schedule_shift` WRITE;
/*!40000 ALTER TABLE `stss_schedule_shift` DISABLE KEYS */;
/*!40000 ALTER TABLE `stss_schedule_shift` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stss_smshistory`
--

DROP TABLE IF EXISTS `stss_smshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `stss_smshistory` (
  `CALLDEPT` varchar(6) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '호출부서',
  `PCMP_MSG_ID` varchar(17) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '원본SMS메시지ID',
  `CALLTIME` varchar(14) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '호출시각',
  `ENDTIME` varchar(14) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '완료일시',
  `FROMDEPT` varchar(6) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'FROM부서',
  `RSVPHNNO` varchar(15) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '수신번호',
  `FROMDEPTNM` varchar(40) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'FROM부서명',
  `MSG` varchar(2000) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '내용',
  `RECALLYN` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '재호출여부',
  `SENTYN` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '발송성공여부',
  `GUBUN` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '이송업무구분',
  `CMP_MSG_ID` varchar(17) COLLATE utf8mb4_general_ci NOT NULL COMMENT '메시지',
  `REQUEST_YN` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL,
  PRIMARY KEY (`CMP_MSG_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='SMS발송내역';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stss_smshistory`
--

LOCK TABLES `stss_smshistory` WRITE;
/*!40000 ALTER TABLE `stss_smshistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `stss_smshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stss_sys_config`
--

DROP TABLE IF EXISTS `stss_sys_config`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `stss_sys_config` (
  `AAUTOFLAG` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '자동배정여부',
  `SAME_FLO_TIME` int DEFAULT NULL COMMENT '임시(동일층)',
  `ELE_TIME` int DEFAULT NULL COMMENT '임시(엘리베이터)',
  `ELE_A_TIME` int DEFAULT NULL COMMENT '임시(집결지엘리베이터근처)',
  `G_TIME` int DEFAULT NULL COMMENT '임시(집결지)',
  `BET_TIME` int DEFAULT NULL COMMENT '건물간이동시간',
  `WORK_RR` int DEFAULT NULL COMMENT '이송수단 요율(걸어서)',
  `BED_RR` int DEFAULT NULL COMMENT '이송수단 요율(침대)',
  `MOV_RR` int DEFAULT NULL COMMENT '이송수단 요율(이동카)',
  `ETC_RR` int DEFAULT NULL COMMENT '이송수단 요율(기타)',
  `ACCTIME` int DEFAULT NULL COMMENT '미배정시간',
  `RESTIME` int DEFAULT NULL COMMENT '예약배정시간',
  `BTIME_RR` int DEFAULT NULL COMMENT '묶음배정 요율',
  `WH_RR` int DEFAULT NULL COMMENT '이송수단 요율(휠체어)',
  `MAUTOFLAG` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '임시',
  `RESV_TIME` int DEFAULT NULL COMMENT '예약가능시간',
  `MSG_CNT` int DEFAULT NULL COMMENT '메시지CNT',
  `SIGN` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '이송신호등(R:RED, Y:YELLOW, G:GREEN)'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='시스템설정정보';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stss_sys_config`
--

LOCK TABLES `stss_sys_config` WRITE;
/*!40000 ALTER TABLE `stss_sys_config` DISABLE KEYS */;
INSERT INTO `stss_sys_config` VALUES ('N',NULL,NULL,NULL,NULL,2,2,2,2,2,2,2,2,2,'1',2,2,'G');
/*!40000 ALTER TABLE `stss_sys_config` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stss_user`
--

DROP TABLE IF EXISTS `stss_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `stss_user` (
  `EMNO` varchar(15) COLLATE utf8mb4_general_ci NOT NULL COMMENT '사용자ID',
  `EMPY_NM` varchar(30) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '사용자명',
  `DPRT_CD` varchar(6) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '부서코드',
  `CMPN_TLNO` varchar(15) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '전화번호',
  `LAST_UPDT_DT` datetime DEFAULT NULL COMMENT '수정일자',
  `STATUS` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '사용여부',
  `PASSWD` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '패스워드',
  PRIMARY KEY (`EMNO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='사용자정보';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stss_user`
--

LOCK TABLES `stss_user` WRITE;
/*!40000 ALTER TABLE `stss_user` DISABLE KEYS */;
INSERT INTO `stss_user` VALUES ('admin','용용이','ABC',NULL,'2025-04-08 16:16:12','','e66860546f18cdbbcd86b35e18b525bffc67f772c650cedfe3ff7a0026fa1dee');
/*!40000 ALTER TABLE `stss_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stss_worktime`
--

DROP TABLE IF EXISTS `stss_worktime`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `stss_worktime` (
  `TIMETP` varchar(2) COLLATE utf8mb4_general_ci NOT NULL COMMENT '근무시간구분코드',
  `START_TIME` varchar(4) COLLATE utf8mb4_general_ci NOT NULL COMMENT '시작시간',
  `END_TIME` varchar(4) COLLATE utf8mb4_general_ci NOT NULL COMMENT '종료시간',
  `USERID` varchar(20) COLLATE utf8mb4_general_ci NOT NULL COMMENT '등록자',
  `RDATE` date NOT NULL COMMENT '등록일',
  PRIMARY KEY (`USERID`,`RDATE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='근무시간정보';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stss_worktime`
--

LOCK TABLES `stss_worktime` WRITE;
/*!40000 ALTER TABLE `stss_worktime` DISABLE KEYS */;
/*!40000 ALTER TABLE `stss_worktime` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-04-09 10:34:00

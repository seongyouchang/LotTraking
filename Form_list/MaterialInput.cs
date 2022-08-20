using Assamble;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Form_list
{
    public partial class Form04_SystemMaster : BaseChlidForm
    {
        /****************************************
         * NAME : Form04_SystemMaster
         * DESC : 자재 LOT
         * ---------------------------------------
         * DATE : 2022-08-13
         * DESC : 최한빈
         * **************************************/

        // 1. 공통 클래스 (데이터 베이스 커넥터)
        private SqlConnection Connect; // 데이터베이스에 접속 하는 정보를 관리하는 클래스.

        // 2. SELECT (조회)를 실행하여 데이터베이스에서 데이터를 받아오는 클래스.
        private SqlDataAdapter Adapter;

        // 3. Insert, Update, Delete 명령을 전달할 클래스
        private SqlTransaction tran; // 데이터베이스 데이터 관리 권한 부여.
        private SqlCommand cmd;      // 데이터베이스에 Insert, Update, Delete 명령을 전달할 클래스 
        public Form04_SystemMaster()
        {
            InitializeComponent();
        }




        private void Form04_SystemMaster_Load(object sender, EventArgs e)
        {
            /*****************기본 그리드 내역 셋팅 *******************/
            DataTable dtGrid = new DataTable();
            dtGrid.Columns.Add("inLotN", typeof(string));                        // inLot번호
            dtGrid.Columns.Add("iLStDate", typeof(DateTime));                 // 입고일자
            dtGrid.Columns.Add("iLOutDate", typeof(DateTime));               // 출고일자
            dtGrid.Columns.Add("iLAccount", typeof(string));                     // 거래처
            dtGrid.Columns.Add("iLRaw", typeof(string));                          // 원자재명



            // 빈 컬럼 테이블 그리드에 매칭. (DataSource : 테이블 형식의 데이터를 표현하는 속성)
            Grid2.DataSource = dtGrid;

            // 그리드 컬럼 명칭(Text) 설정 // 번호로 지정 가능
            Grid2.Columns["WID"].HeaderText = "작업지시번호";
            Grid2.Columns["WSTART"].HeaderText = "작업시작일";
            Grid2.Columns["WFINISH"].HeaderText = "작업종료일";
            Grid2.Columns["WPLAN"].HeaderText = "생산수량";
            Grid2.Columns["ILROW"].HeaderText = "필요원자재";
            Grid2.Columns["FSPACE"].HeaderText = "작업장";


            // 컬럼의 폭 지정
            Grid2.Columns["WID"].Width = 100;
            Grid2.Columns[1].Width = 200;
            Grid2.Columns[2].Width = 100;
            Grid2.Columns[3].Width = 150;
            Grid2.Columns[4].Width = 200;
            Grid2.Columns[5].Width = 100;

            //// 컬럼의 수정 여부를 지정
            //Grid1.Columns["MAKER"].ReadOnly = true;
            //Grid1.Columns["MAKEDATE"].ReadOnly = true;
            //Grid1.Columns["EDITOR"].ReadOnly = true;
            //Grid1.Columns["EDITDATE"].ReadOnly = true;
        }

        // 메서드 오버라이드 (Override)
        // virture로 상속을 허락 한 메서드를
        // 각 화면에 맞는 기능으로 변경하여 메서드를 재 정의하고 사용하는 방식.


        public bool DBHelper(bool Tran)
        {
            // 1. 데이터 베이스 접속
            Connect = new SqlConnection(Commons.cDbCon);

            // 2. 데이터 베이스 OPEN
            Connect.Open();
            if (Connect.State != ConnectionState.Open)
            {
                MessageBox.Show("데이터 베이스 연결에 실패하였습니다.");
                return false;
            }
            if (Tran) tran = Connect.BeginTransaction();
            return true;
        }


    }
}
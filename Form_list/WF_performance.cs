using Assamble;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


/************************************
 실적등록하는 곳입니다.
 *생성자 : 김동욱
 *2022-08-24
 *************************************/


namespace Form_list
{
    public partial class WF_performance : Form
    {
        // 1. 공통 클래스 (데이터 베이스 커넥터)
        private SqlConnection Connect2; // 데이터베이스에 접속 하는 정보를 관리하는 클래스.

        // 2. SELECT (조회)를 실행하여 데이터베이스에서 데이터를 받아오는 클래스.
        private SqlDataAdapter Adapter;

        // 3. Insert, Update, Delete 명령을 전달할 클래스
        private SqlTransaction tran; // 데이터베이스 데이터 관리 권한 부여.
        private SqlCommand cmd;
        private string WID;


        private WF_performance()
        {
            InitializeComponent();

        }

        public void doExit()
        {

            this.Visible = false;

        }



        private void WF_performance_Load(object sender, System.EventArgs e)
        {
            /*****************기본 그리드 내역 셋팅 *******************/


            DataTable dtGrid = new DataTable();

            dtGrid.Columns.Add("WORKDEPT", typeof(string));     //부서명 WORKER 테이블
            dtGrid.Columns.Add("WORKNAME", typeof(string));     //부서명
            dtGrid.Columns.Add("FAIREA", typeof(string));      //양품갯수
            dtGrid.Columns.Add("ERROREA", typeof(string));     //불량갯수


            // 빈 컬럼 테이블 그리드에 매칭
            Grid1.DataSource = dtGrid;

            Grid1.Columns[0].Width = 300;
            Grid1.Columns[1].Width = 300;
            Grid1.Columns[2].Width = 300;
            Grid1.Columns[3].Width = 300;


        }


        public bool DBHelper(bool Tran)
        {
            // 1. 데이터 베이스 접속
            Connect2 = new SqlConnection(Commons.cDbCon);

            // 2. 데이터 베이스 OPEN
            Connect2.Open();
            if (Connect2.State != ConnectionState.Open)
            {
                MessageBox.Show("데이터 베이스 연결에 실패하였습니다.");
                return false;
            }
            if (Tran) tran = Connect2.BeginTransaction();
            return true;
        }


        private void btnfair_Click(object sender, EventArgs e)  //양품등록 클릭시
        {
            if (DBHelper(false) == false) return;


            try
            {
                // 사용자 정보 조회



                // Adapter에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("BM_WF_performanceMaster_repair", Connect2);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;



                // 데이터 베이스 처리 시 C#으로 반환할 값을 담는 변수.
                Adapter.SelectCommand.Parameters.AddWithValue("LANG", "KO");
                Adapter.SelectCommand.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                Adapter.SelectCommand.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                // Adapter 실행
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                // 결과값을 그리드뷰에 표현.
                Grid1.DataSource = dtTemp;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect2.Close();
            }
        }

        private void btnerror_Click(object sender, EventArgs e)  //불량 등록 클릭시
        {
            if (DBHelper(false) == false) return;


            try
            {
                // 사용자 정보 조회



                // Adapter에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("BM_WF_performanceMaster_repair", Connect2);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;



                // 데이터 베이스 처리 시 C#으로 반환할 값을 담는 변수.
                Adapter.SelectCommand.Parameters.AddWithValue("LANG", "KO");
                Adapter.SelectCommand.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                Adapter.SelectCommand.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                // Adapter 실행
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                // 결과값을 그리드뷰에 표현.
                Grid1.DataSource = dtTemp;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect2.Close();
            }
        }



        private void button6_Click(object sender, EventArgs e) //추가버튼
        {

            //데이터가 없는 경우 리턴
            if (this.Grid1.RowCount == 0)
                return;
            if (WID == "")
            {
                MessageBox.Show("작업지시 선택 좀 하세요 제발...");
                return;
            }


            try
            {
                if (DBHelper(false) == false) return;

                // 현재 Row를 가져온다.
                DataGridViewRow dgvr = Grid1.SelectedRows[0];


                // 선택한 Row의 데이터를 가져온다
                string WF_performance = dgvr.Cells[1].Value.ToString();
                string WORKID = dgvr.Cells[2].Value.ToString();


                cmd = new SqlCommand();
                cmd.Connection = Connect2;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "WF_WF_performance_U";

                cmd.Parameters.AddWithValue("WID", WID);
                cmd.Parameters.AddWithValue("WF_performanceNAME", WF_performance);
                cmd.Parameters.AddWithValue("WF_performanceID", WORKID);


                cmd.Parameters.AddWithValue("LANG", "KO");
                cmd.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                doExit();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect2.Close();
            }





        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            doExit();
        }

    }
}

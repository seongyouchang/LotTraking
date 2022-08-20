using Assamble;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WorkFactory;
/************************************
 *현장생산등록에 작업자 투입입니다.
 *생성자 : 김동욱
 *2022-08-20
 *************************************/


namespace Form_list
{
    public partial class Worker : Form
    {
        // 1. 공통 클래스 (데이터 베이스 커넥터)
        private SqlConnection Connect2; // 데이터베이스에 접속 하는 정보를 관리하는 클래스.

        // 2. SELECT (조회)를 실행하여 데이터베이스에서 데이터를 받아오는 클래스.
        private SqlDataAdapter Adapter;

        // 3. Insert, Update, Delete 명령을 전달할 클래스
        private SqlTransaction tran; // 데이터베이스 데이터 관리 권한 부여.
        private SqlCommand cmd;



        public Worker()
        {
            InitializeComponent();
        }

    

        private void Worker_Load(object sender, System.EventArgs e)
        {
            /*****************기본 그리드 내역 셋팅 *******************/


            DataTable dtGrid = new DataTable();

            dtGrid.Columns.Add("WORKDEPT", typeof(string));     //부서명
            dtGrid.Columns.Add("WORKERNAME", typeof(string));   //작업자이름

            // 빈 컬럼 테이블 그리드에 매칭
            Grid1.DataSource = dtGrid;

            Grid1.Columns[0].Width = 400;
            Grid1.Columns[1].Width = 400;

            
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

        public  void btn1_Click(object sender, EventArgs e)
        {
            if (DBHelper(false) == false) return;


            try
            {
                // 사용자 정보 조회



                // Adapter에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("BM_WorkerMaster_ele", Connect2);
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

        private void btn2_Click(object sender, EventArgs e)
        {
            if (DBHelper(false) == false) return;


            try
            {
                // 사용자 정보 조회



                // Adapter에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("BM_WorkerMaster_weld", Connect2);
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

        private void btn3_Click(object sender, EventArgs e)
        {
            if (DBHelper(false) == false) return;


            try
            {
                // 사용자 정보 조회



                // Adapter에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("BM_WorkerMaster_fac", Connect2);
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

        private void btn4_Click(object sender, EventArgs e)
        {
            if (DBHelper(false) == false) return;


            try
            {
                // 사용자 정보 조회



                // Adapter에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("BM_WorkerMaster_dis", Connect2);
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

        private void  btn5_Click(object sender, EventArgs e)
        {
            if (DBHelper(false) == false) return;


            try
            {
                // 사용자 정보 조회



                // Adapter에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("BM_WorkerMaster_repair", Connect2);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            
        }
    }
}

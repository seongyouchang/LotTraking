using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assamble;
using System.Data.SqlClient;

namespace Form_list
{
    public partial class Form01_RowMasterTest : Form
    {
        // 1. 공통 클래스 (데이터 베이스 커넥터)
        private SqlConnection Connect; // 데이터베이스에 접속 하는 정보를 관리하는 클래스.

        // 2. SELECT (조회)를 실행하여 데이터베이스에서 데이터를 받아오는 클래스.
        private SqlDataAdapter Adapter;

        // 3. Insert, Update, Delete 명령을 전달할 클래스
        private SqlTransaction tran; // 데이터베이스 데이터 관리 권한 부여.
        private SqlCommand cmd;      // 데이터베이스에 Insert, Update, Delete 명령을 전달할 클래스 
        public Form01_RowMasterTest()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void Form01_UserMaster_Load(object sender, EventArgs e)
        {
            /*****************기본 그리드 내역 셋팅 *******************/
            DataTable dtGrid = new DataTable();
            dtGrid.Columns.Add("ILROW", typeof(string));   //원자재 번호
            dtGrid.Columns.Add("RowAccount", typeof(DateTime)); //원자재 거래처
            dtGrid.Columns.Add("RowStock", typeof(DateTime));       //원자재입고일자
            dtGrid.Columns.Add("RowEA", typeof(string)); //원자재 재고 개수



            // 빈 컬럼 테이블 그리드에 매칭. (DataSource : 테이블 형식의 데이터를 표현하는 속성)
            RowGrid.DataSource = dtGrid;

            // 그리드 컬럼 명칭(Text) 설정 // 번호로 지정 가능
            RowGrid.Columns["ILROW"].HeaderText = "원자재 번호";
            RowGrid.Columns["RowAccount"].HeaderText = "원자재 거래처";
            RowGrid.Columns["RowStock"].HeaderText = "원자재입고일자";
            RowGrid.Columns["RowEA"].HeaderText = "원자재 재고 개수";


            // 컬럼의 폭 지정
            RowGrid.Columns[0].Width = 100;
            RowGrid.Columns[1].Width = 200;
            RowGrid.Columns[2].Width = 100;
            RowGrid.Columns[3].Width = 150;


            //// 컬럼의 수정 여부를 지정
            RowGrid.Columns["ILROW"].ReadOnly = true;
            RowGrid.Columns["RowAccount"].ReadOnly = true;
            RowGrid.Columns["RowStock"].ReadOnly = true;
            RowGrid.Columns["RowEA"].ReadOnly = true;
        }


        public override void Inquire()
        {

            if (DBHelper(false) == false) return;

            try
            {
                // 사용자 정보 조회

                // Adapter에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("BM_WorkOrder_S", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // 파라미터의 개수 별로 함수에 아규먼트 등록
                Adapter.SelectCommand.Parameters.AddWithValue("WID", txtUserId.Text);
                Adapter.SelectCommand.Parameters.AddWithValue("FSPACE", textBox1.Text);

                // 데이터 베이스 처리 시 C#으로 반환할 값을 담는 변수.
                Adapter.SelectCommand.Parameters.AddWithValue("LANG", "KO");
                Adapter.SelectCommand.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                Adapter.SelectCommand.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                // Adapter 실행
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                // 결과값을 그리드뷰에 표현.
                RowGrid.DataSource = dtTemp;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect.Close();
            }
        }
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

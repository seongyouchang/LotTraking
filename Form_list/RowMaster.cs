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
    public partial class RowMaster : BaseChlidForm
    {
        private SqlConnection Connect; // 데이터베이스에 접속 하는 정보를 관리하는 클래스.

        // 2. SELECT (조회)를 실행하여 데이터베이스에서 데이터를 받아오는 클래스.
        private SqlDataAdapter Adapter;

        // 3. Insert, Update, Delete 명령을 전달할 클래스
        private SqlTransaction tran; // 데이터베이스 데이터 관리 권한 부여.
        private SqlCommand cmd;

        public RowMaster()
        {
            InitializeComponent();
        }
       
          
        private void RowMaster_Load(object sender, EventArgs e)
        {
            /*****************기본 그리드 내역 셋팅 *******************/
            DataTable dtGrid = new DataTable();
            dtGrid.Columns.Add("iLROW", typeof(char));                    // 원자재 번호
            dtGrid.Columns.Add("ROWNAME", typeof(char));            //  원자재 명
            dtGrid.Columns.Add("ROWACCOUNT", typeof(char));       //  원자재 거래처
            dtGrid.Columns.Add("ROWSTOCK", typeof(DateTime));      // 원자재 입고일자
            dtGrid.Columns.Add("ROWEA", typeof(char));                   //원자재 재고 개수



            // 빈 컬럼 테이블 그리드에 매칭. (DataSource : 테이블 형식의 데이터를 표현하는 속성)
            GridRowMaster.DataSource = dtGrid;

            // 그리드 컬럼 명칭(Text) 설정 // 번호로 지정 가능
            GridRowMaster.Columns["iLROW"].HeaderText = "원자재 번호";
            GridRowMaster.Columns["ROWNAME"].HeaderText = "원자재 명";
            GridRowMaster.Columns["ROWACCOUNT"].HeaderText = "원자재 거래처";
            GridRowMaster.Columns["ROWSTOCK"].HeaderText = "원자재 입고일자";
            GridRowMaster.Columns["ROWEA"].HeaderText = "원자재 재고 개수";



            // 컬럼의 폭 지정
            GridRowMaster.Columns[0].Width = 100;
            GridRowMaster.Columns[1].Width = 300;
            GridRowMaster.Columns[2].Width = 400;
            GridRowMaster.Columns[3].Width = 150;
            GridRowMaster.Columns[4].Width = 200;


            //// 컬럼의 수정 여부를 지정
            GridRowMaster.Columns["iLROW"].ReadOnly = true;
            GridRowMaster.Columns["ROWNAME"].ReadOnly = true;
            GridRowMaster.Columns["ROWACCOUNT"].ReadOnly = true;
            GridRowMaster.Columns["ROWSTOCK"].ReadOnly = true;
            GridRowMaster.Columns["ROWEA"].ReadOnly = true;
        }

        // 메서드 오버라이드 (Override)
        // virture로 상속을 허락 한 메서드를
        // 각 화면에 맞는 기능으로 변경하여 메서드를 재 정의하고 사용하는 방식.
        public override void Inquire()
        {

            if (DBHelper(false) == false) return;

            try
            {
                // 사용자 정보 조회

                // Adapter에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("BM_RowManager_S", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // 파라미터의 개수 별로 함수에 아규먼트 등록
                Adapter.SelectCommand.Parameters.AddWithValue("iLROW", txtiLROW.Text);
                Adapter.SelectCommand.Parameters.AddWithValue("ROWNAME", txtRowName.Text);
                Adapter.SelectCommand.Parameters.AddWithValue("ROWACCOUNT", textRowAccount.Text);




                // 데이터 베이스 처리 시 C#으로 반환할 값을 담는 변수.
                Adapter.SelectCommand.Parameters.AddWithValue("LANG", "KO");
                Adapter.SelectCommand.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                Adapter.SelectCommand.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                // Adapter 실행
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                // 결과값을 그리드뷰에 표현.
                GridRowMaster.DataSource = dtTemp;
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


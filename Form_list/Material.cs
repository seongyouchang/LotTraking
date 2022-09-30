using Assamble;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Form_list
{
    public partial class Material : Form
    {
        private SqlConnection Connect; // 데이터베이스에 접속 하는 정보를 관리하는 클래스.

        // 2. SELECT (조회)를 실행하여 데이터베이스에서 데이터를 받아오는 클래스.
        private SqlDataAdapter Adapter;

        // 3. Insert, Update, Delete 명령을 전달할 클래스
        private SqlTransaction tran; // 데이터베이스 데이터 관리 권한 부여.
        private SqlCommand cmd;
        private string WID2;
        public Material(string sWid)
        {
            InitializeComponent();
            WID2 = sWid;
        }

        private void Material_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("현재 창을 닫으시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
        }


        private void Material_Load(object sender, EventArgs e)
        {
            /*****************기본 그리드 내역 셋팅 *******************/
            DataTable dtGrid = new DataTable();
            dtGrid.Columns.Add("ROWNAME", typeof(string));                  // 자재명
            dtGrid.Columns.Add("LOTNO", typeof(string));                    // 원자재LOT번호
            dtGrid.Columns.Add("STOCKQTY", typeof(double));                 // 재고개수

            // 빈 컬럼 테이블 그리드에 매칭. (DataSource : 테이블 형식의 데이터를 표현하는 속성)
            Grid1.DataSource = dtGrid;

            // 그리드 컬럼 명칭(Text) 설정 // 번호로 지정 가능
            Grid1.Columns["ROWNAME"].HeaderText = "자재명";
            Grid1.Columns["LOTNO"].HeaderText = "원자재LOT번호";
            Grid1.Columns["STOCKQTY"].HeaderText = "재고개수";


            // 컬럼의 폭 지정
            Grid1.Columns[0].Width = 200;
            Grid1.Columns[1].Width = 200;
            Grid1.Columns[2].Width = 100;


            //// 컬럼의 수정 여부를 지정
            //grid.Columns["MAKER"].ReadOnly = true;
            //grid.Columns["MAKEDATE"].ReadOnly = true;
            //grid.Columns["EDITOR"].ReadOnly = true;
            //grid.Columns["EDITDATE"].ReadOnly = true;

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


        private void btnSearchM_Click(object sender, EventArgs e)
        {
            if (DBHelper(false) == false) return;

            try
            {

                // 사용자 정보 조회

                // Adapter에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("WF_ROWMANAGER_S", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // 파라미터의 개수 별로 함수에 아규먼트 등록
                Adapter.SelectCommand.Parameters.AddWithValue("LOTNO", txtWorkNo.Text);
                Adapter.SelectCommand.Parameters.AddWithValue("ROWNAME", txtName.Text);


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
                Connect.Close();
            }
        }



        private void btnInput_Click(object sender, EventArgs e)
        {
            if (this.Grid1.RowCount == 0)
                return;


            if (MessageBox.Show("현 원재료를 투입하시겠습니까?",
            "추가",
            MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }


            int rowindex = Grid1.CurrentRow.Index;



            try
            {
                if (DBHelper(false) == false) return;

                // 현재 Row를 가져온다.

                // 선택한 Row의 데이터를 가져온다
                string sROWNAME = (string)Grid1.Rows[rowindex].Cells[0].Value;
                string sLOTNo = (string)Grid1.Rows[rowindex].Cells[1].Value;
                double sSTOCKQTY = (double)Grid1.Rows[rowindex].Cells[2].Value;



                cmd = new SqlCommand();
                cmd.Connection = Connect;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "WF_ROWMANAGER_UU";

                cmd.Parameters.AddWithValue("WID", WID2);
                cmd.Parameters.AddWithValue("ROWNAME", sROWNAME);
                cmd.Parameters.AddWithValue("LOTNO", sLOTNo);
                cmd.Parameters.AddWithValue("STOCKQTY", sSTOCKQTY);




                cmd.Parameters.AddWithValue("LANG", "KO");
                cmd.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();







                if (Convert.ToString(cmd.Parameters["RS_CODE"].Value) != "S")
                {
                    throw new Exception("등록 중 오류가 발생하였습니다.");
                }

                cmd.Parameters.Clear();     // 한바퀴 돌았을때 파라미터에 쌓인 값 지우기


                MessageBox.Show("정상적으로 자재투입이 되었습니다.");
                doExit();
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

        public void doExit()
        {

            this.Visible = false;

        }
        private void btnExit_Click(object sender, EventArgs e)
        {

            doExit();



        }




    }





}






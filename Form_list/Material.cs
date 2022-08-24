using Assamble;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
// 스레드를 사용하기 위한 라이브러리 참조.
using System.Threading;
// 폼 리스트 라이브러리 참조
using System.Reflection;


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
        public Material()
        {
            InitializeComponent();
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
            dtGrid.Columns.Add("ILROW", typeof(string));                  // 자재투입
            dtGrid.Columns.Add("ROWNAME", typeof(string));                 // 자재명
            dtGrid.Columns.Add("ROWINQTY", typeof(string));                 // 자재 투입수량
            dtGrid.Columns.Add("ROWUNIT", typeof(string));                 // 단위
            dtGrid.Columns.Add("WORKERNAME", typeof(string));                 // 작업자
            dtGrid.Columns.Add("ROWINDATE", typeof(string));                 // 투입일자
            dtGrid.Columns.Add("ROWEA", typeof(string));                // 재고개수

            // 빈 컬럼 테이블 그리드에 매칭. (DataSource : 테이블 형식의 데이터를 표현하는 속성)
            Grid1.DataSource = dtGrid;

            // 그리드 컬럼 명칭(Text) 설정 // 번호로 지정 가능
            Grid1.Columns["ILROW"].HeaderText = "투입LOT번호";
            Grid1.Columns["ROWNAME"].HeaderText = "자재명";
            Grid1.Columns["ROWINQTY"].HeaderText = "자재 투입수량";
            Grid1.Columns["ROWUNIT"].HeaderText = "단위";
            Grid1.Columns["WORKERNAME"].HeaderText = "작업자";
            Grid1.Columns["ROWINDATE"].HeaderText = "투입일자";
            Grid1.Columns["ROWEA"].HeaderText = "재고개수";


            // 컬럼의 폭 지정
            Grid1.Columns[0].Width = 200;
            Grid1.Columns[1].Width = 200;
            Grid1.Columns[2].Width = 100;
            Grid1.Columns[3].Width = 150;
            Grid1.Columns[4].Width = 200;
            Grid1.Columns[5].Width = 100;


            //// 컬럼의 수정 여부를 지정
            //grid.Columns["MAKER"].ReadOnly = true;
            //grid.Columns["MAKEDATE"].ReadOnly = true;
            //grid.Columns["EDITOR"].ReadOnly = true;
            //grid.Columns["EDITDATE"].ReadOnly = true;
            Inquire();
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

        public void Inquire()
        {
            if (DBHelper(false) == false) return;

            try
            {
                // 사용자 정보 조회

                // Adapter에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("WF_ROWMANAGER_S", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // 파라미터의 개수 별로 함수에 아규먼트 등록
                Adapter.SelectCommand.Parameters.AddWithValue("iLROW", txtWorkNo.Text);
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
        private void btnSearchM_Click(object sender, EventArgs e)
        {
            Inquire();
        }

        public void Save()
        {
            if (DBHelper(true) == false) return;

            cmd = new SqlCommand();
            cmd.Transaction = tran;
            cmd.Connection = Connect;
            cmd.CommandType = CommandType.StoredProcedure;
            string sMessage = string.Empty;

            try
            {
                // 그리드조회 후 변경된 행의 정보만 추출
                DataTable dtChang = ((DataTable)Grid1.DataSource).GetChanges();
                if (dtChang == null) return;

                // 변경된 그리드의 데이터 추출 내역 중 상위로부터 하나의 행씩 뽑아온다.
                foreach (DataRow drrow in dtChang.Rows) // 행을 하나씩 뽑아옴(foreach)
                {
                    switch (drrow.RowState)
                    {
                        case DataRowState.Deleted:
                            drrow.RejectChanges();
                            // 사용자 정보를 변경하는 저장 프로시져 호출
                            cmd.CommandText = "WF_ROWMANAGER_D";
                            //이 이름으로      이 값을 던지겠다
                            cmd.Parameters.AddWithValue("ILROW", drrow["ILROW"]);
                            cmd.Parameters.AddWithValue("ROWNAME", drrow["ROWNAME"]);
                            cmd.Parameters.AddWithValue("ROWINQTY", drrow["WPLANROWINQTY"]);
                            cmd.Parameters.AddWithValue("ROWUNIT", drrow["ROWUNIT"]);
                            cmd.Parameters.AddWithValue("WORKERNAME", drrow["WORKERNAME"]);
                            cmd.Parameters.AddWithValue("ROWINDATE", drrow["ROWINDATE"]);
                            cmd.Parameters.AddWithValue("ROWEA", drrow["ROWEA"]);



                            cmd.Parameters.AddWithValue("LANG", "KO");
                            cmd.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                            cmd.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                            cmd.ExecuteNonQuery();
                            break;
                        case DataRowState.Modified:
                            // 사용자 정보가 수정 된 상태이면
                            if (Convert.ToString(drrow["ILROW"]) == "") sMessage += "투입LOT번호";

                            if (Convert.ToString(drrow["ROWNAME"]) == "") sMessage += "자재명";

                            if (Convert.ToString(drrow["ROWINQTY"]) == "") sMessage += "자재 투입수량";





                            if (sMessage != "")
                            {
                                throw new Exception($"{sMessage}을(를) 입력하지 않았습니다.");
                            }

                            // 사용자 정보를 변경하는 저장 프로시져 호출
                            cmd.CommandText = "WF_ROWMANAGER_U";
                            //이 이름으로      이 값을 던지겠다
                            cmd.Parameters.AddWithValue("ILROW", drrow["ILROW"]);
                            cmd.Parameters.AddWithValue("ROWNAME", drrow["ROWNAME"]);
                            cmd.Parameters.AddWithValue("ROWINQTY", drrow["WPLANROWINQTY"]);
                            cmd.Parameters.AddWithValue("ROWUNIT", drrow["ROWUNIT"]);
                            cmd.Parameters.AddWithValue("WORKERNAME", drrow["WORKERNAME"]);
                            cmd.Parameters.AddWithValue("ROWINDATE", drrow["ROWINDATE"]);
                            cmd.Parameters.AddWithValue("ROWEA", drrow["ROWEA"]);


                            cmd.Parameters.AddWithValue("LANG", "KO");
                            cmd.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                            cmd.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                            cmd.ExecuteNonQuery();

                            break;

                        case DataRowState.Added:
                            cmd.CommandText = "WF_ROWMANAGER_I";
                            cmd.Parameters.AddWithValue("ILROW", drrow["ILROW"]);
                            cmd.Parameters.AddWithValue("ROWNAME", drrow["ROWNAME"]);
                            cmd.Parameters.AddWithValue("ROWINQTY", drrow["ROWINQTY"]);
                            cmd.Parameters.AddWithValue("ROWEA", drrow["ROWEA"]);


                            cmd.Parameters.AddWithValue("LANG", "KO");
                            cmd.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                            cmd.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                            cmd.ExecuteNonQuery();
                            break;
                    }
                    if (Convert.ToString(cmd.Parameters["RS_CODE"].Value) != "S")
                    {
                        throw new Exception("등록 중 오류가 발생하였습니다.");
                    }

                    cmd.Parameters.Clear();     // 한바퀴 돌았을때 파라미터에 쌓인 값 지우기
                }
                tran.Commit();
                MessageBox.Show("정상적으로 자재투입이 되었습니다.");
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                Connect.Close();
            }
        }
        private void btnInput_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Material Material = new Material();
            this.Visible = false;
            Material.Close();


        }

        private void btnSearchM_Click_1(object sender, EventArgs e)
        {
            Inquire();
        }

        private void Grid1_MouseClick(object sender, MouseEventArgs e)
        {
            int rowindex = Grid1.CurrentRow.Index;

            // 현재 Row를 가져온다.
            DataGridViewRow placeindex = Grid1.CurrentRow;

            // 선택한 Row의 데이터를 가져온다.
            DataRow Placerow = (placeindex.DataBoundItem as DataRowView).Row;

            //// TextBox에 그리드 데이터를 넣는다.
            //SWorkOrderGrid.Rows[rowindex].Cells[4].Value = Placerow["WPNAME"].ToString();
        }
    }





}







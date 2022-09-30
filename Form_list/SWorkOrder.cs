using Assamble;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WorkFactory;

namespace Form_list
{
    public partial class SWorkOrder : Form
    {



        // 1. 공통 클래스 (데이터 베이스 커넥터)
        private SqlConnection Connect; // 데이터베이스에 접속 하는 정보를 관리하는 클래스.

        // 2. SELECT (조회)를 실행하여 데이터베이스에서 데이터를 받아오는 클래스.
        private SqlDataAdapter Adapter;

        // 3. Insert, Update, Delete 명령을 전달할 클래스
        private SqlTransaction tran; // 데이터베이스 데이터 관리 권한 부여.
        private SqlCommand cmd;      // 데이터베이스에 Insert, Update, Delete 명령을 전달할 클래스 


        public SWorkOrder()
        {
            InitializeComponent();
        }

        public void doExit()
        {

            this.Visible = false;

        }





        private void SWorkOrder_Load(object sender, System.EventArgs e)
        {
            DataTable dtGrid = new DataTable();
            dtGrid.Columns.Add("MAKEDATE", typeof(DateTime));
            dtGrid.Columns.Add("WID", typeof(string));
            dtGrid.Columns.Add("PROCESS", typeof(string));
            dtGrid.Columns.Add("PLANQTY", typeof(float));
            dtGrid.Columns.Add("WORKPLACE", typeof(string));

            SWorkOrderGrid.DataSource = dtGrid;

            SWorkOrderGrid.Columns["MAKEDATE"].HeaderText = "지시일자";
            SWorkOrderGrid.Columns["WID"].HeaderText = "제조번호";
            SWorkOrderGrid.Columns["PROCESS"].HeaderText = "공정";
            SWorkOrderGrid.Columns["PLANQTY"].HeaderText = "생산수량";
            SWorkOrderGrid.Columns["WORKPLACE"].HeaderText = "작업장";


            if (DBHelper(false) == false) return;

            try
            {

                // Adapter에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("WF_WORKORDER_S", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // 데이터 베이스 처리 시 C#으로 반환할 값을 담는 변수.
                Adapter.SelectCommand.Parameters.AddWithValue("LANG", "KO");
                Adapter.SelectCommand.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                Adapter.SelectCommand.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                // Adapter 실행
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                // 결과값을 그리드뷰에 표현.
                SWorkOrderGrid.DataSource = dtTemp;
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

        private void btnWP_Click(object sender, EventArgs e)
        {
            DataTable dcGrid = new DataTable();
            dcGrid.Columns.Add("WPNAME", typeof(string));

            PlaceGrid.DataSource = dcGrid;

            PlaceGrid.Columns["WPNAME"].HeaderText = "작업장";

            ProcessGrid.Visible = false;
            PlaceGrid.Visible = true;

            if (DBHelper(false) == false) return;

            try
            {



                // Adapter에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("WF_WORKPLACE_S", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // 데이터 베이스 처리 시 C#으로 반환할 값을 담는 변수.
                Adapter.SelectCommand.Parameters.AddWithValue("LANG", "KO");
                Adapter.SelectCommand.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                Adapter.SelectCommand.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                // Adapter 실행
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                // 결과값을 그리드뷰에 표현.
                PlaceGrid.DataSource = dtTemp;
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

        private void btnProcess_Click(object sender, EventArgs e)
        {
            DataTable dpGrid = new DataTable();
            dpGrid.Columns.Add("PNAME", typeof(string));

            ProcessGrid.DataSource = dpGrid;

            ProcessGrid.Columns["PNAME"].HeaderText = "공정";


            PlaceGrid.Visible = false;
            ProcessGrid.Visible = true;
            ProcessGrid.BringToFront();

            if (DBHelper(false) == false) return;

            try
            {



                // Adapter에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("WF_PROCESS_S", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // 데이터 베이스 처리 시 C#으로 반환할 값을 담는 변수.
                Adapter.SelectCommand.Parameters.AddWithValue("LANG", "KO");
                Adapter.SelectCommand.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                Adapter.SelectCommand.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                // Adapter 실행
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                // 결과값을 그리드뷰에 표현.
                ProcessGrid.DataSource = dtTemp;
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



        private void PlaceGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = SWorkOrderGrid.CurrentRow.Index;
            if (this.PlaceGrid.RowCount == 0)
                return;


            // 현재 Row를 가져온다.
            DataGridViewRow placeindex = PlaceGrid.CurrentRow;



            // 선택한 Row의 데이터를 가져온다.
            DataRow Placerow = (placeindex.DataBoundItem as DataRowView).Row;

            if (btnWP.Visible == false)
            {
                return;
            }

            // TextBox에 그리드 데이터를 넣는다.
            SWorkOrderGrid.Rows[rowindex].Cells[4].Value = Placerow["WPNAME"].ToString();




        }

        private void ProcessGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            int rowindex = SWorkOrderGrid.CurrentRow.Index;
            if (this.ProcessGrid.RowCount == 0)
                return;

            DataGridViewRow processindex = ProcessGrid.CurrentRow;

            DataRow Processrow = (processindex.DataBoundItem as DataRowView).Row;

            if (btnProcess.Visible == false)
            {
                return;
            }

            SWorkOrderGrid.Rows[rowindex].Cells[2].Value = Processrow["PNAME"].ToString();
        }



        private void button10_Click(object sender, EventArgs e)
        {

            int rowindex = SWorkOrderGrid.CurrentRow.Index;
            if (this.ProcessGrid.RowCount == 0)
                return;

            DataGridViewRow processindex = ProcessGrid.CurrentRow;

            DataRow Processrow = (processindex.DataBoundItem as DataRowView).Row;


            string WID = (string)SWorkOrderGrid.Rows[rowindex].Cells[0].Value; ;
            string MAKEDATE = string.Format("{0:yyyy-MM-dd}", SWorkOrderGrid.Rows[rowindex].Cells[1].Value);
            string PROCESS = (string)SWorkOrderGrid.Rows[rowindex].Cells[2].Value; ;
            Double WPLAN = (Double)SWorkOrderGrid.Rows[rowindex].Cells[3].Value ; 
            string WORKPLACE = (string)SWorkOrderGrid.Rows[rowindex].Cells[4].Value;


            string query = $"INSERT INTO WORKFACTORY2(MAKEDATE,WID,PROCESS,ROWEA, FSPACE ) VALUES({MAKEDATE},'{WID}','{PROCESS}','{WPLAN}','{WORKPLACE}')"; //DB서버로 전달할 쿼리

            SqlConnection sqlConnection = new SqlConnection(Commons.cDbCon);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = query;
            sqlConnection.Open();                                //SQL커넥션 열기
            sqlCommand.ExecuteNonQuery();                        //쿼리(query)를 DB로 전송
            sqlConnection.Close();                              //SQL커넥션 닫기

            MessageBox.Show("작업등록 성공");



            ////DataRow dr = ((DataTable)Grid1.DataSource).NewRow();
            ////((DataTable)Grid1.DataSource).Rows.Add(dr);


            //// 저장 버튼을 클릭 하였을 때
            //// 사용자 정보를 일괄 저장하는 로직.

            //// 1. 데이터 베이스 접속 가능여부 확인.

            //if (DBHelper(true) == false) return;

            //// 2. Insert, Update, Delete 전달 SqlCommand 클래스 객체 생성.
            //cmd = new SqlCommand();

            //// 3. 생성한 트랜잭션 등록
            //cmd.Transaction = tran;

            //// 4. 데이터 베이스 접속 경로 연결
            //cmd.Connection = Connect;

            //// 5. 프로시져 형태로 호출함을 선언
            //cmd.CommandType = CommandType.StoredProcedure;
            //string sMessage = string.Empty;
            //try
            //{


            //    // 그리드조회 후 변경된 행의 정보만 추출.
            //    DataTable dtChang = ((DataTable)SWorkOrderGrid.DataSource).GetChanges();
            //    if (dtChang == null) return;

            //    // 변경된 그리드의 데이터 추출 내역 중 상위로 부터 하나의 행씩 뽑아온다.
            //    foreach (DataRow drrow in dtChang.Rows)
            //    {
            //        switch (drrow.RowState)
            //        {
            //            case DataRowState.Modified:
            //                // 필요한 정보가 입력되지 않았을 때
            //                if (Convert.ToString(drrow["WORKPLACE"]) == "") sMessage += "작업장";

            //                if (Convert.ToString(drrow["PROCESS"]) == "") sMessage += "공정";


            //                if (sMessage != "")
            //                {
            //                    throw new Exception($"{sMessage}을(를) 입력하지 않았습니다.");
            //                }

            //                // 정보를 업데이트하는 로직
            //                cmd.CommandText = "WF_WORKORDER_U";
            //                //이 이름으로      이 값을 던지겠다
            //                cmd.Parameters.AddWithValue("WPNAME", drrow["WORKPLACE"]);
            //                cmd.Parameters.AddWithValue("PNAME", drrow["PROCESS"]);
            //                cmd.Parameters.AddWithValue("MAKEDATE", drrow["MAKEDATE"]);
            //                cmd.Parameters.AddWithValue("WID", drrow["WID"]);
            //                cmd.Parameters.AddWithValue("ROWEA", drrow["WPLAN"]);

            //                cmd.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
            //                cmd.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

            //                cmd.ExecuteNonQuery();

            //                break;

            //            case DataRowState.Added:

            //                // 정보를 추가하는 로직
            //                cmd.CommandText = "WF_WORKORDER_I";
            //                                         //이 이름으로      이 값을 던지겠다
            //                cmd.Parameters.AddWithValue("WPNAME", drrow["WORKPLACE"]);
            //                cmd.Parameters.AddWithValue("PNAME", drrow["PROCESS"]);
            //                cmd.Parameters.AddWithValue("MAKEDATE", drrow["MAKEDATE"]);
            //                cmd.Parameters.AddWithValue("WID", drrow["WID"]);
            //                cmd.Parameters.AddWithValue("ROWEA", drrow["WPLAN"]);

            //                cmd.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
            //                cmd.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

            //                cmd.ExecuteNonQuery();

            //                break;

            //        }

            //        //if (Convert.ToString(cmd.Parameters["RS_CODE"].Value) != "S")
            //        //{
            //        //    throw new Exception("작업지시 등록중 오류가 발생하였습니다.");
            //        //}

            //        cmd.Parameters.Clear();
            //    }
            //    tran.Commit();
            //    MessageBox.Show("정상적으로 등록되었습니다.");

            //}
            //catch (Exception ex)
            //{
            //    tran.Rollback();
            //    MessageBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    Connect.Close();
            //}

        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            doExit();

            if (DBHelper(false) == false) return;


            try
            {
                // 사용자 정보 조회



                // Adapter에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("WF_WORKFACTORY_S", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;



                // 데이터 베이스 처리 시 C#으로 반환할 값을 담는 변수.
                Adapter.SelectCommand.Parameters.AddWithValue("LANG", "KO");
                Adapter.SelectCommand.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                Adapter.SelectCommand.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                // Adapter 실행
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);


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

      
    }
}



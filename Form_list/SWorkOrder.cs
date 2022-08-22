using Assamble;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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



       

        private void SWorkOrder_Load(object sender, System.EventArgs e)
        {
            DataTable dtGrid = new DataTable();
            dtGrid.Columns.Add("MAKEDATE", typeof(DateTime));   
            dtGrid.Columns.Add("WID", typeof(string));          
            dtGrid.Columns.Add("PROCESS", typeof(string));      
            dtGrid.Columns.Add("WPLAN", typeof(string));        
            dtGrid.Columns.Add("WORKPLACE", typeof(string));

            SWorkOrderGrid.DataSource = dtGrid;

            SWorkOrderGrid.Columns["MAKEDATE"].HeaderText = "지시일자";
            SWorkOrderGrid.Columns["WID"].HeaderText = "제조번호";
            SWorkOrderGrid.Columns["PROCESS"].HeaderText = "공정";
            SWorkOrderGrid.Columns["WPLAN"].HeaderText = "생산수량";
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

        private void button1_Click(object sender, EventArgs e)
        {

            int rowindex = SWorkOrderGrid.CurrentRow.Index;
            if (this.PlaceGrid.RowCount == 0)
                return;
            

            // 현재 Row를 가져온다.
            DataGridViewRow placeindex = PlaceGrid.CurrentRow;



            // 선택한 Row의 데이터를 가져온다.
            DataRow Placerow = (placeindex.DataBoundItem as DataRowView).Row;


            // TextBox에 그리드 데이터를 넣는다.
            SWorkOrderGrid.Rows[rowindex].Cells[4].Value = Placerow["WPNAME"].ToString();
            PlaceGrid.ClearSelection();






            if (this.ProcessGrid.RowCount == 0)
                return;

            DataGridViewRow processindex = ProcessGrid.CurrentRow;

            DataRow Processrow = (processindex.DataBoundItem as DataRowView).Row;

            SWorkOrderGrid.Rows[rowindex].Cells[2].Value = Processrow["PNAME"].ToString();
            ProcessGrid.ClearSelection();

            






        }
    }
}

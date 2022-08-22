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
            dtGrid.Columns.Add("WORKPALCE", typeof(string));

            SWorkOrderGrid.DataSource = dtGrid;

            SWorkOrderGrid.Columns["MAKEDATE"].HeaderText = "지시일자";
            SWorkOrderGrid.Columns["WID"].HeaderText = "제조번호";
            SWorkOrderGrid.Columns["PROCESS"].HeaderText = "공정";
            SWorkOrderGrid.Columns["WPLAN"].HeaderText = "생산수량";
            SWorkOrderGrid.Columns["WORKPALCE"].HeaderText = "작업장";

            


          


        }

        private void btnWP_Click(object sender, EventArgs e)
        {
            ProcessGrid.Visible = false;
            PlaceGrid.Visible = true;

            // 작업장 선택 그리드 뷰

            DataTable dpGrid = new DataTable();
            dpGrid.Columns.Add("WPNAME", typeof(string));

            PlaceGrid.DataSource = dpGrid;

            SWorkOrderGrid.Columns["WPNAME"].HeaderText = "작업장";
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            PlaceGrid.Visible = false;
            ProcessGrid.Visible = true;

            // 공정 선택 그리드 뷰

            DataTable dcGrid = new DataTable();
            dcGrid.Columns.Add("PNAME", typeof(string));

            PlaceGrid.DataSource = dcGrid;

            SWorkOrderGrid.Columns["PNAME"].HeaderText = "공정";
        }

     
    }
}

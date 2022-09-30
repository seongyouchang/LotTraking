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
using Form_list;
using System.Data.SqlClient;


/************************************
 *현장생산등록 메인창입니다
 *수정자 : 김동욱
 *2022-08-22
 *************************************/


namespace WorkFactory
{
    public partial class WorkFactory : Form
    {
        private SqlConnection Connect2; // 데이터베이스에 접속 하는 정보를 관리하는 클래스.

        // 2. SELECT (조회)를 실행하여 데이터베이스에서 데이터를 받아오는 클래스.
        private SqlDataAdapter Adapter;

        // 3. Insert, Update, Delete 명령을 전달할 클래스
        private SqlTransaction tran; // 데이터베이스 데이터 관리 권한 부여.
        private SqlCommand cmd; 

        public WorkFactory()
        {
            InitializeComponent();
        }

        public void inquire()
        {
            if (DBHelper(false) == false) return;


            try
            {
                // 사용자 정보 조회



                // Adapter에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("WF_WORKFACTORY_S", Connect2);
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



    

        private void WorkFactory_Load(object sender, EventArgs e)
        {
            
            Grid1.BorderStyle = BorderStyle.None;
            Grid1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            Grid1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            Grid1.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            Grid1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            Grid1.BackgroundColor = Color.FromArgb(41, 44, 51);
            Grid1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;//optional
            Grid1.EnableHeadersVisualStyles = false;
            Grid1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            Grid1.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 30);
            Grid1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            Grid1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
   



            /*****************기본 그리드 내역 셋팅 *******************/
            DataTable dtGrid = new DataTable();
            dtGrid.Columns.Add("WID", typeof(char));                // 작업지시번호
            dtGrid.Columns.Add("FSPACE", typeof(char));                //  작업장
            dtGrid.Columns.Add("WORKERNAME", typeof(char));                //  작업자
            dtGrid.Columns.Add("FSTART", typeof(char));           // 작업 시작 시간
            dtGrid.Columns.Add("FFINISH", typeof(DateTime));           // 작업 끝난시간
            dtGrid.Columns.Add("ROWNAME", typeof(char));               //원자재 명
            dtGrid.Columns.Add("FEA", typeof(char));               //원자재 재고 개수
            dtGrid.Columns.Add("FAIREA", typeof(char));               //양품 갯수
            dtGrid.Columns.Add("ERROREA", typeof(char));               //불량 갯수



            // 빈 컬럼 테이블 그리드에 매칭. (DataSource : 테이블 형식의 데이터를 표현하는 속성)
            Grid1.DataSource = dtGrid;

            // 그리드 컬럼 명칭(Text) 설정 // 번호로 지정 가능

            // 생산지시일자, 설비 추가 고려해야함
            Grid1.Columns["WID"].HeaderText = "작업지시번호";
            Grid1.Columns["FSPACE"].HeaderText = "작업장";
            Grid1.Columns["WORKERNAME"].HeaderText = "작업자";
            Grid1.Columns["FSTART"].HeaderText = "작업시작시간";
            Grid1.Columns["FFINISH"].HeaderText = "작업종료시간";
            Grid1.Columns["ROWNAME"].HeaderText = "원자재명";
            Grid1.Columns["FEA"].HeaderText = "생산수량";
            Grid1.Columns["FAIREA"].HeaderText = "양품수량";
            Grid1.Columns["ERROREA"].HeaderText = "불량수량";

            if (DBHelper(false) == false) return;

            inquire();


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









        private void btnWorkOrder_Click_1(object sender, EventArgs e)
        {



            SWorkOrder sWorkOrder = new SWorkOrder();
            sWorkOrder.ShowDialog();
            inquire();
        }

        private void btnWorker_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (this.Grid1.RowCount == 0) return;





                DataGridViewRow dgvr = Grid1.SelectedRows[0];

                // 선택한 Row의 데이터를 가져온다.
                string WID = dgvr.Cells[0].Value.ToString();




                Worker worker = new Worker(WID);
                worker.ShowDialog();


                inquire();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect2.Close();
            };
        }

        private void btnMaterial_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (this.Grid1.RowCount == 0) return;





                DataGridViewRow dgvr = Grid1.SelectedRows[0];

                // 선택한 Row의 데이터를 가져온다.
                string WID = dgvr.Cells[0].Value.ToString();


                Material material = new Material(WID);
                material.ShowDialog();


                inquire();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect2.Close();
            };
        }

        private void button8_Click(object sender, EventArgs e)  //실적등록 버튼 클릭
        {
            try
            {
                if (this.Grid1.RowCount == 0) return;





                DataGridViewRow dgvr = Grid1.SelectedRows[0];

                // 선택한 Row의 데이터를 가져온다.
                string WID = dgvr.Cells[0].Value.ToString();




                WF_performance WF_performance = new WF_performance(WID);
                WF_performance.ShowDialog();


                inquire();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect2.Close();
            };
        }

        private void button3_Click(object sender, EventArgs e)  //작업시작
        {

            if (MessageBox.Show("작업을 시작하시겠습니까?",
            "작업시작",
            MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            try
            {
                if (DBHelper(false) == false) return;

                DataGridViewRow dgvr = Grid1.SelectedRows[0];

                // 선택한 Row의 데이터를 가져온다.
                string sWID = dgvr.Cells[0].Value.ToString();
                string sFstart = DateTime.Now.ToString("yyyy/MM/dd/HH:mm:ss");

                cmd = new SqlCommand();
                cmd.Connection =   Connect2;
                cmd.CommandType =  CommandType.StoredProcedure;
                cmd.CommandText =  "WF_WORKFACTORY_START_U";


                

                cmd.Parameters.AddWithValue("WID", sWID);
                cmd.Parameters.AddWithValue("FSTART", sFstart);


                cmd.Parameters.AddWithValue("LANG", "KO");
                cmd.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

              


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect2.Close();
            }

            inquire();


        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("작업을 종료하시겠습니까?",
            "작업종료",
            MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            try
            {
                if (DBHelper(false) == false) return;

                DataGridViewRow dgvr = Grid1.SelectedRows[0];

                // 선택한 Row의 데이터를 가져온다.
                string sWID = dgvr.Cells[0].Value.ToString();
                string sFinish = DateTime.Now.ToString("yyyy/MM/dd/HH:mm:ss");

                cmd = new SqlCommand();
                cmd.Connection = Connect2;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "WF_WORKFACTORY_FINISH_U";




                cmd.Parameters.AddWithValue("WID", sWID);
                cmd.Parameters.AddWithValue("FFINISH", sFinish);


                cmd.Parameters.AddWithValue("LANG", "KO");
                cmd.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect2.Close();
            }

            inquire();
        }

        private void button10_Click(object sender, EventArgs e)   //작업등록 눌렀을 시 
        {
            MessageBox.Show("작업등록이 완료되었습니다");
        }
         
        private void button11_Click(object sender, EventArgs e)  //작업삭제 눌렀을 시 
        {
            if (MessageBox.Show("작업내역을 삭제 하시겠습니까?",
           "작업내역삭제",
           MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            DataGridViewRow dgvr = Grid1.SelectedRows[0];

            // 선택한 Row의 데이터를 가져온다.
            string sWID = dgvr.Cells[0].Value.ToString();
            string sROWNAME = dgvr.Cells[5].Value.ToString();
            try
            {
                if (DBHelper(false) == false) return;

            


                cmd = new SqlCommand();
                cmd.Connection = Connect2;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "WF_WORKFACTORY_D";




                cmd.Parameters.AddWithValue("WID", sWID);



                cmd.Parameters.AddWithValue("LANG", "KO");
                cmd.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect2.Close();
            }

            try
            {
                if (DBHelper(false) == false) return;




                cmd = new SqlCommand();
                cmd.Connection = Connect2;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "WF_ROWMANAGER_D";




                
                cmd.Parameters.AddWithValue("ROWNAME", sROWNAME);



                cmd.Parameters.AddWithValue("LANG", "KO");
                cmd.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect2.Close();
            }



            inquire();
            }
    }
}

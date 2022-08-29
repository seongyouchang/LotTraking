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

     

        private void WorkFactory_Load(object sender, EventArgs e)
        {
            /*****************기본 그리드 내역 셋팅 *******************/
            DataTable dtGrid = new DataTable();
            dtGrid.Columns.Add("WID", typeof(char));                // 작업지시번호
            dtGrid.Columns.Add("FSPACE", typeof(char));                //  작업장
            dtGrid.Columns.Add("WORKERNAME", typeof(char));                //  작업자
            dtGrid.Columns.Add("FSTART", typeof(DateTime));           // 작업 시작 시간
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




                Worker worker = new Worker(WID);
                worker.ShowDialog();


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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect2.Close();
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Assamble;
using System.Data.SqlClient;

namespace Form_list
{
    public partial class Form03_UserMaster : BaseChlidForm
    {
        /****************************************
         * NAME : Form04_SystemMaster
         * DESC : 사용자 마스터(저장 프로시져)
         * ---------------------------------------
         * DATE : 2022-08-08
         * DESC : 성유창, 최초 프로그램 작성.
         * **************************************/

        // 1. 공통 클래스 (데이터 베이스 커넥터)
        private SqlConnection Connect; // 데이터베이스에 접속 하는 정보를 관리하는 클래스.

        // 2. SELECT (조회)를 실행하여 데이터베이스에서 데이터를 받아오는 클래스.
        private SqlDataAdapter Adapter;

        // 3. Insert, Update, Delete 명령을 전달할 클래스
        private SqlTransaction tran; // 데이터베이스 데이터 관리 권한 부여.
        private SqlCommand cmd;      // 데이터베이스에 Insert, Update, Delete 명령을 전달할 클래스 
        public Form03_UserMaster()
        {
            InitializeComponent();
        }




        private void Form03_UserMaster_Load(object sender, EventArgs e)
        {
            /*****************기본 그리드 내역 셋팅 *******************/
            DataTable dtGrid = new DataTable();
            dtGrid.Columns.Add("WID", typeof(string));   //작업지시 번호
            dtGrid.Columns.Add("WSTART", typeof(DateTime)); //Lot 번호
            dtGrid.Columns.Add("WFINISH", typeof(DateTime));       //품명
            dtGrid.Columns.Add("WPLAN", typeof(string)); //원자재 Lot
            dtGrid.Columns.Add("ILROW", typeof(string));// 원자재
            dtGrid.Columns.Add("ILROWEA", typeof(string));  // 원자재 수량
            dtGrid.Columns.Add("FSPACE", typeof(string));    //작업장

            // 빈 컬럼 테이블 그리드에 매칭. (DataSource : 테이블 형식의 데이터를 표현하는 속성)
            Grid1.DataSource = dtGrid;

            // 그리드 컬럼 명칭(Text) 설정 // 번호로 지정 가능
            Grid1.Columns["WID"].HeaderText = "작업지시번호";
            Grid1.Columns["WSTART"].HeaderText = "작업시작일";
            Grid1.Columns["WFINISH"].HeaderText = "작업종료일";
            Grid1.Columns["WPLAN"].HeaderText = "생산수량";
            Grid1.Columns["ILROW"].HeaderText = "필요원자재";
            Grid1.Columns["ILROWEA"].HeaderText = "원자재 수량";
            Grid1.Columns["FSPACE"].HeaderText = "작업장";

            // 컬럼의 폭 지정
            Grid1.Columns["WID"].Width = 200;
            Grid1.Columns[1].Width = 200;
            Grid1.Columns[2].Width = 100;
            Grid1.Columns[3].Width = 150;
            Grid1.Columns[4].Width = 200;
            Grid1.Columns[5].Width = 100;
            Grid1.Columns[6].Width = 200;

            //// 컬럼의 수정 여부를 지정
            //Grid1.Columns["MAKER"].ReadOnly = true;
            //Grid1.Columns["MAKEDATE"].ReadOnly = true;
            //Grid1.Columns["EDITOR"].ReadOnly = true;
            //Grid1.Columns["EDITDATE"].ReadOnly = true;

            Commons Com = new Commons();
            DataTable dtTemp = Com.Standard_Code("FSPACE");
            cboWorkSpace.DataSource = dtTemp;
            cboWorkSpace.ValueMember = "FSPACE";
            cboWorkSpace.DisplayMember = "FSPACE";
        }

        // 메서드 오버라이드 (Override)
        // virture로 상속을 허락 한 메서드를
        // 각 화면에 맞는 기능으로 변경하여 메서드를 재 정의하고 사용하는 방식.
        public override void Inquire()
        {
            /************* 사용자 내역 조회 *****************/
            //// 1. 데이터 베이스 접속
            //Connect = new SqlConnection(Commons.cDbCon);

            //// 2. 데이터 베이스 OPEN
            //Connect.Open();
            //if (Connect.State != ConnectionState.Open)
            //{
            //    MessageBox.Show("데이터 베이스 연결에 실패하였습니다.");
            //    return;
            //}
            if (DBHelper(false) == false) return;

            try
            {
                // 사용자 정보 조회

                // Adapter에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("BM_WorkOrder_S", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // 파라미터의 개수 별로 함수에 아규먼트 등록
                Adapter.SelectCommand.Parameters.AddWithValue("WID", txtUserId.Text);
                Adapter.SelectCommand.Parameters.AddWithValue("FSPACE", cboWorkSpace.Text);

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

        public override void Save()
        {
            // 저장 버튼을 클릭 하였을 때
            // 사용자 정보를 일괄 저장하는 로직.

            // 1. 데이터 베이스 접속 가능여부 확인.

            if (DBHelper(true) == false) return;

            // 2. Insert, Update, Delete 전달 SqlCommand 클래스 객체 생성.
            cmd = new SqlCommand();

            // 3. 생성한 트랜잭션 등록
            cmd.Transaction = tran;

            // 4. 데이터 베이스 접속 경로 연결
            cmd.Connection = Connect;

            // 5. 프로시져 형태로 호출함을 선언
            cmd.CommandType = CommandType.StoredProcedure;
            string sMessage = string.Empty;
            try
            {


                // 그리드조회 후 변경된 행의 정보만 추출.
                DataTable dtChang = ((DataTable)Grid1.DataSource).GetChanges();
                if (dtChang == null) return;

                // 변경된 그리드의 데이터 추출 내역 중 상위로 부터 하나의 행씩 뽑아온다.
                foreach (DataRow drrow in dtChang.Rows)
                {
                    switch (drrow.RowState)
                    {
                        case DataRowState.Deleted:
                            drrow.RejectChanges();
                            // 사용자 정보를 변경하는 저장 프로시져 호출
                            cmd.CommandText = "BM_WorkOrder_D";
                            //이 이름으로      이 값을 던지겠다
                            cmd.Parameters.AddWithValue("WID", drrow["WID"]);
                            cmd.Parameters.AddWithValue("FSPACE", drrow["FSPACE"]);
                            cmd.Parameters.AddWithValue("WSTART", drrow["WSTART"]);
                            cmd.Parameters.AddWithValue("WFINISH", drrow["WFINISH"]);
                            cmd.Parameters.AddWithValue("WPLAN", drrow["WPLAN"]);
                            cmd.Parameters.AddWithValue("ILROW", drrow["ILROW"]);
                            cmd.Parameters.AddWithValue("ILROWEA", drrow["ILROWEA"]);



                            cmd.Parameters.AddWithValue("LANG", "KO");
                            cmd.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                            cmd.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                            cmd.ExecuteNonQuery();
                            break;
                        case DataRowState.Modified:
                            // 사용자 정보가 수정 된 상태이면
                            if (Convert.ToString(drrow["WID"]) == "") sMessage += "작업지시번호";

                            if (Convert.ToString(drrow["FSPACE"]) == "") sMessage += "작업장";

                            if (Convert.ToString(drrow["WPlAN"]) == "") sMessage += "계획수량";

                            if (Convert.ToString(drrow["iLROW"]) == "") sMessage += "원자재";

                            if (Convert.ToString(drrow["iLROWEA"]) == "") sMessage += "원자재 갯수";



                            if (sMessage != "")
                            {
                                throw new Exception($"{sMessage}을(를) 입력하지 않았습니다.");
                            }

                            // 사용자 정보를 변경하는 저장 프로시져 호출
                            cmd.CommandText = "BM_WorkOrder_U";
                            //이 이름으로      이 값을 던지겠다
                            cmd.Parameters.AddWithValue("WID", drrow["WIDd"]);
                            cmd.Parameters.AddWithValue("FSPACE", drrow["FSPACE"]);
                            cmd.Parameters.AddWithValue("WPLAN", drrow["WPLAN"]);
                            cmd.Parameters.AddWithValue("ILROW", drrow["ILROW"]);
                            cmd.Parameters.AddWithValue("ILROWEA", drrow["ILROWEA"]);


                            cmd.Parameters.AddWithValue("LANG", "KO");
                            cmd.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                            cmd.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                            cmd.ExecuteNonQuery();

                            break;
                        case DataRowState.Added:


                            cmd.CommandText = "BM_WorkOrder_I";
                            //이 이름으로      이 값을 던지겠다
                            cmd.Parameters.AddWithValue("Wid", drrow["Wid"]);
                            cmd.Parameters.AddWithValue("WSTART", drrow["WSTART"]);
                            cmd.Parameters.AddWithValue("WFINISH", drrow["WFINISH"]);
                            cmd.Parameters.AddWithValue("WPLAN", drrow["WPLAN"]);
                            cmd.Parameters.AddWithValue("ILROW", drrow["ILROW"]);
                            cmd.Parameters.AddWithValue("FSPACE", drrow["FSPACE"]);
                            cmd.Parameters.AddWithValue("ILROWEA", drrow["ILROWEA"]);



                            cmd.Parameters.AddWithValue("LANG", "KO");
                            cmd.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                            cmd.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                            cmd.ExecuteNonQuery();
                            break;
                    }

                    if (Convert.ToString(cmd.Parameters["RS_CODE"].Value) != "S")
                    {
                        throw new Exception("사용자 등록중 오류가 발생하였습니다.");
                    }

                    cmd.Parameters.Clear();
                }
                tran.Commit();
                MessageBox.Show("정상적으로 등록되었습니다.");
                Inquire();
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

        public override void DoNew()
        {
            // 사용자 내역 등록하는 행 추가
            DataRow dr = ((DataTable)Grid1.DataSource).NewRow();
            ((DataTable)Grid1.DataSource).Rows.Add(dr);
        }

        public override void Delete()
        {
            // 사용자 내역 행에서 삭제.
            // Removeat (행 자체를 DataSource 에서도 삭제)
            if (Grid1.Rows.Count == 0) return;
            int iSelectRowIndex = Grid1.CurrentRow.Index;
            DataTable dtTemp = (DataTable)Grid1.DataSource;


            //dtTemp.Rows.RemoveAt(iSelectRowIndex);

            // 눈에보이는 행은 삭제가 되면서 DataSource에는 삭제된 행이라는 정보 남기기
            // Delete() 삭제한 데이터를 DataSource에는 남긴다.

            // 0부터 시작하는 테이블과 1부터 시작하는 테이블은 위치가 달라서 선택한 것과 다른 것이 삭제되는 경우 for문으로 픽스

            string sUserId = Convert.ToString(Grid1.Rows[iSelectRowIndex].Cells["WID"].Value);
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                if (dtTemp.Rows[i].RowState == DataRowState.Deleted) continue;
                if (sUserId == Convert.ToString(dtTemp.Rows[i]["WID"]))
                {
                    dtTemp.Rows[i].Delete();
                }
            }


            dtTemp.Rows[iSelectRowIndex].Delete();
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

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
    public partial class MaterialOrder : BaseChlidForm
    {
        private SqlConnection Connect;

        private SqlDataAdapter Adapter;

        private SqlTransaction tran;
        private SqlCommand cmd;

        public MaterialOrder()
        {
            InitializeComponent();
        }
        private void MaterialOrder_Load(object sender, EventArgs e)
        {

            /*****************기본 그리드 내역 셋팅 *******************/
            DataTable dtGrid = new DataTable();
            dtGrid.Columns.Add("PLANTCODE", typeof(char));
            dtGrid.Columns.Add("ILROW", typeof(char));
            dtGrid.Columns.Add("PONO", typeof(char));
            dtGrid.Columns.Add("ROWNAME", typeof(char));
            dtGrid.Columns.Add("PODATE", typeof(DateTime));
            dtGrid.Columns.Add("POQTY", typeof(char));
            dtGrid.Columns.Add("ROWUNIT", typeof(char));
            dtGrid.Columns.Add("ROWACCOUNT", typeof(char));
            dtGrid.Columns.Add("INQTY", typeof(char));
            dtGrid.Columns.Add("LOTNO", typeof(char));
            dtGrid.Columns.Add("ROWINDATE", typeof(DateTime));
            // dtGrid.Columns.Add("MAKER",    typeof(char));
            dtGrid.Columns.Add("MAKEDATE", typeof(DateTime));

            // 빈 컬럼 테이블 그리드에 매칭. (DataSource : 테이블 형식의 데이터를 표현하는 속성)
            GridOrder.DataSource = dtGrid;




            // 그리드 컬럼 명칭(Text) 설정 // 번호로 지정 가능
            GridOrder.Columns["PLANTCODE"].HeaderText = "공장";
            GridOrder.Columns["ILROW"].HeaderText = "품번";
            GridOrder.Columns["PONO"].HeaderText = "원자재 발주번호";
            GridOrder.Columns["ROWNAME"].HeaderText = "발주 원자재명";
            GridOrder.Columns["PODATE"].HeaderText = "발주일자";
            GridOrder.Columns["POQTY"].HeaderText = "발주수량";
            GridOrder.Columns["ROWUNIT"].HeaderText = "단위";   
            GridOrder.Columns["ROWACCOUNT"].HeaderText = "거래처";
            GridOrder.Columns["INQTY"].HeaderText = "입고수량";
            GridOrder.Columns["LOTNO"].HeaderText = "LOTNO";
            GridOrder.Columns["ROWINDATE"].HeaderText = "입고일자";
            //GridOrder.Columns["MAKER"].HeaderText      = "생성자";
            GridOrder.Columns["MAKEDATE"].HeaderText = "생성일시";

            // 컬럼의 폭 지정
            GridOrder.Columns["PLANTCODE"].Width = 100;
            GridOrder.Columns["ILROW"].Width = 130;
            GridOrder.Columns["PONO"].Width = 100;
            GridOrder.Columns["ROWNAME"].Width = 100;
            GridOrder.Columns["PODATE"].Width = 130;
            GridOrder.Columns["POQTY"].Width = 130;
            GridOrder.Columns["ROWUNIT"].Width = 130;
            GridOrder.Columns["ROWACCOUNT"].Width = 130;
            GridOrder.Columns["INQTY"].Width = 130;
            GridOrder.Columns["LOTNO"].Width = 130;
            GridOrder.Columns["ROWINDATE"].Width = 130;
            //GridOrder.Columns["MAKER"].Width   = 130;
            GridOrder.Columns["MAKEDATE"].Width = 130;
            //// 컬럼의 수정 여부를 지정
            //GridOrder.Columns["PONO"].ReadOnly = true;

        }

        public override void Inquire()
        {

            if (DBHelper(false) == false) return;

            try
            {
                string sStartdate = string.Format("{0:yyyy-MM-dd}", cboStart.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cboEnd.Value);
                // 사용자 정보 조회

                // Adapter에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("BM_MaterialOrder_S", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                // 파라미터의 개수 별로 함수에 아규먼트 등록
                Adapter.SelectCommand.Parameters.AddWithValue("ROWACCOUNT", cboAccount.Text);
                Adapter.SelectCommand.Parameters.AddWithValue("ROWNAME", cboRowname.Text);
                Adapter.SelectCommand.Parameters.AddWithValue("PONO", txtPono.Text);
                Adapter.SelectCommand.Parameters.AddWithValue("STARTDATE", sStartdate);
                Adapter.SelectCommand.Parameters.AddWithValue("ENDDATE", sEndDate);



                // 데이터 베이스 처리 시 C#으로 반환할 값을 담는 변수.
                Adapter.SelectCommand.Parameters.AddWithValue("LANG", "KO");
                Adapter.SelectCommand.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                Adapter.SelectCommand.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                // Adapter 실행
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                // 결과값을 그리드뷰에 표현.
                GridOrder.DataSource = dtTemp;
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
        /*   public void SavePono()
           {


               if (DBHelper(true) == false) return;
               cmd = new SqlCommand();
               cmd.Transaction = tran;
               cmd.Connection = Connect;

               cmd.CommandType = CommandType.StoredProcedure;
               string sMessage = string.Empty;

               try
               {


                   // 그리드조회 후 변경된 행의 정보만 추출.
                   DataTable dtChang = ((DataTable)GridOrder.DataSource).GetChanges();
                   if (dtChang == null) return;


                   // 변경된 그리드의 데이터 추출 내역 중 상위로 부터 하나의 행씩 뽑아온다.
                   foreach (DataRow drrow in dtChang.Rows)
                   {
                       switch (drrow.RowState)
                       {
                           case DataRowState.Deleted:
                               drrow.RejectChanges();
                               //     사용자 정보를 변경하는 저장 프로시져 호출
                                   cmd.CommandText = "BM_MaterialOrder_D";
                               //    이 이름으로      이 값을 던지겠다
                               cmd.Parameters.AddWithValue("ILROW",        drrow["ILROW"]);
                               cmd.Parameters.AddWithValue("PONO",         drrow["PONO"]);
                               cmd.Parameters.AddWithValue("ROWNAME",      drrow["ROWNAME"]);
                               cmd.Parameters.AddWithValue("PODATE",       drrow["PODATE"]);
                               cmd.Parameters.AddWithValue("POQTY",        drrow["POQTY"]);
                               cmd.Parameters.AddWithValue("ROWUNIT",      drrow["ROWUNIT"]);
                               cmd.Parameters.AddWithValue("ROWACCOUNT",   drrow["ROWACCOUNT"]);
                               cmd.Parameters.AddWithValue("INQTY",        drrow["INQTY"]);
                               cmd.Parameters.AddWithValue("LOTNO",        drrow["LOTNO"]);
                               cmd.Parameters.AddWithValue("MAKER",        drrow["MAKER"]);
                               cmd.Parameters.AddWithValue("MAKEDATE",     drrow["MAKEDATE"]);

                               cmd.Parameters.AddWithValue("LANG", "KO");
                               cmd.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                               cmd.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                               cmd.ExecuteNonQuery();
                               break;
                           case DataRowState.Modified:                            

                               if (Convert.ToString(drrow["INQTY"]) == "") sMessage += "입고수량";


                               if (sMessage != "")
                               {
                                   throw new Exception($"{sMessage}을(를) 입력하지 않았습니다.");
                               }

                               // 사용자 정보를 변경하는 저장 프로시져 호출
                               cmd.CommandText = "BM_MaterialOrder_U";
                               //이 이름으로      이 값을 던지겠다
                               cmd.Parameters.AddWithValue("ROWNAME",   drrow["ROWNAME"]);
                               cmd.Parameters.AddWithValue("PONO",      drrow["PONO"]);
                               cmd.Parameters.AddWithValue("INQTY",     drrow["INQTY"]);



                               cmd.Parameters.AddWithValue("LANG", "KO");
                               cmd.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                               cmd.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                               cmd.ExecuteNonQuery();

                               break;
                           case DataRowState.Added:
                               //    // 구매 자재 발주 내역 등록
                               if (Convert.ToString(drrow["ROWNAME"]) == "") sMessage      += "원자재명";
                               if (Convert.ToString(drrow["POQTY"]) == "") sMessage        += "발주수량";
                               if (Convert.ToString(drrow["ROWACCOUNT"]) == "") sMessage   += "거래처";
                               if (Convert.ToString(drrow["PODATE"]) == "") sMessage       += "발주일자";

                               if (sMessage != "")
                               {
                                   throw new Exception($"{sMessage}을(를) 입력하지 않았습니다.");
                               }

                               cmd.CommandText = "BM_MaterialOrder_I";
                               //이 이름으로      이 값을 던지겠다
                               cmd.Parameters.AddWithValue("ROWNAME",      drrow["ILROW"]);
                               cmd.Parameters.AddWithValue("POQTY",        drrow["POQTY"]);
                               cmd.Parameters.AddWithValue("PODATE ",      drrow["PODATE "]);
                               cmd.Parameters.AddWithValue("ROWUNIT",      drrow["ROWUNIT"]);
                               cmd.Parameters.AddWithValue("ROWACCOUNT",   drrow["ROWACCOUNT"]);




                               cmd.Parameters.AddWithValue("LANG", "KO");
                               cmd.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                               cmd.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                               cmd.ExecuteNonQuery();
                               break;




                       }

                       if (Convert.ToString(cmd.Parameters["RS_CODE"].Value) != "S")
                       {
                           throw new Exception("입고 중 오류가 발생하였습니다.");
                       }

                       cmd.Parameters.Clear();
                   }
                   tran.Commit();
                   MessageBox.Show("정상적으로 입고되었습니다.");
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

           }*/

        public override void Save()   //입고등록 하기
        {

            if (MessageBox.Show("발주 등록을 하시겠습니까?",
                    "발주등록",
                    MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }


            if (DBHelper(true) == false) return;

            cmd = new SqlCommand();
            cmd.Transaction = tran;
            cmd.Connection = Connect;

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                if (this.GridOrder.RowCount == 0) return;
                if (DBHelper(false) == false) return;
                DataGridViewRow dgvr = GridOrder.SelectedRows[0];
                string sPLANTCODE    = dgvr.Cells[0].Value.ToString();
                string sILROW        = dgvr.Cells[1].Value.ToString();
                string sROWNAME      = dgvr.Cells[3].Value.ToString();
                string sPOQTY        = dgvr.Cells[5].Value.ToString();
                string sROWUNIT      = dgvr.Cells[6].Value.ToString(); 
                string sROWACCOUNT   = dgvr.Cells[7].Value.ToString();

                cmd = new SqlCommand();
                cmd.Connection = Connect;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BM_MaterialOrder_UU";

                cmd.Parameters.AddWithValue("PLANTCODE", sPLANTCODE);
                cmd.Parameters.AddWithValue("ILROW", sILROW);
                cmd.Parameters.AddWithValue("ROWNAME", sROWNAME);
                cmd.Parameters.AddWithValue("POQTY", sPOQTY);
                cmd.Parameters.AddWithValue("ROWUNIT", sROWUNIT);
               
                cmd.Parameters.AddWithValue("ROWACCOUNT", sROWACCOUNT);

                cmd.Parameters.AddWithValue("LANG", "KO");
                cmd.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                MessageBox.Show("발주등록을 완료했습니다");

                Inquire();

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
        public override void DoNew()
        {
            // 사용자 내역 등록하는 행 추가
            DataRow dr = ((DataTable)GridOrder.DataSource).NewRow();
            ((DataTable)GridOrder.DataSource).Rows.Add(dr);
            GridOrder.Columns["PONO"].ReadOnly = true;

        }

        public override void Delete()
        {

            // 사용자 내역 행에서 삭제.
            // Removeat (행 자체를 DataSource 에서도 삭제)
            if (GridOrder.Rows.Count == 0) return;
            int iSelectRowIndex = GridOrder.CurrentRow.Index;
            DataTable dtTemp = (DataTable)GridOrder.DataSource;


            //dtTemp.Rows.RemoveAt(iSelectRowIndex);

            // 눈에보이는 행은 삭제가 되면서 DataSource에는 삭제된 행이라는 정보 남기기
            // Delete() 삭제한 데이터를 DataSource에는 남긴다.

            // 0부터 시작하는 테이블과 1부터 시작하는 테이블은 위치가 달라서 선택한 것과 다른 것이 삭제되는 경우 for문으로 픽스

            string sLotNo = Convert.ToString(GridOrder.Rows[iSelectRowIndex].Cells["LOTNO"].Value);
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                if (dtTemp.Rows[i].RowState == DataRowState.Deleted) continue;
                if (sLotNo == Convert.ToString(dtTemp.Rows[i]["LOTNO"]))
                {
                    dtTemp.Rows[i].Delete();
                }
            }


            dtTemp.Rows[iSelectRowIndex].Delete();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
          
            try
            {

                if (MessageBox.Show("입고 등록을 하시겠습니까?",
                        "입고등록",
                        MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                if (DBHelper(true) == false) return;

                cmd = new SqlCommand();
                cmd.Transaction = tran;
                cmd.Connection = Connect;

                cmd.CommandType = CommandType.StoredProcedure;

                if (this.GridOrder.RowCount == 0) return;
                if (DBHelper(false) == false) return;
                DataGridViewRow dgvr = GridOrder.SelectedRows[0];
                string sILROW       = dgvr.Cells[1].Value.ToString();
                string sINQTY       = dgvr.Cells[8].Value.ToString();
                

                cmd = new SqlCommand();
                cmd.Connection = Connect;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BM_MaterialOrder_UUU";

                cmd.Parameters.AddWithValue("ILROW", sILROW);
                cmd.Parameters.AddWithValue("INQTY", sINQTY);
               

                cmd.Parameters.AddWithValue("LANG", "KO");
                cmd.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();



              
                Inquire();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect.Close();
            }


            try
            {
                if (DBHelper(true) == false) return;

                cmd = new SqlCommand();
                cmd.Transaction = tran;
                cmd.Connection = Connect;

                cmd.CommandType = CommandType.StoredProcedure;

                if (this.GridOrder.RowCount == 0) return;
                if (DBHelper(false) == false) return;
                DataGridViewRow dgvr = GridOrder.SelectedRows[0];
                string sPLANTCODE  = dgvr.Cells[0].Value.ToString();
                string sILROW      = dgvr.Cells[1].Value.ToString();
                string sPONO        = dgvr.Cells[2].Value.ToString();
                string sROWNAME    = dgvr.Cells[3].Value.ToString();
                string sPOQTY      = dgvr.Cells[5].Value.ToString();
                string sROWUNIT    = dgvr.Cells[6].Value.ToString();
                string sROWACCOUNT = dgvr.Cells[7].Value.ToString();
                string sINQTY      = dgvr.Cells[8].Value.ToString();
                string sLOTNO      = dgvr.Cells[9].Value.ToString();
                string sROWINDATE  = dgvr.Cells[10].Value.ToString();


                cmd = new SqlCommand();
                cmd.Connection = Connect;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BM_MaterialOrder_UUUU";

                cmd.Parameters.AddWithValue("PLANTCODE", sPLANTCODE);
                cmd.Parameters.AddWithValue("ILROW"    , sILROW);
                cmd.Parameters.AddWithValue("PONO"     , sPONO);
                cmd.Parameters.AddWithValue("ROWNAME"  , sROWNAME);
                cmd.Parameters.AddWithValue("POQTY"    , sPOQTY);
                cmd.Parameters.AddWithValue("ROWUNIT"  , sROWUNIT);        
                cmd.Parameters.AddWithValue("ROWACCOUNT", sROWACCOUNT);
                cmd.Parameters.AddWithValue("INQTY"     , sINQTY);
                cmd.Parameters.AddWithValue("LOTNO"     , sLOTNO);
                cmd.Parameters.AddWithValue("ROWINDATE" , sROWINDATE);



                cmd.Parameters.AddWithValue("LANG", "KO");
                cmd.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                MessageBox.Show("입고등록을 완료했습니다");

                Inquire();



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






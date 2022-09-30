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
    public partial class LotTracking : BaseChlidForm
    {
        private SqlConnection Connect;

        private SqlDataAdapter Adapter;

        private SqlTransaction tran;
        private SqlCommand cmd;
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

        public LotTracking()
        {
            InitializeComponent();
        }
        private void LotTracking_Load(object sender, EventArgs e)
        {

            /*****************기본 그리드 내역 셋팅 *******************/
            DataTable dtGrid1 = new DataTable();
           // dtGrid1.Columns.Add("PLANTCODE", typeof(char));                // 공장
           // dtGrid1.Columns.Add("WID",          typeof(char));             // 작업지시번호
           // dtGrid1.Columns.Add("LOTNO",        typeof(char));             // 생산 LOT
           // dtGrid1.Columns.Add("WORKPLACE",    typeof(char));             // 작업장
           // dtGrid1.Columns.Add("FSPACE",       typeof(char));             // 작업장명
           // dtGrid1.Columns.Add("ITEMCODE",     typeof(char));             // 생산품목
           // dtGrid1.Columns.Add("ITEMNAME",     typeof(char));             // 생산품명
           // dtGrid1.Columns.Add("PRODQTY",      typeof(int));              // 생산수량
           // dtGrid1.Columns.Add("UNITCODE",     typeof(char));             // 단위
           // dtGrid1.Columns.Add("CLOTNO",       typeof(char));             // 투입LOT
           // dtGrid1.Columns.Add("CITEMCODE",    typeof(char));             // 투입품목     
           // dtGrid1.Columns.Add("CITEMNAME",    typeof(char));             // 투입품명
           // dtGrid1.Columns.Add("INQTY",        typeof(char));             // 투입수량
           // dtGrid1.Columns.Add("CUNITCODE",    typeof(char));             // 투입단위
           // dtGrid1.Columns.Add("MAKEDATE",     typeof(DateTime));         // 등록일시
           // dtGrid1.Columns.Add("MAKER",        typeof(char));             // 등록자


            dtGrid1.Columns.Add("PLANTCODE", typeof(char));         // 공장        TB_STOCK
            dtGrid1.Columns.Add("WID", typeof(char));               // 작업지시번호 WORKORDER
            dtGrid1.Columns.Add("FSPACE", typeof(char));            // 작업장명   WORKFACTORY
            dtGrid1.Columns.Add("PROCESS", typeof(char));           // 작업장명   WORKFACTORY
            dtGrid1.Columns.Add("CLOTNO", typeof(char));            // 작업장명   WORKFACTORY
            dtGrid1.Columns.Add("ITEMCODE", typeof(char));          // 생산품목   WORKORDER
            dtGrid1.Columns.Add("ITEMNAME", typeof(char));          // 생산품명   WORKORDER
            dtGrid1.Columns.Add("PLANQTY", typeof(int));            // 계획수량   WORKORDER
            dtGrid1.Columns.Add("Fea", typeof(int));                // 생산수량   WORKFACTORY2
            dtGrid1.Columns.Add("FAIREA", typeof(int));             // 양품수량   WORKFACTORY2
            dtGrid1.Columns.Add("ERROREA", typeof(int));            // 불량수량   WORKFACTORY2
            dtGrid1.Columns.Add("UNITCODE", typeof(char));          // 단위       TB_STOCK
            dtGrid1.Columns.Add("LOTNO", typeof(char));             // 투입LOT    TB_STOCK
            dtGrid1.Columns.Add("iLROW",    typeof(char));          // 투입품목   TB_STOCK
            dtGrid1.Columns.Add("ROWNAME",    typeof(char));        // 투입품명   TB_STOCK
            dtGrid1.Columns.Add("FSTART", typeof(char));       
            dtGrid1.Columns.Add("FFINISH", typeof(char));      


            // 빈 컬럼 테이블 그리드에 매칭. (DataSource : 테이블 형식의 데이터를 표현하는 속성)
            GridOrder.DataSource = dtGrid1;

            /*****************원자재 LOT 그리드 내역 셋팅 *******************/
            DataTable dtGrid2 = new DataTable();
            //dtGrid2.Columns.Add("PLANTCODE",    typeof(char));      // 공장
            //dtGrid2.Columns.Add("INOUTDATE",    typeof(DateTime));  // 입출일자
            //dtGrid2.Columns.Add("ITEMCODE",     typeof(char));      // 품목
            //dtGrid2.Columns.Add("ITEMNAME",     typeof(char));      // 품명
            //dtGrid2.Columns.Add("LOTNO",        typeof(char));      // LOTNO
            //dtGrid2.Columns.Add("WHCODE",       typeof(char));      // 창고번호
            //dtGrid2.Columns.Add("INOUTFLAG",    typeof(char));      // 입출구분
            //dtGrid2.Columns.Add("INOUTQTY",     typeof(char));      // 입출수량
            //dtGrid2.Columns.Add("INOUTWNAME",   typeof(char));      // 작업자
            //dtGrid2.Columns.Add("MAKEDATE",     typeof(DateTime));  // 등록일시

            dtGrid2.Columns.Add("PLANTCODE",    typeof(char));    
            dtGrid2.Columns.Add("INOUTDATE",        typeof(char));
            dtGrid2.Columns.Add("iLROW",      typeof(char));      
            dtGrid2.Columns.Add("ROWNAME",        typeof(char));  
            dtGrid2.Columns.Add("LOTNO",       typeof(char));     
            dtGrid2.Columns.Add("WHCODE",         typeof(char));
            dtGrid2.Columns.Add("INOUTFLAG",       typeof(char));
            dtGrid2.Columns.Add("INOUTQTY",        typeof(char));
            dtGrid2.Columns.Add("WORKERNAME", typeof(DateTime));
         
           

            grid2.DataSource = dtGrid2;

            /*****************제품 LOT 그리드 내역 셋팅 ******************
            DataTable dtGrid3 = new DataTable();
            dtGrid3.Columns.Add("PLANTCODE", typeof(char));         // 공장
            dtGrid3.Columns.Add("INOUTDATE", typeof(DateTime));         // 입출일자
            dtGrid3.Columns.Add("ITEMCODE", typeof(char));          // 품목
            dtGrid3.Columns.Add("ITEMNAME", typeof(char));          // 품명
            dtGrid3.Columns.Add("LOTNO", typeof(char));             // LOTNO
            dtGrid3.Columns.Add("WHCODE", typeof(char));            // 창고번호
            dtGrid3.Columns.Add("INOUTFLAG", typeof(char));         // 입출구분
            dtGrid3.Columns.Add("INOUTQTY", typeof(char));          // 입출수량
            dtGrid3.Columns.Add("INOUTWNAME", typeof(char));        // 작업자
            dtGrid3.Columns.Add("SHIPNO", typeof(char));            // 상차/명세번호
            dtGrid3.Columns.Add("CARNO", typeof(char));             // 차량번호
            dtGrid3.Columns.Add("MAKEDATE", typeof(DateTime));      // 등록일시 */

            DataTable dtGrid3 = new DataTable();

            grid3.DataSource = dtGrid3;   
            dtGrid3.Columns.Add("PLANTCODE", typeof(char));
            dtGrid3.Columns.Add("PODATE", typeof(char));
            dtGrid3.Columns.Add("PONO", typeof(char));
            dtGrid3.Columns.Add("POQTY", typeof(char));
            dtGrid3.Columns.Add("ROWINDATE", typeof(DateTime));
            dtGrid3.Columns.Add("LOTNO", typeof(char));             // 투입LOT    TB_STOCK
            dtGrid3.Columns.Add("iLROW", typeof(char));          // 투입품목   TB_STOCK
            dtGrid3.Columns.Add("ROWNAME", typeof(char));        // 투입품명   TB_STOCK
            dtGrid3.Columns.Add("INQTY", typeof(char));       // 투입수량   TB_STOCK



            // 기본그리드 컬럼 명칭(Text) 설정 // 번호로 지정 가능
            GridOrder.Columns["PLANTCODE"].HeaderText   = "공장";
            GridOrder.Columns["WID"].HeaderText         = "작업지시번호";
            GridOrder.Columns["FSPACE"].HeaderText     = "작업장명";
            GridOrder.Columns["PROCESS"].HeaderText      = "공정";
            GridOrder.Columns["CLOTNO"].HeaderText      = "생산LOT";
            GridOrder.Columns["ITEMCODE"].HeaderText      = "생산품명";
            GridOrder.Columns["ITEMNAME"].HeaderText    = "";
            GridOrder.Columns["PLANQTY"].HeaderText     = "계획수량";
            GridOrder.Columns["Fea"].HeaderText          = "생산수량";
            GridOrder.Columns["FAIREA"].HeaderText        = "양품수량";
            GridOrder.Columns["ERROREA"].HeaderText      = "불량수량";
            GridOrder.Columns["UNITCODE"].HeaderText     = "단위";
            GridOrder.Columns["LOTNO"].HeaderText        = "투입LOT";
            GridOrder.Columns["iLROW"].HeaderText       = "투입원자재코드";
            GridOrder.Columns["ROWNAME"].HeaderText   = "원자재명";
            GridOrder.Columns["FSTART"].HeaderText    = "생산시작일시";
            GridOrder.Columns["FFINISH"].HeaderText    = "생산종료일시";


            // 컬럼의 폭 지정  
            GridOrder.Columns[0].Width  = 100;
            GridOrder.Columns[1].Width  = 130;
            GridOrder.Columns[2].Width  = 130;
            GridOrder.Columns[3].Width  = 150;
            GridOrder.Columns[4].Width  = 140;
            GridOrder.Columns[5].Width  = 130;
            GridOrder.Columns[6].Width  = 0;
            GridOrder.Columns[7].Width  =  80;
            GridOrder.Columns[8].Width  = 100;
            GridOrder.Columns[9].Width  = 130;
            GridOrder.Columns[10].Width = 130;
            GridOrder.Columns[11].Width = 150;
            GridOrder.Columns[12].Width = 120;
            GridOrder.Columns[13].Width = 100;
            GridOrder.Columns[14].Width = 160;
            GridOrder.Columns[13].Width = 130;
            GridOrder.Columns[14].Width = 130;
            GridOrder.Columns[15].Width = 130;
            GridOrder.Columns[16].Width = 130;
          
           

            // 컬럼의 수정 여부를 지정
            //GridOrder.Columns["PONO"].ReadOnly = true;

            // 원자재 LOT 입출고 그리드 컬럼 명칭(Text) 설정 // 번호로 지정 가능
            grid2.Columns["PLANTCODE"].HeaderText   = "공장";
            grid2.Columns["INOUTDATE"].HeaderText =  "입출일자";
            grid2.Columns["iLROW"].HeaderText       = "품목";
            grid2.Columns["ROWNAME"].HeaderText    =  "품명";
            grid2.Columns["LOTNO"].HeaderText       = "LOTNO";
            grid2.Columns["WHCODE"].HeaderText      = "창고번호";
            grid2.Columns["INOUTFLAG"].HeaderText   = "입출구분";
            grid2.Columns["INOUTQTY"].HeaderText    = "입출수량";
            grid2.Columns["WORKERNAME"].HeaderText  = "작업자";
          


            // 컬럼의 폭 지정  
            grid2.Columns[0].Width = 100;
            grid2.Columns[1].Width = 130;
            grid2.Columns[2].Width = 130;
            grid2.Columns[3].Width = 100;
            grid2.Columns[4].Width = 140;
            grid2.Columns[5].Width = 130;
            grid2.Columns[6].Width = 150;
            grid2.Columns[7].Width = 80;
            grid2.Columns[8].Width = 100;
          

           // 원자재 LOT 입출고 그리드 컬럼 명칭(Text) 설정 // 번호로 지정 가능
            grid3.Columns["PLANTCODE"].HeaderText   = "공장";
            grid3.Columns["PODATE"].HeaderText      = "발주일시";
            grid3.Columns["PONO"].HeaderText        = "발주번호";
            grid3.Columns["POQTY"].HeaderText       = "발주수량";
            grid3.Columns["ROWINDATE"].HeaderText   = "원자재입고일시";
            grid3.Columns["LOTNO"].HeaderText       = "LOTNO";
            grid3.Columns["ILROW"].HeaderText       = "원자재번호";
            grid3.Columns["ROWNAME"].HeaderText     = "원자재명";
            grid3.Columns["INQTY"].HeaderText       = "입고수량";
           

            // 컬럼의 폭 지정 
            grid3.Columns[0].Width = 100;
            grid3.Columns[1].Width = 130;
            grid3.Columns[2].Width = 130;
            grid3.Columns[3].Width = 100;
            grid3.Columns[4].Width = 140;
            grid3.Columns[5].Width = 130;
            grid3.Columns[6].Width = 150;
            grid3.Columns[7].Width = 80;
            grid3.Columns[8].Width = 100;
          
        }

        public override void Inquire()
        {

            string sPlantCode = Convert.ToString(txtPlant.Text);
            string sPLotNo = Convert.ToString(txtPLotNo.Text);
            string sPItemCode = Convert.ToString(txtPItemName.Text);
            string sCLotNo = Convert.ToString(txtCLotNo.Text);
            string sCItemCode = Convert.ToString(txtCItemName.Text);


            try
            {

                if (DBHelper(false) == false) return;



                //Adapter에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("AM_LotTracking_S1", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                //파라미터의 개수 별로 함수에 아규먼트 등록
                Adapter.SelectCommand.Parameters.AddWithValue("PLANTCODE", sPlantCode);
                Adapter.SelectCommand.Parameters.AddWithValue("PLOTNO", sPLotNo);
                Adapter.SelectCommand.Parameters.AddWithValue("PITEMCODE", sPItemCode);
                Adapter.SelectCommand.Parameters.AddWithValue("CLOTNO", sCLotNo);
                Adapter.SelectCommand.Parameters.AddWithValue("CITEMCODE", sCItemCode);



                //데이터 베이스 처리 시 C#으로 반환할 값을 담는 변수.
                Adapter.SelectCommand.Parameters.AddWithValue("LANG", "KO");
                Adapter.SelectCommand.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                Adapter.SelectCommand.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                //Adapter 실행
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                //결과값을 그리드뷰에 표현.
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



        private void GridOrder_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (DBHelper(false) == false) return;
                int rowindex = GridOrder.CurrentRow.Index;

                string sPLotNo = Convert.ToString(this.GridOrder.Rows[rowindex].Cells[12].Value);

                //Adapter에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("AM_LotTracking_S2", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                //파라미터의 개수 별로 함수에 아규먼트 등록
                Adapter.SelectCommand.Parameters.AddWithValue("LOTNO", sPLotNo);




                //데이터 베이스 처리 시 C#으로 반환할 값을 담는 변수.
                Adapter.SelectCommand.Parameters.AddWithValue("LANG", "KO");
                Adapter.SelectCommand.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                Adapter.SelectCommand.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                //Adapter 실행
                DataTable dtTemp2 = new DataTable();
                Adapter.Fill(dtTemp2);

                //결과값을 그리드뷰에 표현.
                grid2.DataSource = dtTemp2;


            }
            catch
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                Connect.Close();
            }

            //로트트래킹 S3
            try
            {
                if (DBHelper(false) == false) return;
                int rowindex = GridOrder.CurrentRow.Index;

                string sILROW = Convert.ToString(this.GridOrder.Rows[rowindex].Cells[13].Value);

                //Adapter에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("AM_LotTracking_S3", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                //파라미터의 개수 별로 함수에 아규먼트 등록
                Adapter.SelectCommand.Parameters.AddWithValue("ILROW", sILROW);




                //데이터 베이스 처리 시 C#으로 반환할 값을 담는 변수.
                Adapter.SelectCommand.Parameters.AddWithValue("LANG", "KO");
                Adapter.SelectCommand.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                Adapter.SelectCommand.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                //Adapter 실행
                DataTable dtTemp3 = new DataTable();
                Adapter.Fill(dtTemp3);

                //결과값을 그리드뷰에 표현.
                grid3.DataSource = dtTemp3;


            }
            catch
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                Connect.Close();
            }

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

 
    } 
}






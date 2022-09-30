using Assamble;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Form_list
{
    public partial class TB_STOCK : BaseChlidForm
    {
        private SqlConnection Connect; // 데이터베이스에 접속 하는 정보를 관리하는 클래스.

        // 2. SELECT (조회)를 실행하여 데이터베이스에서 데이터를 받아오는 클래스.
        private SqlDataAdapter Adapter;

        // 3. Insert, Update, Delete 명령을 전달할 클래스
        private SqlTransaction tran; // 데이터베이스 데이터 관리 권한 부여.
        private SqlCommand cmd;
    
        public TB_STOCK()
        {
            InitializeComponent();
        }


        private void StockMMRec2_Load(object sender, EventArgs e)
        {
            /*****************기본 그리드 내역 셋팅 *******************/
            DataTable dtGrid = new DataTable();
                       
            dtGrid.Columns.Add("PLANTCODE"   , typeof(char));     
            dtGrid.Columns.Add("LOTNO",         typeof(char));
            dtGrid.Columns.Add("iLROW",         typeof(char));
            dtGrid.Columns.Add("ROWNAME",       typeof(char));
            dtGrid.Columns.Add("STOCKQTY",      typeof(char));
            dtGrid.Columns.Add("UNITCODE",      typeof(char));
            dtGrid.Columns.Add("WHCODE",        typeof(char));                      
            dtGrid.Columns.Add("INDATE",        typeof(char));    
            dtGrid.Columns.Add("MAKER"      ,   typeof(char));          
            dtGrid.Columns.Add("MAKEDATE"   ,   typeof(char));        
         




            // 빈 컬럼 테이블 그리드에 매칭. (DataSource : 테이블 형식의 데이터를 표현하는 속성)
            GridStockMMRec2.DataSource = dtGrid;

            // 그리드 컬럼 명칭(Text) 설정 // 번호로 지정 가능
           
            GridStockMMRec2.Columns["PLANTCODE"].HeaderText    = "공장";
            GridStockMMRec2.Columns["LOTNO"].HeaderText         = "LOTNO";
            GridStockMMRec2.Columns["iLROW"].HeaderText         = "품목";
            GridStockMMRec2.Columns["ROWNAME"].HeaderText       = "품명";
            GridStockMMRec2.Columns["STOCKQTY"].HeaderText      = "재고수량";
            GridStockMMRec2.Columns["UNITCODE"].HeaderText      = "단위";
            GridStockMMRec2.Columns["WHCODE"].HeaderText        = "창고";
            GridStockMMRec2.Columns["INDATE"].HeaderText        = "입고일자";
            GridStockMMRec2.Columns["MAKER"].HeaderText         = "등록자";
            GridStockMMRec2.Columns["MAKEDATE"].HeaderText      = "등록일시";
         




            // 컬럼의 폭 지정
           
            GridStockMMRec2.Columns[0].Width    = 400;
            GridStockMMRec2.Columns[1].Width    = 200;
            GridStockMMRec2.Columns[2].Width    = 400;
            GridStockMMRec2.Columns[3].Width    = 200;
            GridStockMMRec2.Columns[4].Width    = 100;
            GridStockMMRec2.Columns[5].Width    = 300;
            GridStockMMRec2.Columns[6].Width    = 150;
            GridStockMMRec2.Columns[7].Width    = 300;
            GridStockMMRec2.Columns[8].Width    = 100;
            GridStockMMRec2.Columns[9].Width    = 300;

           



        }

        /*   //// 컬럼의 수정 여부를 지정
           GridStockMMRec2.Columns["iLROW"].ReadOnly = true;
           GridStockMMRec2.Columns["ROWNAME"].ReadOnly = true;
           GridStockMMRec2.Columns["ROWACCOUNT"].ReadOnly = true;
           GridStockMMRec2.Columns["ROWSTOCK"].ReadOnly = true;
           GridStockMMRec2.Columns["ROWEA"].ReadOnly = true;   */
    

        // 메서드 오버라이드 (Override)
        // virture로 상속을 허락 한 메서드를
        // 각 화면에 맞는 기능으로 변경하여 메서드를 재 정의하고 사용하는 방식.
        public override void Inquire()
        {

            if (DBHelper(false) == false) return;

            try
            {
                
             
                // 사용자 정보 조회

                // Adapter에 SQL 프로시져 이름과 접속 정보 등록.
                Adapter = new SqlDataAdapter("TB_STOCK_S", Connect);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // 파라미터의 개수 별로 함수에 아규먼트 등록
                // Adapter.SelectCommand.Parameters.AddWithValue("ROWNAME", txtRowName.Text);
                Adapter.SelectCommand.Parameters.AddWithValue("LOTNO", txtLotNo.Text);
               




                // 데이터 베이스 처리 시 C#으로 반환할 값을 담는 변수.
                Adapter.SelectCommand.Parameters.AddWithValue("LANG", "KO");
                Adapter.SelectCommand.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
                Adapter.SelectCommand.Parameters.AddWithValue("RS_MSG", "").Direction = ParameterDirection.Output;

                // Adapter 실행
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                // 결과값을 그리드뷰에 표현.
                GridStockMMRec2.DataSource = dtTemp;

               
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

    }
}


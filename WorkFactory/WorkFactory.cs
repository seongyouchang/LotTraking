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

namespace WorkFactory
{
    public partial class WorkFactory : Form
    {
        
        public WorkFactory()
        {
            InitializeComponent();
        }

        private void WorkFactory_Load(object sender, EventArgs e)
        {
            /*****************기본 그리드 내역 셋팅 *******************/
            DataTable dtGrid = new DataTable();
            dtGrid.Columns.Add("WID", typeof(char));                    // 원자재 번호
            dtGrid.Columns.Add("FSPACE", typeof(char));            //  원자재 명
            dtGrid.Columns.Add("FWORKER", typeof(char));       //  원자재 거래처
            dtGrid.Columns.Add("FSTART", typeof(DateTime));      // 원자재 입고일자
            dtGrid.Columns.Add("FFINISH", typeof(DateTime));                   //원자재 재고 개수
            dtGrid.Columns.Add("FEA", typeof(char));                   //원자재 재고 개수




            // 빈 컬럼 테이블 그리드에 매칭. (DataSource : 테이블 형식의 데이터를 표현하는 속성)
            Grid1.DataSource = dtGrid;

            // 그리드 컬럼 명칭(Text) 설정 // 번호로 지정 가능

            // 생산지시일자, 설비 추가 고려해야함
            Grid1.Columns["WID"].HeaderText = "작업지시번호";
            Grid1.Columns["FSPACE"].HeaderText = "작업장";
            Grid1.Columns["FWORKER"].HeaderText = "작업자";
            Grid1.Columns["FSTART"].HeaderText = "작업시작시간";
            Grid1.Columns["FFINISH"].HeaderText = "작업종료시간";
            Grid1.Columns["FEA"].HeaderText = "생산수량";

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            
        }

   

  

        private void btnWorkOrder_Click_1(object sender, EventArgs e)
        {
            SWorkOrder sWorkOrder = new SWorkOrder();
            sWorkOrder.ShowDialog();
        }

        private void btnWorker_Click_1(object sender, EventArgs e)
        {
            Worker worker = new Worker();
            worker.ShowDialog();
        }

        private void btnMaterial_Click_1(object sender, EventArgs e)
        {
            Material material = new Material();
            material.ShowDialog();
        }
    }
}

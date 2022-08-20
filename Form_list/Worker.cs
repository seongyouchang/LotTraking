using System.Windows.Forms;
using Assamble;
using System.Data.SqlClient;

/************************************
 *현장생산등록에 작업자 투입입니다.
 *생성자 : 김동욱
 *2022-08-20
 *************************************/


namespace Form_list
{
    public partial class Worker : Form
    {
        // 1. 공통 클래스 (데이터 베이스 커넥터)
        private SqlConnection Connect; // 데이터베이스에 접속 하는 정보를 관리하는 클래스.

        // 2. SELECT (조회)를 실행하여 데이터베이스에서 데이터를 받아오는 클래스.
        private SqlDataAdapter Adapter;

        // 3. Insert, Update, Delete 명령을 전달할 클래스
        private SqlTransaction tran; // 데이터베이스 데이터 관리 권한 부여.

 

        public Worker()
        {
            InitializeComponent();
        }


    }
}

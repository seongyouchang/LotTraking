using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// SQL Server 접속 클래스 라이브러리.
using System.Data.SqlClient;
using Assamble;

/*********************************************************
 * Name : M02_PassWordChange
 * Desc : 사용자 비밀번호 변경
 * -------------------------------------------------------
 * Date : 2022-08-02
 * Author: 성유창
 * Desc : 최초 프로그램 작성
 * *******************************************************/
namespace MainForms
{
    public partial class M02_PassWordChange : Form
    {

        // 1. 공통 sql 서버 처리 클래스 (데이터 베이스 커넥터)
        private SqlConnection Connect;


        // 2. insert, update, delete, 의 명령을 전달 할 클래스.
        SqlTransaction Transaction; // 데이터베이스 데이터 관리 권한 부여 클래스
        SqlCommand cmd;             // 데이터베이스 명령 전달 클래스.

        public M02_PassWordChange()
        {
            InitializeComponent();
        }

        private void btnPWChange_Click(object sender, EventArgs e)
        {
            try
            {
                // 밸리데이션 (validation)
                // . 응용 프로그램 실행 시 발생할 수 있는 예외상황을 미리 인지하여
                // . 예외상황 발생 경우를 사용자에게 전달하는 로직을 구현 함으로서
                //   시스템 오류를 막고, 프로그램 신뢰도를 높여주는 개발 방법.

                // 1. 텍스트 박스의 필수 입력값 여부 확인.

                // 에러 메세지를 받을 변수 지정.
                string sMessage = string.Empty; // 빈값을 초기화 하는 명령어. ""

                if (txtUserID.Text == "")
                {
                    sMessage += "사용자 ID";
                }
                if (txtPerPW.Text == "")
                {
                    sMessage += "이전 비밀번호";
                }
                if (txtChangPW.Text == "")
                {
                    sMessage += "변경할 비밀번호";
                }
                if (sMessage != "")
                {
                    MessageBox.Show($"{sMessage}을(를) 입력하지 않았습니다.");
                    return;
                }

                //사용자 ID와 이전 비밀번호가 일치하는지 확인
                //Log In 할때 로직 동일

                string sCon = Commons.cDbCon;

                // 데이터베이스 접속 경로 설정 및 커넥터 객체 초기화.
                Connect = new SqlConnection(sCon);
                 
                // 데이터베이스 연결 상태 확인
                Connect.Open();
                if (Connect.State != ConnectionState.Open)
                {
                    MessageBox.Show("데이터베이스 연결에 실패하였습니다.");
                    return;
                }

                // 데이터베이스에 전달할 변수 지정.
                // 그냥 사용해도 되지만 깔끔하게 하기 위해서 변수 사용
                string sLonInId = txtUserID.Text;
                string sPerPw = txtPerPW.Text;
                string sNewPW = txtChangPW.Text;

                //기존 비밀번호 비교 SQL
                string sFindUserImfo = $"SELECT * FROM TB_USER WHERE USERID = '{sLonInId}' AND PW = '{sPerPw}'";

                // 데이터 베이스에 전달 할 클래스 생성 및 초기화.
                SqlDataAdapter Adapter = new SqlDataAdapter(sFindUserImfo, Connect);

                // DB 로 부터 결과 값을 받을 빈 DataTable 자료형 생성
                DataTable dtTemp = new DataTable();

                // Adapter 실행 및 결과 값 데이터 테이블에 등록
                Adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0 )
                {
                    MessageBox.Show("ID 또는 이전 비밀번호를 잘못 입력하였습니다.");
                    return;
                }

                // ID와 이전 비밀번호가 모두 동일할 경우 비밀번호 변경 여부 메세지 표현 및 결과에 따른 진행여부 결정.
                if (MessageBox.Show("해당 비밀번호로 변경을 진행하시겠습니까?", 
                    "비밀번호 변경",
                    MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                #region <비밀번호 변경 UPDATE 로직 실행>
                // 비밀 번호 변경 가능상태. 비밀번호 변경 로직 실행
                // 비밀 번호 변경 데이터 테이블의 PW 컬럼 데이터를 UPDATE
                // INSERT, UPDATE, DELETE, 

                // 1. 트랜잭션 선언.
                Transaction = Connect.BeginTransaction();

                // 2. insert, update, delete 명령을 전달 할 Command 클래스 객체 초기화.
                cmd = new SqlCommand();

                // 3. 생성한 트랜잭션을 Command에 등록.
                cmd.Transaction = Transaction;

                // 4. 명령전달 Command가 수행할 데이터 베이스 주소 등록.
                cmd.Connection = Connect;

                // 5. 비밀번호 변경 SQL 문 변수에 등록.
                string sUpdateSql = "UPDATE TB_User        " +
                                    $"SET PW = '{sNewPW}'       " +
                                    $"WHERE USERID = '{sLonInId}'";

                cmd.CommandText = sUpdateSql;

                // 6. SQL문 실행.
                cmd.ExecuteNonQuery();

                // 7. 데이터 등록 승인
                Transaction.Commit();
                MessageBox.Show("정상적으로 변경되었습니다.");

                //this 비밀번호 변경 폼을 닫는다.
                this.Close();
               

                #endregion




            }
            catch (Exception ex)
            {
                Transaction.Rollback();
                MessageBox.Show(ex.ToString());
                
            }
            finally
            {
                Connect.Close();
            }
        }
    }
}

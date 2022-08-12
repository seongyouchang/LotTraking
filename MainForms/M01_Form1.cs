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

/*--------------------------------------------------------------------------------------------------------
 * NAME : M01_LogIn
 * DESC : 시스템 로그인
 * -------------------------------------------------------------------------------------------------------
 * DATE   : 2022.08.01
 * AUTHOR : 성유창 
 * DESC   : 최초 프로그램 작성
 */

// WinformApplication 강의의 목표
// C# .NET FramWork WinForm의 기본 도구화 프로그래밍 문법을 사용하여 개발 솔루션의 프레임을 만들어보고
// 시스템 개발 프레임의 코어 소스 원리를 이해 하고 기능을 습득한다.
 

namespace MainForms
{
    public partial class M01_Form1 : Form
    {
        // SQL Server 커넥터 (MSSQL에 접속 할 수 있는 경로 및 접속 기능을 가진 클래스)
        private SqlConnection connect = null;

        public M01_Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DoLogIN();
        }

        private void DoLogIN()
        {
            try
            {
                // 로그인 정보 확인후 로그인 가능여부 체크

                // 1. 데이터 베이스 접속 경로 설정
                Commons com = new Commons();
                string sCon = Commons.cDbCon;
                // 2. Connect에 접속 경로 매핑
                connect = new SqlConnection(sCon);

                // 3. 데이터베이스 연결 상태 확인.
                connect.Open();

                if (connect.State != ConnectionState.Open)
                {
                    MessageBox.Show("데이터베이스 연결에 실패하였습니다.");
                    return;
                }

                #region <ID PW 전체 관리>
                //// 사용자 ID와 비밀번호 일치 여부 확인 후 이름과 비밀번호 찾는 SQL 구문 작성
                //string sFindUserInfo = "SELECT USERNAME,PW                          " +
                //                       "  FROM TB_USER                              " +
                //                       $"  WHERE USERID = '{txtUserID.Text}'        " +
                //                       $"    AND PW     = '{txtPW.Text}'            ";

                ////데이터 베이스에 sql 구문 전달 후 반환되는 값 받아오기.
                //SqlDataAdapter Adapter = new SqlDataAdapter(sFindUserInfo, connect);

                //// Adapter 실행 및 결과값 반환.
                //DataTable dtTemp = new DataTable();
                //Adapter.Fill(dtTemp);

                //// ID와 PW를 정확하게 입력하였을 경우
                //// dtTemp에 데이터가 존재한다.

                ////if (dtTemp.Rows.Count != 0)
                ////{
                ////    //ID와 PW를 정확하게 입력하여 로그인 데이터가 존재한다.
                ////    MessageBox.Show("님 반갑습니다.");
                ////}
                ////else
                ////{
                ////    MessageBox.Show("ID 또는 PW를 잘못 입력 하였습니다.");
                ////    return;

                ////}

                //if (dtTemp.Rows.Count == 0)
                //{
                //    MessageBox.Show("ID 또는 PW가 잘못되었습니다.");
                //    return;
                //}

                //MessageBox.Show($"{dtTemp.Rows[0]["USERNAME"]}님 반갑습니다.");


                #endregion

                #region <ID PW 각자 관리>
                // 사용자 ID와 비밀번호 일치 여부 확인 후 이름과 비밀번호 찾는 SQL 구문 작성
                string sFindUserInfo = "SELECT USERNAME,PW                          " +
                                       "  FROM TB_USER                              " +
                                       $"  WHERE USERID = '{txtUserID.Text}'        ";   
                                       

                //데이터 베이스에 sql 구문 전달 후 반환되는 값 받아오기.
                SqlDataAdapter Adapter = new SqlDataAdapter(sFindUserInfo, connect);

                // Adapter 실행 및 결과값 반환.
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                // ID와 PW를 정확하게 입력하였을 경우
                // dtTemp에 데이터가 존재한다.

                //if (dtTemp.Rows.Count != 0)
                //{
                //    //ID와 PW를 정확하게 입력하여 로그인 데이터가 존재한다.
                //    MessageBox.Show("님 반갑습니다.");
                //}
                //else
                //{
                //    MessageBox.Show("ID 또는 PW를 잘못 입력 하였습니다.");
                //    return;

                //}

                if (dtTemp.Rows.Count == 0)
                {
                    MessageBox.Show("ID가 잘못되었습니다.");
                    return;
                }
                else
                {
                    if (txtPW.Text != Convert.ToString(dtTemp.Rows[0]["PW"])) 
                    {
                        MessageBox.Show("PW가 잘못되었습니다.");
                        return;
                    }
                }

                Commons.cLogInId = txtUserID.Text;
                Commons.cUserName = Convert.ToString(dtTemp.Rows[0]["USERNAME"]);
                MessageBox.Show($"{Commons.cUserName}님 반갑습니다.");
                //this.Tag = true;
                Commons.cLogInSF = true;
                this.Close();

                #endregion

                //로그인 성공 시 메인화면을 띄워줌.
               
            }
            catch (Exception ex)
            {
                // 소스코딩 내용이 오류가 떴을 때 
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                // 데이터베이스와 접속을 끊어준다.
                connect.Close();
            }
        }

        private void txtPW_KeyDown(object sender, KeyEventArgs e)
        {
            //비밀번호 입력 후 엔터키 입력 시 로그인 기능 구현
            if (e.KeyCode == Keys.Enter)
            {
                DoLogIN();
            }
        }

        private void btnPWChange_Click(object sender, EventArgs e)
        {
             M02_PassWordChange M01 = new M02_PassWordChange();
            //M01.Show(); // 화면을 활성화 하고 다음 로직을 바로 수행

            this.Visible = false; // 기존 로그인창을 잠깐 안보이는 것처럼 처리
            M01.ShowDialog(); // 화면이 활성화 된 이후 화면이 닫히기 전까지 아래로직을 수행하지 않는다.
            this.Visible = true; // 로그인창 활성화
            //테스트
        }
    }
}

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
// 스레드를 사용하기 위한 라이브러리 참조.
using System.Threading;
// 폼 리스트 라이브러리 참조
using Form_list;
// 어셈블리 파일을 사용하기 위한 라이브러리 참조.
using System.Reflection;

namespace MainForms
{
    public partial class M03_MainForm : Form
    {
        private Thread ThNowTime; // 현재 시각을 표현 할 스레드 객체.
        public M03_MainForm()
        {
            M01_Form1 M01 = new M01_Form1();
            // show 쓰면 메인창이랑 같이 뜸
            M01.ShowDialog();
            //if (Convert.ToBoolean(M01.Tag) != true)
           
            if (Commons.cLogInSF != true)
                {
                //프로그램 종료
                //this.Close(); 객체 생성 이전에 종료가 되므로 시스템 오류가 발생함.

                // 프로그램 강제 종료
                Environment.Exit(0);
            }

            InitializeComponent();

            // 스레드 (Thread)
            // 프로세스 내부에서 생성되는 실제로 작업을 하는 주체를 추가 생성함으로서
            // 하나의 메인 프로세스 외에 여러가지 일을 동시에 수행하는 기능
            // 메인 프로세스와는 별개로 개별적인 리소스(컴퓨터상의 메모리)를 가지고 구동, - 비동기식)
        }

        private void M03_MainForm_Load(object sender, EventArgs e)
        {
            // 접속 한 사용자의 이름을 표시.
            stsUserName.Text = Commons.cUserName;

            // 현재 일시를 표현할 Thread 시작.

            // 스레드가 실행 할 로직을 담은 시작 객체.
            ThreadStart ThStart = new ThreadStart(GetNowTime);

            // 실제 스레드가 포함해야할 내용.
            ThNowTime = new Thread(ThStart);
            ThNowTime.Start();

        }

        private void GetNowTime()
        {
            // 현재 일시 표시 하는 스레드가 실행할 로직.
            while (true)
            {
                Thread.Sleep(1000);
                stsNowDateTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
                
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            stsUserName.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}" ,DateTime.Now);
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            // 어플리케이션 종료.
            // Environment.Exit(0); // 현시점에서 해당 어플리케이션을 강제 종료한다 .( 불안정 종료 , 스레드는 남아있음)
            Application.Exit(); // 정말 종료하겠냐고 물을 때 예를 누르면 내가 만들어둔 스레드 까지 안전하게 종료하면서 같이 종료해야 메모리도 좋고 프로그램도 좋음
            // 종료이벤트를 통하여 종료여부 메세지 및 스레드 등 관련 프로세스를 제거하여 안정적으로 응용프로그램을 종료할 수 있도록 한다.
        }

        private void M03_MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 종료 버튼 또는 x 버튼을 클릭 하였을 경우
            // 1. 종료 여부 메세지
            // 2. 관련 프로세스 제거.

            // 확인 후 프로세스 종료.
            if (MessageBox.Show("프로그램을 종료하시겠습니까?", "프로그램 종료", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            if (ThNowTime.IsAlive) ThNowTime.Abort();
        }

        private void M_TEST_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // MDI
            // Multiple Document Interface의 약자로
            // 한개의 창에서 여러가지 작업을 할 수 있는 인터페이스를 뜻한다.

            // 1. CS(클래스) 파일을 직접 호출.
            //Form01_MDITest Form01 = new Form01_MDITest();
            //Form01.MdiParent = this;
            //Form01.Show();

            //// 2. 어셈블리 프로그램 파일로 클래스 호출.
            //// Form_List.DLL을 호출하여 클래스 표현.
            //Assembly assem = Assembly.LoadFrom($"{Application.StartupPath}\\Form_list.DLL");
            //// 클릭한 메뉴의 CS 타입 확인.
            //Type typeForm = assem.GetType($"Form_list.{e.ClickedItem.Name}", true);
            //// Form 형식으로 전환.
            //Form FormMdi = (Form)Activator.CreateInstance(typeForm);
            //// MDI 설정
            //FormMdi.MdiParent = this;
            //// MDI 화면 활성화
            //FormMdi.Show();

            // 3. 탭 컨트롤 페이지에 메뉴 선택화면 등록 및 활성화.
            // Form_list.DLL 파일 호출
            Assembly Assem = Assembly.LoadFrom($"{Application.StartupPath}\\Form_list.DLL");
            // 클릭한 메뉴의 클래스 타입 설정
            Type typeForm = Assem.GetType("Form_list." + e.ClickedItem.Name.ToString(), true);

            // 파일을 Form 클래스로 형변환
            Form FormMdi = (Form)Activator.CreateInstance(typeForm);



            // 1. 클릭한 메뉴의 CS 이름. (고정된 값이니 for 문안에 있으면 리소스를 많이 잡아먹음)
            string sCmenuName = e.ClickedItem.Name.ToString();


            // 4. 중복화면 호출 시 기존 화면 활성화

            for (int i = 0; i < tacMyTab.TabCount; i++)
            {
                
                // 2. 오픈되어있는 페이지의 이름.
                string sTpageName = tacMyTab.TabPages[i].Name;
                if (sCmenuName == sTpageName)
                {
                    tacMyTab.SelectedTab = tacMyTab.TabPages[i];
                    return;
                }
            }

            tacMyTab.AddPage(FormMdi);
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            // 탭 컨트롤에 오픈되어있는 탭 페이지를 제거.
            if (tacMyTab.TabPages.Count == 0) return;
            tacMyTab.SelectedTab.Dispose();
        }


        // 공통적으로 사용할 이벤트라서 직접 메소드를 만들어 줌 (원래는 디자인에서 더블클릭)
        private void ToolButton_Click(object sender, EventArgs e)
        {
            // 공통으로 호출 할 이벤트 메서드 생성 후
            // 모든 버튼의 이벤트와 연동.

            // 각각의 툴바버튼을 클릭 하였을 때 수행되는 공통 로직 구현.

            // EventArgs : 클릭한 이벤트에 대한 속성 정보를 가지고 있음
            // sender : 이벤트를 호출하는 컨트롤에 대한 정보를 가지고 있음.

            // Object 컨트롤 Sender 를 ToolStripButton 으로 캐스팅.
            ToolStripButton tsButton = (ToolStripButton)sender;
            if (tsButton.Name == "tsbSearch") ChildCommand("SEARCH") ;
            else if (tsButton.Name == "tsbDelete") ChildCommand("DELETE");
            else if (tsButton.Name == "tsbAdd") ChildCommand("ADD");
            else if (tsButton.Name == "tsbSave") ChildCommand("SAVE");
        }

        private void ChildCommand(string Command)
        {
            if (tacMyTab.TabPages.Count == 0) return;
            //툴바를 클릭하였을때 
            //활성화된 화면에서 각각의 기능을 수행하는 메서드를 호출

            // 활성화 되어있는 현재 페이지 정보 추출. (as / is)
            // is
            // 만약 활성화된 탭의 메인 컨트롤이 BaseChildForm 형식 이라면 (형변환이 가능하다면)
            //  Child 객체로 인스턴스 화 (객체화) 하라
            //if (!(tacMyTab.SelectedTab.Controls[0] is BaseChlidForm)) return;
            //BaseChlidForm Child = (BaseChlidForm)tacMyTab.SelectedTab.Controls[0];
            // as
            // 현재 활성화 된 화면이 BaseChildForm 형식 이라면
            // Child로 객체화 하고 아니면 null 값을 반환하라.
            BaseChlidForm Child = tacMyTab.SelectedTab.Controls[0] as BaseChlidForm;
            if (Child == null) return;


            switch (Command)
            {
                case "SEARCH":
                    Child.Inquire();
                    break;
                case "ADD":
                    Child.DoNew();
                    break;
                case "DELETE":
                    Child.Delete();
                    break;
                case "SAVE":
                    Child.Save();
                    break;
            }
        }
    }
}

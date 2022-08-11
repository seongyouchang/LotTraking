using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assamble
{

    // 사용자 정의 컨트롤 생성.
    public class MyTabControl : TabControl
    {
        // 클래스 상속 (MyTabControl 클래스는 TabControl 클래스를 상속 받는다.)
        // 상속
        // . 생성되어 있는 클래스의 기능을 그대로 물려받고
        //   새로운 기능을 추가 할 수 있다.

        // Tabcontrol의 기능을 상속 받아
        // 메인화면의 메뉴에서 호출 할 화면을 탭 페이지 클래스에 등록하여
        // 탭 컨트롤에 표현하는 메서드를 새로 생성.

        public void AddPage(Form NewForm)
        {
            // 탭 컨트롤 > 탭 페이지 = 오픈 될 화면
            if (NewForm == null) return; //인자로 받은 폼이 없을 경우 실행중지
            NewForm.TopLevel = false; // 인자로 받은 폼이 최상위 개체가 아님을 선언. (MDI 형식의 Child로 지정 될 수 있도록 함)

            TabPage page = new TabPage(); // 탭페이지 객체 생성
            page.Controls.Clear();        // 탭페이지 초기화
            page.Controls.Add(NewForm);   // 페이지에 폼 추가.
            page.Text = NewForm.Text;     // 활성화될 화면에서 지정한 Text로 메뉴이름 설정
            page.Name = NewForm.Name;     // 활성화될 화면에서 설정한 이름으로 탭페이지 고유 명칭 설정

            base.TabPages.Add(page);      // 탭컨트롤에 페이지를 추가한다.
            NewForm.Show();               // 인자로 받은 폼을 활성화 한다.
            base.SelectedTab = page;      // 탭 컨트롤에서 현재 선택된 페이지를 호출한 폼이 있는 페이지로 활성화 한다.
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assamble
{
    public partial class BaseChlidForm : Form, iChildCommands
    {
        public BaseChlidForm()
        {
            InitializeComponent();
        }

        // Virtual
        // 상속받은 클래스에서 해당 메서드를 재 정의 할 수 있도록 허용
        // BaseChildForm을 상속 받아 개발에 상속될 Form에서 기능을 재 정의하여
        // 각 화면마다 목적에 맞는 기능을 수행 할 수 있도록 함.

        public virtual void Inquire()
        {
            // 상속된 폼이 조회 버튼을 누를 때 기본적으로 수행해야하는 내용
            MessageBox.Show("조회를 시작합니다.");
        }
        public virtual void DoNew()
        {
            // 상속된 폼이 추가 버튼을 누를 때 기본적으로 수행해야하는 내용

        }
        public virtual void Delete()
        {
            // 상속된 폼이 삭제 버튼을 누를 때 기본적으로 수행해야하는 내용

        }
        public virtual void Save()
        {
            // 상속된 폼이 저장 버튼을 누를 때 기본적으로 수행해야하는 내용

        }

    }
}

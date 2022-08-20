using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assamble;
// 스레드를 사용하기 위한 라이브러리 참조.
using System.Threading;
// 폼 리스트 라이브러리 참조
using Form_list;
// 어셈블리 파일을 사용하기 위한 라이브러리 참조.
using System.Reflection;

namespace Form_list
{
    public partial class Material : Form
    {
        public Material()
        {
            InitializeComponent();
        }

        private void Material_FormClosing(object sender, FormClosingEventArgs e)
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

           
        }
    }
}

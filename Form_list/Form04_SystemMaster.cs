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

namespace Form_list
{
    public partial class Form04_SystemMaster : BaseChlidForm
    {
        public Form04_SystemMaster()
        {
            InitializeComponent();
        }
        public override void Inquire()
        {
            MessageBox.Show("시스템 관리 조회 기능입니다.");
        }
    }
}

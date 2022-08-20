using System.Windows.Forms;

namespace Form_list
{
    public partial class SWorkOrder : Form
    {
        public SWorkOrder()
        {
            InitializeComponent();
        }

        private void btnProcess_S_Click(object sender, System.EventArgs e)
        {
            ProcessGrid.Visible = true;
            
            
        }
    }
}

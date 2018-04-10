using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Claymore_watcher
{
    public partial class AddDialog : Form
    {

        public string result = "";
        public bool resultValid = false;

        public AddDialog()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!resultValid) return;
            this.DialogResult = DialogResult.OK;
            this.Close();
            return;
        }

        private void checkResultValid()
        {
            resultValid = true;
            if (txtHost.Text.Trim().Length<2) { resultValid = false; txtHost.BackColor = Color.LightPink;  } else    txtHost.BackColor = Color.WhiteSmoke;
            int ptest = 0;
            int.TryParse(txtPort.Text, out ptest);
            if (ptest<1 || ptest> 65534) { resultValid = false; txtPort.BackColor = Color.LightPink;  } else txtPort.BackColor = Color.WhiteSmoke;
            if (!resultValid) return;
            result = txtHost.Text.Trim() + ":" + ptest.ToString();
            resultValid = true;
        }

        private void txtHost_TextChanged(object sender, EventArgs e)
        {
            checkResultValid();
        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {
            checkResultValid();
        }
    }
}

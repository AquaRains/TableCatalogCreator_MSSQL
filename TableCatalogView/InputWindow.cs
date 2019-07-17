using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableCatalogView
{
    public partial class InputWindow : Form
    {
        public ConnectionInfo ConnectionInfo;

        public InputWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.ConnectionInfo.Server = txt1.Text;
            this.ConnectionInfo.Port = txt2.Text;
            this.ConnectionInfo.DBName = txt3.Text;
            this.ConnectionInfo.ID = txt4.Text;
            this.ConnectionInfo.Pass = txt5.Text;

            this.DialogResult = DialogResult.OK;
        }
    }
}

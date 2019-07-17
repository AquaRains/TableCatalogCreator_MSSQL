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
    public partial class Form1 : Form
    {
        public ConnectionInfo ConnectionInfo { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
     
        }

        private void ListTbName_Click(object sender, EventArgs e)
        {
            GetTableData();
            GetTableConstraint();
        }

        private void GetTableConstraint()
        {
            string s = listTbName.SelectedItem.ToString();
            txtConstraint.Text = string.Empty;
            txtConstraintCol.Text = string.Empty;

            StringBuilder sbConst = new StringBuilder();
            StringBuilder sbConstCol = new StringBuilder();

            DataTable dt = DB.GetTableConstraints(ConnectionInfo, s);

            Dictionary<string, string> constraints = new Dictionary<string, string>();

            foreach (DataRow dr in dt.Rows)
            {
                string name = dr["Constraint Name"].ToString();
                string col = dr["Column Name"].ToString();
                if (!constraints.ContainsKey(name))
                {
                    constraints.Add(name, col);
                }
                else
                {
                    constraints[name] += "," + col;
                }                    
            }

            foreach(var pair in constraints)
            {
                txtConstraint.Text += pair.Key + Environment.NewLine;
                txtConstraintCol.Text += pair.Value + Environment.NewLine;
            }
        }
        private void GetTableData()
        {
            int i = listTbName.SelectedIndex;
            string s = listTbName.SelectedItem.ToString();

            txtTbName.Text = s;

            DataTable dt = DB.GetTableInfo(ConnectionInfo, s);
                      

            txtColno.Text = string.Empty;
            txtColName.Text = string.Empty;
            txtDesc.Text = string.Empty;
            txtType.Text = string.Empty;
            txtPk.Text = string.Empty;
            txtNull.Text = string.Empty;

            StringBuilder sbNo = new StringBuilder();
            StringBuilder sbNm = new StringBuilder();
            StringBuilder sbDc = new StringBuilder();
            StringBuilder sbTy = new StringBuilder();
            StringBuilder sbPk = new StringBuilder();
            StringBuilder sbnl = new StringBuilder();

            foreach(DataRow dr in dt.Rows)
            {
                sbNo.AppendLine(dr["RNUM"].ToString());
                sbNm.AppendLine(dr["COLUMN_NAME"].ToString());
                sbDc.AppendLine(dr["COLUM_COMMENT"].ToString());
                sbTy.AppendLine(dr["COLUMN_LENGTH"].ToString());
                sbPk.AppendLine(dr["PK_YN"].ToString());
                sbnl.AppendLine(dr["NOT_NULL"].ToString());
            }

            txtColno.Text = sbNo.ToString();
            txtColName.Text = sbNm.ToString();
            txtDesc.Text = sbDc.ToString();
            txtType.Text = sbTy.ToString();
            txtPk.Text = sbPk.ToString();
            txtNull.Text = sbnl.ToString();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using(InputWindow inputWindow = new InputWindow())
            {
                if(inputWindow.ShowDialog() == DialogResult.OK)
                {
                    this.ConnectionInfo = inputWindow.ConnectionInfo;
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DataTable dt = DB.GetTableList(ConnectionInfo);

            var list = (from DataRow dr in dt.Rows select dr["Name"].ToString()).ToArray();

            listTbName.Items.Clear();
            listTbName.Items.AddRange(list);
        }
    }
}

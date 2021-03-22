using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleWinApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            InitializeSetting();
            InitializeMenus();
        }

        private void InitializeSetting()
        {
            //SampleWinAppResources.Language.Culture = new System.Globalization.CultureInfo("zh-TW");
            SampleWinAppResources.Language.Culture = new System.Globalization.CultureInfo("en");
        }

        private void InitializeMenus()
        {
            var btn = new Button();
            btn.Text = SampleWinAppResources.Language.Test;
            btn.Dock = DockStyle.Top;
            btn.Click += (object sender, EventArgs e) =>
            {
                MessageBox.Show(SampleWinAppResources.Language.Hello);
            };

            splitContainer.Panel1.Controls.Add(btn);
        }
    }
}

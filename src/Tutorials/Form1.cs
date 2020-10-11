using KTCommon;
using KTCommon.Logger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tutorials
{
    public partial class Form1 : Form
    {
        private ILogger _logger = new FileLog("log", ".log", "Log", "");

        public Form1()
        {
            InitializeComponent();

            string[] levlNames = Enum.GetNames(typeof(LogLevel));
            cboLogLevel.DataSource = levlNames;
            cboLogLevel.SelectedIndex = 0;
        }

        private void btnWriteLog_Click(object sender, EventArgs e)
        {
            LogLevel level = (LogLevel)(cboLogLevel.SelectedIndex);
            string message = txtMessage.Text;

            _logger.Log(message, level);
        }
    }
}

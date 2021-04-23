using SampleWinApp.Views;
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
            CreateButton(SampleWinAppResources.Language.Test,
                () => 
                {
                    MessageBox.Show(SampleWinAppResources.Language.Hello);
                });

            CreateButton("KtMmfEventBus",
                () =>
                {
                    splitContainer.Panel2.Controls.Clear();
                    splitContainer.Panel2.Controls.Add(new KtMmfEventBusPage());
                });

            CreateButton("KtMemoryMappedFile",
                () =>
                {
                    splitContainer.Panel2.Controls.Clear();
                    splitContainer.Panel2.Controls.Add(new KtMemoryMappedFilePage());
                });

            CreateButton("AsynchronousSocket",
                () =>
                {
                    splitContainer.Panel2.Controls.Clear();
                    splitContainer.Panel2.Controls.Add(new AsynchronousSocketPage());
                });
        }

        private void CreateButton(string text, Action action)
        {
            var btn = new Button();
            btn.Text = text;
            btn.Dock = DockStyle.Top;
            btn.Click += (object sender, EventArgs e) =>
            {
                action?.Invoke();
            };

            splitContainer.Panel1.Controls.Add(btn);
        }
    }
}

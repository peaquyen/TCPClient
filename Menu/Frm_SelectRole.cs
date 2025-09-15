using System;
using System.Windows.Forms;

namespace Menu
{
    public partial class Frm_SelectRole : Form
    {
        // Thuộc tính trả về lựa chọn
        public string SelectedRole { get; private set; } = string.Empty;

        public Frm_SelectRole()
        {
            InitializeComponent();

            // Nút Server
            Button btnServer = new Button
            {
                Text = "Server",
                Left = 40,
                Top = 30,
                Width = 100
            };

            // Nút TCP Client
            Button btnClient = new Button
            {
                Text = "TCP Client",
                Left = 160,
                Top = 30,
                Width = 100
            };

            btnServer.Click += (s, e) =>
            {
                SelectedRole = "Server";
                DialogResult = DialogResult.OK; // báo về Form cha
                Close();
            };

            btnClient.Click += (s, e) =>
            {
                SelectedRole = "TCPClient";
                DialogResult = DialogResult.OK;
                Close();
            };

            Controls.Add(btnServer);
            Controls.Add(btnClient);

            Text = "Chọn vai trò";
            StartPosition = FormStartPosition.CenterParent;
            Size = new System.Drawing.Size(340, 150);
        }
    }
}

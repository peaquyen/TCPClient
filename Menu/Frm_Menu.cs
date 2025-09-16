using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Menu
{
    public partial class Frm_Menu : Form
    {
        public Frm_Menu()
        {
            InitializeComponent();
            btn_play.Click += Btn_play_Click;
            btn_exit.Click += Btn_exit_Click;
            btn_halloffame.Click += Btn_halloffame_Click;
            this.BackgroundImageLayout = ImageLayout.Stretch;

        }

        // Xử lý nút Play → chọn vai trò → chạy exe tương ứng
        private void Btn_play_Click(object sender, EventArgs e)
        {
            using (Frm_SelectRole selectRole = new Frm_SelectRole())
            {
                if (selectRole.ShowDialog() == DialogResult.OK)
                {
                    string basePath = AppDomain.CurrentDomain.BaseDirectory;
                    string serverExe = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\Server\bin\Debug\net9.0-windows7.0\Server.exe"));
                    string clientExe = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\TCPClient\bin\Debug\net9.0-windows7.0\TCPClient.exe"));

                    try
                    {
                        if (selectRole.SelectedRole == "Server")
                        {
                            Process.Start(serverExe);
                        }
                        else if (selectRole.SelectedRole == "TCPClient")
                        {
                            Process.Start(clientExe);
                        }
                        else
                        {
                            MessageBox.Show("Vai trò không hợp lệ.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Không thể chạy ứng dụng: {ex.Message}");
                    }
                }
            }
        }

        // Nút Exit: Thoát game
        private void Btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Nút Hall of Fame
        private void Btn_halloffame_Click(object sender, EventArgs e)
        {
            Frm_HallOfFame hof = new Frm_HallOfFame();
            hof.Show();
            this.Hide(); // Ẩn menu nếu muốn
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {

        }
    }
}

using SimpleTcp;
using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // cần cài MySql.Data qua NuGet
using System.Collections.Generic; // để dùng List<string>


namespace Server
{
    public partial class Frm_Server : Form
    {
        SimpleTcpServer server;
        private static ArrayList allWords = new ArrayList();
        private string ourWord = "";
        private static int counter = 15;
        private string connStr = "server=127.0.0.1;user=root;password=Pea27.com;database=word_by_word;";


        public Frm_Server() { InitializeComponent(); }

        private void Form1_Load(object sender, EventArgs e)
        {
            btn_send.Enabled = false;

            // Lấy địa chỉ IPv4 của máy hiện tại để hiển thị
            string localIp = GetLocalIPv4();
            txt_info.Text = $"Local IP: {localIp}{Environment.NewLine}" +
                           $"Server listening on ALL interfaces (0.0.0.0:9000){Environment.NewLine}";

            // Bind trên tất cả interface, port 9000
            server = new SimpleTcpServer("0.0.0.0:9000");
            server.Events.ClientConnected += Events_ClientConnected;
            server.Events.ClientDisconnected += Events_ClientDisconnected;
            server.Events.DataReceived += Events_DataReceived;
        }
        private void Events_ClientConnected(object sender, ClientConnectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txt_info.Text += $"{e.IpPort} connected.{Environment.NewLine}";
                // Lưu IP client hiện tại để gửi tin nhắn
                if (string.IsNullOrEmpty(txt_clientip.Text))
                    txt_clientip.Text = e.IpPort;
            });
        }

        private void Events_ClientDisconnected(object sender, ClientDisconnectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txt_info.Text += $"{e.IpPort} disconnected.{Environment.NewLine}";
                txt_clientip.Text = "";
            });
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                string msg = Encoding.UTF8.GetString(e.Data);
                if (msg == "------| TIME IS UP! PLAYER 1 WINS |------")
                {
                    btn_send.Enabled = false;
                    timer1.Stop();
                    lblTimer.Text = "15";
                    txt_info.Text += $"{msg}{Environment.NewLine}";
                    SaveWinnerToDB("PLAYER 1", allWords.Cast<string>().ToList());
                    allWords.Clear(); // reset ván mới

                }
                else
                {
                    txt_info.Text += $"PLAYER 2: {msg}{Environment.NewLine}";
                    allWords.Add(msg);
                    counter = 15;
                    timer1.Start();
                }
            });
        }

        private void SendWord()
        {
            allWords.Add(ourWord);
            server.Send(txt_clientip.Text, ourWord);
            txt_info.Text += $"PLAYER 1: {ourWord}{Environment.NewLine}";
            txt_word.Clear();
            timer1.Stop();
            counter = 15;
            lblTimer.Text = counter.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = (--counter).ToString();
            if (counter == 0)
            {
                timer1.Stop();
                btn_send.Enabled = false;
                txt_info.Text += $"------| TIME IS UP! PLAYER 2 WINS |------{Environment.NewLine}";
                server.Send(txt_clientip.Text, $"------| TIME IS UP! PLAYER 2 WINS |------");

                // Thêm đoạn này sau khi xử lý hết giờ
                var result = MessageBox.Show("Start a new round?", "Replay", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    counter = 15;
                    lblTimer.Text = counter.ToString();
                    btn_send.Enabled = true;
                    timer1.Stop(); // Đảm bảo timer reset trước khi bắt đầu lại
                }
            }
        }


        // Hàm phụ: lấy IPv4
        private string GetLocalIPv4()
        {
            return Dns.GetHostEntry(Dns.GetHostName())
                      .AddressList
                      .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork)
                      ?.ToString() ?? "127.0.0.1";
        }
        private void SaveWinnerToDB(string winner, List<string> opponents)
        {
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO halloffame (winner_username, play_datetime, opponents) VALUES (@w, @dt, @o)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@w", winner);
                    cmd.Parameters.AddWithValue("@dt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@o", string.Join(",", opponents));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            server.Start();
            txt_info.Text += $"Server started at {DateTime.Now}{Environment.NewLine}";
            btn_start.Enabled = false;
            btn_send.Enabled = true;
        }

        private void txt_info_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            if (!server.IsListening || string.IsNullOrEmpty(txt_word.Text) || string.IsNullOrEmpty(txt_clientip.Text)) return;

            ourWord = txt_word.Text.ToLower();
            if (allWords.Count > 0)
            {
                string lastWord = allWords[allWords.Count - 1].ToString();
                if (lastWord[^2..] == ourWord[..2] && !allWords.Contains(ourWord))
                {
                    lblWarning.Text = "";
                    SendWord();
                }
                else lblWarning.Text = "Invalid word!";
            }
            else SendWord();
        }

        private void lb_server_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void txt_ip_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnChatSend_Click_Server(object sender, EventArgs e)
        {

        }

        private void TxtChat_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}

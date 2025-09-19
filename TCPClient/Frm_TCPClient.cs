using MySql.Data.MySqlClient;
using SimpleTcp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace TCPClient
{
    public partial class Frm_TCPClient : Form
    {
        public Frm_TCPClient()
        {
            InitializeComponent();
        }
        SimpleTcpClient client;
        private string connStr = "server=127.0.0.1;user=root;password=YOURPASS;database=yourdb;";

        private void SaveWinnerToDB(string winner, List<string> opponents)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO halloffame (winner_username, play_datetime, opponents) VALUES (@winner, @dt, @opps)";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@winner", winner);
                    cmd.Parameters.AddWithValue("@dt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@opps", string.Join(",", opponents));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static ArrayList allWords = new ArrayList();
        private string ourWord = "";
        private static int counter = 15;
        private void btnSend_Click1(object sender, EventArgs e)
        {
            if (client.IsConnected)
            {
                if (!string.IsNullOrEmpty(btxt_word.Text))
                {
                    ourWord = btxt_word.Text.ToLower();
                    if (allWords.Count > 0)
                    {
                        if (allWords[allWords.Count - 1].ToString().Substring(allWords[allWords.Count - 1].ToString().Length - 2) == ourWord.Substring(0, 2) && !(allWords.Contains(ourWord)))
                        {
                            lblWarning.Text = "";
                            allWords.Add(ourWord);
                            client.Send(ourWord);
                            txtb_info.Text += $"PLAYER 2: {ourWord}{Environment.NewLine}";
                            btxt_word.Text = string.Empty;
                            timer1.Stop();
                            counter = 15;
                            lblTimer.Text = counter.ToString();
                        }
                        else lblWarning.Text = "This word is not valid! Please, enter an another word.";
                    } // COUNT >0
                    else
                    {
                        allWords.Add(ourWord);
                        client.Send(ourWord);
                        txtb_info.Text += $"PLAYER 2: {ourWord}{Environment.NewLine}";
                        btxt_word.Text = string.Empty;
                        timer1.Stop();
                        counter = 15;
                        lblTimer.Text = counter.ToString();
                    }
                }
            }
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {

                if (client == null)
                {
                    client = new SimpleTcpClient(txtb_ipserver.Text);
                    client.Events.Connected += Events_Connected;
                    client.Events.DataReceived += Events_DataReceived;
                    client.Events.Disconnected += Events_Disconnected;
                }

                client.Connect();
                btn_send.Enabled = true;
                btn_connect.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Your connection proccess is wrong!{Environment.NewLine}Server ip and port format must be '127.0.0.1:9000' (LAN dùng IP host như 192.168.x.x:9000)");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //client = new (txtb_ipserver.Text);
            //client.Events.Connected += Events_Connected;
            //client.Events.DataReceived += Events_DataReceived;
            //client.Events.Disconnected += Events_Disconnected;
            //btn_send.Enabled = false;

            // --- Đăng ký event cho nút Left Server (đã thêm) ---
            btn_leftserver.Click += btn_leftserver_Click;
        }

        private void Events_Disconnected(object sender, ClientDisconnectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtb_info.Text += $"Server disconnected.{Environment.NewLine}";
            });
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (Encoding.UTF8.GetString(e.Data) == "------| TIME IS UP! PLAYER 2 WINS |------")
                {
                    btn_send.Enabled = false;
                    timer1.Stop();
                    lblTimer.Text = "15";
                    txtb_info.Text += $"{Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";
                }
                else
                {
                    txtb_info.Text += $"PLAYER 1: {Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";
                    allWords.Add(Encoding.UTF8.GetString(e.Data));
                    counter = 15;
                    timer1.Start();
                }
            });
        }

        private void Events_Connected(object sender, ClientConnectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtb_info.Text += $"Server connected.{Environment.NewLine}";
            });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = (--counter).ToString();
            if (counter == 0)
            {
                timer1.Stop();
                btn_send.Enabled = false;
                txtb_info.Text += $"------| TIME IS UP! PLAYER 1 WINS |------{Environment.NewLine}";
                client.Send($"------| TIME IS UP! PLAYER 1 WINS |------");
            }
        }

        private void btnConnect_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (client == null)
                {
                    client = new SimpleTcpClient(txtb_ipserver.Text);
                    client.Events.Connected += Events_Connected;
                    client.Events.DataReceived += Events_DataReceived;
                    client.Events.Disconnected += Events_Disconnected;
                }

                client.Connect();
                btn_send.Enabled = true;
                btn_connect.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Your connection proccess is wrong!{Environment.NewLine}Server ip and port format must be '127.0.0.1:9000'");
            }
        }

        private void txtIp_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (client.IsConnected)
            {
                if (!string.IsNullOrEmpty(btxt_word.Text))
                {
                    ourWord = btxt_word.Text.ToLower();
                    if (allWords.Count > 0)
                    {
                        if (allWords[allWords.Count - 1].ToString().Substring(allWords[allWords.Count - 1].ToString().Length - 2) == ourWord.Substring(0, 2) && !(allWords.Contains(ourWord)))
                        {
                            lblWarning.Text = "";
                            allWords.Add(ourWord);
                            client.Send(ourWord);
                            txtb_info.Text += $"PLAYER 2: {ourWord}{Environment.NewLine}";
                            btxt_word.Text = string.Empty;
                            timer1.Stop();
                            counter = 15;
                            lblTimer.Text = counter.ToString();
                        }
                        else lblWarning.Text = "This word is not valid! Please, enter an another word.";
                    } // COUNT >0
                    else
                    {
                        allWords.Add(ourWord);
                        client.Send(ourWord);
                        txtb_info.Text += $"PLAYER 2: {ourWord}{Environment.NewLine}";
                        btxt_word.Text = string.Empty;
                        timer1.Stop();
                        counter = 15;
                        lblTimer.Text = counter.ToString();
                    }
                }
            }
        }

        // --- HÀM LEFT SERVER (đã thêm) ---
        private void btn_leftserver_Click(object sender, EventArgs e)
        {
            // 1) Ngắt kết nối
            try
            {
                if (client != null && client.IsConnected) client.Disconnect();
            }
            catch { }

            // 2) Tìm class Frm_Menu mà không cần namespace
            try
            {
                var frmType = AppDomain.CurrentDomain
                    .GetAssemblies()
                    .SelectMany(x => x.GetTypes())
                    .FirstOrDefault(t => t.Name == "Frm_Menu");

                if (frmType != null)
                {
                    Form menu = (Form)Activator.CreateInstance(frmType);
                    menu.Show();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Frm_Menu. Kiểm tra tên class.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở Frm_Menu: " + ex.Message);
            }

            // 3) Đóng form hiện tại
            this.Close();
        }


        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void btn_leftserver_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnChatSend_Click(object sender, EventArgs e)
        {

        }
    }
}

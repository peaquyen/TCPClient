using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Menu
{
    public partial class Frm_HallOfFame : Form
    {
        private string connectionString = "server=localhost;user=root;password=Pea27.com;database=word_by_word;";

        public Frm_HallOfFame()
        {
            InitializeComponent();
            this.BackgroundImageLayout = ImageLayout.Stretch;
            LoadHallOfFame();
            btn_back.Click += Btn_back_Click;
        }

        /// <summary>
        /// Sự kiện nút Back: quay về Frm_Menu.
        /// </summary>
        private void Btn_back_Click(object sender, EventArgs e)
        {
            Frm_Menu menu = new Frm_Menu();
            menu.Show();
            this.Hide(); // Ẩn form hiện tại
        }

        /// <summary>
        /// Tải dữ liệu bảng halloffame từ MySQL và hiển thị lên DataGridView.
        /// </summary>
        private void LoadHallOfFame()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT winner_username AS 'Winner', play_datetime AS 'DateTime', opponents AS 'Opponents' FROM halloffame ORDER BY play_datetime DESC";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }

                // Tuỳ chọn: căn chỉnh DataGridView đẹp hơn
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải Hall of Fame: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

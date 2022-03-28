using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace hotel
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string myConnectionString = "server=localhost;database=hotel;uid=root;pwd=;";
            
            MySqlConnection con = new MySqlConnection(myConnectionString);
            try
            {
                con.Open();

                String username = txt_Username.Text;
                String password = txt_Password.Text;

                MySqlCommand cmd = new MySqlCommand("select username,password from user where username='" + username + "'and password='" + password+ "'", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Home viewHome = new Home();
                    viewHome.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu. Vui lòng nhập lại.");
                }


                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open connection!");
            }

            

        }
    }
}

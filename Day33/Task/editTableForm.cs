using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _30_1
{
    public partial class editTableForm : Form
    {
        public SqlConnection connection = null;
        public string type = "";
        public string id = "";
        public editTableForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (type == "edit")
            {
                Form1 form1 = new Form1();
                string name = textBox1.Text;
                string surname = textBox2.Text;
                string secondName = textBox3.Text;

                string query = "Update  Туристы " +
                    $"SET Имя='{name}', Фамилия={surname}, Отчество={secondName} " +
                    $"WHERE Код_туриста = {id}";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                this.Close();
                type = "";
            }
            else
            {
                Form1 form1 = new Form1();
                string name = textBox1.Text;
                string surname = textBox2.Text;
                string secondName = textBox3.Text;

                string query = "Insert Into Туристы " +
                    $"(Имя, Фамилия, Отчество) Values({name}, {surname}, {secondName})";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                this.Close();
            }
        }
    }
}

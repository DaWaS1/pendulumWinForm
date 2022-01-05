using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace pendulumWinForm
{
    public partial class MainFrm : Form
    {
        public static string connectuionString { get; set; }
        public MainFrm()
        {
            connectuionString = @"Data Source = (localdb)\ProjectModels;Database = music;";
            InitializeComponent();
        }
        



        private void MainFrm_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            comboBox2.Enabled = false;
            button2.Enabled = false;            
            CB1Fill();
        }

        private void CB2Fill()
        {
            comboBox2.Enabled = true;   
            using (var c = new SqlConnection(connectuionString))
            {
                c.Open();
                var r = new SqlCommand(
                    "SELECT title " +
                    "FROM Albums;",
                    c).ExecuteReader();
                while (r.Read())
                {
                    comboBox2.Items.Add(r[0]);
                }
            }
        }

        private void CB1Fill()
        {
            using (var c = new SqlConnection(connectuionString))
            {
                c.Open();
                var r = new SqlCommand(
                    "SELECT artist " +
                    "FROM Albums " +
                    "GROUP BY artist;",
                    c).ExecuteReader();
                while (r.Read())
                {
                    comboBox1.Items.Add(r[0]);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CB2Fill();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            int index = comboBox2.SelectedIndex;
            switch (index)
            {
                case 0:
                    pictureBox1.Image = Image.FromFile("..\\..\\Res\\hold_your_colour.jpg");
                    using (var c = new SqlConnection(connectuionString))
                    {
                        dataGridView1.Rows.Clear();
                        c.Open();
                        var r = new SqlCommand(
                            "SELECT release " +
                            "FROM Albums " +
                            "WHERE title = 'Hold Your Colour';",
                            c).ExecuteReader();
                        while (r.Read())
                        {
                            DateTime dateTime = Convert.ToDateTime(r[0]);
                            richTextBox1.Text = dateTime.ToString("yyyy. MMM dd.");
                        }
                        c.Close();

                        c.Open();
                        var r2 = new SqlCommand(
                            "SELECT length " +
                            "FROM Tracks " +
                            "WHERE album = 'pnd1';",
                            c).ExecuteReader();
                        double sumTIme = 0.0;
                        while (r2.Read())
                        {
                            string tim = Convert.ToString(r2[0]);
                            sumTIme = tim.Select(time => TimeSpan.Parse(tim).TotalHours).Sum();
                        }
                        richTextBox1.AppendText("\t" + (double)sumTIme + " órányi zene");
                        c.Close();

                        c.Open();
                        var r3 = new SqlCommand(
                            "SELECT title, length " +
                            "FROM Tracks " +
                            "WHERE album = 'pnd1';",
                            c).ExecuteReader();
                        while (r3.Read())
                        {
                            dataGridView1.Rows.Add(r3[0], r3[1]);
                        }
                        c.Close();
                        textBox1.Enabled = true;
                    }


                    break;
                case 1:
                    pictureBox1.Image = Image.FromFile("..\\..\\Res\\in_silico.jpg");
                    using (var c = new SqlConnection(connectuionString))
                    {
                        dataGridView1.Rows.Clear();
                        c.Open();
                        var r = new SqlCommand(
                            "SELECT release " +
                            "FROM Albums " +
                            "WHERE title = 'In Silico';",
                            c).ExecuteReader();
                        while (r.Read())
                        {
                            DateTime dateTime = Convert.ToDateTime(r[0]);
                            richTextBox1.Text = dateTime.ToString("yyyy. MMM dd.");
                        }
                        c.Close();
                        c.Open();
                        var r2 = new SqlCommand(
                            "SELECT length " +
                            "FROM Tracks " +
                            "WHERE album = 'pnd2';",
                            c).ExecuteReader();
                        double sumTIme = 0.0;
                        while (r2.Read())
                        {
                            string tim = Convert.ToString(r2[0]);
                            sumTIme = tim.Select(time => TimeSpan.Parse(tim).TotalHours).Sum();
                        }
                        richTextBox1.AppendText("\t" + (double)sumTIme + " órányi zene");
                        c.Close();
                        c.Open();
                        var r3 = new SqlCommand(
                            "SELECT title, length " +
                            "FROM Tracks " +
                            "WHERE album = 'pnd2';",
                            c).ExecuteReader();
                        while (r3.Read())
                        {
                            dataGridView1.Rows.Add(r3[0], r3[1]);
                        }
                        c.Close();
                        textBox1.Enabled = true;

                    }
                    break;
                case 2:
                    pictureBox1.Image = Image.FromFile("..\\..\\Res\\immersion.jpg");
                    using (var c = new SqlConnection(connectuionString))
                    {
                        dataGridView1.Rows.Clear();
                        c.Open();
                        var r = new SqlCommand(
                            "SELECT release " +
                            "FROM Albums " +
                            "WHERE title = 'Immersion';",
                            c).ExecuteReader();
                        while (r.Read())
                        {
                            DateTime dateTime = Convert.ToDateTime(r[0]);
                            richTextBox1.Text = dateTime.ToString("yyyy. MMM dd.");
                        }
                        c.Close();
                        c.Open();
                        var r2 = new SqlCommand(
                            "SELECT length " +
                            "FROM Tracks " +
                            "WHERE album = 'pnd3';",
                            c).ExecuteReader();
                        double sumTIme = 0.0;
                        while (r2.Read())
                        {
                            string tim = Convert.ToString(r2[0]);
                            sumTIme = tim.Select(time => TimeSpan.Parse(tim).TotalHours).Sum();
                        }
                        richTextBox1.AppendText("\t" + (double)sumTIme + " órányi zene");
                        c.Close();
                        c.Open();
                        var r3 = new SqlCommand(
                            "SELECT title, length " +
                            "FROM Tracks " +
                            "WHERE album = 'pnd1';",
                            c).ExecuteReader();
                        while (r3.Read())
                        {
                            dataGridView1.Rows.Add(r3[0], r3[1]);
                        }
                        c.Close();
                        textBox1.Enabled = true;

                    }
                    break;
            }







        }
        public string link;
        public string cellValue;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            using (var c = new SqlConnection(connectuionString))
            {
                //string cellValue = "";
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    cellValue = Convert.ToString(selectedRow.Cells["titleColum"].Value);
                }

                c.Open();
                var r = new SqlCommand(
                    "SELECT url " +
                    "FROM Tracks " +
                    $"WHERE title = '{cellValue}';",
                    c).ExecuteReader();
                while (r.Read())
                {
                    if (r[0]+"" != "null")
                    {
                        linkLabel1.Text = "https://youtu.be/" + r[0];
                    }
                    else
                    {
                        button2.Enabled = true;
                        linkLabel1.Text = "NOPE";
                    }
                    link = linkLabel1.Text;
                }
                c.Close();
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(linkLabel1.Text);

            }
            catch (Exception E)
            {
                MessageBox.Show("No link for this song! ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewLink newLink = new NewLink();
            newLink.ShowDialog();

            using (var c = new SqlConnection(connectuionString))
            {
               c.Open();
                var r = new SqlCommand(
                    "UPDATE Tracks " +
                    $"SET url = '{NewLink.txtb}' " +
                    $"WHERE title = '{cellValue}';",
                    c).ExecuteNonQuery();
            }



        }
    }
}

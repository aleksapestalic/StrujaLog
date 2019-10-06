using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrujaLog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string query;
        private void bInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string mesec = DateTime.Now.Month.ToString();
                string godina = DateTime.Now.Year.ToString();
                string dan = DateTime.Now.Day.ToString();
                query = "INSERT INTO kWh (stanje, mesec, godina, dan) VALUES (" + tbPodatak.Text + ", " + mesec + ", " + godina + ", " + dan + ");";

                DB.execute(query);
                List<string> rows = DB.select6("SELECT * FROM kWh");
                listBox1.Items.Clear();
                int[] ids = popuniListBox(listBox1, rows);
            }
            catch (Exception)
            {
                MessageBox.Show("Error!", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<string> rows = DB.select6("SELECT * FROM kWh");
            popuniListBox(listBox1, rows);
        }

        int[] popuniListBox(ListBox lb, List<string> rows)
        {
            try
            {
                List<int> ids = new List<int>();
                foreach (var item in rows)
                {
                    lb.Items.Add(item.Split('|')[0] + ".    stanje: " + item.Split('|')[1] + ", dan: " + item.Split('|')[2] + ", mesec: " + item.Split('|')[3] + ", godina: " + item.Split('|')[4] + ", placeno " + item.Split('|')[5]);
                    ids.Add(Convert.ToInt32(item.Split('|')[0]));
                }
                int[] id = ids.ToArray();
                return id;
            }
            catch (Exception)
            {
                MessageBox.Show("Greška u unosu!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        
    }
}

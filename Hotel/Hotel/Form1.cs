using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ReservationClass c = new ReservationClass();

        private void lblNama_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            c.Name = tbNama.Text;
            c.IDNumber = tbIDNumber.Text;
            c.Email = tbEmail.Text;
            c.PhoneNumber = tbPhoneNumber.Text;
            c.TypeRoom = cbTypeRoom.Text;
            c.CheckIn = dtpCheckIn.Text;
            c.CheckOut = dtpCheckOut.Text;
            c.LengthStay = tbLengthStay.Text;

            bool success = c.Insert(c);
            if(success==true)
            {
                MessageBox.Show("Check In succeded");
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to check in. Please try again.");
            }
            DataTable dt = c.Select();
            dgvBookingList.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = c.Select();
            dgvBookingList.DataSource = dt;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void Clear()
        {
            tbNama.Text = "";
            tbIDNumber.Text = "";
            tbEmail.Text = "";
            tbPhoneNumber.Text = "";
            cbTypeRoom.Text = "";
            dtpCheckIn.Text = "";
            dtpCheckOut.Text = "";
            tbLengthStay.Text = "";
            tbCariNama.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            c.BookingID = int.Parse(tbCariNama.Text);
            c.Name = tbNama.Text;
            c.IDNumber = tbIDNumber.Text;
            c.Email = tbEmail.Text;
            c.PhoneNumber = tbPhoneNumber.Text;
            c.TypeRoom = cbTypeRoom.Text;
            c.CheckIn = dtpCheckIn.Text;
            c.CheckOut = dtpCheckOut.Text;

            bool success = c.Edit(c);
            if(success==true)
            {
                MessageBox.Show("Reservation has been successfully edited.");
                DataTable dt = c.Select();
                dgvBookingList.DataSource = dt;
                Clear();
            }
            else
            {
                MessageBox.Show("Edit failed. Please try again.");
            }
        }

        private void dgvBookingList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            tbNama.Text = dgvBookingList.Rows[rowIndex].Cells[1].Value.ToString();
            tbIDNumber.Text = dgvBookingList.Rows[rowIndex].Cells[2].Value.ToString();
            tbEmail.Text = dgvBookingList.Rows[rowIndex].Cells[3].Value.ToString();
            tbPhoneNumber.Text = dgvBookingList.Rows[rowIndex].Cells[4].Value.ToString();
            cbTypeRoom.Text = dgvBookingList.Rows[rowIndex].Cells[5].Value.ToString();
            dtpCheckIn.Text = dgvBookingList.Rows[rowIndex].Cells[6].Value.ToString();
            dtpCheckOut.Text = dgvBookingList.Rows[rowIndex].Cells[7].Value.ToString();
            tbLengthStay.Text = dgvBookingList.Rows[rowIndex].Cells[8].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            c.BookingID = Convert.ToInt32(tbCariNama.Text);
            bool success = c.Delete(c);
            if(success==true)
            {
                MessageBox.Show("Reservation has been successfully deleted. Your total price is Rp8000000");
                DataTable dt = c.Select();
                dgvBookingList.DataSource = dt;
                Clear();
            }

            else
            {
                MessageBox.Show("Failed to delete reservation. Please try again.");
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
    }
}

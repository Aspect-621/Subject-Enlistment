using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form3 : Form
    {
        public static string fName = "";
        public static string mName = "";
        public static string lName = "";
        public static string course = "";
        public static string yearSem = "";
        public static string studentId = "";
        public static string fullName = "";
        public static string yrLevel = "";
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Check if any of the required fields are empty
            if (string.IsNullOrWhiteSpace(firstName.Text) ||
                string.IsNullOrWhiteSpace(lastName.Text) ||
                string.IsNullOrWhiteSpace(courseName.Text) ||
                string.IsNullOrWhiteSpace(selectSem.Text) ||
                string.IsNullOrWhiteSpace(studentNumber.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Error");
                return; 
            }


            lName = lastName.Text;
            fName = firstName.Text;
            mName = middleName.Text;
            course = courseName.Text;
            fullName = fName + " " + mName + " " + lName;

            yrLevel = "";
            if (radioButton1.Checked)
            {
                yrLevel = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                yrLevel = radioButton2.Text;
            }
            else if (radioButton3.Checked)
            {
                yrLevel = radioButton3.Text;
            }
            else if (radioButton4.Checked)
            {
                yrLevel = radioButton4.Text;
            }

            yearSem = selectSem.Text;
            studentId=studentNumber.Text;

            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }
    }
}

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
    public partial class Form2 : Form
    {
        public string Subjects { get; set; }
        public string Types { get; set; }
        public int Units { get; set; }
        public string OthersFee { get; set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void buttonSubject1_Click(object sender, EventArgs e)
        {
            Subjects = "APPLICATIONS DEVT & EMERGING TECHNOLOGIES";
            Types = "LECTURE";
            Units = 2;
            this.Close();
        }

        private void buttonSubject2_Click(object sender, EventArgs e)
        {
            Subjects = "APPLICATIONS DEVT & EMERGING TECHNOLOGIES";
            Types = "LABARATORY";
            Units = 1;
            this.Close();
        }

        private void buttonSubject4_Click(object sender, EventArgs e)
        {
            Subjects = "APPLIED PHYSICS FOR IT";
            Types = "LECTURE";
            Units = 2;
            this.Close();
        }

        private void buttonSubject3_Click(object sender, EventArgs e)
        {
            Subjects = "APPLIED PHYSICS FOR IT";
            Types = "LABARATORY";
            Units = 1;
            this.Close();
        }

        private void buttonSubject6_Click(object sender, EventArgs e)
        {
            Subjects = "COMPUTER PROGRAMMING 2";
            Types = "LECTURE";
            Units = 2;
            this.Close();
        }

        private void buttonSubject5_Click(object sender, EventArgs e)
        {
            Subjects = "COMPUTER PROGRAMMING 2";
            Types = "LABARATORY";
            Units = 1;
            this.Close();
        }

        private void buttonSubject8_Click(object sender, EventArgs e)
        {
            Subjects = "OBJECT ORIENTED PROG'G.";
            Types = "LECTURE";
            Units = 2;
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void buttonSubject7_Click(object sender, EventArgs e)
        {
            Subjects = "OBJECT ORIENTED PROG'G.";
            Types = "LABARATORY";
            Units = 1;
            this.Close();
        }

        private void buttonSubject9_Click(object sender, EventArgs e)
        {
            Subjects = "COMPUTING 2";
            Types = "LECTURE";
            Units = 3;
            this.Close();
        }

        private void buttonSubject10_Click(object sender, EventArgs e)
        {
            Subjects = "SCIENCE, TECHNOLOGY AND SOCIETY";
            Types = "LECTURE";
            Units = 3;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Subjects = "PATHFIT2: EXERCISE-BASED FITNESS ACTIVITIES";
            Types = "LECTURE";
            OthersFee = "pathfit";
            Units = 2;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Subjects = "CIVIC WELFARE TRAINING SRVCE 2";
            Types = "LECTURE";
            Units = 3;
            OthersFee = "cwts";
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        
        int x = 0;

        Label[] subjects = new Label[12];
        Label[] units = new Label[12];
        Label[] types = new Label[12];

        //For computing the tuition and total units
        int[] unitLab = new int[12];
        int[] unitLec = new int[12];
        int sumUnitLab = 0;
        int sumUnitLec = 0;


        double
            totDueTuition = 0,
            totTuition = 0,
            downpaymentNum = 0,
            tuitionLecNum = 0,
            tuitionLabNum = 0,
            aduChronicle = 66,
            athletics = 927,
            audioLibrary = 83,
            ausg = 50,
            culturalFee = 450,
            energyCost = 3990,
            guidance = 402,
            insuranceFee = 68,
            labUsageFee = 0,
            learningManagementSystem = 788,
            libraryFee = 1594,
            medicalDentral = 525,
            registration = 237,
            rso = 50,
            studentActivitiesFee = 275,
            studentNurturanceFee = 362,
            techFee = 348,
            testPapers = 158;
        double cwtsDefault = 0;
        double peDefault = 0;
        // Keeps track of enlisted subjects
        bool[] subjectEnlisted = new bool[12];

        public Form1()
        {
            InitializeComponent();
            fullNameMain.Text = Form3.fullName;
            yearLevelMain.Text = Form3.yrLevel;
            studentNumberMain.Text = Form3.studentId;
            programMain.Text = Form3.course;
            semesterMain.Text = Form3.yearSem;

            subjects[0] = subject1;
            subjects[1] = subject2;
            subjects[2] = subject3;
            subjects[3] = subject4;
            subjects[4] = subject5;
            subjects[5] = subject6;
            subjects[6] = subject7;
            subjects[7] = subject8;
            subjects[8] = subject9;
            subjects[9] = subject10;
            subjects[10] = subject11;
            subjects[11] = subject12;

            units[0] = unit1;
            units[1] = unit2;
            units[2] = unit3;
            units[3] = unit4;
            units[4] = unit5;
            units[5] = unit6;
            units[6] = unit7;
            units[7] = unit8;
            units[8] = unit9;
            units[9] = unit10;
            units[10] = unit11;
            units[11] = unit12;


            types[0] = type1;
            types[1] = type2;
            types[2] = type3;
            types[3] = type4;
            types[4] = type5;
            types[5] = type6;
            types[6] = type7;
            types[7] = type8;
            types[8] = type9;
            types[9] = type10;
            types[10] = type11;
            types[11] = type12;

    
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void enlistButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();

            string receivedDataSubject = form2.Subjects;
            string receivedDataSubjectType = form2.Types;
            int receivedDataUnit = form2.Units;
            string othersFee = form2.OthersFee;

            CheckForCwtsAndPe();

            
            if (!string.IsNullOrEmpty(receivedDataSubject) && !IsSubjectEnlisted(receivedDataSubject, receivedDataSubjectType))
            {
                
                subjects[x].Text = receivedDataSubject;
                types[x].Text = receivedDataSubjectType;
                units[x].Text = receivedDataUnit.ToString();
                
                x++;
            }

            else if (IsSubjectEnlisted(receivedDataSubject, receivedDataSubjectType))
            {
                MessageBox.Show("Subject is already enlisted!");
            }
            ComputeTotUnits();
            ComputeForPayments();
            UpdateComboBox();
            CheckForCwtsAndPe();
        }

        private void CheckForCwtsAndPe()
        {
            bool cwtsEnlisted = false;
            bool peEnlisted = false;

            for (int i = 0; i < x; i++)
            {
                if (subjects[i].Text == "CIVIC WELFARE TRAINING SRVCE 2")
                {
                    cwtsEnlisted = true;
                    break; 
                }
            }

            for (int i = 0; i < x; i++)
            {
                if (subjects[i].Text == "PATHFIT2: EXERCISE-BASED FITNESS ACTIVITIES")
                {
                    peEnlisted = true;
                    break; 
                }
            }

            
            if (cwtsEnlisted)
            {
                double priceCwts = 2283;
                cwtsPrice.Text = priceCwts.ToString("0.00");
                cwtsDefault = priceCwts;
            }
            else
            {
                cwtsDefault = 0;
                cwtsPrice.Text = cwtsDefault.ToString("0.00");
            }

            if (peEnlisted)
            {
                double pricePe = 927;
                pePrice.Text = pricePe.ToString("0.00");
                peDefault = pricePe;
            }
            else
            {
                peDefault = 0;
                pePrice.Text = peDefault.ToString("0.00");
            }
        }
        private void ComputeTotUnits()
        {
            sumUnitLab = 0;
            sumUnitLec = 0;
            for (int i = 0; i < x; i++)
            {
                if (types[i].Text == "LABARATORY")
                {
                    unitLab[i] = int.Parse(units[i].Text);
                    sumUnitLab += unitLab[i];
                }
                else if (types[i].Text == "LECTURE")
                {
                    unitLec[i] = int.Parse(units[i].Text);
                    sumUnitLec += unitLec[i];
                }
            }
            int totUnits = sumUnitLab + sumUnitLec;

            if (totUnits >= 18)
            {
                studentType.Text = "Regular";
            }
            else if (totUnits <= 0)
            {
                studentType.Text = "";
            }
            else
            {
                studentType.Text = "Irregular";
            }

            totalUnitLabel.Text = totUnits.ToString();
        }

        private bool IsSubjectEnlisted(string subjectName, string subjectType)
        {
            for (int i = 0; i < x; i++)
            {
                if (subjects[i].Text == subjectName && types[i].Text == subjectType)
                {
                    return true;
                }
            }
            return false;


        }

        private void confirmEnlist_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateComboBox();
        }

        private void UpdateComboBox()
        {

            if (comboBox1.Text == "Full Payment")
            {
                double totPerTerm = 0;
                totPerTerm = totDueTuition / 1;
                term1.Text = "Term 1:";
                term2.Text = "";
                term3.Text = "";
                term4.Text = "";
                term5.Text = "";

                payOne.Text = totPerTerm.ToString("0.00");
                payTwo.Text = "";
                payThree.Text = "";
                payFour.Text = "";
                payFive.Text = "";
            }

            else if (comboBox1.Text == "Three Term Payment")
            {
                double totPerTerm = 0;
                totPerTerm = totDueTuition / 3;
                term1.Text = "Term 1:";
                term2.Text = "Term 2:";
                term3.Text = "Term 3:";
                term4.Text = "";
                term5.Text = "";

                payOne.Text = totPerTerm.ToString("0.00");
                payTwo.Text = totPerTerm.ToString("0.00");
                payThree.Text = totPerTerm.ToString("0.00");
                payFour.Text = "";
                payFive.Text = "";

            }
            else if (comboBox1.Text == "Four Term Payment")
            {
                double totPerTerm = 0;
                totPerTerm = totDueTuition / 4;
                term1.Text = "Term 1:";
                term2.Text = "Term 2:";
                term3.Text = "Term 3:";
                term4.Text = "Term 4:";
                term5.Text = "";

                payOne.Text = totPerTerm.ToString("0.00");
                payTwo.Text = totPerTerm.ToString("0.00");
                payThree.Text = totPerTerm.ToString("0.00");
                payFour.Text = totPerTerm.ToString("0.00");
                payFive.Text = "";
            }
            else if (comboBox1.Text == "Five Term Payment")
            {
                double totPerTerm = 0;
                totPerTerm = totDueTuition / 5;
                term1.Text = "Term 1:";
                term2.Text = "Term 2:";
                term3.Text = "Term 3:";
                term4.Text = "Term 4:";
                term5.Text = "Term 5:";

                payOne.Text = totPerTerm.ToString("0.00");
                payTwo.Text = totPerTerm.ToString("0.00");
                payThree.Text = totPerTerm.ToString("0.00");
                payFour.Text = totPerTerm.ToString("0.00");
                payFive.Text = totPerTerm.ToString("0.00");

            }
        }

        private void deleteLastEnlisted_Click(object sender, EventArgs e)
        {
            x--;
            CheckForCwtsAndPe();
            subjects[x].Text = "Subject";
            types[x].Text = "Subject Type";
            units[x].Text = "Units";
            ComputeTotUnits();
            ComputeForPayments();
            UpdateComboBox();
        }


        private void ComputeForPayments()
        {
            int tuitionLecPrice = 1474,
                tuitionLabPrice = 2790,
                labUsagePrice = 2500;
            tuitionLecNum = tuitionLecPrice * sumUnitLec;
            tuitionLec.Text = tuitionLecNum.ToString("0.00");
            tuitionLabNum = tuitionLabPrice * sumUnitLab;
            tuitionLab.Text = tuitionLabNum.ToString("0.00");
            labUsageFee = labUsagePrice * sumUnitLab;
            labFee.Text= labUsageFee.ToString("0.00");
            totTuition = cwtsDefault + peDefault+ tuitionLecNum + tuitionLabNum + aduChronicle + athletics + audioLibrary + ausg + culturalFee + energyCost + guidance + insuranceFee + labUsageFee + learningManagementSystem + libraryFee + medicalDentral + registration + rso + studentActivitiesFee + studentNurturanceFee + techFee + testPapers;
            assessAmt.Text = totTuition.ToString("0.00");
            downpaymentNum = (totTuition * 0.30 * -1);
            downpayment.Text = downpaymentNum.ToString("0.00");
            totDueTuition = totTuition + downpaymentNum;
            totDue.Text = totDueTuition.ToString("0.00");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkAllotmentSystem
{
    public partial class Form1 : Form
    {
        

        
        internal Manager tempmanager = new Manager();

        skills[] skillset = { skills.DatabaseKnowledge, skills.TimeManagement, skills.AIExperience, skills.Leadership, skills.Communication };
        public Form1()
        {
            InitializeComponent();

        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            Label[] labels = new Label[] { label10, label9, label8, label7, label5 };
            Employee employee = new Employee();

            employee.employeeName = empname.Text;
            employee.workLoad = 1;
            employee.workCompletionTime = 1f; //connect this to another program as employee determines work done
            employee.experience = int.Parse(experience.Text);
            
            CheckBox[] EmployeeSkills = new CheckBox[] { checkBox6, checkBox7, checkBox8, checkBox9, checkBox10 };
            
            checklistInit(EmployeeSkills, false,employee,null);

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    tempmanager.employeeList[i] = employee;
                }
                catch
                {
                    break;
                }
            }
            WriteOnScreen(labels, empname.Text);
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "STATISTICS";
            foreach (Work i in tempmanager.workList)
            {
                tempmanager.workAssigner();
                tempmanager.scheduler();
            }
            foreach (Employee j in tempmanager.employeeList)
            {
                label11.Text = j.workEligibilty.ToString();
                label1.Text += "\n" + j.employeeName + ": Work = ";
                foreach (Work i in j.assignedWork.Distinct())
                {
                    label1.Text += i.WorkName + " ";
                }
            }


        }

        private void button3_Click(object sender, EventArgs e)

        {
            Work enteredWork = new Work();
            CheckBox[] WorkSkills = new CheckBox[] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5 };
            enteredWork.WorkName = workname.Text;
            checklistInit(WorkSkills, true,null,enteredWork);
            for(int i = 0; i < 5; i++)
            {
                try { 
                tempmanager.workList[i] = enteredWork;
                }
                catch
                {
                    break;
                }
            }
            Label[] labels = new Label[] { label6, label15, label13, label14, label12 };
            WriteOnScreen(labels, workname.Text);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void checklistInit(CheckBox[] CheckList ,bool iswork,Employee employee, Work enteredWork)
        {
            
            foreach(CheckBox i in CheckList)
            {
                if (i.Checked && iswork)
                {
                    enteredWork.requiredSkills.Add(skillset[i.TabIndex]);
                }else if(i.Checked && !iswork)
                {
                    employee.skillset.Add(skillset[i.TabIndex]);
                }
 
            }
            
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Statistics_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void WriteOnScreen(Label[] Label, string word)
        {
            foreach(Label i in Label)
            {
                if(i.Text == "")
                {
                    i.Text = word;
                    break;
                }
            }
        }

        private void ReconcilerConsoleWindow_Load(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 5; i++)
            {
                tempmanager.employeeList[i] = new Employee();
                tempmanager.workList[i] = new Work();
            }
        }
    }
    
}
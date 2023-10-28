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
            Employee employee = new Employee();

            employee.employeeName = empname.Text;
            employee.workLoad = 0;
            employee.workCompletionTime = 1f;
            employee.experience = 1;
            
            CheckBox[] EmployeeSkills = new CheckBox[] { checkBox6, checkBox7, checkBox8, checkBox9, checkBox10 };
            
            checklistInit(EmployeeSkills, false,employee,null);
            tempmanager.employeeList.Add(employee);

        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Work i in tempmanager.workList)
            {
                tempmanager.workAssigner();
                tempmanager.scheduler();
            }
            foreach (Employee j in tempmanager.employeeList)
            {
                foreach (Work i in j.assignedWork)
                {
                    label1.Text += j.employeeName + i.WorkName;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)

        {
            Work enteredWork = new Work();
            CheckBox[] WorkSkills = new CheckBox[] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5 };
            enteredWork.WorkName = workname.Text;
            checklistInit(WorkSkills, true,null,enteredWork);
            
            tempmanager.workList.Add(enteredWork);
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
    }
}
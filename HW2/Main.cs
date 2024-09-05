using System;
using System.Linq;
using System.Windows.Forms;
using CollegeCourseDLL;




namespace HW2
{
    public partial class Main : Form
    {
        

        

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          



        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox3.Text, out int courseHrs))
            {
                var course = new CollegeCourseDLL.CollegeCourse(
                    textBox1.Text,
                    textBox2.Text,
                    courseHrs,
                    Days_CheckedListBox.Text,
                    textBox5.Text,
                    textBox4.Text
                );

                MessageBox.Show("Course Added");
                ClearTextBox(sender, e);
            }
            else
            {
                MessageBox.Show("Invalid hours input.");
            }
        }


        private void ClearTextBox(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            
            for (int i = 0; i < Days_CheckedListBox.Items.Count; i++)
            {
                Days_CheckedListBox.SetItemChecked(i, false);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                CollegeCourseDLL.CollegeCourse.DisplayCoursesForStudent(textBox4.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                CollegeCourseDLL.CollegeCourse.DeleteCourse(textBox1.Text);
                MessageBox.Show("Course Removed");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var course = CollegeCourseDLL.CollegeCourse.CourseInfo(textBox1.Text);
                MessageBox.Show($"Course ID: {course.CourseId}\nName: {course.Name}\nHours: {course.Hours}\nDays: {course.Days}\nTime: {course.Time}\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

    }
}

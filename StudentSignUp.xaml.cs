using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;

namespace Learning_Center
{
    /// <summary>
    /// Interaction logic for StudentSignUp.xaml
    /// </summary>
    public partial class StudentSignUp : Window
    {

        //declaring variables
        string[] student_usernames = new string[1];
        string[] student_passwords = new string[1];
        string[] student_emails = new string[1];
        string[] teacher_usernames = new string[1];
        string[] teacher_passwords = new string[1];
        string[] teacher_emails = new string[1];
        bool noError = false;
        bool isfreeemail = false;
        bool isfreeusername = false;
        string temppassword;
        string temppassword1;
        string tempusername;
        string tempfirstname;
        string templastname;
        string tempemail;
        int student_id = 0;
        int teacher_id = 0;
        string teacher_id_path = AppDomain.CurrentDomain.BaseDirectory + @"db\teachers\id";
        string student_id_path = AppDomain.CurrentDomain.BaseDirectory + @"db\students\id";
        string student_path = AppDomain.CurrentDomain.BaseDirectory + @"db\students\";
        string status;

        Methods m = new Methods();

        public StudentSignUp()
        {
            InitializeComponent();

            //load teacher and student credentials
            student_id = Convert.ToInt32(File.ReadAllText(student_id_path));
            teacher_id = Convert.ToInt32(File.ReadAllText(teacher_id_path));
            if (student_id > 0)
            {
                Array.Resize<string>(ref student_usernames, student_id);
                Array.Resize<string>(ref student_passwords, student_id);
                Array.Resize<string>(ref student_emails, student_id);
                student_usernames = m.LoadStudents(student_id);
                student_passwords = m.LoadPasswordStudents(student_id);
                student_emails = m.LoadEmailStudents(student_id);
            }
            if (teacher_id > 0)
            {
                Array.Resize<string>(ref teacher_usernames, teacher_id);
                Array.Resize<string>(ref teacher_passwords, teacher_id);
                Array.Resize<string>(ref teacher_emails, teacher_id);
                teacher_usernames = m.LoadEmailTeachers(teacher_id);
                teacher_passwords = m.LoadPasswordTeachers(teacher_id);
                teacher_emails = m.LoadEmailTeachers(teacher_id);
            }
            
        }

        //window dragging logic
        private void DragStudentSignUp(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        //closing window logic
        private void StudentSignUpWindowClose(object sender, MouseButtonEventArgs e)
        {
            
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        //logic when complete button is clicked
        private void ButtonCompleteSignUpStudent_Click(object sender, RoutedEventArgs e)
        {
            //getting user input
            tempusername = TextboxUsernameStudentSignUp.Text;
            temppassword = TextboxPasswordStudentSignUp.Text;
            temppassword1 = TextboxPassword2StudentSignUp.Text;
            tempemail = TextboxEmailStudentSignUp.Text;
            tempfirstname = TextboxFirstNameStudentSignUp.Text;
            templastname = TextboxLastNameStudentSignUp.Text;

            int user_id_s = Array.IndexOf(student_usernames, tempusername);
            int user_id_t = Array.IndexOf(teacher_usernames, tempusername);
            int email_s = Array.IndexOf(student_emails, tempemail);
            int email_t = Array.IndexOf(teacher_emails, tempemail);

            //checking if credential are ok and free
            if (user_id_s > -1 | user_id_t > -1)
            {
                noError = false;
                status = "Username is already taken";
                TextStatus.Text = status;
            }
            if (email_t > -1 | email_s > -1)
            {
                noError = false;
                status = "Email address is already used";
                TextStatus.Text = status;
            }
            if (temppassword != temppassword1)
            {
                noError = false;
                status = "Passwords doesn't match";
                TextStatus.Text = status;
            }
            if (m.IsValidEmail(tempemail) == false)
            {
                noError = false;
                status = "Enter valid email address";
                TextStatus.Text = status;
            }
            if (user_id_t == -1 & user_id_s == -1 & email_s == -1 & email_t == -1 & temppassword == temppassword1 & m.IsValidEmail(tempemail))
            {
                noError = true;

                Directory.CreateDirectory(student_path + student_id);

                m.FileWrite(student_path + student_id + @"\username", tempusername);
                m.FileWrite(student_path + student_id + @"\password", Methods.EncryptPass(temppassword));
                m.FileWrite(student_path + student_id + @"\email", tempemail);
                m.FileWrite(student_path + student_id + @"\firstname", tempfirstname);
                m.FileWrite(student_path + student_id + @"\lastname", templastname);

                student_id++;
                m.FileWrite(student_id_path, Convert.ToString(student_id));
            }

            //if everything ok then redirect to student window
            if (noError == true)
            {
                SubjectsStudent subjectsStudent = new SubjectsStudent();
                subjectsStudent.Show();
                this.Close();
            }
        }

        //canceling logic
        private void ButtonCancelSignUpStudent_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}

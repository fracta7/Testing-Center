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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.IO;

namespace Learning_Center
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// initialize the database
    /// loads the previous session if it exists
    /// the main window
    /// </summary>
    public partial class MainWindow : Window
    {

        //declaring variables
        string[] student_usernames = new string[1];
        string[] student_passwords = new string[1];
        string[] teacher_usernames = new string[1];
        string[] teacher_passwords = new string[1];
        bool hasError = true;
        bool isRemembered = false;
        bool isTeacher = false;
        bool isStudent = false;
        string last_session_path = AppDomain.CurrentDomain.BaseDirectory + @"db\last";
        string remembered_path = AppDomain.CurrentDomain.BaseDirectory + @"db\last_0";
        string student_id_path = AppDomain.CurrentDomain.BaseDirectory + @"db\students\id";
        string teacher_id_path = AppDomain.CurrentDomain.BaseDirectory + @"db\teachers\id";
        string login_is_teacher = AppDomain.CurrentDomain.BaseDirectory + @"db\account_type";
        string folders_state = AppDomain.CurrentDomain.BaseDirectory + @"db\folders_state";
        string signin_error = "Username or password is incorrect";
        string tempUsername;
        int teacher_id = 0;
        int student_id = 0;
        int temp_id = 0;
        string temp_pass;
        string account_type;
        Methods m = new Methods();

        public MainWindow()
        {
            InitializeComponent();

            //checking if all directories in place
            //if it is first time launch then create all necessary directories
            if (!File.Exists(folders_state))
            {
                Startup startup1 = new Startup();
                Thread startup = new Thread(new ThreadStart(startup1.StartCheckup));
                startup.Start();
                Thread.Sleep(100);
            }
            
            


            //check if student id is written to a file
            if (!File.Exists(student_id_path))
            {
                m.FileWrite(student_id_path, Convert.ToString(student_id));

            }
            else
            {
                student_id = Convert.ToInt32(File.ReadAllText(student_id_path));
            }

            //resize student_id array
            if (student_id > 1)
            {
                Array.Resize<string>(ref student_usernames, student_id);
                Array.Resize<string>(ref student_passwords, student_id);
            }

            //load student accounts
            if (student_id > 0)
            {
                student_usernames = m.LoadStudents(student_id);
                student_passwords = m.LoadPasswordStudents(student_id);
            }

            //checking teacher
            if (!File.Exists(teacher_id_path))
            {
                m.FileWrite(teacher_id_path, Convert.ToString(teacher_id));
            }
            else
            {
                teacher_id = Convert.ToInt32(File.ReadAllText(teacher_id_path));
            }

            //resizing teacher_usernames arrays
            if (teacher_id > 1)
            {
                Array.Resize<string>(ref teacher_usernames, teacher_id);
                Array.Resize<string>(ref teacher_passwords, teacher_id);
            }

            //loading teacher account
            if (teacher_id > 0)
            {
                teacher_usernames = m.LoadTeachers(teacher_id);
                teacher_passwords = m.LoadPasswordTeachers(teacher_id);
            }

            //check if previous session should be saved
            if (!File.Exists(remembered_path) && !File.Exists(login_is_teacher))
            {
                m.FileWrite(remembered_path, Convert.ToString(isRemembered));

                //changing account type
                account_type = "student";

                m.FileWrite(login_is_teacher, account_type);

            }
            else
            {
                isRemembered = Convert.ToBoolean(File.ReadAllText(remembered_path));
                account_type = File.ReadAllText(login_is_teacher);
                if (account_type == "teacher")
                {
                    isTeacher = true;
                    isStudent = false;
                }
                else if (account_type == "student")
                {
                    isStudent = true;
                    isTeacher = false;
                }
            }

            //if it is saved then direct
            if (File.Exists(last_session_path) && isRemembered == true)
            {
                tempUsername = File.ReadAllText(last_session_path);
            }

        }

        //dragging the window logic
        private void DragSignPage(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        //close button
        private void SignPageCloseButton(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        //sign in button
        private void ButtonSignIn_Click(object sender, RoutedEventArgs e)
        {
            //loads the array of usernames
            //then checks if given username is in array
            //if it is in array then checks the sha256 of password within index in array of passwords
            //if returned index is -1 then username doesn't exist
            isRemembered = Convert.ToBoolean(CheckboxRememberMeSignin.IsChecked);
            tempUsername = TextboxUsernameSignin.Text;
            temp_id = Array.IndexOf(student_usernames, tempUsername);
            int temp_id_teacher = Array.IndexOf(teacher_usernames, tempUsername);

            //check if given username is student
            if (temp_id > -1 && temp_id_teacher == -1)
            {
                isTeacher = false;
                isStudent = true;

            }
            //check if given username is teacher
            else if (temp_id == -1 && temp_id_teacher > -1)
            {
                isTeacher = true;
                isStudent = false;
            }
            //if given username is none them
            else if (temp_id == -1 && temp_id_teacher == -1)
            {
                hasError = true;
                TextStatusSignIn.Text = signin_error;
            }

            //then checks the given password with returned index of username
            //first if previous logic returned isTeacher = true
            //and hasError = false
            if (isTeacher == true && isStudent == false && hasError == false)
            {
                temp_pass = Methods.EncryptPass(TextboxPasswordSignin.Text);
                if (temp_pass == teacher_passwords[temp_id_teacher])
                {
                    hasError = false;
                    account_type = "teacher";
                }
                else
                {
                    hasError = true;
                    TextStatusSignIn.Text = signin_error;
                }
            }

            //the same logic but for student now
            if (isStudent == true && isTeacher == false && hasError == false)
            {
                temp_pass = Methods.EncryptPass(TextboxPasswordSignin.Text);
                if (temp_pass == student_passwords[temp_id])
                {
                    hasError = false;
                    account_type = "student";
                }
                else
                {
                    hasError = true;
                    TextStatusSignIn.Text = signin_error;
                }
            }

            //check if username and password should be saved
            if (isRemembered == true && hasError == false)
            {
                m.FileWrite(last_session_path, TextboxUsernameSignin.Text);
                m.FileWrite(remembered_path, Convert.ToString(isRemembered));

                //saving account type
                if (isTeacher == true && isStudent == false)
                {
                    m.FileWrite(login_is_teacher, "teacher");

                    //redirect to teachers page
                    TeacherSubjects teacherSubjects = new TeacherSubjects();
                    teacherSubjects.Show();
                    Close();
                }
                else if (isTeacher == false && isStudent == true)
                {
                    m.FileWrite(login_is_teacher, "student");

                    //redirect to students page
                    SubjectsStudent subjectsStudent = new SubjectsStudent();
                    subjectsStudent.Show();
                    Close();
                }
            }

            //logic for if credentials is not going to be saved
            if (isRemembered == false && hasError == false)
            {
                m.FileWrite(last_session_path, TextboxUsernameSignin.Text);

                if (isTeacher == true && isStudent == false)
                {
                    m.FileWrite(login_is_teacher, "teacher");
                }
                else if (isTeacher == false && isStudent == true)
                {
                    m.FileWrite(login_is_teacher, "student");
                }
            }

            if (account_type == "student"&hasError==false)
            {
                SubjectsStudent subjectsStudent = new SubjectsStudent();
                subjectsStudent.Show();
                Close();
            }
        }

        //reset password button
        private void ButtonResetSignIn_Click(object sender, RoutedEventArgs e)
        {
            //todo new reset password window
        }

        //signup buttons
        private void ButtonSignUp_Click(object sender, RoutedEventArgs e)
        {
            StudentSignUp studentSignUpWindow = new StudentSignUp();
            studentSignUpWindow.Show();
            Close();
        }

        private void ButtonTeacherSignUp_Click(object sender, RoutedEventArgs e)
        {
            TeacherSignUp teacherSignUp = new TeacherSignUp();
            teacherSignUp.Show();
            Close();
        }
    }
}

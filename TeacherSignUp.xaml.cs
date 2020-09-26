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

namespace Learning_Center
{
    /// <summary>
    /// Interaction logic for TeacherSignUp.xaml
    /// </summary>
    public partial class TeacherSignUp : Window
    {

        //declaring constants
        const string math = "Math";
        string biology = "Biology";
        const string chemistry = "Chemistry";
        const string english = "English";
        const string history = "History";
        const string informatics = "Informatics";
        const string literature = "Literature";
        const string physics = "Physics";
        const int longpass = 8;

        //declaring variables
        string[] student_usernames = new string[1];
        string[] teacher_usernames = new string[1];
        string[] student_emails = new string[1];
        string[] teacher_emails = new string[1];
        int student_id = 0;
        int teacher_id = 0;
        string teacher_id_path = AppDomain.CurrentDomain.BaseDirectory + @"db\teachers\id";
        string student_id_path = AppDomain.CurrentDomain.BaseDirectory + @"db\students\id";
        string teacher_path = AppDomain.CurrentDomain.BaseDirectory + @"db\teachers\";
        string tempusername;
        string temppassword;
        string temppassword1;
        string tempemail;
        string tempsubject;
        string tempfirst;
        string templast;
        string error_message;
        bool isfreemail = false;
        bool isfreeusername = false;
        bool noError = false;
        bool pass_match = false;
        bool pass_long = false;
        bool selected_subject = false;
        bool valid_email = false;
        bool entered_names = false;


        Methods m = new Methods();

        public TeacherSignUp()
        {
            InitializeComponent();

            //loading last id numbers of students and teachers
            student_id = Convert.ToInt32(File.ReadAllText(student_id_path));
            teacher_id = Convert.ToInt32(File.ReadAllText(teacher_id_path));

            //checking if there is some accounts created before
            //so we could check if usernames and emails don't be used 2nd time
            if (student_id > 0)
            {
                Array.Resize<string>(ref student_usernames, student_id);
                Array.Resize<string>(ref student_emails, student_id);
                student_usernames = m.LoadStudents(student_id);
                student_emails = m.LoadEmailStudents(student_id);
            }
            if (teacher_id > 0)
            {
                Array.Resize<string>(ref teacher_usernames, teacher_id);
                Array.Resize<string>(ref teacher_emails, teacher_id);
                teacher_usernames = m.LoadTeachers(teacher_id);
                teacher_emails = m.LoadEmailTeachers(teacher_id);
            }
        }

        //closing button will return to main window
        private void ButtonCloseTeacherSignUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        

        //canceling signup
        private void ButtonCancelTeacherSignUp_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        //window moving logic
        private void MoveTeacherSignUp(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        //completing signup
        //credential checking
        private void ButtonCompleteTeacherSignUp_Click(object sender, RoutedEventArgs e)
        {
            tempfirst = TextboxFirstNameTeacherSignUp.Text;
            templast = TextboxLastNameTeacherSignUp.Text;
            tempemail = TextboxEmailTeacherSignUp.Text;
            temppassword = TextboxPassword1TeacherSignUp.Text;
            temppassword1 = TextboxPassword2TeacherSignUp.Text;
            tempusername = TextboxUsernameTeacherSignUp.Text;

            //returns the index of given username or email
            //returns -1 if username or email is taken
            int username_s = Array.IndexOf(student_usernames, tempusername);
            int username_t = Array.IndexOf(teacher_usernames, tempusername);
            int email_s = Array.IndexOf(student_emails, tempemail);
            int email_t = Array.IndexOf(teacher_emails, tempemail);

            //checking if username is taken
            if (username_s == -1 & username_t == -1)
            {
                isfreeusername = true;
            }
            else if (username_s > -1 | username_t > -1)
            {
                isfreeusername = false;
            }

            //checking if email is taken
            if (email_s == -1 & email_t == -1)
            {
                isfreemail = true;
            }
            else if (email_s > -1 | email_t > -1)
            {
                isfreemail = false;
            }

            //checking if passwords match to each other
            if (temppassword == temppassword1)
            {
                pass_match = true;
            }
            else
            {
                pass_match = false;
            }

            //checking if passwords are long enough
            if (pass_match & temppassword.Length >= longpass)
            {
                pass_long = true;
            }

            //checking if valid email address is entered
            if (m.IsValidEmail(tempemail))
            {
                valid_email = true;
            }

            //checking if names are entered
            if (tempfirst.Length > 0 & templast.Length > 0)
            {
                entered_names = true;
            }

            //checking which subject is selected
            if (Convert.ToBoolean(RadioButtonMath.IsChecked))
            {
                tempsubject = math;
                selected_subject = true;
            }
            else if (Convert.ToBoolean(RadioButtonBiology.IsChecked))
            {
                tempsubject = biology;
                selected_subject = true;
            }
            else if (Convert.ToBoolean(RadioButtonChemistry.IsChecked))
            {
                tempsubject = chemistry;
                selected_subject = true;
            }
            else if (Convert.ToBoolean(RadioButtonEnglish.IsChecked))
            {
                tempsubject = english;
                selected_subject = true;
            }
            else if (Convert.ToBoolean(RadioButtonHistory.IsChecked))
            {
                tempsubject = history;
                selected_subject = true;
            }
            else if (Convert.ToBoolean(RadioButtonInformatics.IsChecked))
            {
                tempsubject = informatics;
                selected_subject = true;
            }
            else if (Convert.ToBoolean(RadioButtonLiterature.IsChecked))
            {
                tempsubject = literature;
                selected_subject = true;
            }
            else if (Convert.ToBoolean(RadioButtonPhysics.IsChecked))
            {
                tempsubject = physics;
                selected_subject = true;
            }

            //assigning error messages
            if (!isfreeusername)
            {
                error_message = "Username is already taken";
            }
            if (!isfreemail)
            {
                error_message = "Email address already is taken";
            }
            if (!pass_match)
            {
                error_message = "Passwords do not match";
            }
            if (!pass_long)
            {
                error_message = "Password should at least contain 8 characters";
            }
            if (!selected_subject)
            {
                error_message = "You did not select any subject";
            }
            if (!valid_email)
            {
                error_message = "Enter valid email address";
            }
            if (!entered_names)
            {
                error_message = "Please enter your name";
            }
            if (!noError)
            {
                StatusMessage.Text = error_message;
            }
            

            //registring if no error occured
            if (isfreeusername&isfreemail&pass_long&pass_match&selected_subject&valid_email&entered_names)
            {
                noError = true;
                string t_c = teacher_path + teacher_id;
                Directory.CreateDirectory(t_c);
                m.FileWrite(t_c + @"\username", tempusername);
                m.FileWrite(t_c + @"\password", Methods.EncryptPass(temppassword));
                m.FileWrite(t_c + @"\email", tempemail);
                m.FileWrite(t_c + @"\subject", tempsubject);
                m.FileWrite(t_c + @"\firstname", tempfirst);
                m.FileWrite(t_c + @"\lastname", templast);
                teacher_id++;
                m.FileWrite(teacher_id_path, Convert.ToString(teacher_id));
            }

            //redirect to teachers window if successful registration
            if (noError)
            {
                TeacherSubjects teacherSubjects = new TeacherSubjects();
                teacherSubjects.Show();
                this.Close();
            }
        }
    }
}

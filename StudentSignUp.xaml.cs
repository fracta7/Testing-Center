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


namespace Learning_Center
{
    /// <summary>
    /// Interaction logic for StudentSignUp.xaml
    /// </summary>
    public partial class StudentSignUp : Window
    {

        //declaring variables
        string[] usernames = new string[1];
        string[] passwords = new string[1];
        string[] emails = new string[1];
        string[] firstnames = new string[1];
        string[] lastnames = new string[1];
        bool isfreeemail = false;
        string temppassword;
        Methods m = new Methods();

        public StudentSignUp()
        {
            InitializeComponent();
        }

        private void DragStudentSignUp(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void StudentSignUpWindowClose(object sender, MouseButtonEventArgs e)
        {
            
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ButtonCompleteSignUpStudent_Click(object sender, RoutedEventArgs e)
        {
            SubjectsStudent subjectsStudent = new SubjectsStudent();
            subjectsStudent.Show();
            this.Close();
        }

        private void ButtonCancelSignUpStudent_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}

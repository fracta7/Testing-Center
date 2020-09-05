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
    /// Interaction logic for TeacherSignUp.xaml
    /// </summary>
    public partial class TeacherSignUp : Window
    {
        public TeacherSignUp()
        {
            InitializeComponent();
        }

        private void ButtonCloseTeacherSignUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ButtonCompleteTeacherSignUp_Click(object sender, RoutedEventArgs e)
        {
            TeacherSubjects teacherSubjects = new TeacherSubjects();
            teacherSubjects.Show();
            this.Close();
        }

        private void ButtonCancelTeacherSignUp_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void MoveTeacherSignUp(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}

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
    /// Interaction logic for TeacherSubjects.xaml
    /// </summary>
    public partial class TeacherSubjects : Window
    {
        public TeacherSubjects()
        {
            InitializeComponent();
        }

        private void ButtonCloseTeacherSubjects(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

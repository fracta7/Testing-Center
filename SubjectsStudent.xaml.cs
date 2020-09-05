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

namespace Learning_Center
{
    /// <summary>
    /// Interaction logic for SubjectsStudent.xaml
    /// </summary>
    public partial class SubjectsStudent : Window
    {
        public SubjectsStudent()
        {
            InitializeComponent();
        }

        private void DragSelectSubjectStudentWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonCloseSelectSubjectStudent(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ButtonOpenProfileSelectSubjectStudent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonMath_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonHistory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonEnglish_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonChemistry_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonPhysics_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonBiology_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonInformatics_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonLiterature_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonStats_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

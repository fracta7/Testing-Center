using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Learning_Center
{
    //thread if it is first launch
    //this thread is used for setting up the database
    class Startup
    {
        //declaring variables
        string db = AppDomain.CurrentDomain.BaseDirectory + @"db\";
        string student_account_path = AppDomain.CurrentDomain.BaseDirectory + @"db\students\";
        string teacher_account_path = AppDomain.CurrentDomain.BaseDirectory + @"db\teachers\";
        string subjects_path = AppDomain.CurrentDomain.BaseDirectory + @"db\subjects";
        string math_path = AppDomain.CurrentDomain.BaseDirectory + @"db\subjects\math\";
        string chemistry_path = AppDomain.CurrentDomain.BaseDirectory + @"db\subjects\chemistry\";
        string physics_path = AppDomain.CurrentDomain.BaseDirectory + @"db\subjects\physics";
        string biology_path = AppDomain.CurrentDomain.BaseDirectory + @"db\subjects\biology";
        string literature_path = AppDomain.CurrentDomain.BaseDirectory + @"db\subjects\literature";
        string english_path = AppDomain.CurrentDomain.BaseDirectory + @"db\subjects\english\";
        string history_path = AppDomain.CurrentDomain.BaseDirectory + @"db\subjects\history\";
        string informatics_path = AppDomain.CurrentDomain.BaseDirectory + @"db\subjects\informatics\";
        string student_id_path = AppDomain.CurrentDomain.BaseDirectory + @"db\students\id";
        string teacher_id_path = AppDomain.CurrentDomain.BaseDirectory + @"db\teachers\id";
        string folders_state = AppDomain.CurrentDomain.BaseDirectory + @"db\folders_state";
        bool isfolderok = false;
        Methods m = new Methods();

        public void StartCheckup()
        {
            if (!Directory.Exists(db))
            {
                Directory.CreateDirectory(db);
            }
            if (!Directory.Exists(student_account_path))
            {
                Directory.CreateDirectory(student_account_path);
            }
            if (!Directory.Exists(teacher_account_path))
            {
                Directory.CreateDirectory(teacher_account_path);
            }
            if (!Directory.Exists(subjects_path))
            {
                Directory.CreateDirectory(subjects_path);
            }
            if (!Directory.Exists(math_path))
            {
                Directory.CreateDirectory(math_path);
            }
            if (!Directory.Exists(chemistry_path))
            {
                Directory.CreateDirectory(chemistry_path);
            }
            if (!Directory.Exists(biology_path))
            {
                Directory.CreateDirectory(biology_path);
            }
            if (!Directory.Exists(physics_path))
            {
                Directory.CreateDirectory(physics_path);
            }
            if (!Directory.Exists(english_path))
            {
                Directory.CreateDirectory(english_path);
            }
            if (!Directory.Exists(literature_path))
            {
                Directory.CreateDirectory(literature_path);
            }
            if (!Directory.Exists(informatics_path))
            {
                Directory.CreateDirectory(informatics_path);
            }
            if (!Directory.Exists(history_path))
            {
                Directory.CreateDirectory(history_path);
            }
            if (!File.Exists(student_id_path))
            {
                m.FileWrite(student_id_path, "0");
            }
            if (!File.Exists(teacher_id_path))
            {
                m.FileWrite(teacher_id_path, "0");
            }

            //after all operation write to a file status
            //so next launch this thread 
            isfolderok = true;
            m.FileWrite(folders_state, Convert.ToString(isfolderok));
        }
    }
}

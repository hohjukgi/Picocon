using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDevelopmentProjects
{
    class LectureManager
    {
        private List<string> _lectureList;
        public List<string> lectureList
        {
            get
            {
                return _lectureList;
            }
        }
        public string fileName;

        public LectureManager()
        {
            _lectureList = new List<string>();
            this.fileName = string.Empty;
        }

        public LectureManager(string fileName)
        {
            _lectureList = new List<string>();
            this.fileName = fileName;
        }

        public void ReadLectureDatas()
        {
            if(fileName == "")
            {
                LogManager.LogOutput("講義データファイルが指定されていません");
                return;
            }

        }
    }
}

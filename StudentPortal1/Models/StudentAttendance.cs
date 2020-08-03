using System;
using System.Collections.Generic;

namespace StudentPortal1.Models
{
    public partial class StudentAttendance
    {
        public int Rollno { get; set; }
        public string Name { get; set; }
        public int English { get; set; }
        public int Mathematics { get; set; }
        public int Science { get; set; }
        public int Socialstudies { get; set; }
        public int Computerscience { get; set; }
        public int Hindi { get; set; }
    }
}

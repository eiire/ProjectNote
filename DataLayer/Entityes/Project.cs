using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entityes
{
    public class Project : Page
    {
        public List<Worker> Workers { get; set; }
        public string NameExeCompany { get; set; }
        public string InformationProjectManager { get; set; }
        public string DataExeProject { get; set; }
        public DateTime DatesProject { get; set; }
        public int ProjectPriority { get; set; }
    }
}

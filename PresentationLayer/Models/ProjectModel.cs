using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Models
{
    public class ProjectViewModel : PageViewModel
    {
        public Project Project { get; set; }
        public List<WorkerViewModel> Workers { get; set; }
    }

    public class ProjectEditModel : PageEditModel
    {
        public string OrderCompany { get; set; }
        public string NameExeCompany { get; set; }

        public string InformationProjectManager { get; set; }

        public string DataExeProject { get; set; }

        public DateTime DatesProject { get; set; }

        public int ProjectPriority { get; set; }
    }
}

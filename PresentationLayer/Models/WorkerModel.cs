using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PresentationLayer.Models
{
    public class WorkerViewModel : PageViewModel
    {
        public Worker Worker { get; set; }
        public Worker NextWorker { get; set; }
    }

    public class WorkerEditModel : PageEditModel
    {
        [Required]
        public int Projectid { get; set; }

        public string DataExeProject { get; set; }

        public string SurName { get; set; }

        public string Patronymic { get; set; }

        public string Mail { get; set; }
    }
}

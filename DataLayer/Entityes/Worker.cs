using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entityes
{
    public class Worker :Page
    {
        public int ProjectId { get; set; } // FK
        public Project Project { get; set; } // Nav
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public string Mail { get; set; }

    }
}

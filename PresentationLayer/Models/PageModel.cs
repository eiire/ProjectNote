using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PresentationLayer.Models
{
    public class PageViewModel { }
    public class PageEditModel {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

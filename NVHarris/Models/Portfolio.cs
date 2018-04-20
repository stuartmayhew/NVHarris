using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NVHarris.Models
{
    public class Portfolio
    {
        [Key]
        public int PortID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDesc { get; set; }
        public string ProjectLink { get; set; }
        public string ProjectImage { get; set; }

    }
}
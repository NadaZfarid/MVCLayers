﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLayers.Models
{
    public class Dept_loc
    {
        public virtual Department? department { get; set; }
        [ForeignKey("department")]
        public int? Dept_id { get; set; }
        public string Locatoin { get;}
    }
}

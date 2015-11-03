using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fall2015.Models
{
    public class Competency
    {
        public int CompetencyId { get; set; }
        public String Name { get; set; }
        public int CompetencyHeaderId { get; set; }

        //public virtual CompetencyHeader CompetencyHeader { get; set; }
        public ICollection<Competency> Competencies { get; set; }
    }
}
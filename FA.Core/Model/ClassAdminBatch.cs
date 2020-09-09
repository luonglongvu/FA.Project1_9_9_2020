using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.Project.Model
{
    public class ClassAdminBatch
    {
        [Key]
        [Column(Order = 1)]
        public int ClassId { get; set; }
        public ClassBatch ClassBatch { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ClassAdminId { get; set; }
        public ClassAdmin ClassAdmin { get; set; }
    }
}

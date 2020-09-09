using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.Project.Model
{
   public  class TrainerClassBatch
    {
        [Key]
        [Column(Order = 1)]
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
        [Key]
        [Column(Order = 2)]
        public int  ClassId { get; set; }
        public ClassBatch ClassBatch { get; set; }
    }
}

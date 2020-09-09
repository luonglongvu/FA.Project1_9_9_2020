using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.Project.Model
{
    public class ClassBatch
    {
        [Key]
        public int ClassId { get; set; }
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string ClassName { get; set; }
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string ClassCode { get; set; }
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string GroupMail { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string Location { get; set; }
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string DetailLocation { get; set; }
        //public int ClassAdminId { get; set; }
        //public int TrainerId { get; set; }
        public string Status
        {
            get
            {
                return this.statustype.ToString();
            }
            set
            {
                statustype = (StatusDetail)Enum.Parse(typeof(StatusDetail), value, true);
            }
        }
        [NotMapped]
        public StatusDetail statustype { get; set; }
        public enum StatusDetail
        {
            [Description("not_started")] not_started = 1,
            [Description("in_process")] in_process = 2,
            [Description("finished")] finished = 3,

        }
      //  public enum Status { not_started, in_process, finished }
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string Remarks { get; set; }
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string AuditTrail { get; set; }
        [DefaultValue(false)]
        [Display(Name = "Is Deleted")]
        public bool isDeleted { get; set; }
        public virtual IList<ClassAdminBatch> ClassAdminBatches { get; set; }
        public virtual IList<TrainerClassBatch> TrainerClassBatches { get; set; }
        public virtual ICollection<Trainee> Trainees { get; set; }
    }
}

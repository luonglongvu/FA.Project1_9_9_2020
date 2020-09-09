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
    public class Trainer
    {
        public int TrainerId { get; set; }
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string FullName { get; set; }
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string Email { get; set; }
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string Account { get; set; }
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
            [Description("availabler")] available = 1,
            [Description("unavailable")] unavailable = 2,

        }
        //public enum Status { available, unavailable }
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string Type { get; set; }
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string Unit { get; set; }
        public string Major
        {
            get
            {
                return this.mafortype.ToString();
            }
            set
            {
                mafortype = (MajorDetail)Enum.Parse(typeof(MajorDetail), value, true);
            }
        }
        [NotMapped]
        public MajorDetail mafortype { get; set; }
        public enum MajorDetail
        {
            [Description("Csharp")] Csharp = 1,
            [Description("Java")] Java = 2,
            [Description("S")] S = 3,
            [Description("Ruby")] Ruby = 4,
            [Description("PHP")] PHP = 5,
            [Description("CSS")] CSS = 6,
            [Description("Python")] Python = 7,
            [Description("CPlus")] CPlus = 8,
            [Description("ObjectC")] ObjectC = 9,


        }
       // public enum Major { Csharp, Java, S, Ruby, PHP, CSS, Python, CPlus, ObjectC }
        public int Experience { get; set; }
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string Remarks { get; set; }
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string AuditTrail { get; set; }
        [DefaultValue(false)]
        [Display(Name = "Is Deleted")]
        public bool isDelete { get; set; }

        public virtual IList<TrainerClassBatch> TrainerClassBatches { get; set; }

       // public virtual IList<ClassAdminBatch> ClassAdminBatches { get; set; }
    }
}

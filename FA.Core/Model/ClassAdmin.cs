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
    public class ClassAdmin
    {
        public int ClassAdminId { get; set; }
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string FullName { get; set; }
        [Display(Name = "Date of bỉth")]
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
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string AuditTrail { get; set; }
        [DefaultValue(false)]
        [Display(Name = "Is Deleted")]
        public bool isDelete { get; set; }

        public virtual IList<ClassAdminBatch> ClassAdminBatches { get; set; }
        public virtual ICollection<Request> Requests { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FA.Project.Model
{
    public class Trainee
    {
        public int TraineeId { get; set; }

        public string FullName { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }

        public GenderDetail Gender { get; set; }

        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string PhoneNumber { get; set; }
       
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string FamilyPhoneNumber { get; set; }
       
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string Email { get; set; }
       
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string ExternalEmail { get; set; }
       
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string  Account { get; set; }
       
        [Display(Name = "Onbroad Date")]
        public DateTime OnboardDate { get; set; }
        
        public StatusDetail Status { get; set; }
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string Remarks { get; set; }
       
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string University { get; set; }
      
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string  Faculty { get; set; }

       
        public SkillDetail Skill { get; set; }
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string ForeignLanguage { get; set; }
        public int Level { get; set; }
       
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string CV  { get; set; }
       
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string AllocationStatus { get; set; }
       
        public string AuditTrail { get; set; }
      
        [DefaultValue(false)]
        [Display(Name = "Is Deleted")]
        public bool isDelete { get; set; }
        public int ClassBatchId { get; set; }
        public ClassBatch ClassBatch { get; set; }
        public virtual ICollection<Request> Requests { get; set; }

        public enum GenderDetail
        {
            [Display(Name ="Male")] male=0,
            [Display(Name ="Female")] female=1,
            [Display(Name ="Other")] other=3
        }
        public enum StatusDetail
        {
            [Display(Name="Waiting for class")] waiting_for_class = 0,
            [Display(Name ="In course")] in_course = 1,
            [Display(Name ="Completed the course")] completed_the_course = 2,
            [Display(Name ="Drop out")] drop_out = 3
        }

        public enum SkillDetail
        {
            [Display(Name ="Csharp")] Csharp = 0,
            [Display(Name ="Java")] Java = 1,
            [Display(Name ="S")] S = 2,
            [Display(Name ="Ruby")] Ruby = 3,
            [Display(Name ="PHP")] PHP = 4,
            [Display(Name ="CSS")] CSS = 5,
            [Display(Name ="Python")] Python = 6,
            [Display(Name ="CPlus")] CPlus = 7,
            [Display(Name ="ObjectC")] ObjectC = 8
        }
    }
}

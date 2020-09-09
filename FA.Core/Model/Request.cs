using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FA.Project.Model
{
    public class Request
    {
        public int RequestId { get; set; }

        public RequestType Requesttype { get; set; }

        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string Reason { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]

        public DateTime EndDate { get; set; }

        public TimeSpan ComimmingTime { get; set; }

        public TimeSpan LeavingTime { get; set; }
        [Display(Name = "Expected Approval ")]
        public DateTime ExpectedApproval { get; set; }
        [Display(Name = "Approval Time")]
        public DateTime ApprovedTime { get; set; }

        public StatusDetail Status { get; set; }

        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string AuditTrail { get; set; }

        [DefaultValue(false)]
        [Display(Name = "Is Deleted")]
        public bool isDelete { get; set; }

        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }
        public int ApproverId { get; set; }
        public ClassAdmin ClassAdmin { get; set; }
        public enum RequestType
        {
            [Display(Name = "Late")]
            Late = 0,
            [Display(Name = "Busy family")]
            busy_family = 1,
            [Display(Name = "Out side wiht customer")]
            outside = 2,
            [Display(Name = "Sick")]
            Sick = 3

        }

        public enum StatusDetail
        {
           
            [Display(Name="Draft")]
            draft = 0,
            [Display(Name ="Approved")] approved = 1,
            [Display(Name ="Returned")] returned = 2,
            [Display(Name ="Rejected")] rejected = 3,
            [Display(Name ="Pending approval")] pending_approval = 4

        }

    }



}

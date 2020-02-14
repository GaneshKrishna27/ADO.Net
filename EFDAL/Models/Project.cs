using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDAL.Models
{
    [Table("Project")]
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [Required]
        [StringLength(20)]
        public string ProjectName { get; set; }
        //set one to many relation
        [Column(TypeName = "Date")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? EndDate { get; set; }

        //set one to many relation with Employee
        public IEnumerable<Employee> Employees { get; set; }
    }
}

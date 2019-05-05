using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestCaseManagementApp.Models
{
    public class TestSetModel
    {
        [Key]
        public int TestSetID { get; set; }
        [Required]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public virtual ICollection<TestCaseModel> TestCases { get; set; }
    }
}
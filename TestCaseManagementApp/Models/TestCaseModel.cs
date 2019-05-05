using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestCaseManagementApp.Models
{
    public class TestCaseModel
    {
        [Key]
        public int TestCaseID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [EnumDataType(typeof(Priority))]
        public Priority Priority { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(500)]
        public string Prerequisites { get; set; }
        public List<TestStep> Steps { get; set; }

        public ICollection<TestStep> TestSteps { get; set; }
    }
    public enum Priority { Critical = 1, High = 2, Normal = 3, Low = 4};

    public class TestStep
    {
        [Key]
        public int TestStepID { get; set; }
        public int TestCaseID { get; set; }
        public int StepNumber { get; set; }
        public string Action { get; set; }
        public string Input { get; set; }
        public string ExpectedResult { get; set; }
    }

    public class TestDBContext : DbContext
    {
        public TestDBContext() { }

        public DbSet <TestCaseModel> TestCases { get; set; }
        public DbSet <TestStep> TestSteps { get; set; }
        public DbSet <TestSetModel> TestSets { get; set; }
    }
}
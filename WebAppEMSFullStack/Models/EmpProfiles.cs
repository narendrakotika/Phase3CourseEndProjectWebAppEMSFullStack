﻿using System.ComponentModel.DataAnnotations;

namespace WebAppEMSFullStack.Models
{
    public class EmpProfiles
    { 

        [Key]
        public int EmpCode { get; set; }
        public string? EmpName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string? Email { get; set; }

        public int DeptCode { get; set; }
         public virtual DeptMaster? DeptMaster { get; set; }
    }
}

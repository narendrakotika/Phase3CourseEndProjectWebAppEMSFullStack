using System.ComponentModel.DataAnnotations;

namespace WebAppEMSFullStack.Models
{
    public class DeptMaster
    {
        [Key]
        public int DeptCode { get; set; }
        public string? DeptName { get; set; }
       public virtual ICollection<EmpProfiles>? EmpProfiles { get; set; } 

    }
}

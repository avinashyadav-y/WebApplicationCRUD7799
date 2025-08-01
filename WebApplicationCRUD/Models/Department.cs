using System.ComponentModel.DataAnnotations;

namespace WebApplicationCRUD.Models
{
    public class Department
    {
        [Key ]
        public int Dept_Id {  get; set; }

        [Required,MaxLength (100)]

        public string DepartmentName {  get; set; }

        



    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationCRUD.Models
{
    public class Employee
    {

        [Key]
        public int EmpID { get; set; }

        [Required(ErrorMessage = "Please Enter Firest Name")]
        [DisplayName ("Firest Name")]
        public string EmpFirestName { get; set; }

        [Required(ErrorMessage = "Please Enter Middle Name")]
        [DisplayName("Middle Name")]
        public string EmpMiddleName { get; set; }

        [Required(ErrorMessage = "Please Enter Employe Last Name")]
        [DisplayName("Last Name")]
        public string EmpLastName { get; set; }

        [Required(ErrorMessage = "Please Enter Email ID ")]
        [DisplayName("Email")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Number ")]
        [DisplayName("Mobile No")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Address ")]
        [DisplayName("Address")]
        public string EmpAddress { get; set; }

        [Required(ErrorMessage = "Please Enter Employee salary ")]
        [DisplayName("Salary")]
        public decimal Salary { get; set; }

        [DisplayName("Status")]
        public bool EmpStatus { get; set; }

        
        [Required (ErrorMessage= "Please select Department")]
        public int Dept_Id {  get; set; }

        [ForeignKey("Dept_Id")]
        public Department? Department { get; set; }


    }
}

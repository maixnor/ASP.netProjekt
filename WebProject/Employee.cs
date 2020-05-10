//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Employees1 = new HashSet<Employee>();
            this.Orders = new HashSet<Order>();
            this.Territories = new HashSet<Territory>();
        }
    
        public int EmployeeID { get; set; }

        [DisplayName("Last Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "must be between 2 and 50 characters")]
        public string LastName { get; set; }

        [DisplayName("First name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "must be between 2 and 50 characters")]
        public string FirstName { get; set; }

        [DisplayName("Title")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "must be between 2 and 50 characters")]
        public string Title { get; set; }

        [DisplayName("Title of Courtesy")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "must be between 2 and 50 characters")]
        public string TitleOfCourtesy { get; set; }

        [DisplayName("Birthdate")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime, ErrorMessage = "must be a date")]
        public Nullable<System.DateTime> BirthDate { get; set; }

        [DisplayName("Hiredate")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime, ErrorMessage = "must be a date")]
        public Nullable<System.DateTime> HireDate { get; set; }

        [DisplayName("Address")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "must be between 2 and 50 characters")]
        public string Address { get; set; }

        [DisplayName("City")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "must be between 2 and 50 characters")]
        public string City { get; set; }

        [DisplayName("Region")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "must be between 2 and 50 characters")]
        public string Region { get; set; }

        [DisplayName("Postal Code")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "must be between 2 and 50 characters")]
        public string PostalCode { get; set; }

        [DisplayName("Country")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "must be between 2 and 50 characters")]
        public string Country { get; set; }

        [DisplayName("Home Phone")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "must be between 2 and 50 characters")]
        public string HomePhone { get; set; }

        [DisplayName("Extension")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "must be between 2 and 50 characters")]
        public string Extension { get; set; }

        [DisplayName("Photo")]
        public byte[] Photo { get; set; }

        [DisplayName("Notes")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "must be between 2 and 50 characters")]
        public string Notes { get; set; }

        [DisplayName("Boss")]
        [Range(0, int.MaxValue, ErrorMessage = "must be a valid id")]
        public Nullable<int> ReportsTo { get; set; }

        [DisplayName("Address")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.ImageUrl, ErrorMessage = "must be a link to an image")]
        public string PhotoPath { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees1 { get; set; }
        public virtual Employee Employee1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Territory> Territories { get; set; }
    }
}

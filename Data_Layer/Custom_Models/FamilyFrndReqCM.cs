using Data_Layer.Custom_Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Custom_Models
{
    public class FamilyFrndReqCM
    {
        [Key]
        [Column("Userid")]
        public string Userid { get; set; }

        public string Symptons { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zipcode { get; set; }

        public string Room { get; set; }

        public IFormFile Upload { get; set; }


        //Family Details
        public string? FamilyFName { get; set; }

        public string? FamilyLName { get; set; }

        public string? FamilyPhone { get; set; }

        public string? FamilyEmail { get; set; }

        public string? FamilyRelation { get; set; }

    }
}

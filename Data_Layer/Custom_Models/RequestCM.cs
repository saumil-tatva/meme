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
    public class RequestViewModel
    {
        public string Name { get; set; }

        public int count { get; set; }

        public DateTime CreatedDate { get; set; }

        public int Status { get; set; }

        public string status_name { get; set; }
    }
}

﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ComplaintSystem.Model
{
    public class Department
    {
        public  int Id  { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentNumber { get; set; }
        public string DepartmentEmail { get; set; }

        [ForeignKey("Municipality")]
        public int MunicipalityId { get; set; }
        public virtual Municipality Municipality { get; set; }

        //[ForeignKey("Branch")]
        //public int BranchId { get; set; }
        //public virtual Branch Branch { get; set; }

    }
}

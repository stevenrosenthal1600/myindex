﻿using System;

namespace CodeChallenge.Models
{
    public class Compensation
    {
        public String EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int Salary { get; set; }

        public DateTime EffectiveDate { get; set; }
    }
}

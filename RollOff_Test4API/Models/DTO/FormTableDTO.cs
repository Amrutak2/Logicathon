﻿using System;
using System.ComponentModel.DataAnnotations;

namespace RollOff_Test4API.Models.DTO
{
    public class FormTableDTO
    {
        [Key]
        public double GlobalGroupId { get; set; }
        public string Name { get; set; }
        public string LocalGrade { get; set; }
        public string PrimarySkill { get; set; }
        public double? ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string Practice { get; set; }
        public DateTime? RollOffEndDate { get; set; }
        public string ReasonForRollOff { get; set; }
        public string ThisReleaseNeedBackfillIsBackFilled { get; set; }
        public string PerformanceIssue { get; set; }
        public string Resigned { get; set; }
        public string UnderProbation { get; set; }
        public string LongLeave { get; set; }
        public string TechnicalSkills { get; set; }
        public string Communication { get; set; }
        public string RoleCompetencies { get; set; }
        public string Remarks { get; set; }
        public double? RelevantExperienceYrs { get; set; }
        public double? EmployeeNo { get; set; }
        public string Status { get; set; }
        public DateTime? RequestDate { get; set; }
    }
}

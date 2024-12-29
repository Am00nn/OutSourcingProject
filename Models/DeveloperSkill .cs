﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace OutsourcingSystem.Models
{
    [PrimaryKey(nameof (DeveloperID ), nameof(SkillID) )]
    public class DeveloperSkill
    {
        [Key]
       
        [ForeignKey(nameof(Developer))]
        public int DeveloperID { get; set; }
        public Developer Developer { get; set; }

        
        
        [ForeignKey(nameof(Skills))]
        public int SkillID { get; set; }
        public Skills Skills { get; set; }



        [Required(ErrorMessage = "Proficiency is required.")]

        [Range(1, 5, ErrorMessage = "Proficiency must be between 1 and 5.")]
        public int Proficiency { get; set; }
    }
}
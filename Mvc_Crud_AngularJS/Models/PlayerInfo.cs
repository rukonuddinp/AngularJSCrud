using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_Crud_Angularjs.Models
{

    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Country_Name { get; set; }
        public ICollection<PlayerInfo> PlayerInfoes { get; set; }
    }
    public class PlayerInfo
    {
        [Key]
         public int Id { get; set; }
         public string PlayerName { get; set; }

         public string PlayerDistrict { get; set; }

         public string image { get; set; }

         public string image_Path { get; set; }

        public bool IsComeFromVillage { get; set; }

         public DateTime JoiningDate { get; set; }
        
        

        public int CountId { get; set; }

         [ForeignKey("CountId")]
         public Country Country { get; set; }

        [NotMapped]
         public string Country_Name { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Intex_2.Models
{
    public class Crash
    {
        [Key]
        [Required]
        public int CRASH_ID { get; set; }
        [Required]
        public string CRASH_DATETIME { get; set; }
        public string ROUTE { get; set; }
        public float MILEPOINT { get; set; }
        public double LAT_UTM_Y { get; set; }
        public double LONG_UTM_X { get; set; }
        public string MAIN_ROAD_NAME { get; set; }
        public string CITY { get; set; }
        [Required]
        public string COUNTY_NAME { get; set; }
        [Required]
        public string WORK_ZONE_RELATED { get; set; }
        [Required]
        public string PEDESTRIAN_INVOLVED { get; set; }
        [Required]
        public string BICYCLIST_INVOLVED { get; set; }
        [Required]
        public string MOTORCYCLE_INVOLVED { get; set; }
        [Required]
        public string IMPROPER_RESTRAINT { get; set; }
        [Required]
        public string UNRESTRAINED { get; set; }
        [Required]
        public string DUI { get; set; }
        [Required]
        public string INTERSECTION_RELATED { get; set; }
        [Required]
        public string WILD_ANIMAL_RELATED { get; set; }
        [Required]
        public string DOMESTIC_ANIMAL_RELATED { get; set; }
        [Required]
        public string OVERTURN_ROLLOVER { get; set; }
        [Required]
        public string COMMERCIAL_MOTOR_VEH_INVOLVED { get; set; }
        [Required]
        public string TEENAGE_DRIVER_INVOLVED { get; set; }
        [Required]
        public string OLDER_DRIVER_INVOLVED { get; set; }
        [Required]
        public string NIGHT_DARK_CONDITION { get; set; }
        [Required]
        public string SINGLE_VEHICLE { get; set; }
        [Required]
        public string DISTRACTED_DRIVING { get; set; }
        [Required]
        public string DROWSY_DRIVING { get; set; }
        [Required]
        public string ROADWAY_DEPARTURE { get; set; }

        // Foreign key
        [Required(ErrorMessage = "Please select from list")]
        [Display(Name = "Severity")]
        public int CRASH_SEVERITY_ID { get; set; }
        [ForeignKey("CRASH_SEVERITY_ID")]
        public virtual Severity Severity { get; set; }
    }
}

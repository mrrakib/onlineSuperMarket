using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eBuyService.Models
{
    public class UserDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Key]
        [StringLength(30)]
        public string UserEmail { get; set; }

        [Required]
        [StringLength(30)]
        public string UserPassword { get; set; }

        [Required]
        [StringLength(10)]
        public string UserRole { get; set; }
    }
}
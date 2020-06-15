using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId { get; set; }

        [Required(ErrorMessage = "is required.")]
        public string WedderOne { get; set; }

        [Required(ErrorMessage = "is required.")]
        public string WedderTwo { get; set; }

        [Required(ErrorMessage = "is required.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "is required.")]
        public string Address { get; set; }
        public User Creator { get; set; }
        public List<RSVP> RSVP { get; set; }
    }
}
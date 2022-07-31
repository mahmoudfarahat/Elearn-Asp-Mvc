using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Elearn.Models
{
    public class Playlist
    {
        public Playlist()
        {
            this.Lectures = new HashSet<Lecture>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageFile { get; set; }

        public ICollection<Lecture> Lectures { get; set; }

        public string ApplicationsUserId { get; set; }

        public ApplicationUser ApplicationsUser { get; set; }
    }
}
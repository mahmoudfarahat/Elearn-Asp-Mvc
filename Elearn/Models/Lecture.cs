using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Elearn.Models
{
    public class Lecture
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string VideoFile { get; set; }

        public string Description { get; set; }
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }


        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

     
    }
}
using System;
using System.Collections.Generic;

namespace Epsi_Festival.Models
{
    public partial class Programmation
    {
        public int Id { get; set; }
        public DateTime? Heure { get; set; }
        public int? ArtisteId { get; set; }
        public int? SceneId { get; set; }

        public virtual Artiste? Artiste { get; set; }
        public virtual Scene? Scene { get; set; }
    }
}

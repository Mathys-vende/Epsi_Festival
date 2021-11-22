using System;
using System.Collections.Generic;

namespace Epsi_Festival.Models
{
    public partial class Scene
    {
        public Scene()
        {
            Programmations = new HashSet<Programmation>();
        }

        public int Id { get; set; }
        public string? Nom { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Programmation> Programmations { get; set; }
    }
}

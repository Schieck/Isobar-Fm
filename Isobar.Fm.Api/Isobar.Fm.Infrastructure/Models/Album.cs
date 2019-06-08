using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace Isobar.Fm.Infrastructure.Models
{
    [ExcludeFromCodeCoverage]
    public class Album
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime ReleasedDate { get; set; }
        public string Band { get; set; }
        public IEnumerable<Track> Tracks { get; set; }
    }
}

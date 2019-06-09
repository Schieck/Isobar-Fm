using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace Isobar.Fm.Core.Models
{
    [ExcludeFromCodeCoverage]
    public class Band
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Genre { get; set; }
        public string Biography { get; set; }
        public Int64 NumPlays { get; set; }
        public IEnumerable<string> Albums { get; set; }
        public List<IEnumerable<Album>> AlbumList { get; set; }
    }
}

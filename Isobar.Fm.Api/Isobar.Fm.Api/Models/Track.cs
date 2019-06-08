using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace Isobar.Fm.Api.Models
{
    [ExcludeFromCodeCoverage]
    public class Track
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
    }
}

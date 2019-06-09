using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace Isobar.Fm.Core.Models
{
    [ExcludeFromCodeCoverage]
    public class Track
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Int64 Duration { get; set; }
    }
}

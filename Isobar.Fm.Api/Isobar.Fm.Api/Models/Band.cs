﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Isobar.Fm.Api.Models
{
    public class Band
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Genre { get; set; }
        public string Biography { get; set; }
        public int NumPlays { get; set; }
        public int MyProperty { get; set; }
        public IEnumerable<string> Albums { get; set; }
        public List<IEnumerable<Album>> AlbumList { get; set; }
    }
}
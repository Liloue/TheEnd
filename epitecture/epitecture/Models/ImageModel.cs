﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epitecture.Models
{
    public class ImageModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        public bool Favorite { get; set; }

        public bool Is_album { get; set; }

        public List<ImageModel> Images { get; set; }
    }
}

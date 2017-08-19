﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epitecture.ViewModels
{
    public class AccountViewModel : PageViewModelBase
    {
        public UploadViewModel UploadVM { get; set; }

        public AccountViewModel()
        {
            UploadVM = new UploadViewModel(_imageService, this);
        }

        public async Task<bool> Initialize()
        {
            bool response = await _imageService.LoadAccountImagesAsync(_page);
            this.UpdateImages(_page.ImageList);
            return (response);
        }
    }
}

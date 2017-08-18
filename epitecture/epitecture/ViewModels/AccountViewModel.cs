﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epitecture.ViewModels
{
    public class AccountViewModel : PageViewModelBase
    {
        public async Task<bool> Initialize()
        {
            bool response = await _imageService.LoadAccountImagesAsync(_page);
            ImageList.Clear();
            foreach (var image in _page.ImageList)
            {
                ImageList.Add(image);
            }
            return (response);
        }
    }
}
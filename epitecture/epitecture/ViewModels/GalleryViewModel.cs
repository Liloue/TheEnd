using epitecture.Models;
using epitecture.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace epitecture.ViewModels
{
    public class GalleryViewModel : PageViewModelBase
    {
        public async Task<bool> Initialize()
        {
            bool response = await _imageService.LoadPageOfPicturesAsync(_page, 1);
            ImageList.Clear();
            foreach (var image in _page.ImageList)
            {
                ImageList.Add(image);
            }
            return (response);
        }
    }
}

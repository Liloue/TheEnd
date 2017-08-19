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

        public ResearchViewModel ResearchControlVM { get; set; }

        public GalleryViewModel()
        {
            ResearchControlVM = new ResearchViewModel(_imageService, this);
        }

        public async Task<bool> Initialize()
        {
            bool response = await _imageService.LoadPageOfPicturesAsync(_page, 1);
            this.UpdateImages(_page.ImageList);
            return (response);
        }
    }
}

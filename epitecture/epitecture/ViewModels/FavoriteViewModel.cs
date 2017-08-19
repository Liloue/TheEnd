using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using epitecture.Models;

namespace epitecture.ViewModels
{
    public class FavoriteViewModel : PageViewModelBase
    {
        protected override async void AddToFavorite(object parameter)
        {
            await _imageService.AddImageToFavoriteAsync((ImageModel)parameter);
            await Initialize();
        }

        public async Task<bool> Initialize()
        {
            bool response = await _imageService.LoadFavoritesAsync(_page);
            this.UpdateImages(_page.ImageList);
            return (response);
        }
    }
}

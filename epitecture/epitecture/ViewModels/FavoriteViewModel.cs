using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epitecture.ViewModels
{
    public class FavoriteViewModel : PageViewModelBase
    {
        public async Task<bool> Initialize()
        {
            bool response = await _imageService.LoadFavoritesAsync(_page);
            ImageList.Clear();
            foreach (var image in _page.ImageList)
            {
                ImageList.Add(image);
            }
            return (response);
        }
    }
}

using epitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epitecture.Services
{
    interface IImageService
    {
        string ClientId { get; set; }
        
        Task<bool> UploadImageAsync(string path);

        Task<bool> LoadAccountImagesAsync(ImagePageModel imagePage);

        Task<bool> LoadPageOfPicturesAsync(ImagePageModel imagePage, int page);

        Task<bool> DeleteImageAsync(ImageModel image);

        Task<bool> AddImageToFavoriteAsync(ImageModel image);

        Task<bool> RemoveImageFromFavoriteAsync(ImageModel image);

        Task<bool> SearchPicturesAsync(string quest, string size, string type, int page);

        Task<bool> LoadFavoritesAsync(ImagePageModel imagePage);
        
    }
}

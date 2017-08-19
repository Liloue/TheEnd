using epitecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace epitecture.Services
{
    public interface IImageService
    {
        string ClientId { get; set; }
        
        Task<bool> UploadImageAsync(StorageFile file);

        Task<bool> LoadAccountImagesAsync(ImagePageModel imagePage);

        Task<bool> LoadPageOfPicturesAsync(ImagePageModel imagePage, int page);

        Task<bool> DeleteImageAsync(ImageModel image);

        Task<bool> AddImageToFavoriteAsync(ImageModel image);

        Task<ResultModel> SearchPicturesAsync(string quest, string size, string type, int page = 0);

        Task<bool> LoadFavoritesAsync(ImagePageModel imagePage);
        
    }
}

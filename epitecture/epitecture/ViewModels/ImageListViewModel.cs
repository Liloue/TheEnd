using epitecture.Models;
using epitecture.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epitecture.ViewModels
{
    public class ImageListViewModel
    {

        private IImageService _imageService;

        private ImagePageModel _page;

        private ObservableCollection<ImageModel> _imageList;
        public ObservableCollection<ImageModel> ImageList
        {
            get
            {
                return _imageList;
            }
            set
            {
                _imageList = value;
            }
        }

        public ImageListViewModel()
        {
            _imageService = new ImgurService("13ee3954755a5c351d7afd24f16b507114f85029", "Liloue", "f7f8be70568959e");
            _page = new ImagePageModel();
            ImageList = new ObservableCollection<ImageModel>(_page.ImageList);
        }

        public async Task<bool> LoadGallery()
        {
            bool response = await _imageService.LoadPageOfPicturesAsync(_page, 1);
            _imageList = new ObservableCollection<ImageModel>(_page.ImageList);
            return (response);
        }

        public async Task<bool> LoadAccountImages()
        {
            bool response = await _imageService.LoadAccountImagesAsync(_page);
            _imageList = new ObservableCollection<ImageModel>(_page.ImageList);
            return (response);
        }

        public async Task<bool> LoadFavoritesImages()
        {
            bool response = await _imageService.LoadFavoritesAsync(_page);
            _imageList = new ObservableCollection<ImageModel>(_page.ImageList);
            return (response);
        }
    }
}

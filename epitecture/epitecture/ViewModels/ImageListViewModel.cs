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

        public ICommand OnAddImageToFavorite { get; set; }
        public ICommand OnGalleryImageButton { get; set; }
        public ICommand OnAccountImageButton { get; set; }
        public ICommand OnFavoritesButton { get; set; }

        public ImageListViewModel()
        {
            _imageService = new ImgurService("13ee3954755a5c351d7afd24f16b507114f85029", "Liloue", "f7f8be70568959e");
            _page = new ImagePageModel();
            ImageList = new ObservableCollection<ImageModel>(_page.ImageList);

            OnAddImageToFavorite = new CommandBase(AddToFavorite);
            OnGalleryImageButton = new CommandBase(ShowGalleryImages);
            OnAccountImageButton = new CommandBase(ShowAccountImages);
            OnFavoritesButton = new CommandBase(ShowFavorites);
        }

        public void AddToFavorite(object parameter)
        {
            _imageService.AddImageToFavoriteAsync((ImageModel)parameter);
        }

        public void ShowGalleryImages(object parameter)
        {
            LoadGallery();
        }

        public void ShowAccountImages(object parameter)
        {
            LoadAccountImages();
        }

        public void ShowFavorites(object parameter)
        {
            LoadFavoritesImages();
        }

        public async Task<bool> LoadGallery()
        {
            bool response = await _imageService.LoadPageOfPicturesAsync(_page, 1);
            _imageList.Clear();
            foreach (var image in _page.ImageList)
            {
                _imageList.Add(image);
            }
            return (response);
        }

        public async Task<bool> LoadAccountImages()
        {
            bool response = await _imageService.LoadAccountImagesAsync(_page);
            _imageList.Clear();
            foreach (var image in _page.ImageList)
            {
                _imageList.Add(image);
            }
            return (response);
        }

        public async Task<bool> LoadFavoritesImages()
        {
            bool response = await _imageService.LoadFavoritesAsync(_page);
            _imageList.Clear();
            foreach (var image in _page.ImageList)
            {
                _imageList.Add(image);
            }
            return (response);
        }
    }
}

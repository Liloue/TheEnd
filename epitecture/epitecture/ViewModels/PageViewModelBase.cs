using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using epitecture.Models;
using epitecture.Services;
using epitecture.Views;

namespace epitecture.ViewModels
{
    public abstract class PageViewModelBase : ViewModelBase
    {
        protected ImagePageModel _page;
        protected readonly IImageService _imageService;
        private Frame _rootFrame = Window.Current.Content as Frame;

        public ObservableCollection<ImageModel> ImageList { get; set; }
        public ICommand OnAddImageToFavorite { get; set; }
        public ICommand OnGalleryImageButton { get; set; }
        public ICommand OnAccountImageButton { get; set; }
        public ICommand OnFavoritesButton { get; set; }

        protected PageViewModelBase()
        {
            _imageService = ServiceProvider.Instance();
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
            _rootFrame.Navigate(typeof(GalleryControl), null);
        }

        public void ShowAccountImages(object parameter)
        {
            _rootFrame.Navigate(typeof(AccountControl), null);
        }

        public void ShowFavorites(object parameter)
        {
            _rootFrame.Navigate(typeof(FavoriteControl), null);
        }

        public void UpdateImages(List<ImageModel> resData)
        {
            ImageList = new ObservableCollection<ImageModel>(resData);
            RaisePropertyChanged(nameof(ImageList));
        }
    }
}

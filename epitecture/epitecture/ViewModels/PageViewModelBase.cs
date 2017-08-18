using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using epitecture.Models;
using epitecture.Services;

namespace epitecture.ViewModels
{
    public abstract class PageViewModelBase : ViewModelBase
    {
        protected ImagePageModel _page;
        protected readonly IImageService _imageService;

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
            // TODO Navigation to new control
        }

        public void ShowAccountImages(object parameter)
        {
            // TODO Navigation to new control
        }

        public void ShowFavorites(object parameter)
        {
            // TODO Navigation to new control
        }

    }
}

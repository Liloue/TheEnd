using epitecture.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;

namespace epitecture.ViewModels
{
    public class UploadViewModel : ViewModelBase
    {
        protected IImageService _imageService;

        protected AccountViewModel _parent;

        public ICommand OnBrowserButton { get; set; }

        public UploadViewModel(IImageService imageService, AccountViewModel parent)
        {
            _imageService = imageService;
            _parent = parent;
            OnBrowserButton = new CommandBase(Browser);
        }

        public async void Browser(object parameter)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker()
            {
                ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail,
                SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.PicturesLibrary
            };
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".gif");

            var file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                await _imageService.UploadImageAsync(file);
                await _parent.Initialize();
            }
        }
    }
}

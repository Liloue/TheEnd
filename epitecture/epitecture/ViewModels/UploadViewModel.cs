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

        private string _imagePath;
        private StorageFile _file;

        public string ImagePath
        {
            get
            {
                RaisePropertyChanged(nameof(ImagePath));
                return _imagePath;
            }
            set
            {
                _imagePath = value;
            }
        }

        public ICommand OnBrowserButton { get; set; }
        public ICommand OnUploadButton { get; set; }

        public UploadViewModel(IImageService imageService, AccountViewModel parent)
        {
            _imageService = imageService;
            _parent = parent;
            _imagePath = "";
            OnBrowserButton = new CommandBase(Browser);
            OnUploadButton = new CommandBase(Upload);
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

            _file = await picker.PickSingleFileAsync();
            if (_file != null)
            {
                // Application now has read/write access to the picked file
                ImagePath = _file.Path;
                RaisePropertyChanged(nameof(ImagePath));
            }
        }
        
        public async void Upload(object parameter)
        {
            await _imageService.UploadImageAsync(_file);
            await _parent.Initialize();
        }
    }
}

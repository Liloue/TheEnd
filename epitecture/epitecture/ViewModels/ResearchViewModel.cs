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
    public class ResearchViewModel : ViewModelBase
    {
        private readonly IImageService _imageService;
        private PageViewModelBase _parent;

        public ICommand OnSearchCommand { get; set; }
        public string SearchText { get; set; }
        public ObservableCollection<string> Sizes { get; set; }
        public string SelectedSize { get; set; }
        public ObservableCollection<string> Types { get; set; }
        public string SelectedType { get; set; }

        public ResearchViewModel(IImageService imageService, PageViewModelBase parent)
        {
            this._imageService = imageService;
            this._parent = parent;
            OnSearchCommand = new CommandBase(OnSearch);
            Sizes = new ObservableCollection<string>
            {
                "all",
                "small",
                "med",
                "big",
                "irg",
                "huge",
            };
            Types = new ObservableCollection<string>
            {
                "all",
                "jpg",
                "png",
                "gif",
                "anigif",
                "album",
            };
        }

        private async void OnSearch(object obj)
        {
            await HackOnSearch();
        }

        public async Task<bool> HackOnSearch()
        {
            var res = await _imageService.SearchPicturesAsync(SearchText, SelectedSize, SelectedType);
            if (res.Success)
                _parent.UpdateImages(res.Data);
            return res.Success;
        }
    }
}

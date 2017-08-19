using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using epitecture.Models;

namespace epitecture.ViewModels
{
    public class AccountViewModel : PageViewModelBase
    {
        public UploadViewModel UploadVM { get; set; }
        public ICommand RemoveImageCommand { get; set; }
        public override bool IsDeleteButtonVisible => true;


        public AccountViewModel()
        {
            UploadVM = new UploadViewModel(_imageService, this);
            RemoveImageCommand = new CommandBase(OnRemoveImage);
        }

        private async void OnRemoveImage(object obj)
        {
            await _imageService.DeleteImageAsync(obj as ImageModel);
            await this.Initialize();
        }

        public async Task<bool> Initialize()
        {
            bool response = await _imageService.LoadAccountImagesAsync(_page);
            this.UpdateImages(_page.ImageList);
            return (response);
        }
    }
}

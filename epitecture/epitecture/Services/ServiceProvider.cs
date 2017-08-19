using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epitecture.Services
{
    public class ServiceProvider
    {
        private static IImageService _imageService;
        private static readonly string _accessToken = "13ee3954755a5c351d7afd24f16b507114f85029";
        private static readonly string _userName = "Liloue";
        private static readonly string _clientId = "f7f8be70568959e";

        public static IImageService Instance()
        {
            if (_imageService == null)
                _imageService = new ImgurService(_accessToken, _userName, _clientId);
            return _imageService;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epitecture.Models
{
    public class ImagePageModel
    {
        private List<ImageModel> _imageList;
        public List<ImageModel> ImageList
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

        public ImagePageModel()
        {
            _imageList = new List<ImageModel>();
        }
    }
}

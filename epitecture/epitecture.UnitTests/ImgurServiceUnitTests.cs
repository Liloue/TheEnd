
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using epitecture.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using epitecture.Services;
using epitecture.ViewModels;

namespace epitecture.UnitTests
{
    [TestClass]
    public class ImgurServiceUnitTests
    {
        private int _toto;
        [TestInitialize]
        public void Init()
        {
        }

        private ImageModel GenerateImageModel(string id)
        {
            return new ImageModel
            {
                Favorite = true,
                Id = id,
                Images = null,
                Is_album = false,
                Link = "http://fakelink.com",
                Title = $"Image{id}"
            };
        }

        private ImageModel GenerateAlbumModel(string id, int numberOfImage = 3)
        {
            var images = new List<ImageModel>();
            for (int i = 0; i < numberOfImage; i++)
            {
                images.Add(GenerateImageModel(id + i));
            }

            return new ImageModel
            {
                Favorite = true,
                Id = id,
                Images = images,
                Is_album = true,
                Link = "http://fakelink.com",
                Title = $"Image{id}"
            };
        }
        [TestMethod]
        public void SearchImagesWithResult()
        {
            var galleryVM = new GalleryViewModel();
            galleryVM.UpdateImages(new List<ImageModel>
            {
                GenerateImageModel("1"),
                GenerateImageModel("2"),
                GenerateAlbumModel("999", 5),
                GenerateImageModel("3"),
                GenerateAlbumModel("1010"),
                GenerateImageModel("4"),
                GenerateImageModel("5"),
            });

            Assert.AreEqual(13, galleryVM.ImageList.Count);
        }

        [TestMethod]
        public void werwef()
        {
            Assert.AreEqual(42, _toto);
            _toto = 0;
        }
    }
}

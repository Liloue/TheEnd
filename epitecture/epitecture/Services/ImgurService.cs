﻿using epitecture.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace epitecture.Services
{
    public class ImgurService : IImageService
    {
        private string _clientId;
        public string ClientId
        {
            get
            {
                return _clientId;
            }
            set
            {
                _clientId = value;
            }
        }

        private string _accessToken;
        public string AccessToken
        {
            get
            {
                return _accessToken;
            }
            set
            {
                _accessToken = value;
            }
        }

        private string _userName;
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
            }
        }

        private HttpClient _myClient = new HttpClient();

        public ImgurService(string accesToken, string userName, string clientId)
        {
            _accessToken = accesToken;
            _userName = userName;
            _clientId = clientId;
        }

        public async Task<bool> LoadPageOfPicturesAsync(ImagePageModel imagePage, int page)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri("https://api.imgur.com/3/gallery/hot/viral/day/" + page));
            request.Headers.Add("Authorization", "Client-ID " + _clientId);

            var response = await _myClient.SendAsync(request);
            var toto = await response.Content.ReadAsStringAsync();
            if (imagePage != null)
            {
                imagePage.ImageList = Newtonsoft.Json.JsonConvert.DeserializeObject<ResultModel>(toto).Data;
            }
            return (response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        public async Task<bool> LoadAccountImagesAsync(ImagePageModel imagePage)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri("https://api.imgur.com/3/account/me/images"));
            request.Headers.Add("Authorization", "Bearer " + _accessToken);

            var response = await _myClient.SendAsync(request);
            var toto = await response.Content.ReadAsStringAsync();
            if (imagePage != null)
            {
                imagePage.ImageList = Newtonsoft.Json.JsonConvert.DeserializeObject<ResultModel>(toto).Data;
            }
            return (response.IsSuccessStatusCode);
        }

        public async Task<bool> UploadImageAsync(StorageFile file)
        {
            return await Task.Run<bool>(async () =>
            { 
                var buffer = await FileIO.ReadBufferAsync(file);
                byte[] fileContent;
                using (var dataReader = Windows.Storage.Streams.DataReader.FromBuffer(buffer))
                {
                    fileContent = new byte[buffer.Length];
                    dataReader.ReadBytes(fileContent);
                }
                string imageBase64 = Convert.ToBase64String(fileContent);

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri("https://api.imgur.com/3/image"));
                request.Headers.Add("Authorization", "Bearer " + _accessToken);
                request.Content = new MultipartFormDataContent();
                (request.Content as MultipartFormDataContent).Add(new StringContent(imageBase64), "image");
                // new StringContent(imageBase64);

                var response = await _myClient.SendAsync(request);
                return (response.StatusCode == System.Net.HttpStatusCode.OK);
            });
        }

        public async Task<bool> DeleteImageAsync(ImageModel image)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, new Uri("https://api.imgur.com/3/image/" + image.Id));
            request.Headers.Add("Authorization", "Bearer " + _accessToken);

            var response = await _myClient.SendAsync(request);
            return (response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        public async Task<bool> AddImageToFavoriteAsync(ImageModel image)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri("https://api.imgur.com/3/image/" + image.Id + "/favorite"));
            request.Headers.Add("Authorization", "Bearer " + _accessToken);

            var response = await _myClient.SendAsync(request);
            return (response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        public async Task<bool> RemoveImageFromFavoriteAsync(ImageModel image)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri("https://api.imgur.com/3/image/" + image.Id + "/favorite"));
            request.Headers.Add("Authorization", "Bearer " + _accessToken);

            var response = await _myClient.SendAsync(request);
            return (response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        public async Task<bool> SearchPicturesAsync(string quest, string size, string type, int page)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri("https://api.imgur.com/3/gallery/search/time/all/" + page + "?q_type=" + type + "?q_size_px=" + size + "&q=" + quest));
            request.Headers.Add("Authorization", "Client-ID " + _clientId);

            var response = await _myClient.SendAsync(request);
            return (response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        public async Task<bool> LoadFavoritesAsync(ImagePageModel imagePage)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri("https://api.imgur.com/3/account/" + _userName + "/favorites/"));
            request.Headers.Add("Authorization", "Bearer " + _accessToken);

            var response = await _myClient.SendAsync(request);
            var toto = await response.Content.ReadAsStringAsync();
            if (imagePage != null)
            {
                imagePage.ImageList = Newtonsoft.Json.JsonConvert.DeserializeObject<ResultModel>(toto).Data;
            }
            return (response.IsSuccessStatusCode);
        }
    }
}

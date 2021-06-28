using Newtonsoft.Json;
using PruebaTecnica.Models;
using PruebaTecnica.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Services
{
    public class PushNotificationService
    {
        public ObservableCollection<PushNotificationModel> pushNotification { get; set; }

        public PushNotificationService()
        {
            if (pushNotification == null)
            {
                pushNotification = new ObservableCollection<PushNotificationModel>();
            }
        }

        public async Task<bool> SendMessage(FirebaseNotifyRequest request)
        {
            bool response = true;

            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.firebaseKey);
                var contentRequest = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, Constants.applicationJson);
                var responseApi = await client.PostAsync(new Uri(Constants.firebaseApi), contentRequest);

                if (!(responseApi.StatusCode == HttpStatusCode.OK))
                {
                    response = false;
                }
            }
            catch (Exception ex)
            {
                response = false;
            }

            return response;
        }
    }
}

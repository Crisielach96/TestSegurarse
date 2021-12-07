using Newtonsoft.Json;
using Servicios.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Servicios
{
    public class Service
    {
        public async Task <object> Test(string name,string lastname)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://segurarse.com.ar/qa/pruebas/testencrypt");


                var authorization = name + lastname;
                var encode = Base64Encode(authorization);
                var json = JsonConvert.SerializeObject(new User() { name = name, lastname = lastname });
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                //httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", encode);
                var response = await client.PostAsync(client.BaseAddress, data);
                return response;
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}

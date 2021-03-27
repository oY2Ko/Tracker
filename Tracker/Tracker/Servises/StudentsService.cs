using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tracker.Models;

namespace Tracker.Servises
{
    class StudentsService
    {
        const string Url = "http://192.168.1.4:53002/api/Students/"; 

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            IncludeFields = true,
        };
        // настройка клиента
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        // получаем всех студентов
        public async Task<IEnumerable<Student>> Get()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url);
            return JsonSerializer.Deserialize<IEnumerable<Student>>(result, options);
        }

        // добавляем одного студента
        public async Task<Student> Add(Student student)
        {
            HttpClient client = GetClient();
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonSerializer.Serialize(student),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonSerializer.Deserialize<Student>(
                await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<Student> Update(Student student)
        {
            HttpClient client = GetClient();
            var response = await client.PutAsync(Url,
                new StringContent(
                    JsonSerializer.Serialize(student),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonSerializer.Deserialize<Student>(
                await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<Student> Delete(int id)
        {
            HttpClient client = GetClient();
            var response = await client.DeleteAsync(Url + id);
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonSerializer.Deserialize<Student>(
               await response.Content.ReadAsStringAsync(), options);
        }
    }
}

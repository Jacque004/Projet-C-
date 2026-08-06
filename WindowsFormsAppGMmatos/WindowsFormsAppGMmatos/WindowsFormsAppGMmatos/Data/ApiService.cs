using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using WindowsFormsAppGMmatos.Models;

namespace WindowsFormsAppGMmatos.Data
{
    public static class ApiService
    {
        private static readonly HttpClient Http = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(15)
        };

        private static readonly JavaScriptSerializer Json = new JavaScriptSerializer();

        private static string BaseUrl
        {
            get
            {
                var url = ConfigurationManager.AppSettings["ApiBaseUrl"];
                return string.IsNullOrWhiteSpace(url)
                    ? "http://localhost/Projet-C/api/"
                    : url.TrimEnd('/') + "/";
            }
        }

        public static async Task<List<Client>> GetClientsAsync()
        {
            var json = await GetAsync("clients.php");
            return Json.Deserialize<List<Client>>(NormalizeKeys(json));
        }

        public static async Task CreateClientAsync(Client client)
        {
            await SendAsync(HttpMethod.Post, "clients.php", ToClientPayload(client));
        }

        public static async Task UpdateClientAsync(Client client)
        {
            await SendAsync(HttpMethod.Put, "clients.php?id=" + client.Id, ToClientPayload(client));
        }

        public static async Task DeleteClientAsync(int id)
        {
            await SendAsync(HttpMethod.Delete, "clients.php?id=" + id, null);
        }

        public static async Task<List<Materiel>> GetMaterielsAsync()
        {
            var json = await GetAsync("materiel.php");
            return Json.Deserialize<List<Materiel>>(NormalizeKeys(json));
        }

        public static async Task CreateMaterielAsync(Materiel materiel)
        {
            await SendAsync(HttpMethod.Post, "materiel.php", ToMaterielPayload(materiel));
        }

        public static async Task UpdateMaterielAsync(Materiel materiel)
        {
            await SendAsync(HttpMethod.Put, "materiel.php?id=" + materiel.Id, ToMaterielPayload(materiel));
        }

        public static async Task DeleteMaterielAsync(int id)
        {
            await SendAsync(HttpMethod.Delete, "materiel.php?id=" + id, null);
        }

        private static object ToClientPayload(Client c)
        {
            return new
            {
                nom = c.Nom,
                prenom = c.Prenom,
                email = c.Email,
                telephone = c.Telephone,
                adresse = c.Adresse
            };
        }

        private static object ToMaterielPayload(Materiel m)
        {
            return new
            {
                reference = m.Reference,
                designation = m.Designation,
                categorie = m.Categorie,
                quantite = m.Quantite,
                prix_jour = m.PrixJour,
                etat = m.Etat
            };
        }

        private static async Task<string> GetAsync(string path)
        {
            using (var response = await Http.GetAsync(BaseUrl + path))
            {
                var body = await response.Content.ReadAsStringAsync();
                EnsureSuccess(response, body);
                return body;
            }
        }

        private static async Task SendAsync(HttpMethod method, string path, object payload)
        {
            using (var request = new HttpRequestMessage(method, BaseUrl + path))
            {
                if (payload != null)
                {
                    var json = Json.Serialize(payload);
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                }

                using (var response = await Http.SendAsync(request))
                {
                    var body = await response.Content.ReadAsStringAsync();
                    EnsureSuccess(response, body);
                }
            }
        }

        private static void EnsureSuccess(HttpResponseMessage response, string body)
        {
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            string message = body;
            try
            {
                var err = Json.Deserialize<Dictionary<string, object>>(body);
                if (err != null && err.ContainsKey("error"))
                {
                    message = Convert.ToString(err["error"]);
                }
            }
            catch
            {
                // keep raw body
            }

            throw new InvalidOperationException(
                "API (" + (int)response.StatusCode + "): " + message);
        }

        /// <summary>
        /// Convertit les clés snake_case PHP (prix_jour) vers PascalCase C#.
        /// </summary>
        private static string NormalizeKeys(string json)
        {
            return json
                .Replace("\"id\"", "\"Id\"")
                .Replace("\"nom\"", "\"Nom\"")
                .Replace("\"prenom\"", "\"Prenom\"")
                .Replace("\"email\"", "\"Email\"")
                .Replace("\"telephone\"", "\"Telephone\"")
                .Replace("\"adresse\"", "\"Adresse\"")
                .Replace("\"reference\"", "\"Reference\"")
                .Replace("\"designation\"", "\"Designation\"")
                .Replace("\"categorie\"", "\"Categorie\"")
                .Replace("\"quantite\"", "\"Quantite\"")
                .Replace("\"prix_jour\"", "\"PrixJour\"")
                .Replace("\"etat\"", "\"Etat\"");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Escuela_DAL;

namespace ServiciosWeb.ClienteConsola
{
    class Program
    {
        static void Main(string[] args)
        {

            //Invocar Servicio Rest

            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://localhost:44384");

            var request = clienteHttp.GetAsync("api/Alumnos").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Object>>(resultString);


                foreach(var item in listado)
                {
                    Console.WriteLine(item);
                }

                Console.ReadLine();

                
            }

            

        }
    }
}

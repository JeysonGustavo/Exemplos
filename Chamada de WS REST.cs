using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            Put().Wait();
        }

        /*
         * Este exemplo demontra a chamada de um WS REST em uma outra aplicação. 
         * é necessário instalar o Newtonsoft.Json e Microsoft.AspNet.WebApi.Client
         */

        static async Task Put()
        {

            using (var client = new HttpClient())
            {
                //client.BaseAddress = new System.Uri("http://192.168.0.96/WebApi/");

                //Url Principal, uso em teste local
                client.BaseAddress = new System.Uri("http://localhost:60070/");
                client.DefaultRequestHeaders.Accept.Clear();
                //informar que será em JSON
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;

                //POST FUNCIONA!
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("nome", "JEYSON"),
                    new KeyValuePair<string, string>("sobrenome", "POST COM VAR"),
                    new KeyValuePair<string, string>("flag", "1")
                });

                /*
                 * OBSERVAÇÃO: 
                 * quando usar var para passar os parametros usar o PostAsync("caminho", var), como mostra abaixo
                //var content = new FormUrlEncodedContent(new[]
                //{
                //    new KeyValuePair<string, string>("nome", "JEYSON"),
                //    new KeyValuePair<string, string>("sobrenome", "POST COM VAR"),
                //    new KeyValuePair<string, string>("flag", "1")
                //});
                 *
                 *   quando usar o objeto(Pessoa) neste exemplo usar o PostAsJsonAsync("caminho", objeto), como mostra abaixo
                 *   Pessoa p = new Pessoa()
                     {
                        nome = "JEYSON",
                        sobrenome = "POST",
                        flag = 1
                     };
                 * 
                 */

                /*
                 * Passar o que deseja usar, nesse exemplo quero fazer um insert, então uso POST.
                 * Passo o caminho do controller/a ação que quero acessar do controller, o meu objeto/var

                */
                response = await client.PostAsync("Objeto/Inserir", content);
                //captura o retorno do WS em string
                string retornoPost2 = await response.Content.ReadAsStringAsync();
            }
        }

//teste commit git
    }
}

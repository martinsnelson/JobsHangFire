using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace JobsHangFire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static readonly UTF8Encoding _utf8 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost]
        [Route("PostDocument")]
        public void PostDocument([FromBody] string value)
        {
            var client = new RestClient("https://app.clicksign.com/api/v1/documents?access_token=55785e0a-b4b6-4847-b28f-4254e6fedfa4");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\r\n  \"document\": {\r\n    \"path\": \"/Contrato de Prestação de Serviços-camila.pdf\",\r\n    \"content_base64\": \"data:application/pdf;base64,,TmVsc29u\",\r\n    \"deadline_at\": \"2020-03-23T14:30:59-03:00\",\r\n    \"auto_close\": true,\r\n    \"locale\": \"pt-BR\",\r\n    \"sequence_enabled\": false\r\n  }\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            // var uri = @"http://sandbox.clicksign.com/api/v1/documents?access_token=1cdb03b5-8eac-492c-bdaf-756b8cfd29f7";
            // var uri = @"http://sandbox.clicksign.com/api/v1/documents?access_token=1cdb03b5-8eac-492c-bdaf-756b8cfd29f7";

            // using (HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri))
            // {
            //     req.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            //     req.Headers.Add("Cache-Control", "no-cache");
            //     // req.Headers.Add("otherHeader", myValue);
            //     //etc. more headers added, as needed...

            //     var cconsent = new
            //     {
            //         document = new
            //         {
            //             path = "/12345678910111213141516.pdf",
            //             content_base64 = "data:application/pdf;base64,,TmVsc29u",
            //             deadline_at = "2020-03-22T14:30:59-03:00",
            //             auto_close = true,
            //             locale = "pt-BR",
            //             sequence_enabled = false
            //         },
            //     };

            //     String jsonObject = JsonConvert.SerializeObject(cconsent, Formatting.Indented);
            //     req.Content = new StringContent(jsonObject, _utf8, "application/json");

            //     using (HttpResponseMessage response = await _httpClient.SendAsync(req).ConfigureAwait(false))
            //     {
            //         Int32 responseHttpStatusCode = (Int32)response.StatusCode;
            //         Console.WriteLine("Got response: HTTP status: {0} ({1})", response.StatusCode, responseHttpStatusCode);
            //     }

            // return "ok";
            // }

            #region UM

            // try
            // {
            //     var url = "http://sandbox.clicksign.com/api/v1/documents?access_token=1cdb03b5-8eac-492c-bdaf-756b8cfd29f7";
            //     var cliente = new HttpClient();
            //     cliente.DefaultRequestHeaders.Clear();

            //     HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, url);

            //     var documentoRequest = new
            //     {
            //         path = "/teste_" + DateTime.Now + ".doc"
            //     };

            //     var request = JsonConvert.SerializeObject(documentoRequest);

            //     var requestBody = JsonConvert.SerializeObject(request, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            //     requestMessage.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            //     var response = cliente.SendAsync(requestMessage);

            //     var responseContent = response.Result.Content.ReadAsStringAsync().Result;

            //     if (response.Result.IsSuccessStatusCode)
            //     {
            //         var documentoResponse = JsonConvert.DeserializeObject<dynamic>(responseContent);
            //     }

            //     return responseContent;
            // }
            // catch (System.Exception)
            // {
            //     throw;
            // }

            #endregion
        }
    }
}

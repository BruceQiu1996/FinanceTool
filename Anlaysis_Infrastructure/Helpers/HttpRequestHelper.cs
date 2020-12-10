using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Anlaysis_Infrastructure.Helpers
{
    public class HttpRequestHelper
    {
        public async static Task<HttpResponseMessage> GetAsync(string url) 
        {
            try
            {
                using (HttpClient client = new HttpClient()) 
                {
                    return await client.GetAsync(url);
                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anlaysis_Infrastructure;
using Anlaysis_Infrastructure.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnalysisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public HomeController()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        [HttpGet("main")]
        public async Task<IActionResult> GetInfo(string lsts) 
        {
            var result=await HttpRequestHelper.GetAsync($"{Const.BaseUrl}list={lsts}");
            if (result.IsSuccessStatusCode) 
            {
                return Ok(System.Text.Encoding.GetEncoding("gb2312").GetString(await result.Content.ReadAsByteArrayAsync()));
            }
            return Problem("Server Error");
        }

        [HttpGet("tops")]
        public async Task<IActionResult> GetTops(string local,int page)
        {
            if (string.IsNullOrEmpty(local))
                return BadRequest();
            var url = $"{Const.Tops}&page={page}$node={local}";
            var result = await HttpRequestHelper.GetAsync($"{Const.Tops}&page={page}&node={local}");
            if (result.IsSuccessStatusCode)
            {
                var temp = await result.Content.ReadAsStringAsync();
                return Ok(await result.Content.ReadAsStringAsync());
            }
            return Problem("Server Error");
        }

        [HttpGet("lasts")]
        public async Task<IActionResult> GetLasts(string local, int page)
        {
            if (string.IsNullOrEmpty(local))
                return BadRequest();
            var result = await HttpRequestHelper.GetAsync($"{Const.Lasts}&page={page}&node={local}");
            if (result.IsSuccessStatusCode)
            {
                return Ok(await result.Content.ReadAsStringAsync());
            }
            return Problem("Server Error");
        }

        [HttpGet("news")]
        public async Task<IActionResult> GetNews(int? page)
        {
            if (page == null) return BadRequest();
            var result = await HttpRequestHelper.GetAsync($"{Const.News}&page={page}");
            if (result.IsSuccessStatusCode)
            {
                return Ok(await result.Content.ReadAsStringAsync());
            }
            return Problem("Server Error");
        }
    }
}

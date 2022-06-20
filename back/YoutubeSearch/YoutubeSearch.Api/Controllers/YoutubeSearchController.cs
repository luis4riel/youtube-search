using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using YoutubeSearch.Application.Interfaces;
using YoutubeSearch.Domain.Models;

namespace YoutubeSearch.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YoutubeSearchController : ControllerBase
    {
        public IYoutubeSearchService YoutubeSearchService { get; set; }

        public YoutubeSearchController(IYoutubeSearchService youtubeSearchService)
        {
            YoutubeSearchService = youtubeSearchService;
        }

        [HttpPost("SearchByValueContent/{valueContent}")]
        public async Task<IActionResult> SearchByValueContent(string valueContent)
        {
            try
            {
                return Ok(YoutubeSearchService.SearchContent(valueContent));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred when trying search by value content: {e.Message}");
            }
        }

        [HttpGet("GetAllSearchResults")]
        public async Task<IActionResult> GetAllSearchResults()
        {
            try
            {
                var result = await YoutubeSearchService.GetAllSearchResultsAsync();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred when trying get all results: {e.Message}");
            }
        }

        [HttpPost("AddSearchResult/{id}")]
        public bool AddSearchResult(int id)
        {
            //todo pegar o objeto e enviar aqui...
            string example = "{\"ResourceGuid\":\"7ade6a17-5bb8-4fdb-ba02-f8f91ef94f49\",\"SnippetGuid\":\"6e344251-5095-4163-8996-9a72e150f6e8\",\"ETag\":\"7GkoR1-c4xQxdFSp-g_Xz3seyls\",\"ResourceId\":{\"ChannelId\":null,\"Kind\":\"youtube#video\",\"PlaylistId\":null,\"VideoId\":\"x_vxcQfZctU\",\"ETag\":null},\"Kind\":\"youtube#searchResult\",\"Snippet\":{\"ChannelId\":\"UCVFbXI6Gu8U2f9Gjtxw4A-Q\",\"ChannelTitle\":\"UOL\",\"Description\":\"OcolunistaJosiasdeSouzacomentouhoje,duranteaparticipaçãonoUOLNews,sobrearepercussãododesfiledaescolade...\",\"LiveBroadcastContent\":\"none\",\"PublishedAtRaw\":\"2022-04-20T15:27:50Z\",\"PublishedAt\":\"2022-04-20T12:27:50-03:00\",\"Title\":\"asd\",\"ETag\":null}}";

            SearchResult abc = JsonSerializer.Deserialize<SearchResult>(example);

            return YoutubeSearchService.Add(abc).Result;
        }
        
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                return await YoutubeSearchService.Delete(id) ? Ok("Success") : BadRequest("It was not possible to delete event");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred when trying to delete event: {ex.Message}");
            }
        }
    }
}

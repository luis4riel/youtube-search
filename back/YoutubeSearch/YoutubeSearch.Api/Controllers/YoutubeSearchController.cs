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

        [HttpPost("AddSearchResult")]
        public bool AddSearchResult(SearchResult content)
        {
            return YoutubeSearchService.Add(content).Result;
        }
        
        [HttpDelete("Delete/{etag}")]
        public async Task<IActionResult> Delete(string etag)
        {
            try
            {
                return await YoutubeSearchService.Delete(etag) ? Ok(true) : BadRequest("It was not possible to delete event");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred when trying to delete event: {ex.Message}");
            }
        }
    }
}

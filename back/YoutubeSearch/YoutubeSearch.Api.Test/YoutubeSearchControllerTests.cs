
using FluentAssertions;
using Moq;
using YoutubeSearch.Api.Controllers;
using YoutubeSearch.Application.Interfaces;
using YoutubeSearch.Domain.Models;
using YoutubeSearch.Tests.Common;

namespace YoutubeSearch.Api.Tests
{
    [TestClass]
    public class YoutubeSearchControllerTests
    {
        public YoutubeSearchController Controller { get; set; }
        public Mock<IYoutubeSearchService> Service { get; set; }
        public YoutubeSearchControllerTests()
        {
            Service = new Mock<IYoutubeSearchService>();
            Service.Setup(x => x.Add(It.IsAny<SearchResult>()).Result).Returns(true);
            Service.Setup(x => x.Delete(It.IsAny<string>()).Result).Returns(true);
            Service.Setup(x => x.SearchContent(It.IsAny<string>())).Returns(It.IsAny<string>());
            Service.Setup(x => x.GetAllSearchResultsAsync().Result).Returns(ObjectMother.GetAllResults());

            Controller = new YoutubeSearchController(Service.Object);
        }

        [TestMethod]
        public void Test_YoutubeSearchController_AddSearchResult_ShouldBeOk()
        {
            //arrange
            SearchResult content = ObjectMother.GetFakeSearchResult();

            //act
            var response = Controller.AddSearchResult(content);

            //assert
            response.Should().BeTrue();
        }

        [TestMethod]
        public void Test_YoutubeSearchController_DeleteSearchResult_ShouldBeOk()
        {
            //arrange
            SearchResult content = ObjectMother.GetFakeSearchResult();

            //act
            var response = Controller.Delete(content.ETag);

            //assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public void Test_YoutubeSearchController_SearchContent_ShouldBeOk()
        {
            //arrange
            string content = "abc,bolinhas";

            //act
            var response = Controller.SearchByValueContent(content);

            //assert
            response.Should().NotBeNull();
        }

        [TestMethod]
        public void Test_YoutubeSearchController_GetAllSearchResults_ShouldBeOk()
        {
            //act
            var response = Controller.GetAllSearchResults().Result;

            //assert
            response.Should().NotBeNull();
        }
    }
}
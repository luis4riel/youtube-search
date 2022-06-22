# youtube-search back-end

Simple API that allows listing channel/video details via YouTube Data API

Data API Returns a set of search results that match query parameters specified in the API request. By default, a search result set identifies matching video, channel, and playlist resources.

Is it possible to save/delete the result using sqlite resource

To run this project:
	- Build solution;
	- run in root directory "dotnet ef database update -s .\YoutubeSearch.Api\" to create database;
	- dotnet run .\YoutubeSearch.Api\ to Startup Project;

*Api reference
https://developers.google.com/youtube/v3/docs/search/list#.net

*Packages
https://www.nuget.org/profiles/google-apis-packages




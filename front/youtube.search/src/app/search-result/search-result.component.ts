import { Component, OnInit } from '@angular/core';
import { YoutubeSearchService } from '../services/youtubeSearchService.spec';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.scss']
})
export class SearchResultComponent implements OnInit {

  constructor(private youtubeSearchService: YoutubeSearchService) { }

  public ytSearchList: any;

  ngOnInit(): void {
    this.GetAllSearchResultsSaved();
  }

  public GetAllSearchResultsSaved(): void {
    this.youtubeSearchService.GetAllSearchResults().subscribe(
      data => {
      this.ytSearchList = data;
    });
  }
}

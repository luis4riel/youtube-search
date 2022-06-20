import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class YoutubeSearchService {
  baseUrl = ' https://localhost:7060';
  constructor(private http: HttpClient) {}

  GetAllSearchResults() {
    return this.http.get(this.baseUrl + '/YoutubeSearch/GetAllSearchResults');
  }
}

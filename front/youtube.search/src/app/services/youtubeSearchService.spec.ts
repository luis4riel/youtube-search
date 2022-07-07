import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class YoutubeSearchService {
  private baseUrl = ' https://localhost:7060/YoutubeSearch';
  private headers: { 'content-type': string };

  constructor(private http: HttpClient) {
    this.headers = { 'content-type': 'application/json' };
  }

  public GetAllSearchResults() {
    return this.http.get(this.baseUrl + '/GetAllSearchResults');
  }

  public SaveResult(item: any) {
    const body: string = JSON.stringify(item);
    return this.http
      .post(`${this.baseUrl}/AddSearchResult`, body, { headers: this.headers })
      .pipe(map((response: any) => response));
  }

  public DeleteResult(etag: any) {
    return this.http
      .delete(`${this.baseUrl}/Delete/${etag}`)
      .pipe(map((response: any) => response));
  }

  public SearchByValueContent(content: string) {
    return this.http
      .post(`${this.baseUrl}/SearchByValueContent/${content}`, null)
      .pipe(map((response: any) => response));
  }
}

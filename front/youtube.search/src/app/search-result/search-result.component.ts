import { Component, OnInit } from '@angular/core';
import { YoutubeSearchService } from '../services/youtubeSearchService.spec';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.css'],
})
export class SearchResultComponent implements OnInit {
  constructor(
    private youtubeSearchService: YoutubeSearchService,
    private toastr: ToastrService
  ) {}
  public ytSearchListSaved: any;
  public ytSearchListSearch: any;
  public controlSpinner = false;

  ngOnInit(): void {
    this.GetAllSearchResultsSaved();
  }

  public GetAllSearchResultsSaved(): any {
    this.youtubeSearchService.GetAllSearchResults().subscribe((data) => {
      this.ytSearchListSaved = data;
    });
  }
  public clearSearchResults(): any {
    this.ytSearchListSearch = null;
  }
  public GetAllSearchResults(content: string): any {
    if(content == null || content.trim() === '') {
      this.clearSearchResults();
      return;
    }
    this.controlSpinner = true;
    this.youtubeSearchService
      .SearchByValueContent(content)
      .subscribe((data) => {
        this.ytSearchListSearch = data;
        this.controlSpinner = false;
      });
  }

  public AddSearchResult(item: any): any {
    this.youtubeSearchService.SaveResult(item).subscribe((data) => {
      this.handleToasts(data);
    });
  }

  public RemoveSearchResult(etag: any): any {
    this.youtubeSearchService.DeleteResult(etag).subscribe((data) => {
      this.handleToasts(data);
    });
  }

  public showSuccess() {
    this.toastr.success('success in the request', 'Success!');
  }

  public showError(reason: string) {
    this.toastr.error(reason, 'Error');
  }

  public handleToasts(data: any) {
    this.GetAllSearchResultsSaved();
    if (data == true) {
      this.showSuccess();
    } else {
      this.showError(data.toString());
    }
  }

  public ClearUpdate() {
    this.GetAllSearchResultsSaved();
  }
}

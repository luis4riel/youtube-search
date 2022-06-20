export interface searchResult {
  Id: string;
  ETag: string;
  ResourceId: resourceId;
  Kind: string;
  Snippet: snippet;
}

export interface resourceId {
  Id: string;
  ChannelId: string;
  Kind: string;
  PlaylistId: string;
  VideoId: string;
  ETag: string;
}

export interface snippet {
  ChannelId: string;
  ChannelTitle: string;
  Description: string;
  LiveBroadcastContent: string;
  PublishedAtRaw: string;
  PublishedAt: Date;
  Title: string;
  ETag: string;
}

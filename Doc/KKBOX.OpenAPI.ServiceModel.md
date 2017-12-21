## `AlbumData`

Album meatadata.
```csharp
public class KKBOX.OpenAPI.ServiceModel.AlbumData

```

Properties

| Type | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `ArtistData` | Artist |  |  | 
| `List<String>` | AvailableTerritories |  |  | 
| `Boolean` | Explicitness |  |  | 
| `String` | Id |  |  | 
| `List<ImageData>` | Images |  |  | 
| `String` | Name |  |  | 
| `String` | ReleaseDate |  |  | 
| `String` | URL |  |  | 


## `AlbumOffsetData`

Album collection with offset data.
```csharp
public class KKBOX.OpenAPI.ServiceModel.AlbumOffsetData
    : OffsetData<List<AlbumData>>

```

## `APIStatus`

API response status.
```csharp
public enum KKBOX.OpenAPI.ServiceModel.APIStatus
    : Enum, IComparable, IFormattable, IConvertible

```

Enum

| Value | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `0` | Unknow |  |  | 
| `1` | Success |  |  | 
| `2` | Failed |  |  | 


## `ArtistData`

Artist metadata.
```csharp
public class KKBOX.OpenAPI.ServiceModel.ArtistData

```

Properties

| Type | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `String` | Id |  |  | 
| `List<ImageData>` | Images |  |  | 
| `String` | Name |  |  | 
| `String` | Url |  |  | 


## `BaseItemData`

```csharp
public class KKBOX.OpenAPI.ServiceModel.BaseItemData

```

Properties

| Type | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `String` | Id |  |  | 
| `List<ImageData>` | Images |  |  | 
| `String` | Title |  |  | 


## `BaseItemOffsetData`

BaseItem collection with offset data.
```csharp
public class KKBOX.OpenAPI.ServiceModel.BaseItemOffsetData
    : OffsetData<List<BaseItemData>>

```

## `ErrorData`

API error content.
```csharp
public class KKBOX.OpenAPI.ServiceModel.ErrorData

```

Properties

| Type | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `Int32` | Code | Error code. |  | 
| `String` | Message | Message. |  | 


## `FeaturedPlaylistOfCategoryData`

Featured Playlists of the category.
```csharp
public class KKBOX.OpenAPI.ServiceModel.FeaturedPlaylistOfCategoryData

```

Properties

| Type | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `String` | Id |  |  | 
| `List<ImageData>` | Images |  |  | 
| `OffsetData<List<PlaylistData>>` | Playlists |  |  | 
| `String` | Title |  |  | 


## `ImageData`

Image format.
```csharp
public class KKBOX.OpenAPI.ServiceModel.ImageData

```

Properties

| Type | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `Int32` | Height |  |  | 
| `String` | Url |  |  | 
| `Int32` | Width |  |  | 


## `KKOAuthResponse`

KKBOX OAuth 2.0 Authorize Response.
```csharp
public class KKBOX.OpenAPI.ServiceModel.KKOAuthResponse

```

Properties

| Type | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `OAuthTokenData` | Content | OAuth token data. |  | 
| `String` | ErrorMessage | Error message. |  | 
| `Exception` | Exception |  |  | 
| `APIStatus` | Staus | Response status. |  | 


## `NewReleaseData`

New release metadata.
```csharp
public class KKBOX.OpenAPI.ServiceModel.NewReleaseData

```

Properties

| Type | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `OffsetData<List<AlbumData>>` | Albums |  |  | 
| `String` | Id |  |  | 
| `String` | Title |  |  | 


## `OAuthTokenData`

OAuth token data.
```csharp
public class KKBOX.OpenAPI.ServiceModel.OAuthTokenData

```

Properties

| Type | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `String` | AccessToken | Access token. |  | 
| `Int32` | ExipresIn | Expires in. |  | 
| `String` | RefreshToken | Refresh token. |  | 
| `String` | Scope | Scope. |  | 
| `String` | TokenType | Token type. |  | 


## `OffsetData<T>`

Include PagingData Class.
```csharp
public class KKBOX.OpenAPI.ServiceModel.OffsetData<T>

```

Properties

| Type | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `T` | Data | Data tag. |  | 
| `PagingData` | Paging | Paging tag. |  | 
| `SummaryData` | Summary | Summary tag. |  | 


## `OwnerData`

Ower of the Playlist.
```csharp
public class KKBOX.OpenAPI.ServiceModel.OwnerData

```

Properties

| Type | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `String` | Id |  |  | 
| `String` | Name |  |  | 


## `PagingData`

Paging information.
```csharp
public class KKBOX.OpenAPI.ServiceModel.PagingData

```

Properties

| Type | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `Int32` | Limit | The size of one page. |  | 
| `String` | Next |  |  | 
| `Int32` | Offset | The index offset for first element. |  | 
| `String` | Previous |  |  | 


Methods

| Type | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `Boolean` | IsEnd() | Is to the last data. |  | 
| `Int32` | NextOffset() | Get next offset. |  | 


## `ParseResult<T>`

Indicated API response.
```csharp
public class KKBOX.OpenAPI.ServiceModel.ParseResult<T>

```

Properties

| Type | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `T` | Content | API response content. |  | 
| `ErrorData` | Error | API error content. |  | 


## `PlaylistData`

Playlist metadata.
```csharp
public class KKBOX.OpenAPI.ServiceModel.PlaylistData

```

Properties

| Type | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `String` | Description |  |  | 
| `String` | Id |  |  | 
| `List<ImageData>` | Images |  |  | 
| `OwnerData` | Owner |  |  | 
| `String` | Title |  |  | 
| `OffsetData<List<TrackData>>` | Tracks |  |  | 
| `String` | UpdateAt |  |  | 
| `String` | Url |  |  | 


## `PlaylistOffsetData`

Playlist collection with offset data.
```csharp
public class KKBOX.OpenAPI.ServiceModel.PlaylistOffsetData
    : OffsetData<List<PlaylistData>>

```

## `SearchResultData`

Search result.
```csharp
public class KKBOX.OpenAPI.ServiceModel.SearchResultData

```

Properties

| Type | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `OffsetData<List<AlbumData>>` | Albums | Album data collection. |  | 
| `OffsetData<List<ArtistData>>` | Artists | Artist data collection. |  | 
| `PagingData` | Paging |  |  | 
| `OffsetData<List<PlaylistData>>` | Playlists | Playlist data collection. |  | 
| `SummaryData` | Summary |  |  | 
| `OffsetData<List<TrackData>>` | Tracks | Track data collection. |  | 


## `SearchType`

The type of search. Default to search all types.
```csharp
public enum KKBOX.OpenAPI.ServiceModel.SearchType
    : Enum, IComparable, IFormattable, IConvertible

```

Enum

| Value | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `0` | artist |  |  | 
| `1` | album |  |  | 
| `2` | track |  |  | 
| `3` | playlist |  |  | 


## `StationData`

Station metadata.
```csharp
public class KKBOX.OpenAPI.ServiceModel.StationData

```

Properties

| Type | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `String` | Categroy | For Genre station. |  | 
| `String` | Id |  |  | 
| `List<ImageData>` | Images | For Moog station. |  | 
| `String` | Name |  |  | 
| `OffsetData<List<TrackData>>` | Tracks |  |  | 


## `StationListData`

Station data collection.
```csharp
public class KKBOX.OpenAPI.ServiceModel.StationListData

```

Properties

| Type | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `String` | Paging |  |  | 
| `List<StationData>` | Stations | Station collection. |  | 
| `String` | Summary |  |  | 


## `StationOffsetData`

Station collection with offset data.
```csharp
public class KKBOX.OpenAPI.ServiceModel.StationOffsetData
    : OffsetData<List<StationData>>

```

## `SummaryData`

Summary metadata.
```csharp
public class KKBOX.OpenAPI.ServiceModel.SummaryData

```

Properties

| Type | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `Int32` | Total |  |  | 


## `TerritoryType`

The type of territory.
```csharp
public enum KKBOX.OpenAPI.ServiceModel.TerritoryType
    : Enum, IComparable, IFormattable, IConvertible

```

Enum

| Value | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `0` | TW | Taiwan |  | 
| `1` | HK | Hong Kong |  | 
| `2` | SG | Singapore |  | 
| `3` | MY | Malaysia |  | 
| `4` | JP | Japan |  | 


## `TrackData`

Track metadata.
```csharp
public class KKBOX.OpenAPI.ServiceModel.TrackData

```

Properties

| Type | Name | Summary | Example | 
| --- | --- | --- | --- | 
| `AlbumData` | Album |  |  | 
| `List<String>` | AvailableTerritories |  |  | 
| `Nullable<Double>` | Duration |  |  | 
| `Boolean` | Explicitness |  |  | 
| `String` | Id |  |  | 
| `String` | Name |  |  | 
| `Int32` | TrackNumber |  |  | 
| `String` | URL |  |  | 


## `TrackOffsetData`

Track collection with offset data.
```csharp
public class KKBOX.OpenAPI.ServiceModel.TrackOffsetData
    : OffsetData<List<TrackData>>

```


# E-Book Repository API

## Search

### Search functions:
- Match search:  
`Search(IEBookSearchOptions options)`  

- Fuzzy search:  
`FuzzySearch(IEBookSearchOptions options)`  

> On `feature/full-search` branch: 
> - Match search:  
> `SearchByTitle(string title)`  
> `SearchByAuthor(string author)`  
> `SearchByKeywords(string keywords)`  
> `SearchByCategory(string category)`  
> `SearchByLanguage(string language)`  
>
> - Fuzzy search:  
> `FuzzySearchByTitle(string title)`  
> `FuzzySearchByAuthor(string author)`  
> `FuzzySearchByKeywords(string keywords)`  
> `FuzzySearchByCategory(string category)`  
> `FuzzySearchByLanguage(string language)`  

### Search Options  
```
public interface IEBookSearchOptions
{
    string Title { get; set; }
    string Author { get; set; }
    string Keywords { get; set; }
    string Language { get; set; }
    string Category { get; set; }
}
```

### Example search requests

Without fuzzy search:  
`GET /ebooks/search?title=the great gatsby&language=english`  

With fuzzy search:  
`GET /ebooks/search?title=the graet gatby&language=eglish&fuzzy=true`

## Filter

### Filter functions:  
- Match filter:  
`Filter(IEBooksFilterOptions options)`  

- Fuzzy filter:  
`FuzzyFilter(IEBooksFilterOptions options)`  

### Filter Options  
```
public interface IEBookFilterOptions
{
    string Title { get; set; }
    string Author { get; set; }
    string Keywords { get; set; }
    string Language { get; set; }
    string Category { get; set; }
}
```

### Example filter requests:

Without fuzzy filter:  
`GET /ebooks/filter?author=george&title=catch 22`  

With fuzzy filter:  
`GET /ebooks/filter?author=gorge&title=catc 25&fuzzy=true`


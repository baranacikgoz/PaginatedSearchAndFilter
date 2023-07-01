# PaginatedSearchAndFilter
PaginatedSearchAndFilter is a lightweight and flexible library designed to provide search and filter functionality for paginated data in your .NET applications. It simplifies the implementation of search and filter features in your API endpoints, allowing you to offer advanced filtering and searching capabilities directly from the frontend.

# Features
- Easy integration with your API endpoints
- Support for JSON request bodies to encapsulate search and filter criteria
- Programmatically construct and configure search requests using provided classes
- Integration with LINQ and Ardalis.Specification for querying and filtering data
- Seamless integration with EF Core for efficient database queries

# Installation
TODO: Provide installation instructions for the package once it is published.

# Usage
## Creating the SearchRequest Object
### Option 1: JSON Request Body
To use the SearchRequest object within a JSON request body, define an endpoint (controller or minimal API) that accepts a SearchRequest object as a parameter. This object will encapsulate the search and filter criteria. Here's an example:

```csharp
public class ProductsController
{
    [HttpPost("search")]
    public Task<PaginationResponse<ProductDto>> SearchAsync(SearchRequest request)
    {
        ... // use request object.
    }
}
```

Your endpoint will accept the JSON representation of the SearchRequest:
```json
{
  "advancedSearch": {
    "fields": ["title", "description"],
    "keyword": "phone"
  },
  "keyword": "apple",
  "advancedFilter": {
    "logic": "and",
    "filters": [
      {
        "field": "price",
        "operator": "gte",
        "value": "500"
      },
      {
        "field": "category",
        "operator": "eq",
        "value": "electronics"
      }
    ]
  },
  "pageNumber": 1,
  "pageSize": 10,
  "orderBy": ["price", "rating"]
}
```
By accepting the SearchRequest object as a parameter in your endpoint, you enable your frontend to send advanced search and filter requests, allowing users to perform complex searches and apply filters directly from your application.

### Option 2: Using the Constructor in Code
You can also create instances of the provided classes and configure the properties programmatically to define the search and filter options. Here's an example of using the models within your application:

```csharp
var searchRequest = new SearchRequest
{
    AdvancedSearch = new AdvancedSearch
    {
        Fields = new List<string> { "title", "description" },
        Keyword = "phone"
    },
    Keyword = "apple",
    AdvancedFilter = new AdvancedFilter
    {
        Logic = "and",
        Filters = new List<Filter>
        {
            new Filter
            {
                Field = "price",
                Operator = "gte",
                Value = "500"
            },
            new Filter
            {
                Field = "category",
                Operator = "eq",
                Value = "electronics"
            }
        }
    },
    PageNumber = 1,
    PageSize = 10,
    OrderBy = new List<string> { "price", "rating" }
};

```

## Examples
### LINQ Example
TODO: Provide an example of using LINQ with PaginatedSearchAndFilter once it is implemented.

### Specification Example
```csharp
public class ProductsBySearchRequestSpec : EntitiesBySearchRequestSpecification<Product, ProductDto>
{
    public ProductsBySearchRequestSpec(SearchRequest request)
        : base(request)
        {
        }
        
}

public class SearchProductsRequestHandler : IRequestHandler<SearchProductsRequest, PaginationResponse<ProductDto>>
{
    private readonly IReadRepository<Product> _repository;

    public SearchProductsRequestHandler(IReadRepository<Product> repository) => _repository = repository;

    public async Task<PaginationResponse<ProductDto>> Handle(SearchProductsRequest request, CancellationToken cancellationToken)
    {
        var spec = new ProductsBySearchRequestSpec(request);
        return await _repository.PaginateBySpecAsync<Product,ProductDto>(spec, cancellationToken);
    }
}
```

# Contributing
Contributions are welcome! If you encounter any issues or have suggestions for improvements, please open an issue on the GitHub repository. Additionally, feel free to submit pull requests with any enhancements or fixes you'd like to contribute.

# License
TODO: Add license information once it is determined for the package.
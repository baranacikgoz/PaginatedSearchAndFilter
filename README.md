# PaginatedSearchAndFilter

PaginatedSearchAndFilter is a lightweight and flexible library designed to provide search and filter functionality for paginated data in your .NET applications. It simplifies the implementation of search and filter features in your API endpoints, allowing you to offer advanced filtering and searching capabilities directly from the frontend.

## Features
- Easy integration with your API endpoints
- Support for JSON request bodies to encapsulate search and filter criteria
- Programmatically construct and configure search requests using provided classes
- Integration with LINQ and Ardalis.Specification for querying and filtering data
- Seamless integration with EF Core for efficient database queries

## Table of Contents
1. [Installation](#installation)
2. [Usage](#usage)
3. [Examples](#examples)
4. [Contributing](#contributing)
5. [License](#license)

## Installation
TODO: Provide installation instructions for the package once it is published.

## Usage

### Creating the SearchRequest Object
#### Option 1: JSON Request Body
To use the SearchRequest object within a JSON request body, define an endpoint (controller or minimal API) that accepts a SearchRequest object as a parameter. This object will encapsulate the search and filter criteria.

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
    "fields": [
      "title",
      "description"
    ],
    "keyword": "phone"
  },
  "keyword": "apple",
  "advancedFilter": {
    "logic": "and",
    "filters": [
      {
        "field": "price.value",
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
  "orderBys": [
    {
      "field": "price.value",
      "isDescending": true
    },
    {
      "field": "rating",
      "isDescending": true
    }
  ]
}

```

#### Option 2: Using the Constructor in Code
You can also create instances of the provided classes and configure the properties programmatically to define the search and filter options.

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
                Field = "price.value",
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
    OrderBys = new List<OrderBy> { new("price.value", true), new("rating", true) }
};

```


## Examples

### LINQ
TODO: Add examples for LINQ integration.

### Specification
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

## Contributing
Contributions are welcome! If you encounter any issues or have suggestions for improvements, please open an issue on the GitHub repository. Additionally, feel free to submit pull requests with any enhancements or fixes you'd like to contribute. For more details, please check out the [contributing guide](CONTRIBUTING.md).

## License
This project is licensed under the terms of the [Apache license](LICENSE).
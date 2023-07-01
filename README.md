# Entity Framework Change Tracking
Entity Framework Change Tracking for Domain project without direct dependency on Entity Framework

``` mermaid
graph TB
    subgraph UI 
        subgraph Sales.Tests
            Microsoft.EntityFrameworkCore.Sqlite
        end
        subgraph Sales.WebApi
            Microsoft.EntityFrameworkCore.SqlServer
        end
        subgraph Sales.WebApp
        end
    end
    subgraph Domain
        Sales
    end
    subgraph Infrastructure
        subgraph Sales.Infrastructure
            Microsoft.EntityFrameworkCore
        end
    end
    Sales.Infrastructure --> |references| Sales
    Sales.Tests & Sales.WebApi & Sales.WebApp --> |references| Sales & Sales.Infrastructure
```

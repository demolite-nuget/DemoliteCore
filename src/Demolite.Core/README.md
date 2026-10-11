# Demolite.Core

Shared `Result<T>` and `Error` types for the Demolite packages (`Demolite.Db`, `Demolite.Http`).

```csharp
using Demolite.Core.Models;

Result<int> Parse(string s) => int.TryParse(s, out var v)
    ? Result<int>.Success(v)
    : Result<int>.Failure(new Error("Parse.Invalid", $"'{s}' is not a number."));
```

# Demolite.Core

Shared `Result`, `Result<T>` and `Error` types for the Demolite packages (`Demolite.Db`, `Demolite.Http`).

```csharp
using Demolite.Core.Models;

Result<int> Parse(string s) => int.TryParse(s, out var v)
    ? Result<int>.Success(v)
    : Result<int>.Failure(new Error("Parse.Invalid", $"'{s}' is not a number."));
```

Use the non-generic `Result` for operations that return no value.

```csharp
Result Validate(string s) => s.Length > 0
    ? Result.Success()
    : Result.Failure(new Error("Validate.Empty", "The value is empty."));
```

`Result<T>` derives from `Result`, so `IsSuccess` and `Error` are available on both.

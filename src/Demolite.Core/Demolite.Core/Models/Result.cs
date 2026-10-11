namespace Demolite.Core.Models;

/// <summary>
/// The outcome of an operation without a value: either success or an <see cref="Error" /> on failure.
/// </summary>
public class Result
{
	/// <summary>
	/// Whether the operation succeeded.
	/// </summary>
	public bool IsSuccess { get; }

	/// <summary>
	/// The failure description. Only set when <see cref="IsSuccess" /> is <c>false</c>.
	/// </summary>
	public Error? Error { get; }

	/// <summary>
	/// Creates a result with the given state.
	/// </summary>
	/// <param name="success">Whether the operation succeeded.</param>
	/// <param name="error">The reason the operation failed, if it did.</param>
	protected Result(bool success, Error? error)
	{
		IsSuccess = success;
		Error = error;
	}

	/// <summary>
	/// Creates a successful result.
	/// </summary>
	public static Result Success() => new(true, null);

	/// <summary>
	/// Creates a failed result.
	/// </summary>
	/// <param name="error">The reason the operation failed.</param>
	public static Result Failure(Error error) => new(false, error);
}

/// <summary>
/// The outcome of an operation: either a <see cref="Value" /> on success or an <see cref="Core.Models.Error" /> on failure.
/// </summary>
/// <typeparam name="T">The type of the value returned on success.</typeparam>
public sealed class Result<T> : Result
{
	/// <summary>
	/// The resulting value. Only set when <see cref="Result.IsSuccess" /> is <c>true</c>.
	/// </summary>
	public T? Value { get; }

	private Result(T? value, bool success, Error? error) : base(success, error)
	{
		Value = value;
	}

	/// <summary>
	/// Creates a successful result.
	/// </summary>
	/// <param name="value">The value produced by the operation.</param>
	public static Result<T> Success(T value) => new(value, true, null);

	/// <summary>
	/// Creates a failed result.
	/// </summary>
	/// <param name="error">The reason the operation failed.</param>
	public static new Result<T> Failure(Error error) => new(default, false, error);
}

namespace Demolite.Core.Models;

/// <summary>
/// The outcome of an operation: either a <see cref="Value" /> on success or an <see cref="Error" /> on failure.
/// </summary>
/// <typeparam name="T">The type of the value returned on success.</typeparam>
public sealed class Result<T>
{
	/// <summary>
	/// Whether the operation succeeded.
	/// </summary>
	public bool IsSuccess { get; }

	/// <summary>
	/// The resulting value. Only set when <see cref="IsSuccess" /> is <c>true</c>.
	/// </summary>
	public T? Value { get; }

	/// <summary>
	/// The failure description. Only set when <see cref="IsSuccess" /> is <c>false</c>.
	/// </summary>
	public Error? Error { get; }

	private Result(T? value, bool success, Error? error)
	{
		Value = value;
		IsSuccess = success;
		Error = error;
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
	public static Result<T> Failure(Error error) => new(default, false, error);
}

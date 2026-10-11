using System.Text.Json.Serialization;

namespace Demolite.Core.Models;

/// <summary>
///     Describes why an operation failed.
/// </summary>
/// <param name="Code">A stable, machine-readable identifier such as <c>Db.NotFound</c>.</param>
/// <param name="Message">A human-readable description of the failure.</param>
/// <param name="Exception">The exception that caused the failure, if any. Excluded from JSON serialization.</param>
/// <param name="Metadata">Optional additional data that gives context to the failure.</param>
public sealed record Error(
	string Code,
	string Message,
	[property: JsonIgnore] Exception? Exception = null,
	IReadOnlyDictionary<string, object?>? Metadata = null);

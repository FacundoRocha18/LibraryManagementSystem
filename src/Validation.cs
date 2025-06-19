public static class Validation
{
	private static readonly int maxTitleLength = 100;
	private static readonly int maxNameLength = 50;
	public static ValidationResult IsValidTitle(string title)
	{
		ValidationResult? result = null;

		result = ValidateNonEmpty(title, "Title cannot be empty.");

		if (!result.IsValid)
		{
			return result;
		}

		result = ValidateLength(title, maxTitleLength, $"Title is too long. Maximum length is {maxTitleLength} characters.");

		if (!result.IsValid)
		{
			return result;
		}

		return new ValidationResult(true, "Title is valid.");
	}

	public static ValidationResult IsValidUserName(string name)
	{
		ValidationResult? result = null;

		result = ValidateNonEmpty(name, "Name cannot be empty.");

		if (!result.IsValid)
		{
			return result;
		}

		result = ValidateLength(name, maxNameLength, $"Name is too long. Maximum length is {maxNameLength} characters.");

		if (!result.IsValid)
		{
			return result;
		}

		return new ValidationResult(true, "Name is valid.");
	}

	private static ValidationResult ValidateNonEmpty(string? value, string errorMessage)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return new ValidationResult(false, errorMessage);
		}

		return new ValidationResult(true, "Value is valid.");
	}

	private static ValidationResult ValidateLength(string value, int maxLength, string errorMessage)
	{
		if (value.Length > maxLength)
		{
			return new ValidationResult(false, errorMessage);
		}

		return new ValidationResult(true, "Value length is valid.");
	}
}
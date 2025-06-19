public static class Validation
{
	private static readonly int maxTitleLength = 100;
	private static readonly int maxNameLength = 50;

	public static ValidationResult IsValidTitle(string title) => RunValidations(
		ValidateNonEmpty(title, "Title cannot be empty."),
		ValidateLength(title, maxTitleLength, $"Title is too long. Maximum length is {maxTitleLength} characters.")
	);

	public static ValidationResult IsValidUserName(string name) => RunValidations(
		ValidateNonEmpty(name, "Name cannot be empty."),
		ValidateLength(name, maxTitleLength, $"Name is too long. Maximum length is {maxNameLength} characters.")
	);

	private static ValidationResult RunValidations(params ValidationResult[] checks)
	{
		foreach (var check in checks)
		{
			if (!check.IsValid)
				return check;
		}
		return new ValidationResult(true, "All validations passed.");
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
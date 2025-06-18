public static class Validation
{
	public static ValidationResult IsValidBookName(string bookName)
	{
		if (string.IsNullOrWhiteSpace(bookName))
		{
			return new ValidationResult(false, "Book name cannot be empty.");
		}

		if (bookName.Length > 100)
		{
			return new ValidationResult(false, "Book name is too long. Maximum length is 100 characters.");
		}

		return new ValidationResult(true, "Book name is valid.");
	}
}
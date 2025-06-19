public static class BookInventory
{
	private static readonly List<string> books = new(5);

	public static OperationResult Add(string title)
	{
		string normalizedTitle = title.Trim().ToLowerInvariant();
		ValidationResult validationResult = Validation.IsValidBookName(normalizedTitle);

		if (!validationResult.IsValid)
		{
			return new(false, validationResult.Message);
		}

		if (IsFull())
		{
			return new(false, "Inventory is full. Cannot add more books.");
		}

		if (books.Contains(normalizedTitle))
		{
			return new(false, $"Book '{normalizedTitle}' already exists in inventory.");
		}

		books.Add(normalizedTitle);

		return new(true, $"Book '{normalizedTitle}' added to inventory.");
	}

	public static OperationResult Remove(string title)
	{
		ValidationResult validationResult = Validation.IsValidBookName(title);

		if (!validationResult.IsValid)
		{
			return new(false, validationResult.Message);
		}

		if (!books.Remove(title))
		{
			return new(false, $"Book '{title}' not found in inventory.");
		}

		return new(true, $"Book '{title}' removed from inventory.");
	}

	private static bool IsFull() => books.Count >= 5;

	public static string[] GetBooks()
	{
		if (books.Count == 0)
		{
			return [];
		}

		return [.. books];
	}
}
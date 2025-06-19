public static class BookInventory
{
	private static readonly List<string> books = new(5);
	private static readonly Dictionary<string, List<string>> borrowedBooks = new();
	private static readonly int maxBookInventorySize = 5;
	private static readonly int maxBorrowedBooks = 3;

	public static OperationResult<string> Add(string title)
	{
		string normalizedTitle = Normalize(title);

		ValidationResult validationResult = Validation.IsValidTitle(normalizedTitle);

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

	public static OperationResult<string> Remove(string title)
	{
		string normalizedTitle = Normalize(title);

		ValidationResult validationResult = Validation.IsValidTitle(normalizedTitle);

		if (!validationResult.IsValid)
		{
			return new(false, validationResult.Message);
		}

		if (!books.Remove(normalizedTitle))
		{
			return new(false, $"Book '{normalizedTitle}' not found in inventory.");
		}

		return new(true, $"Book '{normalizedTitle}' removed from inventory.");
	}

	public static string[] GetBooks()
	{
		if (books.Count == 0)
		{
			return [];
		}

		return [.. books];
	}

	public static OperationResult<string> SearchBook(string title)
	{
		string normalizedTitle = Normalize(title);

		ValidationResult validationResult = Validation.IsValidTitle(normalizedTitle);

		if (!validationResult.IsValid)
		{
			return new(false, validationResult.Message);
		}

		if (!books.Contains(normalizedTitle))
		{
			return new(false, $"Book '{normalizedTitle}' not found in inventory.");
		}

		return new(true, $"Book '{normalizedTitle}' found in inventory.", normalizedTitle);
	}

	public static OperationResult<string> BorrowBook(string user, string title)
	{
		string normalizedTitle = Normalize(title);
		string normalizedUser = Normalize(user);

		ValidationResult validation = Validation.IsValidTitle(normalizedTitle);
		if (!validation.IsValid)
		{
			return new(false, validation.Message);
		}

		if (!books.Contains(normalizedTitle))
		{
			return new(false, $"Book '{normalizedTitle}' not found in inventory.");
		}

		if (!borrowedBooks.ContainsKey(normalizedUser))
		{
			borrowedBooks[normalizedUser] = [];
		}

		if (borrowedBooks[normalizedUser].Count >= maxBorrowedBooks)
		{
			return new(false, $"User '{normalizedUser}' has already borrowed {maxBorrowedBooks} books.");
		}

		if (borrowedBooks[normalizedUser].Contains(normalizedTitle))
		{
			return new(false, $"User '{normalizedUser}' has already borrowed '{normalizedTitle}'.");
		}

		// Remove from inventory and add to borrowed list
		books.Remove(normalizedTitle);
		borrowedBooks[normalizedUser].Add(normalizedTitle);

		return new(true, $"User '{normalizedUser}' borrowed '{normalizedTitle}'.", normalizedTitle);
	}

	public static OperationResult<string> ReturnBook(string user, string title)
{
	string normalizedUser = Normalize(user);
	string normalizedTitle = Normalize(title);

	// Validación del título
	ValidationResult validation = Validation.IsValidTitle(normalizedTitle);
	if (!validation.IsValid)
	{
		return new(false, validation.Message);
	}

	// Verifica si el usuario existe en el diccionario de préstamos
	if (!borrowedBooks.ContainsKey(normalizedUser))
	{
		return new(false, $"User '{normalizedUser}' has no borrowed books.");
	}

	// Verifica si el usuario efectivamente tomó prestado ese libro
	if (!borrowedBooks[normalizedUser].Contains(normalizedTitle))
	{
		return new(false, $"Book '{normalizedTitle}' is not checked out by user '{normalizedUser}'.");
	}

	// Eliminar el libro del registro del usuario
	borrowedBooks[normalizedUser].Remove(normalizedTitle);

	// Si el inventario no está lleno, lo agregamos de nuevo
	if (!IsFull())
	{
		books.Add(normalizedTitle);
		return new(true, $"Book '{normalizedTitle}' returned by user '{normalizedUser}'.", normalizedTitle);
	}

	// Si está lleno, avisamos que se devolvió pero no se pudo reingresar
	return new(true, $"Book '{normalizedTitle}' returned by user '{normalizedUser}', but inventory is full. It was not re-added.", normalizedTitle);
}

	private static string Normalize(string str) => str.Trim().ToLowerInvariant();
	private static bool IsFull() => books.Count >= maxBookInventorySize;
}
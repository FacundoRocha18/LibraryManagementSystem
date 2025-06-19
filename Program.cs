public class LibraryManager
{
	public static void Main()
	{
		while (true)
		{
			ShowMenu();

			if (!int.TryParse(Console.ReadLine(), out int option))
			{
				Console.WriteLine("Invalid input. Please enter a number.");
				continue;
			}

			switch (option)
			{
				case 1:
					AddBook();
					break;

				case 2:
					RemoveBook();
					break;

				case 3:
					ShowBooks();
					break;

				case 0:
					Console.WriteLine("Exiting the program. Goodbye!");
					return;

				default:
					Console.WriteLine("Invalid option. Please select a valid option.");
					break;
			}
		}
	}

	private static void ShowMenu()
	{
		Console.WriteLine("\nPlease select an option:");
		Console.WriteLine("1 – Add a new book.");
		Console.WriteLine("2 – Remove a book.");
		Console.WriteLine("3 – Show all books.");
		Console.WriteLine("0 – Exit.");
		Console.Write("> Chosen option: ");
	}

	private static void AddBook()
	{
		Console.Write("Enter the book name to add: ");
		string newBook = (Console.ReadLine() ?? string.Empty).Trim();

		if (string.IsNullOrWhiteSpace(newBook))
		{
			Console.WriteLine("Book name cannot be empty.");
			return;
		}

		OperationResult addResult = BookInventory.Add(newBook);
		Console.WriteLine(addResult.Message);
	}

	private static void RemoveBook()
	{
		Console.Write("Enter the book name to remove: ");
		string bookToRemove = Console.ReadLine() ?? string.Empty;

		OperationResult removeResult = BookInventory.Remove(bookToRemove);
		Console.WriteLine(removeResult.Message);
	}

	private static void ShowBooks()
	{
		string[] books = BookInventory.GetBooks();

		if (books.Length == 0)
		{
			Console.WriteLine("No books in inventory.");
			return;
		}

		Console.WriteLine("Books in inventory:");
		foreach (string book in books)
		{
			Console.WriteLine($"- {book}");
		}
	}
}
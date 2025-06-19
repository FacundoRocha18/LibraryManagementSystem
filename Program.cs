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

				case 4:
					SearchBook();
					break;

				case 5:
					BorrowBook();
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
		Console.WriteLine("4 – Search for a book.");
		Console.WriteLine("5 – Borrow a book.");
		Console.WriteLine("0 – Exit.");
		Console.Write("> Chosen option: ");
	}

	private static void AddBook()
	{
		Console.Write("Enter the book name to add: ");
		string newBook = (Console.ReadLine() ?? string.Empty).Trim();

		OperationResult<string> addResult = BookInventory.Add(newBook);
		Console.WriteLine(addResult.Message);
	}

	private static void RemoveBook()
	{
		Console.Write("Enter the book name to remove: ");
		string bookToRemove = Console.ReadLine() ?? string.Empty;

		OperationResult<string> removeResult = BookInventory.Remove(bookToRemove);
		Console.WriteLine(removeResult.Message);
	}

	private static void ShowBooks()
	{
		string[] books = BookInventory.GetBooks();



		Console.WriteLine("Books in inventory:");
		foreach (string book in books)
		{
			Console.WriteLine($"- {book}");
		}
	}

	private static void SearchBook()
	{
		Console.Write("Enter the book name to search: ");
		string bookToSearch = Console.ReadLine() ?? string.Empty;

		OperationResult<string> result = BookInventory.SearchBook(bookToSearch);
		Console.WriteLine(result.Message);
	}

	private static void BorrowBook()
	{
		Console.Write("Enter your name: ");
		string user = Console.ReadLine() ?? string.Empty;

		Console.Write("Enter the book name to borrow: ");
		string bookToBorrow = Console.ReadLine() ?? string.Empty;

		OperationResult<string> result = BookInventory.BorrowBook(user, bookToBorrow);
		Console.WriteLine(result.Message);
	}
}
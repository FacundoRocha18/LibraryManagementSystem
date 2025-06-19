public class LibraryManager
{
	public static void Main()
	{
		while (true)
		{
			Console.WriteLine("\nPlease select an option:");
			Console.WriteLine("1 – Add a new book.");
			Console.WriteLine("2 – Remove a book.");
			Console.WriteLine("3 – Show all books.");
			Console.WriteLine("0 – Exit.");
			Console.Write("> ");

			if (!int.TryParse(Console.ReadLine(), out int option))
			{
				Console.WriteLine("Invalid input. Please enter a number.");
				continue;
			}

			switch (option)
			{
				case 1:
					Console.Write("Enter the book name to add: ");
					string newBook = Console.ReadLine() ?? string.Empty;

					OperationResult addResult = BookInventory.Add(newBook);
					Console.WriteLine(addResult.Message);

					break;

				case 2:
					Console.Write("Enter the book name to remove: ");
					string bookToRemove = Console.ReadLine() ?? string.Empty;

					OperationResult removeResult = BookInventory.Remove(bookToRemove);
					Console.WriteLine(removeResult.Message);

					break;

				case 3:
					string[] books = BookInventory.GetBooks();

					if (books.Length == 0)
					{
						Console.WriteLine("No books in inventory.");
						continue;
					}

					Console.WriteLine("Books in inventory:");
					foreach (string book in books)
					{
						Console.WriteLine($"- {book}");
					}

					break;

				case 0:
					Console.WriteLine("Goodbye!");
					return;

				default:
					Console.WriteLine("Invalid option. Please select a valid option.");
					break;
			}
		}
	}
}
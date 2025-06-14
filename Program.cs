public class LibraryManagementSystem
{
	public static void Main()
	{
		while (true)
		{
			Console.WriteLine("Please select an option:");
			Console.WriteLine("1 – Add a new book.");
			Console.WriteLine("2 – Remove a book.");
			Console.WriteLine("3 – Show all books.");
			Console.WriteLine("0 – Exit.");

			string input = Console.ReadLine();
			if (!int.TryParse(input, out int option))
			{
				Console.WriteLine("Invalid input. Please enter a number.");
				continue;
			}

			switch (option)
			{
				case 1:
					Console.WriteLine("Please enter a book to add.");
					string newBook = Console.ReadLine();
					BookInventory.AddBook(newBook);
					break;
				case 2:
					Console.WriteLine("Please enter a book to remove.");
					string bookToRemove = Console.ReadLine();
					BookInventory.RemoveBook(bookToRemove);
					break;
				case 3:
					string[] books = BookInventory.GetBooks();
					SystemUI.DisplayBooksInventory(books);
					break;
				case 0:
					Console.WriteLine("Goodbye!");
					return; // exits the Main method
				default:
					Console.WriteLine("Invalid option.");
					break;
			}
		}
	}
}
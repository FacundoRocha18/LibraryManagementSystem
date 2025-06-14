public static class BookInventory
{
	private static List<string> books = new List<string>(5);

	public static void AddBook(string book)
	{
		if (books.Count < 5)
		{
			books.Add(book);
			Console.WriteLine($"Book '{book}' added to inventory.");
		}
		else
		{
			Console.WriteLine("Inventory is full. Cannot add more books.");
		}
	}

	public static void RemoveBook(string book)
	{
		if (books.Remove(book))
		{
			Console.WriteLine($"Book '{book}' removed from inventory.");
		}
		else
		{
			Console.WriteLine($"Book '{book}' not found in inventory.");
		}
	}

	public static string[] GetBooks()
	{
		return books.ToArray();
	}	
}
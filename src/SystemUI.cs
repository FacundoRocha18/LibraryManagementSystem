public static class SystemUI
{
		public static void DisplayBooksInventory(string[] books)
		{
				if (books.Length == 0)
				{
						Console.WriteLine("No books in inventory.");
				}
				else
				{
						Console.WriteLine("Books in inventory:");
						foreach (var book in books)
						{
								Console.WriteLine($"- {book}");
						}
				}
		}
}
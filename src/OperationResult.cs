public class OperationResult<T>
{
	public bool Success { get; }
	public string Message { get; }
	public T? Data { get; }

	public OperationResult(bool success, string message, T? data = default)
	{
		Success = success;
		Message = message;
		Data = data;
	}
}
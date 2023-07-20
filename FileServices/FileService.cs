namespace Book.API.FileServices;

public class FileService
{
	private const string Wwwroot = "wwwroot";

	private static void CheckDirectory(string folder)
	{
		if (!Directory.Exists(folder))
			Directory.CreateDirectory(folder);
	}

	public static string BookImages(IFormFile file)
	{
		return SaveFile(file, "BookImages");
	}
	public static string BookFiles(IFormFile file)
	{
		return SaveFile(file, "BookFiles");
	}

	private static string SaveFile(IFormFile file, string folder)
	{
		CheckDirectory(Path.Combine(Wwwroot, folder));
		var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
		var ms = new MemoryStream();
		file.CopyToAsync(ms);
		File.WriteAllBytesAsync(Path.Combine(Wwwroot, folder, fileName), ms.ToArray());
		return $"/{folder}/{fileName}";
	}
}
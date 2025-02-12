namespace PropertyDataTester.Services;

public static class ImageFileWriterService
{
	public static async Task WriteImagesAsync(string folderPath, List<(string Name, byte[] Data)> images)
	{
		if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

		foreach (var (imageName, imageData) in images)
			await File.WriteAllBytesAsync(Path.Combine(folderPath, imageName), imageData);
	}
}
namespace PropertyDataTester.Services;

public static class ImageFileWriterService
{
	public static Task WriteImagesAsync(string folderPath, List<(string fileName, byte[] data)> images)
	{
		if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

		var writeImageTasks = images.DistinctBy(i => i.fileName)
									.Select(i => File.WriteAllBytesAsync(
														Path.Combine(folderPath, i.fileName), 
														i.data));

		return Task.WhenAll(writeImageTasks);
    }
}
using SQLite;

namespace SelectImages.Models;

public class ImageInfo
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Path { get; set; }
    public string Description { get; set; }
    
    // var image = await FilePicker.Default.PickAsync(new PickOptions
    //     {
    //         PickerTitle = "Pick Image",
    //         FileTypes = FilePickerFileType.Images
    //     });
    //     if (image != null)
    // {
    //     _imagePath = image.FullPath.ToString();
    //     selectedImage.Source = _imagePath;
    // }
}
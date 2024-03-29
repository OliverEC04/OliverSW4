﻿using System.Collections.ObjectModel;
using SelectImages.Data;
using SelectImages.Models;

namespace SelectImages;

public partial class MainPage : ContentPage
{
    private int idCounter = 0;
    private string? _imagePath;
    private Database _database;
    public ObservableCollection<ImageInfo> Imgs;
    
    public MainPage()
    {
        InitializeComponent();
        
        _database = new Database();
        Imgs = new ObservableCollection<ImageInfo>();

        BindableLayout.SetItemsSource(ImgCollection, Imgs);
    }

    private async void OnSelectBtn(object sender, EventArgs e)
    {
        var image = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Select image",
                FileTypes = FilePickerFileType.Images
            });
        if (image != null)
        {
            _imagePath = image.FullPath.ToString();
            // SelectedImage.Source = _imagePath;
        }
    }

    private async void OnAddBtn(object sender, EventArgs e)
    {
        ImageInfo imageInfo = new ImageInfo();
        imageInfo.Id = idCounter;
        imageInfo.Title = TitleEntry.Text;
        imageInfo.Path = _imagePath;
        imageInfo.Description = DescEditor.Text;

        var _ = await _database.AddImageInfo(imageInfo);
        Imgs.Add(imageInfo);
        
        // TODO: reset controls
        
        idCounter++;
    }
}
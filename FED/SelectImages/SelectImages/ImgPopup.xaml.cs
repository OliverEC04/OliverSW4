using CommunityToolkit.Maui.Views;
using SelectImages.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;

namespace SelectImages;

public partial class ImgePopup : Popup
{
    public ImgePopup(ImageInfo imageInfo)
    {
        BindingContext = this;
    }
}
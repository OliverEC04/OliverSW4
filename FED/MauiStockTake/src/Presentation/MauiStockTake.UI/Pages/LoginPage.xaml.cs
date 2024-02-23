using MauiStockTake.UI.Services;

namespace MauiStockTake.UI.Pages;

public partial class LoginPage : ContentPage
{
    private readonly IAuthService _authService;

    public LoginPage()
    {
        InitializeComponent();
        /* Assign a new instance of the MockAuthService to the field */
        _authService = new MockAuthService();
    }

    /* LoginButton_Clicked event handler */
    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        LoginButton.IsEnabled = false;
        LoggingIn.IsVisible = true;
        //Call the LoginAsync method on the IAuthService and assign the result to a temporary variable
        var loggedIn = await _authService.LoginAsync();
        LoggingIn.IsVisible = false;

        //If the login is not successful, show a warning to the user
        //hide the ActivityIndicator, and enable the button.
        if (!loggedIn)
        {
            await App.Current.MainPage.DisplayAlert("Error", "Something went wrong logging you in.Please try again.", "OK");
            LoginButton.IsEnabled = true;
        }
        else
        {
            await Navigation.PopModalAsync();
        }
    }
}
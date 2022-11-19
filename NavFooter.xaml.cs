namespace NavigationCrashTest;

public partial class NavFooter : ContentView
{
	public NavFooter()
	{
		InitializeComponent();
	}

    public async void Home_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage", false);
    }

    public async void Second_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SecondPage), false);
    }

    public async void Third_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ThirdPage), false);
    }
}

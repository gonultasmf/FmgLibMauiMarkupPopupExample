using System.Reflection;
using CommunityToolkit.Maui.Views;

namespace FmgLibMauiMarkupPopupExample;

public partial class MainPage : ContentPage, IFmgLibHotReload
{
    public MainPage()
    {
        this.InitializeHotReload();
    }

    public void Build()
    {
        var version = typeof(MauiApp).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;

        this
        .Content(
            new ScrollView()
            .Content(
                new Grid()
                .RowDefinitions(e => e.Star(90).Star(10))
                .Children(
                    new StackLayout()
                    .Spacing(25)
                    .Children(
                        new Label()
                        .Text("Welcome to FmgLib .NET MAUI Markup App")
                        .FontSize(18)
                        .CenterHorizontal()
                        .SemanticDescription("Welcome to dot net Multi platform App U I")
                        .SemanticHeadingLevel(SemanticHeadingLevel.Level1),

                        new Button()
                        .Text("Open Popup")
                        .CenterHorizontal()
                        .OnClicked(OnCounterClicked)
                        .SemanticHint("Counts the number of times you click")
                    ),

                    new Grid()
                    .BackgroundColor(AppColors.Primary)
                    .Row(1)
                    .Children(
                        new Label()
                        .Text($"dotNet version: {version}")
                        .TextColor(White)
                        .Center()
                    )
                )
            )
        );
    }

    private async void OnCounterClicked(object? sender, EventArgs e)
    {
        await Shell.Current.ShowPopupAsync(new MyPopup());
    }
}

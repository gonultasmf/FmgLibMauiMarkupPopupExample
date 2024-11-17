# FmgLibMauiMarkupPopupExample

Configuration:
```csharp
using CommunityToolkit.Maui;          // <------- added.
using CommunityToolkit.Maui.Views;    // <------- added.

namespace FmgLibMauiMarkupPopupExample;

[MauiMarkup(typeof(Popup))]  // <------- added.
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()  // <------- added.
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services
            .AddSingleton<App>()
            .AddSingleton<AppShell>()
            .AddScoped<MainPage>();

        return builder.Build();
    }
}

```

Custom Popup:
```csharp
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.Shapes;

namespace FmgLibMauiMarkupPopupExample;

public partial class MyPopup : Popup
{
    public MyPopup()
    {
        this
        .CanBeDismissedByTappingOutsideOfPopup(false)
        .Color(Transparent)
        .Content(
            new Grid()
            .Children(
                new Border()
                .BackgroundColor(Gray)
                .Stroke(DarkGray)
                .StrokeThickness(2)
                .StrokeShape(new RoundRectangle().CornerRadius(25))
                .Margin(10)
                .Padding(10)
                .Content(
                    new VerticalStackLayout()
                    .FillBothDirections()
                    .Margin(10)
                    .Spacing(20)
                    .Children(
                        new Label()
                        .Text("Example Popup Message")
                        .FontAttributes(Italic)
                        .FontSize(18),

                        new Button()
                        .Text("CLOSE")
                        .FontAttributes(Bold)
                        .BackgroundColor(DarkBlue)
                        .TextColor(White)
                        .HeightRequest(35)
                        .WidthRequest(120)
                        .Padding(0)
                        .InvokeOnElement(b => b.Clicked += async (sender, e) =>
                        {
                            await CloseAsync();
                        })
                    )
                )
            )
        );
    }
}
```

Using in page:
```csharp
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
                        // Open popup button
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
        await Shell.Current.ShowPopupAsync(new MyPopup());  // Open Custom Popup.
    }
}

```

![image](https://github.com/user-attachments/assets/f04bbe16-40c2-43d9-a1bf-a9e2e1981fdb)
![image](https://github.com/user-attachments/assets/bdc5dcf5-5ddd-4b5d-a7a4-bd52ec12d772)


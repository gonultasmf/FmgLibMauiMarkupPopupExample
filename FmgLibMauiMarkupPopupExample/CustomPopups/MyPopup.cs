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
                .BackgroundColor(LightGray)
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

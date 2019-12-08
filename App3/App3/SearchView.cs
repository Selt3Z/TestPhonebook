using Xamarin.Forms;

namespace App3
{
    public delegate void SearchEventHandler(string text);

    public class SearchView : ContentView
    {
        public event SearchEventHandler Search;
        public SearchView()
        {
            Button searchBtn = new Button { Text = "Поиск" };
            Entry searchEntry = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand };

            searchBtn.Clicked += (sender, e) => Search?.Invoke(searchEntry.Text);
            Content = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 5,
                Children =
                {
                    searchEntry,
                    searchBtn
                }
            };
        }
    }
}
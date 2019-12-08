using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace App3
{
	public partial class MainPage : ContentPage
	{
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            SearchView searchView = new SearchView();
            searchView.Search += (text) =>
            {
                if (!string.IsNullOrEmpty(text))
                {
                    IEnumerable<Coworker> enumerable = App.Database.GetItems();
                    List<Coworker> coworkers = enumerable.ToList();
                    coworkersList.ItemsSource = coworkers.Where(u => u.FirstName.Contains(text) || u.LastName.Contains(text));
                }
                else
                {
                    coworkersList.ItemsSource = App.Database.GetItems();
                }
            };
            Content = new StackLayout { Children = { searchView, coworkersList } };
            coworkersList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }
        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Coworker selectedCoworker = (Coworker)e.SelectedItem;
            CoworkerPage coworkerPage = new CoworkerPage();
            coworkerPage.BindingContext = selectedCoworker;
            await Navigation.PushAsync(coworkerPage);
        }
        // обработка нажатия кнопки добавления
        private async void CreateCoworker(object sender, EventArgs e)
        {
            Coworker coworker = new Coworker();
            CoworkerPage coworkerPage = new CoworkerPage();
            coworkerPage.BindingContext = coworker;
            await Navigation.PushAsync(coworkerPage);
        }
        //private void SearchUsers(string text)
        //{
        //    if (!string.IsNullOrEmpty(text))
        //    {
        //        IEnumerable<Coworker> enumerable = App.Database.GetItems();
        //        List<Coworker> coworkers = enumerable.ToList();
        //        coworkersList.ItemsSource = coworkers.Where(u => u.FullName.Contains(text));
        //    }
        //    else
        //    {
        //        coworkersList.ItemsSource = App.Database.GetItems();
        //    }
        //}
    }
}

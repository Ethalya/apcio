using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Lab06a.Models;
using Lab06a.Views;
using System.Windows.Input;

namespace Lab06a.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Students> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        private readonly INavigation _navigation;

        private int a;
        public int A
        {
            get
            {
                return a;
            }
            set
            {
                if (value != a)
                {
                    a = value;
                    //OnPropertyChanged(nameof(A));  OnPropertyChanged(nameof(A));
                    // OnPropertyChanged(nameof(Sum));
                }
            }
        }

        private int b;
        public int B
        {
            get
            {
                return b;
            }
            set
            {
                if (value != b)
                {
                    b = value;
                    OnPropertyChanged(nameof(B));
                    //  OnPropertyChanged(nameof(Sum));
                }
            }
        }

        private string someText;
        public string SomeText
        {
            get
            {
                return someText;
            }
            set
            {
                if (value != someText)
                {
                    someText = value;
                    OnPropertyChanged(nameof(SomeText));
                    //  OnPropertyChanged(nameof(Sum));
                }
            }
        }


        public int Sum
        {
            get
            {
                return a + b;
            }
        }

        public ItemsViewModel(INavigation navigation)
        {
            Title = "Browse";
            Items = new ObservableCollection<Students>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            _navigation = navigation;
            SomeText = "blablabla";
            MessagingCenter.Subscribe<NewItemPage, Students>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Students;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }


        public ICommand GoToDetailsCommand => new Command<Students>(GoToDetails);

        private async void GoToDetails(Students item)
        {
            await _navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
        }


        public ICommand SumChangeCommand => new Command(OnSumChange);

        private void OnSumChange()
        {
            var costam = SomeText;

            //  OnPropertyChanged(nameof(Sum));
        }
    }
}
using System;

using Lab06a.Models;

namespace Lab06a.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Students Item { get; set; }
        public ItemDetailViewModel(Students item = null)
        {
            Title = item.FName + "" + item.LName;
            Item = item;
        }
    }
}

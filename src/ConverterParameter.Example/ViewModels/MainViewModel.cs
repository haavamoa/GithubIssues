using System.Collections.Generic;

namespace ConverterParameter.Example.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            TheList = new List<ItemViewModel>()
            {
                new ItemViewModel("First Item"),
                new ItemViewModel("Second Item"),
                new ItemViewModel("Third Item"),
                new ItemViewModel("Forth Item"),
            };    
        }

        public IEnumerable<ItemViewModel> TheList { get; set; }
    }
}
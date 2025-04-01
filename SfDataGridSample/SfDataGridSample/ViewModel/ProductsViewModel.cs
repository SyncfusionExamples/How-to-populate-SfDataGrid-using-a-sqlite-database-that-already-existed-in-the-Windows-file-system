using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridSample
{
    public class ProductsViewModel
    {
        public ObservableCollection<Products> Products { get; set; } = new();

        private readonly DatabaseService _databaseService;

        public ProductsViewModel()
        {
            _databaseService = new DatabaseService();
            LoadData();
        }

        private async void LoadData()
        {
            var items = await _databaseService.GetProductsAsync();
            foreach (var item in items)
            {
                Products.Add(item);
            }
        }
    }
}

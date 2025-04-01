# How to populate SfDataGrid using a sqlite database that already existed in the Windows file system?
In this article, we will show you how to populate [.NET MAUI DataGrid](https://www.syncfusion.com/maui-controls/maui-datagrid) using a sqlite database that already existed in the Windows file system.

## Xaml
```
<ContentPage.BindingContext>
    <local:ProductsViewModel x:Name="viewModel" />
</ContentPage.BindingContext>

<syncfusion:SfDataGrid ItemsSource="{Binding Products}"
                       ColumnWidthMode="Auto"
                       GridLinesVisibility="Both"
                       HeaderGridLinesVisibility="Both" />
```

## DatabaseService.cs file 
The below code demonstrates how to handle database operations in a .NET MAUI application using SQLite asynchronously.
```
public class DatabaseService
{
    private readonly SQLiteAsyncConnection _database;
    private readonly string _dbPath;

    public DatabaseService()
    {
         // NOTE: Don't forget to update the database path to match your machine's directory.
        _dbPath = @"D:\Support\MarchSupport\703516\products.db";

        // Check if file exists before connecting
        if (!File.Exists(_dbPath))
        {
            throw new FileNotFoundException($"Database file not found at {_dbPath}");
        }

        _database = new SQLiteAsyncConnection(_dbPath);
    }

    public async Task<List<Products>> GetProductsAsync()
    {
        return await _database.Table<Products>().ToListAsync();
    }
}
```

## ProductViewModel.cs file
This ProductsViewModel class is responsible for managing and displaying product data in a UI using the MVVM pattern.
```
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
```

<img src="https://support.syncfusion.com/kb/agent/attachment/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjM3OTUwIiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.8qVANmAUhBL_knLLXVFDZAK_UX6Am7AaZFKle-AluqQ" width=800/>

[View sample in GitHub](https://github.com/SyncfusionExamples/How-to-populate-SfDataGrid-using-a-sqlite-database-that-already-existed-in-the-Windows-file-system)

Take a moment to explore this [documentation](https://help.syncfusion.com/maui/datagrid/overview), where you can find more information about Syncfusion .NET MAUI DataGrid (SfDataGrid) with code examples. Please refer to this [link](https://www.syncfusion.com/maui-controls/maui-datagrid) to learn about the essential features of Syncfusion .NET MAUI DataGrid (SfDataGrid).
 
##### Conclusion
 
I hope you enjoyed learning about how to populate SfDataGrid using a sqlite database that already existed in the Windows file system.
 
You can refer to our [.NET MAUI DataGrid’s feature tour](https://www.syncfusion.com/maui-controls/maui-datagrid) page to learn about its other groundbreaking feature representations. You can also explore our [.NET MAUI DataGrid Documentation](https://help.syncfusion.com/maui/datagrid/getting-started) to understand how to present and manipulate data. 
For current customers, you can check out our .NET MAUI components on the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page. If you are new to Syncfusion, you can try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to explore our .NET MAUI DataGrid and other .NET MAUI components.
 
If you have any queries or require clarifications, please let us know in the comments below. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/create) or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sfdatagrid), or the feedback portal. We are always happy to assist you!
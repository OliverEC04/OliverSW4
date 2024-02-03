using MauiTodo.Models;
using System.Collections.ObjectModel;

namespace MauiTodo
{
    public partial class MainPage : ContentPage
    {
        private int _count = 0;
        private readonly ObservableCollection<TodoItem> _todoItems;
        private readonly Database _database;

        public MainPage()
        {
            InitializeComponent();

            _todoItems = new ObservableCollection<TodoItem>();
            _database = new Database();

            TodosCollection.ItemsSource = _todoItems;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            TodoItem todoItem = new TodoItem();

            _count++;
            todoItem.Id = _count;
            todoItem.Title = TodoTitleEntry.Text;
            todoItem.Due = DueDatePicker.Date;

            AddBtn.BackgroundColor = new Color(0, 255, 0);

            Console.WriteLine("oliuvrer");

            _todoItems.Add(todoItem);
        }
    }

}

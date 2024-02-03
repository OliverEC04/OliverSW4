using MauiTodo.Models;
using System.Collections.ObjectModel;

namespace MauiTodo
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<TodoItem> todoItems;
        int count = 0;
        private readonly Database _database;

        public MainPage()
        {
            InitializeComponent();

            _database = new Database();

            TodosCollection.ItemsSource = todoItems;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            TodoItem _todoItem = new TodoItem();

            _todoItem.Id = 1;
            _todoItem.Title = "oliver test";

            Console.WriteLine("oliuvrer");

            _ = _database.Addtodo(_todoItem);
        }
    }

}

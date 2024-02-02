using MauiTodo.Models;

namespace MauiTodo
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private string _todoListData = string.Empty;
        private readonly Database _database;

        public MainPage()
        {
            InitializeComponent();

            _database = new Database();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            TodoItem _todoItem = new TodoItem();

            _database.Addtodo(_todoItem);
        }
    }

}

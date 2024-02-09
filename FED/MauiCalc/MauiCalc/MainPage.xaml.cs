namespace MauiCalc;

public partial class MainPage : ContentPage
{
    private Grid _grid;
    
    public MainPage()
    {
        InitializeComponent();
        InitGrid();
        InitLcd();
        InitBtns();
    }

    private void InitGrid()
    {
        _grid = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
                new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
                new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
                new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
                new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
            },
            ColumnDefinitions =
            {
                new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
                new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
                new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
                new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
            },
            RowSpacing = 2,
            ColumnSpacing = 2,
        };

        Content = _grid;
    }

    private void InitLcd()
    {
        Label label = new Label
        {
            Text = "LCD",
            FontFamily = "LCD",
            FontSize = 60,
            HorizontalTextAlignment = TextAlignment.End,
            VerticalTextAlignment = TextAlignment.Center,
        };
        
        _grid.AddWithSpan(label, 0, 0, 1, 4);
    }
    
    private void InitBtns()
    {
        int btnI = 0;
        string[] btnTxt = ["7", "4", "1", ".", "8", "5", "2", "0", "9", "6", "3", "=", "+", "-", "X", "/"];
        
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                Button btn = new Button
                {
                    Text = btnTxt[btnI],
                    CornerRadius = 0,
                };
                btn.Clicked += OnBtn;
                
                _grid.Add(btn, x, y+1);
                btnI++;
            }
        }
    }

    private void OnBtn(object sender, EventArgs e)
    {
        var btn = sender as Button;
        var input = btn.Text;
        
        
    }
}
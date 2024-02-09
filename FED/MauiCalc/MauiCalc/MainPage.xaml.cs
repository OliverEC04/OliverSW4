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
            }
        };

        Content = _grid;
    }

    private void InitLcd()
    {
        Label label = new Label
        {
            Text = "LCD",
            
        };
        
        _grid.Add(label);
    }
    
    private void InitBtns()
    {
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                Button btn = new Button
                {
                    Text = $"{x}, {y}",
                };
                btn.Clicked += OnBtn;
                
                _grid.Add(btn, x, y+1);
            }
        }
    }

    private void OnBtn(object sender, EventArgs e)
    {
        //Cast sender to Button type to read its text
        var btn = sender as Button;
        //Assigns the value of the Button's Text property to a temporary variable
        var thisInput = btn.Text;

        if (numbers.Contains(thisInput))
        {
            if (resetOnNextInput)
            {
                CurrentInput = btn.Text;
                resetOnNextInput = false;
            }
            else
            {
                CurrentInput += btn.Text;
            }
            LCD.Text = CurrentInput;
        }
        else if (operators.Contains(thisInput))
        {
            //PerformCalculation method to calculate operation(+,-,/,=)
            var result = PerformCalculation();
            if (thisInput == "=")
            {
                CurrentInput = result.ToString();
                LCD.Text = CurrentInput;
                RunningTotal = String.Empty;
                selectedOperator = String.Empty;
                resetOnNextInput = true;
            }
            else
            {
                RunningTotal = result.ToString();
                selectedOperator = thisInput;
                CurrentInput = String.Empty;
                LCD.Text = CurrentInput;
            }
        }
    }
}
namespace MauiCalc;

public partial class MainPage : ContentPage
{
    private Grid _grid;
    protected Label LCD;
    
    //Declare a string variable to store the current number is entered
    public string CurrentInput { get; set; } = String.Empty;
//Declare a string variable to store the running total after currently calculated
    public string RunningTotal { get; set; } = String.Empty;
//Declare a private string variable to store the selected operator
    private string selectedOperator;
//Declare an array of operators
    string[] operators = { "+", "-", "/", "X", "=" };
//Declare an array of the available numbers
    string[] numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "." };
//Declare a Boolean to determine whether the screen will reset the next time the user presses a Button
    bool resetOnNextInput = false;
    
    public MainPage()
    {
        InitializeComponent();
        InitGrid();
        LCD = InitLcd();
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

    private Label InitLcd()
    {
        Label label = new Label
        {
            Text = "LCD",
            FontFamily = "LCD",
            FontSize = 60,
            HorizontalTextAlignment = TextAlignment.End,
            VerticalTextAlignment = TextAlignment.Center,
            StyleId = "LCD",
        };
        
        _grid.AddWithSpan(label, 0, 0, 1, 4);

        return label;
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
    
    private double PerformCalculation()
    {
        double currentVal; //Cast CurrentInput from string to double to perform arithmetic operations on it
        double.TryParse(CurrentInput, out currentVal);

        double runningVal; //Casts the RunningTotal from string to double to perform arithmetic operations on it
        double.TryParse(RunningTotal, out runningVal);

        double result;
        /* ToDo: Implement the mathematic operation code by the selected operator*/
        switch (selectedOperator)
        {
            case "+":
                result = runningVal + currentVal;
                break;
            case "-":
                result = runningVal - currentVal;
                break;
            case "X":
                result = runningVal * currentVal;
                break;
            case "/":
                result = runningVal / currentVal;
                break;
            default:
                result = currentVal;
                break;
        }
        return result;
    }
}
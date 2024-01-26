using DoStuff;

class Program
{
    public static void Main()
    {
        IDoThings myIDoThings;

        Console.WriteLine("Press 1 for DoHickey, press 2 for DoDickey");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                myIDoThings = new DoHickey();
                break;

            case "2":
                myIDoThings = new DoDickey();
                break;

            default:
                myIDoThings = new DoHickey();
                break;
        }

        myIDoThings.DoNothing();
        myIDoThings.DoSomething(69);
        myIDoThings.DoSomethingElse("C++ is gay");
    }
}
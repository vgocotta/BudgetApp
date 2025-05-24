using Budget.App.Views.Expenses;

namespace Budget.App;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("Expenses/ExpenseDetail", typeof(ExpenseDetailPage));
    }
}

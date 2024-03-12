using FinancialAssistent.Views;

namespace FinancialAssistent
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //DatabaseInitializer.InitializeDatabase();
            //DatabaseInitializer.AddTestUser();

            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }

    }
}
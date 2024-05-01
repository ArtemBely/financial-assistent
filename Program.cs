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

            ///<summary>
            /// Simulate first DB init 
            ///</summary>
            //DatabaseInitializer.InitializeDatabase();

            ///<summary>
            /// Simulate adding new user with custom credentials. Add it if nedd to test new user.
            ///</summary>
            //DatabaseInitializer.AddTestUser();

            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }

    }
}
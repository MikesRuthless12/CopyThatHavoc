using static CopyThatProgram.mainForm;

namespace CopyThatProgram
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()

        {

            // Enable visual styles for the application

            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);



            // Create and display the main form

            Application.Run(new mainForm());
        }
    }
}
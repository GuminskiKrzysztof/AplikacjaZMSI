using System;
using System.Windows.Forms;
using AplikacjaZMSI.View;
using AplikacjaZMSI.Presenter;


namespace AplikacjaZMSI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Tworzenie widoku
            MainForm mainForm = new MainForm();

            // Tworzenie prezentera
            MainPresenter presenter = new MainPresenter(mainForm);

            // Uruchomienie aplikacji
            Application.Run(mainForm);
        }
    }
}

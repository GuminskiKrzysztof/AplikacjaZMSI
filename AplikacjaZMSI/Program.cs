using System;
using System.Windows.Forms;
using AplikacjaZMSI.View;
using AplikacjaZMSI.Presenter;
using AplikacjaZMSI.Model;
using System.Threading;

namespace AplikacjaZMSI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Ustawienie minimalnej liczby wątków w puli wątków
            ThreadPool.SetMinThreads(4, 4);  // Minimalna liczba wątków roboczych i I/O
            ThreadPool.SetMaxThreads(20, 20);  // Maksymalna liczba wątków roboczych i I/O

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

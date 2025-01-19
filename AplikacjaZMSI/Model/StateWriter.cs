using System;
using System.IO;

namespace AplikacjaZMSI
{
    public class StateWriter : IStateWriter
    {
        public void SaveToFileStateOfAlghoritm(string path)
        {
            // Przykładowe dane (należy dostosować do konkretnego algorytmu)
            string state = "Numer iteracji: 1\nLiczba wywołań funkcji celu: 100\nPopulacja: ...";
            File.WriteAllText(path, state);
        }
    }

    public class StateReader : IStateReader
    {
        public void LoadFromFileStateOfAlghoritm(string path)
        {
            if (File.Exists(path))
            {
                string state = File.ReadAllText(path);
                // Wczytaj stan algorytmu z pliku (należy dostosować do formatu danych)
                Console.WriteLine(state);
            }
            else
            {
                throw new FileNotFoundException("Plik stanu nie istnieje.");
            }
        }
    }
}

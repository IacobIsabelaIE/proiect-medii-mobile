using ProiectMobile.Data;

namespace ProiectMobile;

public partial class App : Application
{

    static ProgramariBisericaDatabase database;
    public static ProgramariBisericaDatabase Database
    {
        get 
        {
            if (database == null)
            {
               database = new
               ProgramariBisericaDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "ProgramariBisericaDB.db3"));
            }
            return database;
        }
    }


    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}

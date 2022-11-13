// dotnet add DevTeams.Repositories reference DevTeams.(File to reference)

// CRUD
namespace Developer_Repository;
public class DeveloperRepository
{
    protected readonly List<Developer> _devDatabase = new List<Developer>();

    // Create
    public bool AddNewDeveloper(Developer developer)
    {
        int prevCount = _devDatabase.Count;

        _devDatabase.Add(developer);

        return prevCount < _devDatabase.Count ? true : false;
    }

    // Read
    public List<Developer> GetAllDevelopers()
    {
        return _devDatabase;
    }

    // Read One
    public Developer GetDeveloper(int iD)
    {
        foreach (Developer developer in _devDatabase)
        {
            if(developer.ID == iD)
            return developer;
        }
        return null;
    }

    // Update
    public bool UpdateDevData(int iD, Developer newDevData)
    {
        Developer oldDevData = _devDatabase.Find(developer => developer.ID == iD);
        if (oldDevData != null)
        {
            oldDevData.LastName = newDevData.LastName;
            oldDevData.FirstName = newDevData.FirstName;
            oldDevData.HasPluralsight = newDevData.HasPluralsight;
            return true;
        } 
        else
        {
            return false;
        }
    }

    public bool AddDeveloperAccess(int iD, Developer newDeveloper)
    {
        Developer? oldDeveloper = _devDatabase.Find(developer => developer.ID == iD);

        if (oldDeveloper != null)
        {
            oldDeveloper.HasPluralsight = newDeveloper.HasPluralsight != 0 ? newDeveloper.HasPluralsight : oldDeveloper.HasPluralsight;

            return true;
        }
        else
        {
            return false;
        }
    }

    // Delete
    public bool RemoveDeveloper(int ID)
    {
        Developer? devToDelete = _devDatabase.Find(developer => developer.ID == ID);

        bool deleteResult = _devDatabase.Remove(devToDelete);

        return deleteResult;
    }

    // Helper Methods
    public Developer GetDevByID(int getID)
    {
        foreach (Developer developer in _devDatabase)
        {
            if (developer.ID == getID)
            {
                return developer;
            }
        }
        return null;
    }

    public List<Developer> DoesDeveloperHaveLicense()
    {
        List<Developer> pluralsightDev = new List<Developer>();

        foreach (Developer developer in _devDatabase)
        {
            if (developer.HasPluralsight == HasPluralsight.No)
            {
                pluralsightDev.Add(developer);
            }
        }
        return pluralsightDev;
    }
}
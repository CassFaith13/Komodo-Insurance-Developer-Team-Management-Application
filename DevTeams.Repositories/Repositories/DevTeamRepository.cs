// dotnet add DevTeams.Repositories reference DevTeams.(File to reference)

// CRUD
namespace DevTeam_Repository;
public class DevTeamRepository
{
    protected readonly List<DevTeam> _devTeamDatabase = new List<DevTeam>();

    //Create
    public bool AddNewTeam(DevTeam devTeam)
    {
        int prevCount = _devTeamDatabase.Count();

        _devTeamDatabase.Add(devTeam);

        return prevCount < _devTeamDatabase.Count ? true : false;
    }

    //Read
    public List<DevTeam> GetAllTeams()
    {
        return _devTeamDatabase;
    }

    //Update
    public bool UpdatedDevTeam(int devTeamId, DevTeam updatedTeam)
    {
        var oldDevTeam = GetDevTeamByID(devTeamId);

        if (oldDevTeam != null)
        {
            oldDevTeam.TeamName = updatedTeam.TeamName;
            return true;
        } 
        else
        {
            return false;
        }
    }

    //Delete
    public bool DeleteDevTeam(int teamID) 
    {
        DevTeam? devTeamDelete = _devTeamDatabase.Find(devTeam => devTeam.TeamID == teamID);

        bool deleteDevTeam = _devTeamDatabase.Remove(devTeamDelete);

        return deleteDevTeam;
    }

    //Helper Methods
    public DevTeam GetDevTeamByID(int getTeamID)
    {
        foreach (DevTeam devTeam in _devTeamDatabase)
        {
            if (devTeam.TeamID == getTeamID)
            {
                return devTeam;
            }
        }

        return null;
    }

    public bool AddDevTeamMem(int addDevToTeam, List<Developer> devs)
        {
            var newID = GetDevTeamByID(addDevToTeam);

            if (newID != null && devs != null)
            {
            newID.Developers.AddRange(devs);
            return true;
        }
        else
        {
            return false;
        }
        }
}
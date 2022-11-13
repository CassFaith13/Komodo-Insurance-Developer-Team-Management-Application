// dotnet add DevTeams.UI reference DevTeams.(File to reference)

using Developer_Repository;
using DevTeam_Repository;
public class ProgramUI
{
    DeveloperRepository _dev = new DeveloperRepository();
    DevTeamRepository _devTeam = new DevTeamRepository();

    public void Run()
    {
        Seed();
        Dev();
        DevMenu();
        DevTeamMenu();
    }

    private void Dev()
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.Clear();
            System.Console.WriteLine("Welcome to Komodo Insurance. In order to verify security clearance, please enter your name:");

            string? personnelName = Console.ReadLine();

            System.Console.WriteLine("\n"
            + $"Hello {personnelName}! Which menu would you like to access?\n"
            + "1. Developer menu\n"
            + "2. Developer Teams menu\n"
            + "3. Exit");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    DevMenu();
                    break;
                case "2":
                    DevTeamMenu();
                    break;
                case "3":
                    System.Console.WriteLine($"Thank you, {personnelName}, for being a loyal employee to Komodo Insurance. Have a great day!");
                    // keepRunning = false;
                    Environment.Exit(0);
                    break;
                default:
                    System.Console.WriteLine("Invalid Response. Please try again.");
                    break;
            }
        }
    }

    private void DevMenu()
    {
        bool keepDevMenuRunning = true;

        while (keepDevMenuRunning)
        {
            Console.Clear();
            System.Console.WriteLine("Please select from the following options:\n"
            + "1. Create a new Developer.\n"
            + "2. Update Developer information.\n"
            + "3. Update Plursalsight access to an existing Developer.\n"
            + "4. Remove Developer.\n"
            + "5. Show all Developers and Pluralsight access privileges.\n"
            + "6. Show all Developers who do NOT have Pluralsight access privileges.\n"
            + "7. Show a specific Developer.\n"
            + "8. Developer Teams menu\n"
            + "9. Exit.");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateNewDeveloper();
                    break;
                case "2":
                    UpdateDevData();
                    break;
                case "3":
                    AddDeveloperAccess();
                    break;
                case "4":
                    RemoveDeveloper();
                    break;
                case "5":
                    ViewAllDevelopers();
                    break;
                case "6":
                    PluralsightDev();
                    break;
                case "7":
                    ViewDeveloperByID();
                    break;
                case "8":
                    DevTeamMenu();
                    break;
                case "9":
                    System.Console.WriteLine("Thank you for being a loyal employee to Komodo Insurance. Have a great day!");
                    Environment.Exit(0);
                    // keepDevMenuRunning = false;
                    break;
                default:
                    System.Console.WriteLine("Unable to compute. Please try again.");
                    break;
            }
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    private void DevTeamMenu()
    {
        bool keepDevTeamMenuRunning = true;

        while (keepDevTeamMenuRunning)
        {
            Console.Clear();
            System.Console.WriteLine("Please select from the following options:\n"
            + "1. Create a new Developer Team.\n"
            + "2. Update a Developer Team.\n"
            + "3. Add Developers to a Developer Team.\n"
            + "4. Remove a Developer Team.\n"
            + "5. Show all Developer Teams.\n"
            + "6. Show a specific Developer Team.\n"
            + "7. Developer menu\n"
            + "8. Exit.");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateNewTeam();
                    break;
                case "2":
                    UpdateDevTeam();
                    break;
                case "3":
                    AddDevsToTeam();
                    break;
                case "4":
                    DeleteDevTeam();
                    break;
                case "5":
                    ViewAllDevTeams();
                    break;
                case "6":
                    ViewDevTeam();
                    break;
                case "7":
                    DevMenu();
                    break;
                case "8":
                    System.Console.WriteLine("Thank you for being a loyal employee to Komodo Insurance. Have a great day!");
                    Environment.Exit(0);
                    // keepDevTeamMenuRunning = false;
                    break;
                default:
                    System.Console.WriteLine("Unable to compute. Please try again.");
                    break;
            }
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    private void CreateNewDeveloper()
    {
        Console.Clear();

        Developer newDeveloper = new Developer();

        newDeveloper.ID = _dev.GetAllDevelopers().Count + 1;

        System.Console.WriteLine("Please enter the last name of the Developer:");
        newDeveloper.LastName = Console.ReadLine();

        System.Console.WriteLine("Please enter the first name of the Developer:");
        newDeveloper.FirstName = Console.ReadLine();

        System.Console.WriteLine("Please enter if this Developer has Pluralsight access:\n"
        + "1. Yes\n"
        + "2. No");
        int pluralsightInt = int.Parse(Console.ReadLine());
        newDeveloper.HasPluralsight = (HasPluralsight)pluralsightInt;

        bool developerAdded = _dev.AddNewDeveloper(newDeveloper);

        if (developerAdded)
        {
            Console.Clear();
            System.Console.WriteLine("Developer added successfully!\n");
        }
        else
        {
            Console.Clear();
            System.Console.WriteLine("Developer NOT added. Please try again!\n");
        }
    }
    private void CreateNewTeam()
    {
        Console.Clear();

        DevTeam newDevTeam = new DevTeam();

        System.Console.WriteLine("Please enter the name of the new Developer Team:");
        newDevTeam.TeamName = Console.ReadLine();

        newDevTeam.TeamID = _devTeam.GetAllTeams().Count + 1;

        bool devTeamAdded = _devTeam.AddNewTeam(newDevTeam);

        if (devTeamAdded)
        {
            Console.Clear();
            System.Console.WriteLine("Developer Team added successfully!\n");
        }
        else
        {
            Console.Clear();
            System.Console.WriteLine("Developer Team NOT added. Please try again!\n");
        }
    }
    private void UpdateDevData()
    {
        Console.Clear();
        ViewAllDevelopers();

        System.Console.WriteLine("Please enter the ID number of the Developer you would like to update:");
        int userDevID = int.Parse(Console.ReadLine());

        Developer devInDatabase = GetDeveloperInDatabase(userDevID);

        Developer newDeveloper = new Developer();

        System.Console.WriteLine("Please enter the last name of the Developer:");
        newDeveloper.LastName = Console.ReadLine();

        System.Console.WriteLine("Please enter the first name of the Developer:");
        newDeveloper.FirstName = Console.ReadLine();

        System.Console.WriteLine("Please enter if this Developer has Pluralsight access:\n"
        + "1. Yes\n"
        + "2. No");
        int pluralsightInt = int.Parse(Console.ReadLine());
        newDeveloper.HasPluralsight = (HasPluralsight)pluralsightInt;

        bool developerAdded = _dev.UpdateDevData(userDevID, newDeveloper);

        if (developerAdded)
        {
            Console.Clear();
            System.Console.WriteLine("Developer added successfully!\n");
        }
        else
        {
            Console.Clear();
            System.Console.WriteLine("Developer NOT added. Please try again!\n");
        }
    }

    private void AddDeveloperAccess()
    {
        Console.Clear();

        ViewAllDevelopers();
        System.Console.WriteLine("Please enter the ID number of the Developer you would like to add Pluralsight access to:");
        int iD = int.Parse(Console.ReadLine());
        Developer newDeveloper = new Developer();

        System.Console.WriteLine("Do you want to give this Developer access to Pluralsight?\n"
        + "1. Yes\n"
        + "2. No");
        string? accessInput = Console.ReadLine();
        int pluralsightInt = accessInput != "" ? int.Parse(accessInput) : 0;
        newDeveloper.HasPluralsight = (HasPluralsight)pluralsightInt;

        bool updateSuccess = _dev.AddDeveloperAccess(iD, newDeveloper);

        if (updateSuccess)
        {
            Console.Clear();
            System.Console.WriteLine("Pluralsight access added successfully!\n");
        }
        else
        {
            Console.Clear();
            System.Console.WriteLine("Pluralsight access NOT added. Please try again!\n");
        }
    }

    private void UpdateDevTeam()
    {
        Console.Clear();
        ViewAllDevTeams();

        List<DevTeam> devTeam = _devTeam.GetAllTeams();
        if (devTeam.Count() > 0)
        {
            System.Console.WriteLine("Please enter the ID number of the Team you would like to update:");
            int userTeamID = int.Parse(Console.ReadLine());

            DevTeam teamDev = _devTeam.GetDevTeamByID(userTeamID);

            if (teamDev != null)
            {
                DevTeam updatedTeam = new DevTeam();

                System.Console.WriteLine("Please enter the new name of the Developer Team:");
                teamDev.TeamName = Console.ReadLine();

                bool updateSuccess = _devTeam.UpdatedDevTeam(userTeamID, teamDev);

                if (updateSuccess) 
                {
                    Console.Clear();
                    System.Console.WriteLine("Developer Team successfully updated}!");
                }
                else
                {
                    Console.Clear();
                    System.Console.WriteLine("Developer Team NOT updated. Please try again!\n");
                }
            }
        }
    }

    private void AddDevsToTeam()
    {
        Console.Clear();
        ViewAllDevTeams();
        List<DevTeam> devTeams = _devTeam.GetAllTeams();

        System.Console.WriteLine("Please enter the ID number of the Team you would like to add Developers to:");
        int userTeamID = int.Parse(Console.ReadLine());

        DevTeam newDevTeam = _devTeam.GetDevTeamByID(userTeamID);

        List<Developer> auxDevInDb = _dev.GetAllDevelopers();

        List<Developer> addDevs = new List<Developer>();

        if (newDevTeam != null)
        {
            bool filledTeam = false;

            while (!filledTeam)
            {
                if (auxDevInDb.Count() > 0)
                {
                    System.Console.WriteLine($"Do you want to add a Developer to Team #{userTeamID}?\n"
                    + "Yes\n"
                    + "No");
                    var userInput = Console.ReadLine();
                    if (userInput == "Yes")
                    {
                        ViewAllDevelopers();
                        System.Console.WriteLine($"Enter the ID number of the Developer you would like to add to Team #{userTeamID}:");
                        int userID = int.Parse(Console.ReadLine());
                        Developer dev = _dev.GetDevByID(userID);

                        if (dev != null)
                        {
                            addDevs.Add(dev);
                            auxDevInDb.Remove(dev);
                        }
                        else
                        {
                            System.Console.WriteLine("That Developer does not exist. Please try again.");
                        }
                    }
                    else
                    {
                        filledTeam = true;
                    }
                }
                else
                {
                    System.Console.WriteLine("There are no Developers available.");
                    break;
                }
            }
            if (_devTeam.AddDevTeamMem(newDevTeam.TeamID, addDevs))
            {
                Console.Clear();
                System.Console.WriteLine($"Developer added successfully to Team #{userTeamID}!");
            }
            else
            {
                Console.Clear();
                System.Console.WriteLine($"Developer NOT added to Team #{userTeamID}. Please try again!\n");
            }
        }
    }

    private void RemoveDeveloper()
    {
        Console.Clear();
        System.Console.WriteLine("Please enter the ID number of the Developer you would like to remove:");
        int iD = int.Parse(Console.ReadLine());
        Developer newDeveloper = new Developer();

        bool deleteSuccess = _dev.RemoveDeveloper(iD);

        if (deleteSuccess)
        {
            Console.Clear();
            System.Console.WriteLine("Developer has been removed successfully!\n");
        }
        else
        {
            Console.Clear();
            System.Console.WriteLine("Developer has not been removed. Please try again!\n");
        }
    }

    private void DeleteDevTeam()
    {
        Console.Clear();
        System.Console.WriteLine("Please enter the ID number of the Team you would like to remove:");
        int userTeamID = int.Parse(Console.ReadLine());
        DevTeam newDevTeam = new DevTeam();

        bool deleteSuccess = _devTeam.DeleteDevTeam(userTeamID);

        if (deleteSuccess)
        {
            Console.Clear();
            System.Console.WriteLine("Developer Team has been removed successfully!\n");
        }
        else
        {
            Console.Clear();
            System.Console.WriteLine("Developer Team has not been removed. Please try again!\n");
        }
    }

    private void ViewAllDevelopers()
    {
        Console.Clear();
        List<Developer> devList = _dev.GetAllDevelopers();

        foreach (Developer developer in devList)
        {
            System.Console.WriteLine("\n"
            + $"ID #{developer.ID}: {developer.FullName}\n"
            + "-------------\n"
            + $"Last Name: {developer.LastName}, First Name: {developer.FirstName}\n"
            + $"Pluralsight access: {developer.HasPluralsight}\n"
            + "");
        }
    }

    private void PluralsightDev()
    {
        List<Developer> pluralsightDev = _dev.DoesDeveloperHaveLicense();

        foreach (Developer developer in pluralsightDev)
        {
            Console.WriteLine($"ID #{developer.ID}: {developer.FullName}\n"
                + "");
        }
    }

    private void ViewDeveloperByID()
    {
        Console.Clear();
        ViewAllDevelopers();

        System.Console.WriteLine("Please enter the ID number of Developer you would like to view:");
        int userDevID = int.Parse(Console.ReadLine());

        Developer developer = _dev.GetDevByID(userDevID);

        System.Console.WriteLine("\n"
            + $"ID #{developer.ID}: {developer.FullName}\n"
            + "-------------\n"
            + $"Last Name: {developer.LastName}, First Name: {developer.FirstName}\n"
            + $"Pluralsight access: {developer.HasPluralsight}\n"
            + "");
    }

    private void ViewAllDevTeams()
    {
        System.Console.WriteLine("Developer Teams:");

        foreach (DevTeam devTeam in _devTeam.GetAllTeams())
        {
            Console.WriteLine("\n"
            + $"Developer Team: {devTeam.TeamName} | Team ID #{devTeam.TeamID}\n"
            + "-------------\n"
            + "Team Members:");

            if (devTeam.Developers != null)
            {
                foreach (Developer developer in devTeam.Developers)
                {
                    Console.WriteLine($"ID #{developer.ID}: {developer.FullName}\n"
                    + "");
                }
            }
        }
    }

    private void ViewDevTeam()
    {
        Console.Clear();
        ViewAllDevTeams();

        System.Console.WriteLine("Please enter the ID number of the Team you would like to view:");
        string? userTeamName = Console.ReadLine();
        int userTeamID = int.Parse(userTeamName);

        DevTeam devTeam = _devTeam.GetDevTeamByID(userTeamID);

        System.Console.WriteLine($"\n"
        + $"Developer Team Name: {devTeam.TeamName} | Team ID#: {devTeam.TeamID}");

        if (devTeam.Developers != null)
        {
            foreach (Developer developer in devTeam.Developers)
            {
                Console.WriteLine("\n"
                + $"Team Members: {developer.FullName}\n"
                + "");
            }
        }
        else
        {
            System.Console.WriteLine("There are no members on this team.\n"
            + "");
        }
    }

    private Developer GetDeveloperInDatabase(int userDevID)
    {
        return _dev.GetDeveloper(userDevID);
    }

    private void Seed()
    {
        Developer martinez = new Developer(_dev.GetAllDevelopers().Count + 1, "Martinez", "Angie", "Angie Martinez", HasPluralsight.No);
        _dev.AddNewDeveloper(martinez);

        Developer jacobs = new Developer(_dev.GetAllDevelopers().Count + 1, "Jacobs", "Alaric", "Alaric Jacobs", HasPluralsight.Yes);
        _dev.AddNewDeveloper(jacobs);

        Developer rainfeather = new Developer(_dev.GetAllDevelopers().Count + 1, "Rainfeather", "Ton", "Ton Rainfeather", HasPluralsight.Yes);
        _dev.AddNewDeveloper(rainfeather);

        Developer johnson = new Developer(_dev.GetAllDevelopers().Count + 1, "Johnson", "Dwayne", "Dwayne Johnson", HasPluralsight.No);
        _dev.AddNewDeveloper(johnson);

        Developer afiola = new Developer(_dev.GetAllDevelopers().Count + 1, "Afiola", "Lupita", "Lupita Afiola", HasPluralsight.Yes);
        _dev.AddNewDeveloper(afiola);

        Developer windsor = new Developer(_dev.GetAllDevelopers().Count + 1, "Windsor", "Harry", "Harry Windsor", HasPluralsight.No);
        _dev.AddNewDeveloper(windsor);

        List<Developer> devTeamOne = new List<Developer>();
        devTeamOne.Add(martinez);

        List<Developer> devTeamTwo = new List<Developer>();
        devTeamTwo.Add(jacobs);

        List<Developer> devTeamThree = new List<Developer>();
        devTeamThree.Add(rainfeather);

        DevTeam red = new DevTeam("Red", _devTeam.GetAllTeams().Count + 1, devTeamOne);
        _devTeam.AddNewTeam(red);

        DevTeam blue = new DevTeam("Blue", _devTeam.GetAllTeams().Count + 1, devTeamTwo);
        _devTeam.AddNewTeam(blue);

        DevTeam yellow = new DevTeam("Yellow", _devTeam.GetAllTeams().Count + 1, devTeamThree);
        _devTeam.AddNewTeam(yellow);
    }
}

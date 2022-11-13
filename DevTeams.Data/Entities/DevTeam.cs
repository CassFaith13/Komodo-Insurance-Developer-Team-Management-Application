public class DevTeam
{
    public DevTeam() { }

    public DevTeam(string teamName, int teamID, List<Developer> developers)
    {
        TeamName = teamName;
        TeamID = teamID;
        Developers = developers;
    }

    public string? TeamName { get; set; }
    public int TeamID { get; set; }
    public List<Developer>? Developers { get; set; } = new List<Developer>();
}

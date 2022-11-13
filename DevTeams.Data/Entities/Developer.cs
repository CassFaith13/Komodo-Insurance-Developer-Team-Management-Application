    public class Developer
    {
        public Developer() {}

        public Developer(int iD, string lastName, string firstName, string fullName, HasPluralsight hasPluralsight)
        {
            ID = iD;
            LastName = lastName;
            FirstName = firstName;
            HasPluralsight = hasPluralsight;
        }

        public int ID { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        
        public string FullName 
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public HasPluralsight HasPluralsight { get; set; }
    }

public enum HasPluralsight { Yes = 1, No }

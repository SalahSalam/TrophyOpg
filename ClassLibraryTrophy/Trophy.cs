using System.ComponentModel.Design;
using System.Reflection;

namespace ClassLibraryTrophy
{
    public class Trophy

    {
        //prop
        #region 
        public int Id { get; set; }
        public string? Competition { get; set; }
        public int Year { get; set; }
        #endregion
        //Con
        #region 
        public Trophy() { }
        public Trophy(int id, string competition, int year)
        {
            Id = id;
            Competition = competition;
            Year = year;
        }
        #endregion

        #region
        public override string ToString()
        {
            return $"Trophy ID: {Id}, Competition: {Competition}, Year: {Year}";
        }
        #endregion

        #region
        public void ValidateId()
        {
            if (Id <= 0)
            {
                throw new ArgumentException("TrophyId must be bigger than 0");//eller ArgumentOutOfRangeException
            }
        }
        public void ValidateCompetition()
        {
            if (Competition == null)
            {
                throw new ArgumentNullException("Trophy must5 have a competition");
            }
            else if (Competition == "") 
            {
                throw new ArgumentOutOfRangeException("Trophy Should have a value");
            }
            else if (Competition.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Competition must be at least 3 characters long");
            }
        }
        public void ValidateYear()
        {
            if (!(Year < 1970 && Year > 2024))
            {
                throw new ArgumentOutOfRangeException("Year must be between 1970 and 2024");
            }
        }
        public void Validate() 
        {
            ValidateId();
            ValidateCompetition();
            ValidateYear();
        }
        #endregion
    }
}
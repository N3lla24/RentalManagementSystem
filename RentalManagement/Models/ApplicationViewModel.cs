namespace RentalManagement.Models
{
    public class ApplicationViewModel
    {
        public IEnumerable<Unit> UnitModel { get; set; }

        public Unit Unit { get; set; }

        public IEnumerable<Room> RoomModel { get; set; }

        public Room Room { get; set; }

        public Applicants Applicants { get; set; }

        /*public virtual ApplicantsModel { get; set; }*/

    }
}

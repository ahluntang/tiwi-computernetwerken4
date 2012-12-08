using System.Collections.Generic;
using System.Linq;

namespace Workshops.Models
{
    public class InMemoryWorkshopRepository : Workshops.Models.IWorkshopRepository
    {
        private Dictionary<int, WorkshopWithDetails> workshops = new Dictionary<int, WorkshopWithDetails>();
        int nextAvailableId = 1;

        public InMemoryWorkshopRepository()
        {
            Add("My first workshop", "B211", new System.DateTime(2012,10,10));
            Add("My third workshop", "B221", new System.DateTime(2012, 10, 10));
            Add("My tenth workshop", "B223", new System.DateTime(2012, 10, 10));
        }

        public IEnumerable<Workshop> GetAllWorkshops()
        {
            return from workshop in workshops.Values
                   select new Workshop { Id = workshop.Id, Title = workshop.Title };
        }

        public WorkshopWithDetails GetWorkshop(int id)
        {

            if (workshops.ContainsKey(id))
            {
                WorkshopWithDetails w = workshops[id];
                return new WorkshopWithDetails { Id = id, Title = w.Title, Place = w.Place, Time =w.Time }; // copy
            }
            else
                return null;
        }

        public void SaveWorkshop(WorkshopWithDetails workshop)
        {
            if (workshop.Id == null)
            {
                workshop.Id = nextAvailableId;
                nextAvailableId++;
            }
            workshops[workshop.Id.Value] = new WorkshopWithDetails { Id = workshop.Id, Title = workshop.Title, Place = workshop.Place , Time = workshop.Time };
        }

        public void RemoveWorkshop(int id)
        {
            workshops.Remove(id);
        }



        private void Add(string title, string place, System.DateTime time)
        {
            SaveWorkshop(new WorkshopWithDetails { Id = null, Title = title, Place = place, Time = time });
        }


    }
}
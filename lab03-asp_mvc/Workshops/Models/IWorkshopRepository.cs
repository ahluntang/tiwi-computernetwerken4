using System;
using System.Collections.Generic;
namespace Workshops.Models
{
    public interface IWorkshopRepository
    {
        IEnumerable<Workshop> GetAllWorkshops();

        WorkshopWithDetails GetWorkshop(int id);

        void SaveWorkshop(WorkshopWithDetails workshop); // fills in ID if null

        void RemoveWorkshop(int id);
    }
}

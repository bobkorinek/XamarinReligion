using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Religions.Backend.Models;

namespace Religions.Backend.Managers
{
    public class ReligionsManager
    {
        private static List<Religion> religions = new List<Religion>();

        public async Task<bool> AddReligions(Religion Religions)
        {
            try
            {
                religions.Add(Religions);
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public List<Religion> GetReligions()
        {
            return religions;
        }
    }
}

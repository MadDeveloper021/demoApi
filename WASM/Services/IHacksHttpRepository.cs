using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackRegistration.Models;

namespace HackRegistration.HttpRepository
{
    public interface IHacksHttpRepository
    {
        Task<List<Hacks>> GetHacks();

        Task<string> DeleteHacks(string HackIds);

        Task<Hacks> GetHacksById(int id);

        Task<string> UpdateHacks(int id, Hacks hacks);

        Task<string> InsertHacks(Hacks hacks);
    }
}

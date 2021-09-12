using DemoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.Extensions
{
    public interface IHackRegistration
    {
        List<HackRegistration> GetHackRegistrations();
        HackRegistration GetHackRegistrations(int id);
        HackRegistration AddHackRegistration(HackRegistration hack);
        void UpdateHackRegistration(HackRegistration hack);
        void DeleteHackRegistration(string[] ids);
    }
}

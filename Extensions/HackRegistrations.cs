using DemoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.Extensions
{
    public class HackRegistrations : IHackRegistration
    {
        private readonly ChatBotDBContext _context;
        public HackRegistrations(ChatBotDBContext context)
        {
            _context = context;
        }

        public HackRegistration AddHackRegistration(HackRegistration hack)
        {
            hack.CreatedOn = DateTime.Now;
            hack.ModifiedOn = null;
            _context.HackRegistration.Add(hack);
            _context.SaveChanges();
            return hack;
        }

        public void DeleteHackRegistration(string[] ids)
        {
            foreach (var item in ids)
            {
                var data = _context.HackRegistration.Find(Convert.ToInt32(item));
                if (data != null)
                {
                    _context.HackRegistration.Remove(data);
                }
            }
            _context.SaveChanges();
        }

        public List<HackRegistration> GetHackRegistrations()
        {
           return _context.HackRegistration.Take(10).OrderBy(x=>x.CreatedOn).ToList();
        }

        public HackRegistration GetHackRegistrations(int id)
        {
            var data = _context.HackRegistration.Find(id);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public void UpdateHackRegistration(HackRegistration hack)
        {           
            if (hack != null)
            {
                hack.ModifiedOn = DateTime.Now;
                _context.HackRegistration.Update(hack);
                _context.SaveChanges();
            }
        }
    }
}

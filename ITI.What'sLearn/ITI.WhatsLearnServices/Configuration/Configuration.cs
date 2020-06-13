using ITI.WhatsLearn.Entities;
using ITI.WhatsLearn.Reposatories;
using ITI.WhatsLearn.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITI.WhatsLearn.Services
{
    public class ConfigurationService
    {
        UnitOfWork unitOfWork;
        Generic<Configuration> ConfigurationRepo;
        public ConfigurationService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            ConfigurationRepo = unitOfWork.ConfigurationRepo;

        }

        public IQueryable<Configuration> GetAll()
        {
            return ConfigurationRepo.GetAll();
        }


        public int Increment(string key)
        {
            Configuration c = ConfigurationRepo.Get(i => i.Key == key).FirstOrDefault();
           c.Value++;

            //   ConfigurationRepo.u
            // c.Value = c.Value + 1;
            // ConfigurationRepo.Update(c);
            unitOfWork.Commit();
            return c.Value;
        }

        public int Count(string key)
        {
            int count= ConfigurationRepo.Get(i => i.Key == key).Select(i => i.Value).FirstOrDefault();
            return count;


        }


    }
}

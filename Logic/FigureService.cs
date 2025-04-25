using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Logic
{
    public class FigureService
    {
        FigureRepository repo;

        public void Add(Figure fig)
        {
            repo.Add(fig);
        }

        public void Delete(Figure fig)
        {
            repo.Delete(fig);
        }

        public String GetDescription()
        {
            return repo.GetDescription();
        }

        public void ChangeByIndex(int idx, Figure fig)
        {
            repo.ChangeByIndex(idx, fig);
        }

        public void DeleteByIndex(int idx)
        {
            repo.DeleteByIndex(idx);
        }
    }
}

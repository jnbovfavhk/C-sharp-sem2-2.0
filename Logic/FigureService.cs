using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data;

namespace Logic
{
    public class FigureService
    {
        private FigureRepository repo = new FigureRepository();

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
            if (repo.Length < idx)
            {
                return;
            }
            if (idx < 0)
            {
                return;
            }
            repo.ChangeByIndex(idx, fig);
        }

        public void DeleteByIndex(int idx)
        {
            repo.DeleteByIndex(idx);
        }
    }
}

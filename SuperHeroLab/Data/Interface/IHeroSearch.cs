using SuperHeroLab.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroLab.Data.Interface
{
    public interface IHeroSearch
    {
        public HeroResponse GetData(int id);
    }
}

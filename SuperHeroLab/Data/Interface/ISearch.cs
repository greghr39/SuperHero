using SuperHeroLab.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroLab.Data.Interface
{
    public interface ISearch
    {
        public SearchResponse GetDataList(string searchValue);
    }
}

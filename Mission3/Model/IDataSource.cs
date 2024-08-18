using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission3.Model
{
    public interface IDataSource<T>
    {
        void Save(List<T> list);
        Task SaveAsync(List<T> list);
        List<T> Load();
    }
}

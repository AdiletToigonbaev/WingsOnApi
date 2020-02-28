using System;
using System.Collections.Generic;
using System.Text;
using WingsOn.BLL.DTOs;

namespace WingsOn.BLL.Interfaces
{
    public interface IService<T> where T: DTOObject
    {
        IEnumerable<T> GetAll();
    }
}

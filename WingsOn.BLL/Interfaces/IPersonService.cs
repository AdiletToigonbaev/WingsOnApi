using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WingsOn.BLL.DTOs;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.BLL.Interfaces
{
    public interface IPersonService : IService<PersonDTO>
    {
        Task <IEnumerable<PersonDTO>> GetByGenderAsync(string gender);
        Task <PersonDTO> GetAsync(int id);
        Task <PersonDTO> UpdateAddressAsync(UpdateAddressDTO dto);
    }
}

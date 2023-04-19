using RollOff_Test4API.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollOff_Test4API.Repository
{
    public interface IFormRepository
    {
        Task<FormTable> AddFormAsync(FormTable formTable);

        Task<IEnumerable<FormTable>> GetAllFormsAsync();

        //Task<FormTable> DeleteFormAsync(double ggid);

        //Task<FormTable> UdateFormAsync(double ggid, FormTable formTable);
    }
}

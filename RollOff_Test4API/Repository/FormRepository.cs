using Microsoft.EntityFrameworkCore;
using RollOff_Test4API.Data;
using RollOff_Test4API.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollOff_Test4API.Repository
{
    public class FormRepository: IFormRepository
    {
        private readonly RollOff4DbContext context;

        public FormRepository(RollOff4DbContext context)
        {
            this.context = context;
        }
        public async Task<FormTable> AddFormAsync(FormTable formTable)
        {
            await context.AddAsync(formTable);
            await context.SaveChangesAsync();
            return formTable;
        }
       

        public async Task<IEnumerable<FormTable>> GetAllFormsAsync()
        {
            return await context.FormTables.ToListAsync();

        }

        
    }
}

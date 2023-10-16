using OrleansWebAPI7AppDemo.Models.Accounting;

namespace OrleansWebAPI7AppDemo.Orleans.Abstractions
{
    public interface ICompanyGrain : IGrainWithStringKey
    {
        Task<Company> Get();

        Task Set(Company value);
        
    }
}

using Domain.Bases;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<BaseHttpResponse<bool>> Proccess();
    }
}

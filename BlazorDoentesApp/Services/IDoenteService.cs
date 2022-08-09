using Models;
using Models.CustomModels;

namespace BlazorDoentesApp.Services
{
    public interface IDoenteService
    {
        Task<List<TbDoente>> GetDoentes();
        Task<ResponseModel> AddDoente(TbDoente _doente);
        Task<ResponseModel> DeleteDoente(int _doenteId);
        Task<ResponseModel> UpdateDoente(TbDoente _doente);
        Task<ResponseModel> GetDoente(int doenteId);
    }
}

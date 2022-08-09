using Models;
using Models.CustomModels;


namespace BlazorDoentesApp.Services
{
    public interface IConsultasService
    {
        Task<List<TbConsulta>> GetConsultas();
        Task<ResponseModel> AddConsulta(TbConsulta _consulta);
        Task<ResponseModel> DeleteConsulta(int _consultaId);
        Task<ResponseModel> UpdateConsulta(TbConsulta _consulta);
        Task<List<ConsultasDia>> GetConsultasDia();
        Task<List<TbConsulta>> GetConsultasDoente(int idDoente);


    }
}

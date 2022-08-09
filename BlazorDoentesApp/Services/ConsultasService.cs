using Models;
using Models.CustomModels;


namespace BlazorDoentesApp.Services
{
    public class ConsultasService : IConsultasService
    {
        private readonly HttpClient httpClient;

        public ConsultasService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public async Task<List<TbConsulta>> GetConsultas()
        {
            return await httpClient.GetFromJsonAsync<List<TbConsulta>>("api/Consulta/GetConsultas");
        }

        public async Task<ResponseModel> AddConsulta(TbConsulta _consulta)
        {
            var response = await httpClient.PostAsJsonAsync("api/Consulta/AddConsulta", _consulta);
            return await response.Content.ReadFromJsonAsync<ResponseModel>();
        }

        public async Task<ResponseModel> UpdateConsulta(TbConsulta _consulta)
        {
            var response = await httpClient.PostAsJsonAsync("api/Consulta/UpdateConsulta", _consulta);
            return await response.Content.ReadFromJsonAsync<ResponseModel>();
        }

        public async Task<ResponseModel> DeleteConsulta(int consultaId)
        {
            return await httpClient.GetFromJsonAsync<ResponseModel>("api/Consulta/DeleteConsulta/?consultaId=" + consultaId);
        }

        public async Task<List<ConsultasDia>> GetConsultasDia()
        {
            return await httpClient.GetFromJsonAsync<List<ConsultasDia>>("api/Consulta/GetConsultasDia");
        }
        public async Task<List<TbConsulta>> GetConsultasDoente(int idDoente)
        {
            return await httpClient.GetFromJsonAsync<List<TbConsulta>>("api/Consulta/GetConsultasDoente/?idDoente=" + idDoente);
        }
    }
}

using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.CustomModels;


namespace ApiDoentes.Controllers
{
    [Route("api/Consulta")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private readonly Context _dbcontext;
        public ConsultasController(Context context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        [Route("GetConsultas")]
        public async Task<IActionResult> GetConsultas()
        {
            var data = _dbcontext.TbConsultas.ToList();

            return Ok(data);
        }

        [HttpPost]
        [Route("AddConsulta")]
        public async Task<ActionResult<ResponseModel>> AddConsulta(TbConsulta _consulta)
        {
            try
            {
                var doente = _dbcontext.TbDoentes.Where(x => x.Id == _consulta.IdDoente).FirstOrDefault();
                ResponseModel response = new ResponseModel();
                TbConsulta data = _dbcontext.TbConsultas.Where(x => x.Id == _consulta.Id).FirstOrDefault();
                if(doente == null)
                {
                    response.Status = false;
                    response.Message = "Não existe nenhum doente com esse ID";
                    return response;
                }
                if (data == null && _consulta != null && _consulta.Especialidade != "" && !_consulta.Data.Equals(null) && _consulta.IdDoente != 0)
                {
                    data = new TbConsulta();
                    data.Data = _consulta.Data;
                    data.Especialidade = _consulta.Especialidade;
                    data.IdDoente = _consulta.IdDoente;
                    _dbcontext.TbConsultas.Add(data);
                    _dbcontext.SaveChanges();
                    response.Status = true;
                    response.Message = "Sucess";
                    return response;
                }
                else
                {
                    response.Status = false;
                    response.Message = "Erro ao adicionar Consulta!!";
                    return response;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("UpdateConsulta")]
        public async Task<ActionResult<ResponseModel>> UpdateConsulta(TbConsulta _consulta)
        {
            try
            {
                ResponseModel response = new ResponseModel();
                var data = _dbcontext.TbConsultas.Where(x => x.Id == _consulta.Id).FirstOrDefault();
                var doente = _dbcontext.TbDoentes.Where(x => x.Id == _consulta.IdDoente).FirstOrDefault();
                if (doente == null)
                {
                    response.Status = false;
                    response.Message = "Não existe nenhum doente com esse ID";
                    return response;
                }
                if (data != null)
                {

                    data.Data = _consulta.Data;
                    data.Especialidade = _consulta.Especialidade;
                    data.IdDoente = _consulta.IdDoente;
                    
                    _dbcontext.TbConsultas.Update(data);
                    _dbcontext.SaveChanges();
                    response.Status = true;
                    response.Message = "Sucess";
                    return response;
                }
                else
                {
                    response.Status = false;
                    response.Message = "Consulta não existe!!";
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("DeleteConsulta")]
        public async Task<ActionResult<ResponseModel>> DeleteConsulta(int consultaId)
        {
            try
            {
                ResponseModel response = new ResponseModel();

                var data = _dbcontext.TbConsultas.Where(x => x.Id == consultaId).FirstOrDefault();
                if (data != null)
                {

                    _dbcontext.TbConsultas.Remove(data);
                    _dbcontext.SaveChanges();
                    response.Status = true;
                    response.Message = "Sucess";
                    return response;
                }
                else
                {
                    response.Status = false;
                    response.Message = "Consulta não existe!!";
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpGet]
        [Route("GetConsultasDia")]
        public async Task<IActionResult> GetConsultasDia()
        {
            var data = _dbcontext.TbConsultas.ToList();

            List<ConsultasDia> listConsultasDia = new List<ConsultasDia>();

            if (data != null)
            {
                bool JaexisteItemComEsseDia;
                foreach (var consulta in data)
                {
                    JaexisteItemComEsseDia = false;
                    foreach (ConsultasDia item in listConsultasDia)
                    {
                        //se existir adiciona uma consulta ao Nr de consulta do dia
                        if (consulta.Data.ToShortDateString() == item.Dia.ToShortDateString())
                        {
                            item.NrConsultas++;
                            JaexisteItemComEsseDia = true;
                        }
                    }
                    //se sair do foreach e continuar a falso é pq aque dia ainda não esta registado na lista
                    if (JaexisteItemComEsseDia == false)
                    {
                        ConsultasDia cd = new ConsultasDia();
                        cd.NrConsultas = 1;
                        cd.Dia = consulta.Data;
                        listConsultasDia.Add(cd);
                    }

                }
            }
            return Ok(listConsultasDia);
        }

        [HttpGet]
        [Route("GetConsultasDoente")]
        public async Task<IActionResult> GetConsultasDoente(int idDoente)
        {
            var data = _dbcontext.TbConsultas.ToList();
            List<TbConsulta> listconsultasDoente=new List<TbConsulta>();

            if (data != null)
            {
                foreach (var item in data)
                {
                    if(item.IdDoente == idDoente){
                        listconsultasDoente.Add(item);
                    }
                }
            }

            return Ok(listconsultasDoente);
        }
    }
}

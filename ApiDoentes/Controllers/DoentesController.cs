using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.CustomModels;
using System.Data.Entity;

namespace ApiDoentes.Controllers
{
    [Route("api/Doente")]
    [ApiController]
    public class DoentesController : ControllerBase
    {
        private readonly Context _dbcontext;
        public DoentesController(Context context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        [Route("GetDoentes")]
        public async Task<IActionResult> GetDoentes()
        {
            var data = _dbcontext.TbDoentes.ToList();
          
            return Ok(data);
        }

        [HttpPost]
        [Route("AddDoente")]
        public async Task<ActionResult<ResponseModel>> AddDoente(TbDoente _doente)
        {
            try
            {
                ResponseModel response = new ResponseModel();
                TbDoente data = _dbcontext.TbDoentes.Where(x => x.Id == _doente.Id).FirstOrDefault();
                if (data == null && _doente != null && _doente.Nome != "" && !_doente.DataNascimento.Equals(null) && _doente.Sexo != "")
                {   
                    data = new TbDoente();
                    data.Nome = _doente.Nome;
                    data.DataNascimento = _doente.DataNascimento;
                    data.Sexo = _doente.Sexo;
                    _dbcontext.TbDoentes.Add(data);
                    _dbcontext.SaveChanges();
                    response.Status = true;
                    response.Message = "Sucess";
                    return response;
                }
                else
                {
                    response.Status = false;
                    response.Message = "Erro ao adicionar Doente!!";
                    return response;
                }
                
            }
            catch(Exception ex)
            {
                throw;
            }
        }


        [HttpPost]
        [Route("UpdateDoente")]
        public async Task<ActionResult<ResponseModel>> UpdateDoente(TbDoente _doente)
        {
            try
            {
                ResponseModel response = new ResponseModel();
                
                var data = _dbcontext.TbDoentes.Where(x => x.Id == _doente.Id).FirstOrDefault();
                if (data != null)
                {

                    data.Nome = _doente.Nome;
                    data.DataNascimento = _doente.DataNascimento;
                    data.Sexo = _doente.Sexo;
                    _dbcontext.TbDoentes.Update(data);
                    _dbcontext.SaveChanges();
                    response.Status = true;
                    response.Message = "Sucess";
                    return response;
                }
                else
                {
                    response.Status = false;
                    response.Message = "Doente não existe!!";
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("DeleteDoente")]
        public async Task<ActionResult<ResponseModel>> DeleteDoente(int doenteId)
        {
            try
            {
                ResponseModel response = new ResponseModel();
               
                var data = _dbcontext.TbDoentes.Where(x => x.Id == doenteId).FirstOrDefault();
                if (data != null)
                {
                    
                    _dbcontext.TbDoentes.Remove(data);
                    _dbcontext.SaveChanges();
                    response.Status = true;
                    response.Message = "Sucess";
                    return response;
                }
                else
                {
                    response.Status = false;
                    response.Message = "Doente não existe!!";
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetDoente")]
        public async Task<ActionResult<ResponseModel>> GetDoente(int doenteId)
        {
            try
            {
                ResponseModel response = new ResponseModel();

                var data = _dbcontext.TbDoentes.Where(x => x.Id == doenteId).FirstOrDefault();
                if (data != null)
                {

                    response.Doente = data;
                    response.Status = true;
                    response.Message = "Sucess";
                    return response;
                }
                else
                {
                    response.Status = false;
                    response.Message = "Doente não existe!!";
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}

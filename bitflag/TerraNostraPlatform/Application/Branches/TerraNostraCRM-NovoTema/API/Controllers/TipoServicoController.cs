using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.TipoServico;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TipoServicoController : ControllerBase
    {
        private readonly TipoServicoService tipoServicoService;
        public TipoServicoController(ITipoServicoService tipoServicoService)
        {
            this.tipoServicoService = (TipoServicoService)tipoServicoService;
        }

        [HttpGet]
        public List<TipoServicoViewModel> Get()
        {
            return tipoServicoService.List();
        }
    }
}
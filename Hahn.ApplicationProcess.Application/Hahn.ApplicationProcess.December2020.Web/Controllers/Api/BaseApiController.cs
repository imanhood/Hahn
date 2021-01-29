using AutoMapper;
using Hahn.ApplicationProcess.December2020.Data.Entites;
using Hahn.ApplicationProcess.December2020.Domain.Services.Contracts;
using Hahn.ApplicationProcess.December2020.Domain.Services.Implements;
using Hahn.ApplicationProcess.December2020.Web.Models.Binding;
using Hahn.ApplicationProcess.December2020.Web.Models.View;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Hahn.ApplicationProcess.December2020.Web.Controllers.Api {
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController<TController, TBindingModel, TViewModel, TEntity, TService> : ControllerBase 
        where TController : ControllerBase
        where TBindingModel : BaseBindingModel
        where TEntity : BaseEntity
        where TService : IBaseService<TEntity> {
        private readonly ILogger<TController> _logger;
        private readonly TService _service;
        private readonly IMapper _mapper;
        private readonly string _presentationController;
        public BaseApiController(
                ILogger<TController> logger,
                TService service,
                IMapper mapper,
                string presentationController
        ) {
            _logger = logger;
            _service = service;
            _mapper = mapper;
            _presentationController = presentationController;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int? id) {
            if(id == null) {
                return BadRequest("ID must be submited");
            }
            var entity = await _service.GetByIdAsync(id: id.Value);
            if(entity == null) {
                return BadRequest("ID does not exist");
            }
            return Ok(_mapper.Map<TViewModel>(entity));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> Add([FromBody] TBindingModel input) {
            var entity = await _service.AddAsync(_mapper.Map<TEntity>(input));
            return Created($"{_presentationController}/edit/{entity.ID}", entity);
        }
        [HttpPut]
        public IActionResult Edit([FromBody] TBindingModel input) {
            if(input.ID == null) {
                return BadRequest("ID must be submited");
            }
            var entity = _service.GetById(input.ID.Value);
            if(entity == null) {
                return BadRequest("ID does not exist");
            }
            _service.Edit(_mapper.Map<TEntity>(input));
            return Ok();
        }
        [HttpDelete]
        public IActionResult Remove(int? id) {
            if(id == null) {
                return BadRequest("ID must be submited");
            }
            if(!ModelState.IsValid) {
                return ValidateMessage();
            }
            var entity = _service.GetById(id: id.Value);
            if(entity == null) {
                return BadRequest("ID does not exist");
            }
            _service.Remove(entity);
            return Ok();
        }
        protected IActionResult ValidateMessage() {
            if(ModelState.IsValid)
                return null;

            var message = (ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)).FirstOrDefault();

            return BadRequest(message);
        }
    }
}
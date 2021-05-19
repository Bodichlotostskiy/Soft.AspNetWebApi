using Microsoft.AspNetCore.Mvc;

using RB_Soft.Data.Entities;
using RB_Soft.Infrastructure.Models;
using RB_Soft.Infrastructure.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace RB_Soft.AspNetWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DetailController : ControllerBase
    {
        private readonly IDetailService detailService;
        
        public DetailController(IDetailService detailService)
        {
            this.detailService = detailService;
        }


        /// <summary>
        /// Return page with count.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{page}/{count}")]
        public async Task<IEnumerable<Detail>> GetAll(int page, int count)
        {
            return await detailService.GetAsync(page, count);
        }

        /// <summary>
        /// return Detail by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Detail> GetById(int id)
        {
            return await detailService.GetByIdAsync(id);
        }

        /// <summary>
        /// Create new item Detail
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<Detail> Create(DetailModel detail)
        {
            return await detailService.CreateAsync(detail);
        }

        /// <summary>
        /// Update Detail
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<Detail> Update(DetailModel detail)
        {
            return await detailService.UpdateAsync(detail);
        }

        /// <summary>
        /// Delete detail from db by detail id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            return await detailService.DeleteAsync(id);
        }
    }
}

using LectorUniversal.Client.Shared;
using LectorUniversal.Server.Data;
using LectorUniversal.Shared.DTOs;
using LectorUniversal.Server.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LectorUniversal.Server.Models;

namespace LectorUniversal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsersController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> Get([FromQuery] PaginationDTO paginacion)
        {
            var queryable = context.Users.AsQueryable();
            await HttpContext.InsertParameterInResponse(queryable, paginacion.Records);
            return await queryable.Pagination(paginacion)
                .Select(x => new UserDTO { UserName = x.UserName, UserId = x.Id }).ToListAsync();
        }

        [HttpGet("roles")]
        public async Task<ActionResult<List<RoleDTO>>> Get()
        {
            return await context.Roles
                .Select(x => new RoleDTO { Name = x.Name, RoleId = x.Id }).ToListAsync();
        }

        [HttpPost("asignRole")]
        public async Task<ActionResult> AsignRoleUser(EditRoleDTO editRoleDTO)
        {
            var user = await userManager.FindByIdAsync(editRoleDTO.UserId);
            await userManager.AddToRoleAsync(user, editRoleDTO.RoleId);
            return NoContent();
        }

        [HttpPost("removeRole")]
        public async Task<ActionResult> RemoveUserRole(EditRoleDTO editRoleDTO)
        {
            var user = await userManager.FindByIdAsync(editRoleDTO.UserId);
            await userManager.RemoveFromRoleAsync(user, editRoleDTO.RoleId);
            return NoContent();
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkSpace.Core.Domain;
using WorkSpace.Core.Models.System;
using WorkSpace.Core.Repositories;
using WorkSpace.Core.SeedWorks;
using WorkSpace.Core.SeedWorks.Constants;

namespace WorkSpace.WebApi.Controllers;

[Route("api/admin/users")]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;
    private readonly IUnitOfWork _unitOfWork;

    public UserController(IMapper mapper, UserManager<AppUser> userManager, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _userManager = userManager;
        _unitOfWork = unitOfWork;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user == null)
        {
            return NotFound();
        }

        var userDto = _mapper.Map<AppUser, UserDto>(user);
        var roles = await _userManager.GetRolesAsync(user);
        userDto.Roles = roles;
        return Ok(userDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        if ((await _userManager.FindByNameAsync(request.Email)) != null)
        {
            return BadRequest();
        }

        if ((await _userManager.FindByEmailAsync(request.UserName)) != null)
        {
            return BadRequest();
        }
        
        var user = _mapper.Map<CreateUserRequest, AppUser>(request);
        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            return Ok();
        }
        
        return BadRequest(string.Join("<br>", result.Errors.Select(e => e.Description)));
    }
    
    [HttpPut("{id}/assign-users")]
    [Authorize(Permissions.Users.Edit)]
    public async Task<IActionResult> AssignRolesToUser(string id, [FromBody] string[] roles)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        var currentRoles = await _userManager.GetRolesAsync(user);
        await _unitOfWork.Users.RemoveUserFromRoles(user.Id, currentRoles.ToArray());
        var addedResult = await _userManager.AddToRolesAsync(user, roles);
        if (!addedResult.Succeeded)
        {
            List<IdentityError> addedErrorList = addedResult.Errors.ToList();
            var errorList = new List<IdentityError>();
            errorList.AddRange(addedErrorList);

            return BadRequest(string.Join("<br/>", errorList.Select(x => x.Description)));
        }
        return Ok();
    }
    
}
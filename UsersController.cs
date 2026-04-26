using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    static List<User> users = new List<User>();

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(users);
    }

    [HttpPost]
    public IActionResult Post(User user)
    {
        if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email))
            return BadRequest("Invalid data");

        users.Add(user);
        return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, User u)
    {
        var user = users.FirstOrDefault(x => x.Id == id);
        if (user == null) return NotFound();

        user.Name = u.Name;
        user.Email = u.Email;
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = users.FirstOrDefault(x => x.Id == id);
        if (user == null) return NotFound();

        users.Remove(user);
        return Ok();
    }
}

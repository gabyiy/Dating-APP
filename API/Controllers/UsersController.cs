using Microsoft.AspNetCore.Mvc;
using API.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    //le dam 2 atribute ap controler si routr
    [ApiController]
    [Route("api/[controller]")]//ca sa ajunga la controler trebuie sa inceapa cu api/controlerr care este userscontroller numele clasei de ma ijos
    public class UsersController : ControllerBase
    //specificam ca dorim sa utilizeze clasa controler base
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)            //la context intiem un field

        //creem constructoru  si ca parametru ii trecem clasa data context si context ,scriem si usining data adica clasa data
        {
            _context = context;

        }
       
       [HttpGet]
       //cu async facem codu asincronizat
       public async Task<ActionResult<IEnumerable<AppUser>>>GetUsers()
       {
       return  await _context.Users.ToListAsync();
       //specificam ca dorim sa astepte pana se face tascu si sa ne retureze tot de forma async 
       
       }

        //cand se acceseaza api/user/3 o sa se afiseze cine este la id 3
        [HttpGet("{id}")]
        // specificam ca dorim sa trimitem la client o liste de useri
        public async Task< ActionResult<AppUser>> GetUser(int id)//si il trecem ca parametru si aici
        {
                return  await _context.Users.FindAsync(id);
                
        }
        //dupa activa serveru cu donet run intram in https://localhost:5001/api/users/2 si ne apara ce user avem la pozitia 2

    }
}
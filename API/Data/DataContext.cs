using API.Controllers;
using Microsoft.EntityFrameworkCore;
//prima oara creem folderu entities iar dupa folderu data si cu clasa data context
//in controller creem clasa appuser cu metodele get set id si fullname

namespace API.Data
{
    //PRIMI PASI IN A CONSTRU UN SCELETON PART 1
    public class DataContext : DbContext//ptem citi descriptia sa vedem ce adaugam la clasa noastra
    {
        //dand click pe bec o sa alegeme generate contructor cu base option
        public DataContext( DbContextOptions options) : base(options)
        
        {
        }
        //cand clasa este initiata o sa cheme constructuarele astea

        public DbSet<AppUser> Users { get; set; }//creem un prop de  dbset si specificam ca dorim ca creem o baza de date pentru ceva  de tip appuser,si in interioru bazei de date acesta va ave numele de users,ca sa dispara eroarea dam iar pe beculet si specificam ca dorim sa utilizee usinng
        

        //DUPA  TREBUIE SA CONSTRUIM O ONEXIUNE PENTRU BAZA NOASTRA DE DATE IN STSRTUP LA METODA COFIGUREsERVICES

    }
}
using Hotel.DataAccessLayer.Abstract;
using Hotel.DataAccessLayer.Concrete;
using Hotel.DataAccessLayer.Repositories;
using Hotel.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataAccessLayer.EntityFramework
{
    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
        public EfAboutDal(Context context) : base(context)
        {
        }
    }
}

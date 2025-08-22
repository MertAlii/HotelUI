using Hotel.BusinessLayer.Abstract;
using Hotel.DataAccessLayer.Abstract;
using Hotel.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.BusinessLayer.Concrete;
public class AboutManager : IAboutService
{
    private readonly IAboutDal _aboutDal;

    public AboutManager(IAboutDal aboutDal)
    {
        _aboutDal = aboutDal;
    }

    public void TDelete(About entity)
    {
        _aboutDal.Delete(entity);
    }

    public About TGetById(int id)
    {
        return _aboutDal.GetById(id);
    }

    public List<About> TGetList()
    {
        return _aboutDal.GetList();
    }

    public void TInsert(About entity)
    {
        _aboutDal.Insert(entity);
    }

    public void TUpdate(About entity)
    {
        _aboutDal.Update(entity);
    }
}

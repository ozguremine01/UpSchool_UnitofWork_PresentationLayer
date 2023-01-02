using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchool_UnitofWork_BussinessLayer.Abstract;
using UpSchool_UnitofWork_DataAccessLayer.Abstract;
using UpSchool_UnitofWork_DataAccessLayer.UnitofWork;
using UpSchool_UnitofWork_EntityLayer.Concrete;

namespace UpSchool_UnitofWork_BussinessLayer.Concrete
{
    public class AccountManager : IAccounService
    {
        private readonly IAccountDal _accountDal;
        private readonly IUoWDal _uoWDal;

        public AccountManager(IAccountDal accountDal, IUoWDal uoWDal)
        {
            _accountDal = accountDal;
            _uoWDal = uoWDal;
        }

        public void TDelete(Account t)
        {
            _accountDal.Delete(t);
            _uoWDal.Save();
        }

        public Account TGetByID(int id)
        {
            return _accountDal.GetByID(id);
        }

        public List<Account> TGetList()
        {
            return _accountDal.GetList();
        }

        public void TInsert(Account t)
        {
            _accountDal.Insert(t);
            _uoWDal.Save();
        }

        public void TMultiUpdate(List<Account> t)
        {
            _accountDal.MultiUpdate(t);
            _uoWDal.Save();
        }

        public void TUpdate(Account t)
        {
            _accountDal.Update(t);
            _uoWDal.Save();
        }
    }
}

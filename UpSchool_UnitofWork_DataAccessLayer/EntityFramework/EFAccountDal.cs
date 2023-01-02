using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchool_UnitofWork_DataAccessLayer.Abstract;
using UpSchool_UnitofWork_DataAccessLayer.Concrete;
using UpSchool_UnitofWork_DataAccessLayer.Repository;
using UpSchool_UnitofWork_EntityLayer.Concrete;

namespace UpSchool_UnitofWork_DataAccessLayer.EntityFramework
{
    public class EFAccountDal : GenericRepository<Account>, IAccountDal
    {
        public EFAccountDal(Context context): base(context)
        {

        }
    }
}

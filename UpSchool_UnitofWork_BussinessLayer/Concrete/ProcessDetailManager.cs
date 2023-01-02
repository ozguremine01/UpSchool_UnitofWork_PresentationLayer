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
    public class ProcessDetailManager : IProcessDetailService
    {
        private readonly IProcessDetailDal _processDetailDal;
        private readonly IUoWDal _uoWDal;

        public ProcessDetailManager(IProcessDetailDal processDetailDal, IUoWDal uoWDal)
        {
            _processDetailDal = processDetailDal;
            _uoWDal = uoWDal;
        }

        public void TDelete(ProcessDetail t)
        {
            _processDetailDal.Delete(t);
            _uoWDal.Save();
        }

        public ProcessDetail TGetByID(int id)
        {
            return _processDetailDal.GetByID(id);   
        }

        public List<ProcessDetail> TGetList()
        {
            return _processDetailDal.GetList(); 
        }

        public void TInsert(ProcessDetail t)
        {
            _processDetailDal.Insert(t);
            _uoWDal.Save();
        }

        public void TMultiUpdate(List<ProcessDetail> t)
        {
            _processDetailDal.MultiUpdate(t);
            _uoWDal.Save();
        }

        public void TUpdate(ProcessDetail t)
        {
            _processDetailDal.Update(t);
            _uoWDal.Save();
        }
    }
}

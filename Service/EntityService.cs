using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;

namespace Service
{
    public abstract class EntityService<T> : IEntityService<T> where T : class
    {
        private UnitOfWork _unitOfWork;
       

        public EntityService()
        {
            _unitOfWork = new UnitOfWork();
    
        }

        public UnitOfWork unitofwork
        {
            get { return _unitOfWork ; }
        }

        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            // Code
            _unitOfWork.GetRepository<T>().Add(entity);


        }


        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            // Code
            _unitOfWork.GetRepository<T>().Update(entity);


        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            // Code
            _unitOfWork.GetRepository<T>().Delete(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            // Code
            return _unitOfWork.GetRepository<T>().GetAll();
        }

        public virtual T GetById(int id)
        {
            // Code
            return _unitOfWork.GetRepository<T>().GetById(id);
        }
        public virtual T GetById(string id)
        {
            // Code
            return _unitOfWork.GetRepository<T>().GetById(id);
        }
		
		public virtual void Dispose()
        {
            // Code
            _unitOfWork.Dispose();
        }
        public void Commit()
        {
            try
            {
                // Code
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}

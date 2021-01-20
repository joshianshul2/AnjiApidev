#region Using Namespaces...
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.Entity.Validation;
using DataModel.GenericRepository;
#endregion
namespace DataModel.UnitOfWork
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        #region Private member variables...
        private bmwEntities _context = null;

        private GenericRepository<Counter> _CounterRepository;
        private GenericRepository<CategoryMaster> _CategoryMasterRepository;
        private GenericRepository<CityMaster> _CityMasterRepository;
        private GenericRepository<HospitalMaster> _HospitalMasterRepository;
        private GenericRepository<HospitalTransaction> _HospitalTransactionRepository;
        private GenericRepository<PaymentDetail> _PaymentDetailRepository;
        private GenericRepository<UserMaster> _UserMasterRepository;

   
        #endregion
        public UnitOfWork()
        {
            _context = new bmwEntities();
        }
        #region Public Repository Creation properties...
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        public GenericRepository<CityMaster> CityMasterRepository
        {
            get
            {
                if (this._CityMasterRepository == null)
                    this._CityMasterRepository = new GenericRepository<CityMaster>(_context);
                return _CityMasterRepository;
            }
        }
        public GenericRepository<CategoryMaster> CategoryMasterRepository
        {
            get
            {
                if (this._CategoryMasterRepository == null)
                    this._CategoryMasterRepository = new GenericRepository<CategoryMaster>(_context);
                return _CategoryMasterRepository;
            }
        }

        public GenericRepository<HospitalMaster> HospitalMasterRepository
        {
            get
            {
                if (this._HospitalMasterRepository == null)
                    this._HospitalMasterRepository = new GenericRepository<HospitalMaster>(_context);
                return _HospitalMasterRepository;
            }
        }
        public GenericRepository<Counter> CounterRepository
        {
            get
            {
                if (this._CounterRepository == null)
                    this._CounterRepository = new GenericRepository<Counter>(_context);
                return _CounterRepository;
            }
        }
        public GenericRepository<HospitalTransaction> HospitalTransactionRepository
        {
            get
            {
                if (this._HospitalTransactionRepository == null)
                    this._HospitalTransactionRepository = new GenericRepository<HospitalTransaction>(_context);
                return _HospitalTransactionRepository;
            }
        }
        public GenericRepository<PaymentDetail> PaymentDetailRepository
        {
            get
            {
                if (this._PaymentDetailRepository == null)
                    this._PaymentDetailRepository = new GenericRepository<PaymentDetail>(_context);
                return _PaymentDetailRepository;
            }
        }
        public GenericRepository<UserMaster> UserMasterRepository
        {
            get
            {
                if (this._UserMasterRepository == null)
                    this._UserMasterRepository = new GenericRepository<UserMaster>(_context);
                return _UserMasterRepository;
            }
        }
        #endregion
        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);
                throw e;
            }
        }
        #endregion
        #region Implementing IDiosposable...
        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion
        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
/**
 * Copyright (C) 2017 Kamarudin (http://coding4ever.net/)
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not
 * use this file except in compliance with the License. You may obtain a copy of
 * the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations under
 * the License.
 *
 * The latest version of this file can be found at https://github.com/rudi-krsoftware/open-retail
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;
using OpenRetail.Model;
using OpenRetail.Bll.Api;
using OpenRetail.Repository.Api;
using OpenRetail.Repository.Service;
 
namespace OpenRetail.Bll.Service
{    
    public class PembayaranHutangProdukBll : IPembayaranHutangProdukBll
    {
        private ILog _log;
        private IUnitOfWork _unitOfWork;
		private PembayaranHutangProdukValidator _validator;

		public PembayaranHutangProdukBll(ILog log)
        {
            _log = log;
            _validator = new PembayaranHutangProdukValidator();
        }

        public PembayaranHutangProduk GetByID(string id)
        {
            PembayaranHutangProduk obj = null;
            
            using (IDapperContext context = new DapperContext())
            {
                _unitOfWork = new UnitOfWork(context, _log);
                obj = _unitOfWork.PembayaranHutangProdukRepository.GetByID(id);
            }

            return obj;
        }

        public IList<PembayaranHutangProduk> GetByName(string name)
        {
            IList<PembayaranHutangProduk> oList = null;

            using (IDapperContext context = new DapperContext())
            {
                _unitOfWork = new UnitOfWork(context, _log);
                oList = _unitOfWork.PembayaranHutangProdukRepository.GetByName(name);
            }

            return oList;
        }

        public IList<PembayaranHutangProduk> GetAll()
        {
            IList<PembayaranHutangProduk> oList = null;

            using (IDapperContext context = new DapperContext())
            {
                _unitOfWork = new UnitOfWork(context, _log);
                oList = _unitOfWork.PembayaranHutangProdukRepository.GetAll();
            }

            return oList;
        }

        public IList<ItemPembayaranHutangProduk> GetHistoriPembayaran(string beliId)
        {
            IList<ItemPembayaranHutangProduk> oList = null;

            using (IDapperContext context = new DapperContext())
            {
                _unitOfWork = new UnitOfWork(context, _log);
                oList = _unitOfWork.PembayaranHutangProdukRepository.GetHistoriPembayaran(beliId);
            }

            return oList;
        }

		public int Save(PembayaranHutangProduk obj)
        {
            throw new NotImplementedException();
        }

        public int Save(PembayaranHutangProduk obj, bool isSaveFromPembelian, ref ValidationError validationError)
        {
			var validatorResults = _validator.Validate(obj);

            if (!validatorResults.IsValid)
            {
                foreach (var failure in validatorResults.Errors)
                {
                    validationError.Message = failure.ErrorMessage;
                    validationError.PropertyName = failure.PropertyName;
                    return 0;
                }
            }

            var result = 0;

            using (IDapperContext context = new DapperContext())
            {
                _unitOfWork = new UnitOfWork(context, _log);
                result = _unitOfWork.PembayaranHutangProdukRepository.Save(obj, isSaveFromPembelian);
            }

            return result;
        }

		public int Update(PembayaranHutangProduk obj)
        {
            throw new NotImplementedException();
        }

        public int Update(PembayaranHutangProduk obj, bool isUpdateFromPembelian, ref ValidationError validationError)
        {
            var validatorResults = _validator.Validate(obj);

            if (!validatorResults.IsValid)
            {
                foreach (var failure in validatorResults.Errors)
                {
                    validationError.Message = failure.ErrorMessage;
                    validationError.PropertyName = failure.PropertyName;
                    return 0;
                }
            }

            var result = 0;

            using (IDapperContext context = new DapperContext())
            {
                _unitOfWork = new UnitOfWork(context, _log);
                result = _unitOfWork.PembayaranHutangProdukRepository.Update(obj, isUpdateFromPembelian);
            }

            return result;
        }

        public int Delete(PembayaranHutangProduk obj)
        {
            var result = 0;

            using (IDapperContext context = new DapperContext())
            {
                _unitOfWork = new UnitOfWork(context, _log);
                result = _unitOfWork.PembayaranHutangProdukRepository.Delete(obj);
            }

            return result;
        }

        public string GetLastNota()
        {
            var lastNota = string.Empty;

            using (IDapperContext context = new DapperContext())
            {
                _unitOfWork = new UnitOfWork(context, _log);
                lastNota = _unitOfWork.PembayaranHutangProdukRepository.GetLastNota();
            }

            return lastNota;
        }

        public ItemPembayaranHutangProduk GetByBeliID(string id)
        {
            ItemPembayaranHutangProduk obj = null;

            using (IDapperContext context = new DapperContext())
            {
                _unitOfWork = new UnitOfWork(context, _log);
                obj = _unitOfWork.PembayaranHutangProdukRepository.GetByBeliID(id);
            }

            return obj;
        }

        public IList<PembayaranHutangProduk> GetByTanggal(DateTime tanggalMulai, DateTime tanggalSelesai)
        {
            IList<PembayaranHutangProduk> oList = null;

            using (IDapperContext context = new DapperContext())
            {
                _unitOfWork = new UnitOfWork(context, _log);
                oList = _unitOfWork.PembayaranHutangProdukRepository.GetByTanggal(tanggalMulai, tanggalSelesai);
            }

            return oList;
        }        
    }
}     

using AutoMapper;
using CSVApplication.Core.Interfaces;
using CSVApplication.Core.Models;
using CSVApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVApplication.Business.Services
{
    public class CSVBodyService : ICSVBody
    {
        private readonly IRepository<CSVBodyEntity> _repository;
        private readonly IMapper _mapper;
        public CSVBodyService(IRepository<CSVBodyEntity> repository,
                              IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public CSVBodyModel Create(CSVBodyModel CSV)
        {
            CSV.CreationDate = DateTime.Now;
            CSV.LastUpdate = DateTime.Now;
            var item = _repository.Create(_mapper.Map<CSVBodyEntity>(CSV));
            return _mapper.Map<CSVBodyModel>(item);
        }

        public void Delete(int id)
        {
            var CSV = _repository.GetById(id);
            _repository.Delete(_mapper.Map<CSVBodyEntity>(CSV));
        }

        public List<CSVBodyModel> GetAll() => _mapper.Map<List<CSVBodyModel>>(_repository.GetAll());

        public ProcessedFileModel ProcessString(CSVBodyModel CSV)
        {
            ProcessedFileModel procesedFileModel = new ProcessedFileModel();
            if (CSV.FileAsBase64 != null && !CSV.FileAsBase64.Equals(""))
            {
                Byte[] bytes = Convert.FromBase64String(CSV.FileAsBase64);
                procesedFileModel.fullContent = Encoding.Default.GetString(bytes);
                procesedFileModel.SetSplittedText(CSV.Delimiter);
            }
            return procesedFileModel;
        }


        public CSVBodyModel Update(CSVBodyModel CSV)
        {
            var item = _repository.Update(_mapper.Map<CSVBodyEntity>(CSV));
            return _mapper.Map<CSVBodyModel>(item);
        }
    }
}

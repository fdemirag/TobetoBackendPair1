﻿using AutoMapper;
using Business.Abstract;
using Business.Dtos.Responses;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SynchronLessonDetailManager : ISynchronLessonDetailService
    {
        ISynchronLessonDetailDal _synchronLessonDetailDal;
        IMapper _mapper;

        public SynchronLessonDetailManager(ISynchronLessonDetailDal synchronLessonDetailDal, IMapper mapper)
        {
            _synchronLessonDetailDal = synchronLessonDetailDal;
            _mapper = mapper;
        }

        public async Task<CreatedSynchronLessonDetailResponse> Add(CreateSynchronLessonDetailRequest createSynchronLessonDetailRequest)
        {
            SynchronLessonDetail synchronLessonDetail = _mapper.Map<SynchronLessonDetail>(createSynchronLessonDetailRequest);
            SynchronLessonDetail createdSynchronLessonDetail = await _synchronLessonDetailDal.AddAsync(synchronLessonDetail);
            CreatedSynchronLessonDetailResponse createdSynchronLessonDetailResponse = _mapper.Map<CreatedSynchronLessonDetailResponse>(createdSynchronLessonDetail);
            return createdSynchronLessonDetailResponse;
        }

        public async Task<DeletedSynchronLessonDetailResponse> Delete(DeleteSynchronLessonDetailRequest deleteSynchronLessonDetailRequest)
        {
            SynchronLessonDetail synchronLessonDetail = _mapper.Map<SynchronLessonDetail>(deleteSynchronLessonDetailRequest);
            SynchronLessonDetail deletedSynchronLessonDetail = await _synchronLessonDetailDal.DeleteAsync(synchronLessonDetail);
            DeletedSynchronLessonDetailResponse deletedSynchronLessonDetailResponse = _mapper.Map<DeletedSynchronLessonDetailResponse>(deletedSynchronLessonDetail);
            return deletedSynchronLessonDetailResponse;
        }

        public async Task<IPaginate<GetListSynchronLessonDetailResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _synchronLessonDetailDal.GetListAsync(include: s => s.Include(s => s.Category).
       Include(s => s.Course).Include(s=>s.SubType).Include(s=>s.LessonLanguage),
          index: pageRequest.PageIndex,
          size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListSynchronLessonDetailResponse>>(data);
            return result;
        }

        public async Task<UpdatedSynchronLessonDetailResponse> Update(UpdateSynchronLessonDetailRequest updateSynchronLessonDetailRequest)
        {
            SynchronLessonDetail synchronLessonDetail = _mapper.Map<SynchronLessonDetail>(updateSynchronLessonDetailRequest);
            SynchronLessonDetail updatedSynchronLessonDetail = await _synchronLessonDetailDal.UpdateAsync(synchronLessonDetail);
            UpdatedSynchronLessonDetailResponse updatedSynchronLessonDetailResponse = _mapper.Map<UpdatedSynchronLessonDetailResponse>(updatedSynchronLessonDetail);
            return updatedSynchronLessonDetailResponse;
        }
    }
}

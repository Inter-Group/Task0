using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contract.Repository_Contract;
using Core.Contract.Services_Contract;
using Core.DTO.DonHang;
using Core.Mapper;
using Core.Models;

namespace Core.Services
{
    public class DonHangServices:IDonHangServices
    {
        private readonly IDonHangRepository _donhangRepository;

        public DonHangServices(IDonHangRepository donhangRepository)
        {
            _donhangRepository = donhangRepository;
        }
        //public async DonHang<DonHangDTO> CreateTaskAsync(DonHangDTO donhangDto)
        //{
        //    var donhang = donhangDto.DonHangFromDTO();
        //    //if (donhang.Start.TimeOfDay < new TimeSpan(7, 0, 0) || task.End.TimeOfDay > new TimeSpan(17, 0, 0) || task.End.TimeOfDay <= task.Start.TimeOfDay)
        //    //{
        //    //    throw new ArgumentException("Thời gian làm việc phải từ 7h sáng đến 5h chiều");
        //    //}
        //    var createdTask = await _donhangRepository.CreatAsycn(donhang);
        //    return createdTask.toDonHangDTO();
        //}



        //public async Task<IEnumerable<DonHangDTO>> GetAllTasksAsync()
        //{
        //    var tasks = await _donhangRepository.GetAllAsync();
        //    return tasks.Select(task => task.toDonHangDTO());
        //}

        //public async Task<DonHangDTO?> GetTaskByIdAsync(int id)
        //{
        //    var task = await _donhangRepository.GetByIdAsync(id);
        //    return task?.toDonHangDTO();
        //}

        public async Task<DonHangDTO?> UpdateTaskAsync(DonHangDTO taskDto)
        {
            var task = taskDto.DonHangFromDTO();

            var updatedTask = await _donhangRepository.UpdateAsycn(task);
            return updatedTask?.toDonHangDTO();
        }

        //public async Task<DonHangDTO?> UpdateTaskAsync(DonHangDTO taskDto)
        //{
        //    var donhang = taskDto.DonHangFromDTO();
        //    var updatedTask = await _donhangRepository.UpdateAsync(donhang);
        //    return updatedTask?.toDonHangDTO();
        //}

        public async Task<DonHangDTO> CreateTaskAsync(DonHangDTO taskDto)
        {
            var task = taskDto.DonHangFromDTO();

            var createdTask = await _donhangRepository.AddAsync(task);
            return createdTask.toDonHangDTO();
        }

        public async Task<IEnumerable<DonHangDTO>> GetAllTasksAsync()
        {
            var tasks = await _donhangRepository.GetAllAsync();
            return tasks.Select(task => task.toDonHangDTO());
        }

        public async Task<DonHangDTO?> GetTaskByIdAsync(int id)
        {
            var task = await _donhangRepository.GetByIdAsync(id);
            return task?.toDonHangDTO();
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            return await _donhangRepository.DeleteAsycn(id);
        }
    }
}

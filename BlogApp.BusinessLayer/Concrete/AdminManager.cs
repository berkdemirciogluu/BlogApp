using BlogApp.BusinessLayer.Abstract;
using BlogApp.BusinessLayer.Utilities.Messages;
using BlogApp.CoreLayer.Utilities.Results;
using BlogApp.DataAccessLayer.Abstract;
using BlogApp.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace BlogApp.BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminRepository _adminRepository;
        public AdminManager(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public void Add(Admin admin)
        {

            _adminRepository.Add(admin);
        }

        public void Delete(int id)
        {
            _adminRepository.Delete(id);
        }

        public List<Admin> GetAll()
        {
            return _adminRepository.GetAll();
        }

        public Admin GetById(int id)
        {
            return _adminRepository.GetById(id);
        }

        public void Update(Admin admin)
        {
            _adminRepository.Update(admin);
        }
    }
}

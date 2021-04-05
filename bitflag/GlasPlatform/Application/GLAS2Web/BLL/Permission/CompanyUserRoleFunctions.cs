using DAL;
using DTO.Permission;
using DTO.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BLL.Permission
{
    public class CompanyUserRoleFunctions
    {
        private readonly GLAS2Context context;
        private readonly Company.CompanyFunctions companyFunctions;
        private readonly Company.CompanyUserFunctions companyUserFunctions;

        public CompanyUserRoleFunctions(GLAS2Context context)
        {
            this.context = context;
            this.companyFunctions = new Company.CompanyFunctions(context);
            this.companyUserFunctions = new Company.CompanyUserFunctions(context);
        }

        public bool CompanyUserHasRole(int companyId, int userId, IEnumerable<string> roles)
        {
            return (from cur in this.context.CompanyUserRole
                    join r in this.context.Role on cur.RoleId equals r.Id
                    join rs in roles on r.NormalizedName equals rs.ToUpper()
                    where cur.UserId == userId && cur.CompanyId == companyId
                    select new { cur.CompanyUserRoleId }).Any();
        }

        public bool UserHasCompanyRole(int userId, IEnumerable<string> roles)
        {
            return (from cur in this.context.CompanyUserRole
                    join r in this.context.Role on cur.RoleId equals r.Id
                    join rs in roles on r.NormalizedName equals rs.ToUpper()
                    where cur.UserId == userId
                    select new { cur.CompanyUserRoleId }).Any();
        }


        public List<DTO.Company.CompanyViewModel> UserCompanies(int userId)
        {
            var q = (from cur in this.context.CompanyUserRole
                     join c in this.context.Company on cur.CompanyId equals c.CompanyId
                     where c.IsActive == true && c.IsDeleted == false && cur.UserId == userId
                     orderby c.NomeFantasia
                     select c).Distinct();

            return this.companyFunctions.GetDataViewModel(q);
        }

        public List<DTO.Company.CompanyUser> UsersInCompany(int companyId)
        {
            var q = (from cur in this.context.CompanyUserRole
                     join u in this.context.User on cur.UserId equals u.Id
                     join r in this.context.Role on cur.RoleId equals r.Id
                     where cur.CompanyId.Equals(companyId) && u.IsDeleted == false
                     group new { r } by new { cur, u } into g
                     select new DTO.Company.CompanyUser()
                     {
                         CompanyId = g.Key.cur.CompanyId,
                         CompanyUserRoleId = g.Key.cur.CompanyUserRoleId,
                         UserId = g.Key.u.Id,
                         FirstName = g.Key.u.FirstName,
                         LastName = g.Key.u.LastName,
                         Email = g.Key.u.Email,
                         CompanyRoleDescription = string.Join(", ", g.Select(x => x.r.Description)),
                     }).ToList();

            foreach (var item in q)
            {
                item.UserRole = GetUserRole(item.UserId).Name;
                item.UserRoleDescription = GetUserRole(item.UserId).Description;
            }

            return q;
        }

        public List<DTO.Company.CompanyUser> UsersInCompanyByRole(int companyId, IEnumerable<string> roles)
        {
            var q = (from cur in this.context.CompanyUserRole
                     join u in this.context.User on cur.UserId equals u.Id
                     join r in this.context.Role on cur.RoleId equals r.Id
                     join rs in roles.DefaultIfEmpty() on r.NormalizedName equals rs.ToUpper()
                     where cur.CompanyId.Equals(companyId) && u.IsDeleted == false
                     group new { r, rs } by new { cur, u } into g
                     select new DTO.Company.CompanyUser()
                     {
                         CompanyId = g.Key.cur.CompanyId,
                         CompanyUserRoleId = g.Key.cur.CompanyUserRoleId,
                         UserId = g.Key.u.Id,
                         FirstName = g.Key.u.FirstName,
                         LastName = g.Key.u.LastName,
                         Email = g.Key.u.Email,
                         CompanyRoleDescription = string.Join(", ", g.Select(x => x.r.Description)),
                     }).ToList();

            foreach (var item in q)
            {
                item.UserRole = GetUserRole(item.UserId).Name;
                item.UserRoleDescription = GetUserRole(item.UserId).Description;
            }

            return q;
        }

        public DAL.Identity.Role GetUserRole(int userId)
        {
            var q = (from anur in this.context.AspNetUserRoles
                     join r in this.context.Role on anur.RoleId equals r.Id
                     where anur.UserId == userId
                     select r).FirstOrDefault();

            if (q != null)
                return q;
            else
                return new DAL.Identity.Role();
        }

        public List<int> UserCompaniesIdByRole(int userId, IEnumerable<string> roles)
        {
            var q = (from cur in this.context.CompanyUserRole
                     join c in this.context.Company on cur.CompanyId equals c.CompanyId
                     join r in this.context.Role on cur.RoleId equals r.Id
                     join rs in roles.DefaultIfEmpty() on r.NormalizedName equals rs.ToUpper()
                     where c.IsActive == true && c.IsDeleted == false && cur.UserId == userId
                     select c.CompanyId).Distinct();

            return q.ToList();
        }

        public bool UserCompanyHasRole(int userId, int companyId, string role)
        {
            var r = this.context.Role.Single(x => x.NormalizedName.Equals(role.ToUpper()));
            return this.context.CompanyUserRole.Any(x => x.UserId.Equals(userId) && x.CompanyId.Equals(companyId) && x.RoleId.Equals(r.Id));
        }

        public string GetCompanyRoleByCompanyUser(int companyId, int userId)
        {
            var cur = this.context.CompanyUserRole.SingleOrDefault(x => x.UserId.Equals(userId) && x.CompanyId.Equals(companyId));
            return cur == null ? string.Empty : this.context.Role.Single(x => x.Id.Equals(cur.RoleId)).Name;
        }

        public string GetCompanyRoleDescriptionByCompanyUser(int companyId, int userId)
        {
            var cur = this.context.CompanyUserRole.SingleOrDefault(x => x.UserId.Equals(userId) && x.CompanyId.Equals(companyId));
            return cur == null ? string.Empty : this.context.Role.Single(x => x.Id.Equals(cur.RoleId)).Description;
        }

        public List<int> UsersIdInCompaniesByRole(IEnumerable<int> companiesId, IEnumerable<string> roles)
        {
            var q = (from cur in this.context.CompanyUserRole
                     join u in this.context.User on cur.UserId equals u.Id
                     join c in this.context.Company on cur.CompanyId equals c.CompanyId
                     join cs in companiesId.DefaultIfEmpty() on cur.CompanyId equals cs
                     join r in this.context.Role on cur.RoleId equals r.Id
                     join rs in roles.DefaultIfEmpty() on r.NormalizedName equals rs.ToUpper()
                     where c.IsDeleted == false && u.IsDeleted == false
                     select u.Id).Distinct();

            return q.ToList();
        }

        public int AddCompanyUserRole(int companyId, int userId, string role)
        {
            var r = this.context.Role.Single(x => x.NormalizedName.Equals(role.ToUpper()));
            var companyUserRole = new DAL.CompanyUserRole()
            {
                CompanyId = companyId,
                UserId = userId,
                RoleId = r.Id
            };

            this.context.CompanyUserRole.Add(companyUserRole);
            this.context.SaveChanges();

            return companyUserRole.CompanyUserRoleId;
        }

        public void ClearUserRoles(int userId)
        {
            var userRoles = this.context.AspNetUserRoles.Where(x => x.UserId.Equals(userId)).ToArray();
            for (int i = userRoles.Length - 1; i == 0; i--)
            {
                this.context.AspNetUserRoles.Remove(userRoles[i]);
            }
            this.context.SaveChanges();
        }

        public void AddUserToRole(int userId, string role)
        {
            var r = this.context.Role.Single(x => x.NormalizedName.Equals(role.ToUpper()));
            var anur = new DAL.Identity.AspNetUserRoles()
            {
                RoleId = r.Id,
                UserId = userId
            };

            this.context.Add(anur);
            this.context.SaveChanges();
        }

        public void Delete(int companyUserRoleId)
        {
            this.context.CompanyUserRole.Remove(this.context.CompanyUserRole.Single(x => x.CompanyUserRoleId.Equals(companyUserRoleId)));
            this.context.SaveChanges();
        }
        public void DeleteByCompanyId(int companyId)
        {
            this.context.CompanyUserRole.RemoveRange(this.context.CompanyUserRole.Where(x => x.CompanyId == companyId));
            this.context.SaveChanges();
        }

        public void DeleteAllCompanyUserRoleByUser(int userId)
        {
            var companyUsers = this.context.CompanyUserRole.Where(x => x.UserId.Equals(userId));
            foreach(var companyUser in companyUsers)
            {
                this.context.CompanyUserRole.Remove(companyUser);
            }
            
            this.context.SaveChanges();
        }

        public int GetUserId(int companyUserRoleId)
        {
            return this.context.CompanyUserRole.Single(x => x.CompanyUserRoleId == companyUserRoleId).UserId;
        }

        public int GetCompanyId(int companyUserRoleId)
        {
            return this.context.CompanyUserRole.Single(x => x.CompanyUserRoleId == companyUserRoleId).CompanyId;
        }

        public bool UserIsInCompany(int companyId, int userId)
        {
            return this.context.CompanyUserRole.Any(x => x.CompanyId.Equals(companyId) && x.UserId.Equals(userId));
        }

    }
}

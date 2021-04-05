using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using FUNCTIONS;
using FUNCTIONS.Utils;
using Microsoft.AspNetCore.Identity;


namespace FUNCTIONS.User
{
    public class UserFunctions : FUNCTIONS.BasicIdentityFunctions<TerraNostraIdentityDbContext.User, DTO.User.UserViewModel>
    {
        UserManager<TerraNostraIdentityDbContext.User> userManager;
        private readonly Role.RoleFunctions roleFunctions;
        private DB.TerraNostraContext terraNostaContext;
        private FUNCTIONS.Client.ClientFunctions clientFunctions;

        public UserFunctions(TerraNostraIdentityDbContext.ApplicationDbContext context, DB.TerraNostraContext terraNostaContext, UserManager<TerraNostraIdentityDbContext.User> userManager)
            : base(context, "Id")
        {
            this.userManager = userManager;
            this.roleFunctions = new Role.RoleFunctions(context);
            this.terraNostaContext = terraNostaContext;
        }


        public override int CreateOrUpdate(DTO.User.UserViewModel model, string entityIdPropertyName = "UserId")
        {
            return base.CreateOrUpdate(model, entityIdPropertyName);
        }

        protected override void SetDbSet()
        {
            this.dbSet = ((TerraNostraIdentityDbContext.ApplicationDbContext)context).Users;
        }

        public override int Create(DTO.User.UserViewModel model)
        {
            return _Create(model);
        }

        public int _Create(DTO.User.UserViewModel model)
        {
            var user = new TerraNostraIdentityDbContext.User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                MobileNumber = model.MobileNumber,
                IsActive = model.IsActive,
                LastHandler = model.LastHandler,
                CreatedDate = DateTime.Now,
                CPF = model.Cpf,
                LastSaleDate = DateTime.Now,



            };

            var identityResult = this.userManager.CreateAsync(user, model.Password);
            if (identityResult.Result.Succeeded)
            {
                return user.Id;
            }
            else
            {
                return 0;
                //throw new Exception(string.Join(';', identityResult.Errors.Select(x => x.Code)));
            }
        }

        public override void Update(DTO.User.UserViewModel model)
        {
            var user = this.GetDataByID(model.UserId);
            var clientRole = this.context.Roles.Single(x => x.NormalizedName == "CLIENT");
            var isClient = this.context.UserRoles.Any(x => x.UserId == user.Id && x.RoleId == clientRole.Id);

            if (!string.IsNullOrWhiteSpace(model.Password))
                user.PasswordHash = this.userManager.PasswordHasher.HashPassword(user, model.Password);

            this.userManager.UpdateAsync(user).Wait();

            if (!isClient)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.MobileNumber = model.MobileNumber;
                user.PhoneNumber = model.PhoneNumber;
                user.Email = model.Email;
                user.UserName = model.Email;
                user.LastHandler = model.LastHandler;
                user.SalesmanAvailable = model.SalesmanAvailable;
                user.LastSaleDate = model.LastSaleDate;
            }

            user.CPF = model.Cpf;

            user.IsActive = model.IsActive;
            this.context.Update(user);

            this.context.SaveChanges();
        }

        public void UpdateBasicData(DTO.User.UserViewModel model)
        {
            var user = this.GetDataByID(model.UserId);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Email;
            user.UserName = model.Email;
            user.LastSaleDate = model.LastSaleDate;

            this.context.Update(user);
            this.context.SaveChanges();
        }

        public override void Delete(object id)
        {
            var user = this.GetDataByID(id);

            user.IsDeleted = true;
            user.UserName = null;
            user.NormalizedUserName = null;
            user.NormalizedEmail = null;
            user.DeletedDate = DateTime.Now;


            this.context.Update(user);
            this.context.SaveChanges();
        }

        public void Delete(object id, int lastHandler)
        {
            var user = this.GetDataByID(id);

            user.IsDeleted = true;
            user.UserName = null;
            user.NormalizedUserName = null;
            user.NormalizedEmail = null;
            user.DeletedDate = DateTime.Now;

            this.context.Update(user);
            this.context.SaveChanges();
        }

        public override List<DTO.User.UserViewModel> GetDataViewModel(IEnumerable<TerraNostraIdentityDbContext.User> data)
        {
            var q = (from y in data.ToList()
                     join ur in context.UserRoles on y.Id equals ur.UserId
                     join ro in context.Roles on ur.RoleId equals ro.Id
                     select new DTO.User.UserViewModel()
                     {
                         UserId = y.Id,
                         FirstName = y.FirstName,
                         LastName = y.LastName,
                         Email = y.Email,
                         PhoneNumber = y.PhoneNumber,
                         MobileNumber = y.MobileNumber,
                         IsActive = y.IsActive,
                         Role = ro.Description,
                         RoleNormalizedName = ro.NormalizedName,
                         LastHandler = y.LastHandler,
                         Cpf = y.CPF,
                         CreatedDate = y.CreatedDate,
                         DeletedDate = y.DeletedDate,
                         SalesmanAvailable = y.SalesmanAvailable,
                         LastSaleDate = y.LastSaleDate,



                     }).ToList();

            return q;
        }

        public override DTO.User.UserViewModel GetDataViewModel(TerraNostraIdentityDbContext.User data)
        {
            var role = GetRolesByUserId(data.Id);

            return new DTO.User.UserViewModel()
            {
                UserId = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber,
                MobileNumber = data.MobileNumber,
                IsActive = data.IsActive,
                Role = role?.Description,
                RoleNormalizedName = role?.NormalizedName,
                LastHandler = data.LastHandler,
                Cpf = data.CPF,
                CreatedDate = data.CreatedDate,
                DeletedDate = data.DeletedDate,
                SalesmanAvailable = data.SalesmanAvailable,
                LastSaleDate = data.LastSaleDate,


            };
        }

        public void ClearUserRoles(int userId)
        {
            var userRoles = this.context.UserRoles.Where(x => x.UserId.Equals(userId)).ToArray();
            this.context.UserRoles.RemoveRange(userRoles);

            this.context.SaveChanges();
        }

        public void AddUserToRole(int userId, string role)
        {
            var r = this.context.Roles.Single(x => x.NormalizedName.Equals(role.ToUpper()));

            var anur = new IdentityUserRole<int>()
            {
                RoleId = r.Id,
                UserId = userId
            };

            this.context.Add(anur);
            this.context.SaveChanges();
        }

        public void CompararUser(DTO.Client.ClientViewModel model, string oldEmail, int? oldResponsible, int? oldStatusId)
        {

            FUNCTIONS.AuditLog.DBActionType dbActionType;
            if (model.ClientId.HasValue)
            {
                dbActionType = FUNCTIONS.AuditLog.DBActionType.UPDATE;
                var oldModel = clientFunctions.GetDataByID(model.ClientId);
                oldEmail = oldModel.Email;
                oldResponsible = oldModel.ResponsibleId;
                oldStatusId = oldModel.ClientStatusId;
            }
        }

        public void AddUserToRoles(int userId, List<string> roles)
        {
            foreach (var role in roles)
            {
                var r = this.context.Roles.Single(x => x.NormalizedName.Equals(role.ToUpper()));
                var anur = new DB.AspNetUserRoles()
                {
                    RoleId = r.Id,
                    UserId = userId
                };

                this.context.Add(anur);
            }
            this.context.SaveChanges();
        }

        public TerraNostraIdentityDbContext.Role GetRolesByUserId(int id)
        {
            return (from y in dbSet
                    join ur in context.UserRoles on y.Id equals ur.UserId
                    join ro in context.Roles on ur.RoleId equals ro.Id
                    where y.Id == id
                    select ro).SingleOrDefault();
        }
        public List<TerraNostraIdentityDbContext.User> GetDataByRole(params string[] normalizedName)
        {
            return (from y in dbSet
                    join ur in context.UserRoles on y.Id equals ur.UserId
                    join ro in context.Roles on ur.RoleId equals ro.Id
                    where normalizedName.Contains(ro.NormalizedName) && !y.IsDeleted
                    select y).ToList();
        }

        public string GeneratePasswordRecoveryReference(int userId)
        {
            var user = GetDataByID(userId);

            int maxTries = 10;
            for (int i = 0; i <= maxTries; i++)
            {
                if (i == maxTries) throw new Exception("Reference max tries reached.");
                var reference = Utils.ReferenceUtils.GetReference();
                if (!ReferenceExiste(reference))
                {
                    user.PasswordRecoveryReference = reference;
                    break;
                }
            }

            this.dbSet.Update(user);
            this.context.SaveChanges();

            return user.PasswordRecoveryReference;
        }

        public bool ReferenceExiste(string reference)
        {
            return this.dbSet.Any(x => x.PasswordRecoveryReference == reference);
        }

        public TerraNostraIdentityDbContext.User GetDataByReference(string reference)
        {
            return this.dbSet.SingleOrDefault(x => x.PasswordRecoveryReference == reference);
        }

        public void ClearReference(int userId)
        {
            var data = GetDataByID(userId);

            data.PasswordRecoveryReference = null;

            this.dbSet.Update(data);
            this.context.SaveChanges();
        }

        public int? GetUserIdByEmail(string email)
        {
            var user = this.context.Users.SingleOrDefault(x => x.Email == email && !x.IsDeleted);
            if (user != null) return user.Id;

            return null;
        }

        public bool ExistEmail(string email, int? userId = null)
        {
            return this.context.Users.Any(x => x.Email == email && !x.IsDeleted && userId != x.Id);
        }

        public async Task<DTO.User.UserViewModel> CreateFromClient(int clientId)
        {
            var client = this.terraNostaContext.Client.Single(c => c.ClientId == clientId);

            //StringUtils.GetName(client.Contact, out string firstName, out string lastName);

            var user = new TerraNostraIdentityDbContext.User()
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                UserName = client.Email,
                NormalizedEmail = client.Email.ToUpper(),
                NormalizedUserName = client.Email.ToUpper(),
                Email = client.Email,
                PhoneNumber = client.Telefone,
                IsActive = client.IsActive,
                LastHandler = client.LastHandler,
                CPF = client.Cpf,
                CreatedDate = DateTime.Now,
                LastSaleDate = DateTime.Now
            };

            var password = Utils.ReferenceUtils.GetReference();

            var identityResult = await this.userManager.CreateAsync(user, password);
            if (identityResult.Succeeded)
            {
                var userViewModel = GetDataViewModel(user);
                userViewModel.Password = password;
                return userViewModel;
            }
            else
            {
                return null;
            }
        }

        public bool IsInRole(int userId, string roleExternalCode)
        {
            var role = roleFunctions.GetData(x => x.NormalizedName == roleExternalCode).FirstOrDefault();

            if (role == null) return false;
            return this.context.UserRoles.Any(x => x.UserId == userId && x.RoleId == role.Id);
        }

        public string GetFullName(int userId)
        {
            var user = this.dbSet.SingleOrDefault(x => x.Id == userId);
            if (user == null) return string.Empty;

            return string.Format("{0} {1}", user.FirstName, user.LastName);
        }

        public bool SetSalesmanAvailable(int userId, bool salesmanAvailable)
        {
            try
            {
                var user = this.terraNostaContext.User.SingleOrDefault(x => x.UserId == userId);
                if (user == null) return false;

                user.SalesmanAvailable = salesmanAvailable;
                this.terraNostaContext.SaveChanges();

                return true;

            }
            catch { return false; }
        }
        public bool GetSalesmanAvailable(int userId)
        {
            try
            {
                var user = this.terraNostaContext.User.SingleOrDefault(x => x.UserId == userId);
                if (user == null) return false;

                return user.SalesmanAvailable;
            }
            catch { return false; }
        }

        public int? GetNextSalesman()
        {
            var client = this.terraNostaContext.Client.Where(x => !x.IsDeleted && x.ResponsibleId.HasValue && x.ResponsibleId != x.CreatorUserId).OrderByDescending(x => x.ClientId).First();

            if (client == null) return null;

            var salesmen = this.terraNostaContext.User.Where(x => x.SalesmanAvailable && !x.IsDeleted).OrderBy(x => x.LastSaleDate).ToList();

            if (salesmen.Count == 0)
            {
                return null;
            }
            else
            {
                foreach (var salesman in salesmen)
                    if (client.ResponsibleId != salesman.UserId)
                        return salesman.UserId;

                return null;
            }

        }

        public void UpdateLastSaleDate(int? clientId, int? userId)
        {
            if (!userId.HasValue) return;

            var user = this.context.Users.SingleOrDefault(x => x.Id == userId);
            if (user == null) return;

            if (!clientId.HasValue)
            {
                user.LastSaleDate = DateTime.Now;
                this.context.SaveChanges();
                return;
            }
            else
            {
                var client = this.terraNostaContext.Client.SingleOrDefault(x => x.ClientId == clientId);
                if (client == null) return;
                if (client.ResponsibleId.HasValue && client.ResponsibleId.Value != userId)
                {
                    user.LastSaleDate = DateTime.Now;
                    this.context.SaveChanges();
                }
            }
        }
    }
}

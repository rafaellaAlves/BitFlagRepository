using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AMaisImob_WEB.Utils;
using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using Newtonsoft.Json;
using BLL;

namespace AMaisImob_WEB.BLL
{
    public class AuditLogFunctions : BLLBasicFunctions<AuditLog, AuditLog>
    {
        public AuditLogFunctions(AMaisImob_HomologContext context)
            : base(context, "AuditLogId")
        {
        }

        public override int Create(AuditLog model)
        {
            this.dbSet.Add(model);
            context.SaveChanges();

            return model.AuditLogId;
        }

        public void Log(string entityName, int entityId, string entityKey, DBActionType actionType, object entity, int ownerId, string observation = "")
        {
            var auditLog = new AuditLog()
            {
                Observation = observation,
                ActionType = actionType.ToString(),
                OwnerId = ownerId,
                CreatedDate = DateTime.Now,
                EntityName = entityName,
                EntityId = entityId,
                EntityKey = entityKey,
                Entity = JsonConvert.SerializeObject(entity)
            };
            Create(auditLog);
        }

        public T GetAuditLogEntity<T>(int auditLogId) where T : class
        {
            if (!this.Exists(auditLogId)) return null;
            var o = this.GetDataByID(auditLogId);

            return JsonConvert.DeserializeObject<T>(o.Entity);
        }

        public List<AuditLogItemViewModel> GetAuditLogEntityChanges<T>() where T : class
        {
            var auditLogItens = new List<AuditLogItemViewModel>();
            var l = this.GetData(x => x.EntityName.Equals(typeof(T).Name));

            T oldAuditLogEntity = null;
            int oldEntityId = l.First().EntityId;

            foreach (var item in l)
            {
                if (oldEntityId != item.EntityId)
                    oldAuditLogEntity = null;

                var auditLogItemViewModel = new AuditLogItemViewModel
                {
                    ActionType = item.ActionType,
                    Date = item.CreatedDate,
                    EntityId = item.EntityId,
                    LastHandler = item.OwnerId,
                    Observation = item.Observation,
                    AuditChangeItens = new List<AuditChangeItemViewModel>()
                };

                T auditLogEntity;
                auditLogEntity = JsonConvert.DeserializeObject<T>(item.Entity, new JsonSerializerSettings()
                {
                    Error = (sender, args) => { auditLogEntity = null; args.ErrorContext.Handled = true; },
                    MissingMemberHandling = MissingMemberHandling.Error
                });
                if (auditLogEntity == null) continue;

                foreach (var p in typeof(T).GetProperties())
                {
                    var propName = p.GetDisplayName();
                    if (string.IsNullOrWhiteSpace(propName)) continue;

                    object oldValue = null;
                    var currentValue = typeof(T).GetProperty(p.Name).GetValue(auditLogEntity);

                    if (oldAuditLogEntity != null)
                        oldValue = typeof(T).GetProperty(p.Name).GetValue(oldAuditLogEntity);

                    var propertyType = typeof(T).GetProperty(p.Name).PropertyType;
                    if (propertyType == typeof(bool?) || propertyType == typeof(bool))
                    {
                        if (currentValue != null) currentValue = (bool)currentValue == true ? "Sim" : "Não";
                        if (oldValue != null) oldValue = (bool)oldValue == true ? "Sim" : "Não";
                    }

                    if ((currentValue == null && oldValue == null) || (currentValue != null && currentValue.Equals(oldValue))) continue;

                    var maskClass = p.GetDisplayDescription();

                    if (maskClass == "money")
                    {
                        oldValue = oldValue != null ? Convert.ToDouble(oldValue).ToString("0.00") : oldValue;
                        currentValue = currentValue != null ? Convert.ToDouble(currentValue).ToString("0.00") : currentValue;
                    }
                    auditLogItemViewModel.AuditChangeItens.Add(new AuditChangeItemViewModel
                    {
                        Propriety = p.Name,
                        MaskClass = !string.IsNullOrWhiteSpace(maskClass) ? maskClass : "",
                        OldValue = oldValue != null ? oldValue.ToString() : "",
                        Value = currentValue != null ? currentValue.ToString() : ""
                    });
                }

                oldAuditLogEntity = auditLogEntity;

                auditLogItens.Add(auditLogItemViewModel);
                oldEntityId = item.EntityId;
            }
            return auditLogItens;
        }

        public List<AuditLogItemViewModel> GetAuditLogEntityChangesByEntityId<T>(int entityId) where T : class
        {
            var users = this.context.User.ToList();
            var l = this.GetData(x => x.EntityName.Equals(typeof(T).Name) && x.EntityId.Equals(entityId));

            var auditLogItens = new List<AuditLogItemViewModel>();
            T oldAuditLogEntity = null;

            foreach (var item in l)
            {
                var auditLogItemViewModel = new AuditLogItemViewModel
                {
                    ActionType = item.ActionType,
                    Date = item.CreatedDate,
                    EntityId = item.EntityId,
                    LastHandler = item.OwnerId,
                    Observation = item.Observation,
                    AuditChangeItens = new List<AuditChangeItemViewModel>()
                };

                var user = users.SingleOrDefault(x => x.Id == auditLogItemViewModel.LastHandler && !x.IsDeleted);
                if (user != null)
                    auditLogItemViewModel.LastHandlerName = $"{user.FirstName} {user.LastName}";

                T auditLogEntity = JsonConvert.DeserializeObject<T>(item.Entity, new JsonSerializerSettings()
                {
                    Error = (sender, args) => { auditLogEntity = null; args.ErrorContext.Handled = true; },
                    MissingMemberHandling = MissingMemberHandling.Error
                });

                foreach (var p in typeof(T).GetProperties())
                {
                    var propName = p.GetDisplayName();
                    if (string.IsNullOrWhiteSpace(propName)) continue;

                    object oldValue = null;
                    var currentValue = typeof(T).GetProperty(p.Name).GetValue(auditLogEntity);

                    if (oldAuditLogEntity != null)
                        oldValue = typeof(T).GetProperty(p.Name).GetValue(oldAuditLogEntity);

                    if ((currentValue == null && oldValue == null) || (currentValue != null && currentValue.Equals(oldValue))) continue;

                    var propertyType = typeof(T).GetProperty(p.Name).PropertyType;
                    if (propertyType == typeof(bool?) || propertyType == typeof(bool))
                    {
                        if (currentValue != null) currentValue = (bool)currentValue == true ? "Sim" : "Não";
                        if (oldValue != null) oldValue = (bool)oldValue == true ? "Sim" : "Não";
                    }

                    var maskClass = p.GetDisplayDescription();
                    if (maskClass == "money")
                    {
                        oldValue = oldValue != null ? Convert.ToDouble(oldValue).ToString("0.00") : oldValue;
                        currentValue = currentValue != null ? Convert.ToDouble(currentValue).ToString("0.00") : currentValue;
                    }
                    auditLogItemViewModel.AuditChangeItens.Add(new AuditChangeItemViewModel
                    {
                        Propriety = propName,
                        MaskClass = !string.IsNullOrWhiteSpace(maskClass) ? maskClass : "",
                        OldValue = oldValue != null ? oldValue.ToString() : "",
                        Value = currentValue != null ? currentValue.ToString() : ""
                    });
                }
                oldAuditLogEntity = auditLogEntity;
                auditLogItens.Add(auditLogItemViewModel);
            }
            return auditLogItens;
        }

        public List<T> GetAuditLogEntities<T>() where T : class
        {
            var l = this.GetData(x => x.EntityName.Equals(typeof(T).Name));
            var r = new List<T>();
            foreach (var item in l)
            {
                r.Add(JsonConvert.DeserializeObject<T>(item.Entity, new JsonSerializerSettings()
                {
                    Error = (sender, args) => { r.Add(null); args.ErrorContext.Handled = true; },
                    MissingMemberHandling = MissingMemberHandling.Error
                }));
            }
            return r;
        }

        public List<T> GetAuditLogEntityByEntityId<T>(int entityId) where T : class
        {
            var l = this.GetData(x => x.EntityName.Equals(typeof(T).Name) && x.EntityId.Equals(entityId));
            var r = new List<T>();
            foreach (var item in l)
            {

                r.Add(JsonConvert.DeserializeObject<T>(item.Entity, new JsonSerializerSettings()
                {
                    Error = (sender, args) => { r.Add(null); args.ErrorContext.Handled = true; },
                    MissingMemberHandling = MissingMemberHandling.Error
                }));
            }
            return r;
        }

        public List<T> GetAuditLogEntityByEntityId<T>(int entityId, DBActionType dbActionType) where T : class
        {
            var l = this.GetData(x => x.EntityName.Equals(typeof(T).Name) && x.EntityId.Equals(entityId) && x.ActionType.ToUpper().Equals(dbActionType.ToString().ToUpper()));
            var r = new List<T>();
            foreach (var item in l)
            {
                r.Add(JsonConvert.DeserializeObject<T>(item.Entity, new JsonSerializerSettings()
                {
                    Error = (sender, args) => { r.Add(null); args.ErrorContext.Handled = true; },
                    MissingMemberHandling = MissingMemberHandling.Error
                }));
            }
            return r;
        }

        public T GetAuditLogEntityByEntityId<T>(int entityId, DateTime _date) where T : class
        {
            DateTime date = _date.AddSeconds(1);
            var l = this.GetData(x => x.EntityName.Equals(typeof(T).Name) && x.EntityId.Equals(entityId) && x.CreatedDate <= date).OrderByDescending(x => x.CreatedDate).ToList();

            if (l.Count == 0) return null;

            var auditLog = l.First();

            T r;
            r = JsonConvert.DeserializeObject<T>(auditLog.Entity, new JsonSerializerSettings()
            {
                Error = (sender, args) => { r = null; args.ErrorContext.Handled = true; },
                MissingMemberHandling = MissingMemberHandling.Error
            });

            return r;
        }

        public AuditLogItemViewModel GetAuditLogEntityChangesByDate<T>(int entityId, DateTime _date) where T : class
        {
            DateTime date = _date.AddSeconds(1);
            var l = this.GetData(x => x.EntityName.Equals(typeof(T).Name) && x.EntityId.Equals(entityId) && x.CreatedDate <= date).OrderByDescending(x => x.CreatedDate).ToList();

            if (l.Count == 0) return null;

            T oldAuditLogEntity = null;

            if (l.Count > 1)
            {
                oldAuditLogEntity = JsonConvert.DeserializeObject<T>(l[1].Entity, new JsonSerializerSettings()
                {
                    Error = (sender, args) => { oldAuditLogEntity = null; args.ErrorContext.Handled = true; },
                    MissingMemberHandling = MissingMemberHandling.Error
                });
            }

            var item = l.First();

            var auditLogItemViewModel = new AuditLogItemViewModel
            {
                ActionType = item.ActionType,
                Date = item.CreatedDate,
                EntityId = item.EntityId,
                LastHandler = item.OwnerId,
                Observation = item.Observation,
                AuditChangeItens = new List<AuditChangeItemViewModel>()
            };

            T auditLogEntity = JsonConvert.DeserializeObject<T>(item.Entity, new JsonSerializerSettings()
            {
                Error = (sender, args) => { auditLogEntity = null; args.ErrorContext.Handled = true; },
                MissingMemberHandling = MissingMemberHandling.Error
            });

            foreach (var p in typeof(T).GetProperties())
            {
                var propName = p.GetDisplayName();
                if (string.IsNullOrWhiteSpace(propName)) continue;

                object oldValue = null;
                var currentValue = typeof(T).GetProperty(p.Name).GetValue(auditLogEntity);

                if (oldAuditLogEntity != null)
                    oldValue = typeof(T).GetProperty(p.Name).GetValue(oldAuditLogEntity);

                if ((currentValue == null && oldValue == null) || (currentValue != null && currentValue.Equals(oldValue))) continue;

                var propertyType = typeof(T).GetProperty(p.Name).PropertyType;
                if (propertyType == typeof(bool?) || propertyType == typeof(bool))
                {
                    if (currentValue != null) currentValue = (bool)currentValue == true ? "Sim" : "Não";
                    if (oldValue != null) oldValue = (bool)oldValue == true ? "Sim" : "Não";
                }

                var maskClass = p.GetDisplayDescription();
                if (maskClass == "money")
                {
                    oldValue = oldValue != null ? Convert.ToDouble(oldValue).ToString("0.00") : oldValue;
                    currentValue = currentValue != null ? Convert.ToDouble(currentValue).ToString("0.00") : currentValue;
                }
                auditLogItemViewModel.AuditChangeItens.Add(new AuditChangeItemViewModel
                {
                    Propriety = propName,
                    MaskClass = !string.IsNullOrWhiteSpace(maskClass) ? maskClass : "",
                    OldValue = oldValue != null ? oldValue.ToString() : "",
                    Value = currentValue != null ? currentValue.ToString() : ""
                });
            }

            return auditLogItemViewModel;
        }

        //public AuditChangeItemViewModel GetPropertyByEntityId<T>(int entityId, DateTime date, AuditChangeItemViewModel auditChangeItem) where T : class
        //{
        //    var l = this.GetData(x => x.EntityName.Equals(typeof(T).Name) && x.EntityId.Equals(entityId) && x.CreatedDate < date).OrderByDescending(x => x.CreatedDate).ToList();
        //    object value = null, oldValue = null;
        //    T r;
        //    r = JsonConvert.DeserializeObject<T>(l[0].Entity, new JsonSerializerSettings()
        //    {
        //        Error = (sender, args) => { r = null; args.ErrorContext.Handled = true; },
        //        MissingMemberHandling = MissingMemberHandling.Error
        //    });
        //    value = typeof(T).GetProperties().Single(x => x.Name == auditChangeItem.Propriety).GetValue(r);

        //    if (l.Count() > 1)
        //    {
        //        r = JsonConvert.DeserializeObject<T>(l[1].Entity, new JsonSerializerSettings()
        //        {
        //            Error = (sender, args) => { r = null; args.ErrorContext.Handled = true; },
        //            MissingMemberHandling = MissingMemberHandling.Error
        //        });
        //        oldValue = typeof(T).GetProperties().Single(x => x.GetDisplayName() == auditChangeItem.Propriety).GetValue(r);
        //    }

        //    return new AuditChangeItemViewModel
        //    {
        //        MaskClass = auditChangeItem.MaskClass,
        //        OldValue = oldValue != null ? oldValue.ToString() : "",
        //        Value = value != null ? value.ToString() : ""
        //    };

        //}

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<AuditLog> GetDataViewModel(IEnumerable<AuditLog> data)
        {
            throw new NotImplementedException();
        }

        public override AuditLog GetDataViewModel(AuditLog data)
        {
            throw new NotImplementedException();
        }

        public override void Update(AuditLog model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.AuditLog;
        }
    }
}

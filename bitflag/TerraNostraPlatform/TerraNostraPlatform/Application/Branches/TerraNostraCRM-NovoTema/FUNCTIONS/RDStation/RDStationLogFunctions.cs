using DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace FUNCTIONS.RDStation
{
    public class RDStationLogFunctions : BasicFunctions<RDStationLog, RDStationLog>
    {
        public RDStationLogFunctions(TerraNostraContext context) : base(context, "RDStationLogId")
        {
        }

        public override int Create(RDStationLog model)
        {
            this.dbSet.Add(model);
            this.context.SaveChanges();

            return model.RDStationLogId;
        }

        public int Create(string uuid, int? clientId, bool success, string message)
        {
            var entity = new DB.RDStationLog
            {
                ClientId = clientId,
                Uuid = uuid,
                Message = message,
                Success = success
            };

            this.dbSet.Add(entity);
            this.context.SaveChanges();

            return entity.RDStationLogId;
        }


        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<RDStationLog> GetDataViewModel(IEnumerable<RDStationLog> data)
        {
            throw new NotImplementedException();
        }

        public override RDStationLog GetDataViewModel(RDStationLog data)
        {
            throw new NotImplementedException();
        }

        public override void Update(RDStationLog model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet() => this.dbSet = context.RDStationLog;
    }
}

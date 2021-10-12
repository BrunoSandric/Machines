using Machines.BL.Models;
using Machines.DAL.DataAccess;
using Machines.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Machines.BL.Handlers
{
    public static class MalfunctionHandler
    {

        public static ApiResponseModel GetAllMalfunctions(int? page, int? pageSize)
        {
            var toReturn = new ApiResponseModel();
            var dbMalfunctions = MalfunctionDataAccess.GetAllMalfunctions();
            var malfunctions = new List<MalfunctionModel>();
            foreach (var dbItem in dbMalfunctions)
            {
                malfunctions.Add(new MalfunctionModel(dbItem));
            }

            // sorts by priority ascending, then by start time descending then creates list in that order
            malfunctions = malfunctions.OrderBy(i => i.Priority).ThenByDescending(j => j.StartTime).ToList();

            var count = malfunctions.Count;

            #region pagination

            if (page > 0 && pageSize > 1)
            {
                pageSize = pageSize ?? 20; //if pageSize = null make it 20
                int skip = (page.Value - 1) * pageSize.Value;

                if (malfunctions.Count <= skip)
                {
                    toReturn.StatusCode = HttpStatusCode.BadRequest;
                    toReturn.Errors.Add($"Requested page does not exist. Number of malfunctions in system: {count}");

                    return toReturn;
                }

                malfunctions = malfunctions.Skip(skip).Take(pageSize.Value).ToList();
            }

            #endregion


            toReturn.Payload = new
            {
                Items = malfunctions,
                TotalItems = count
            };

            return toReturn;
        }

        public static ApiResponseModel GetSingleMalfunction(int malfunctionId)
        {
            var toReturn = new ApiResponseModel();
            var malfunction = MalfunctionDataAccess.GetMalfunction(malfunctionId);

            toReturn.Payload = malfunction;

            if (malfunction == null)
            {
                toReturn.StatusCode = HttpStatusCode.NotFound;
            }

            return toReturn;
        }

        public static ApiResponseModel InsertMalfunction(Malfunction malfunctions)
        {
            var toReturn = new ApiResponseModel();

            #region validation

            var activeMalfunctionOnMachine = false;
            var malfunctionWithSameIdExists = false;
            foreach (var item in MalfunctionDataAccess.GetAllMalfunctions())
            {
                if (item.statusid == MalfunctionStatuses.Finished && item.machineid == malfunctions.machineid)
                {
                    activeMalfunctionOnMachine = true;
                }
                if (item.id == malfunctions.id)
                {
                    malfunctionWithSameIdExists = true;

                }
                if (activeMalfunctionOnMachine && malfunctionWithSameIdExists)
                {
                    break;
                }
            }
            if (activeMalfunctionOnMachine)
            {
                toReturn.StatusCode = HttpStatusCode.BadRequest;
                toReturn.Errors.Add("Machine already has an active malfunction");
                return toReturn;
            }
            if (malfunctionWithSameIdExists)
            {

                toReturn.StatusCode = HttpStatusCode.BadRequest;
                toReturn.Errors.Add("Malfunction ID already present in DB");
                return toReturn;
            }

            #endregion

            var insertMalfunctionId = MalfunctionDataAccess.InsertMalfunction(malfunctions);
            toReturn.Payload = insertMalfunctionId;

            return toReturn;
        }

        public static ApiResponseModel DeleteMalfunction(int malfunctionId)
        {
            var toReturn = new ApiResponseModel();

            var exists = false;
            foreach (var malfunction in MalfunctionDataAccess.GetAllMalfunctions())
            {
                if (malfunction.id == malfunctionId)
                {
                    exists = true;
                    break;
                }
            }
            if (!exists)
            {
                toReturn.StatusCode = HttpStatusCode.NotFound;
                toReturn.Errors.Add("Malfunction ID not found in DB");
                return toReturn;
            }

            var deleteSuccess = MalfunctionDataAccess.DeleteMalfunction(malfunctionId);
            if (!deleteSuccess)
            {
                toReturn.StatusCode = HttpStatusCode.InternalServerError;
                toReturn.Errors.Add("Malfunction ID could not be deleted from DB");
            }

            return toReturn;
        }

        public static ApiResponseModel UpdateMalfunction(Malfunction malfunctions)
        {
            var toReturn = new ApiResponseModel();

            #region Validation

            if ((malfunctions.id) == 0)
            {
                toReturn.StatusCode = HttpStatusCode.BadRequest;
                toReturn.Errors.Add("Empty Id");
                return toReturn;
            }

            var malfunctionsToUpdateExists = false;
            foreach (var item in MalfunctionDataAccess.GetAllMalfunctions())
            {
                if (item.id == malfunctions.id)
                {
                    malfunctionsToUpdateExists = true;
                }
            }
            if (!malfunctionsToUpdateExists)
            {
                toReturn.StatusCode = HttpStatusCode.NotFound;
                toReturn.Errors.Add("Malfunction ID not found in DB");
                return toReturn;
            }

            #endregion

            var updateSuccess = MalfunctionDataAccess.UpdateMalfunction(malfunctions);
            if (!updateSuccess)
            {
                toReturn.StatusCode = HttpStatusCode.InternalServerError;
                toReturn.Errors.Add("Malfunction could not be updated");
            }

            return toReturn;
        }



    }

}

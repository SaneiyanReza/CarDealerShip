using _0_Framework.App;
using ShopManagement.Domain.VehiclePictureAgg;
using ShopManegement.App.VehiclePicture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegment.App.Concrete
{
    public class VehiclePictureApplication : IVehiclePictureApplication
    {
        private readonly IVehiclePictureRepository _vehiclePictureRepository;

        public VehiclePictureApplication(IVehiclePictureRepository vehiclePictureRepository)
        {
            _vehiclePictureRepository = vehiclePictureRepository;
        }

        public OperationResult Create(CreateVehiclePicture createVehiclePicture)
        {
            var operation = new OperationResult();
            if (_vehiclePictureRepository.Exist(x => x.VehicleID == createVehiclePicture.VehicleID 
            && x.Picture == createVehiclePicture.Picture))
            {
                return operation.Faild(ErrorMessage.DuplicatedRecord);
            }
            var vehiclePicture = new VehiclePicture(createVehiclePicture.VehicleID, createVehiclePicture.Picture ,
                createVehiclePicture.PictureTitle , createVehiclePicture.PictureAlt);

            _vehiclePictureRepository.Create(vehiclePicture);
            _vehiclePictureRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditVehiclePicture editVehiclePicture)
        {
            var operation = new OperationResult();
            var vehiclePicture = _vehiclePictureRepository.Get(editVehiclePicture.ID);

            if (vehiclePicture == null)
            {
                return operation.Faild(ErrorMessage.RecordNotFound);
            }

            if (_vehiclePictureRepository.Exist(x => x.VehicleID == editVehiclePicture.VehicleID
            && x.Picture == editVehiclePicture.Picture && x.ID != editVehiclePicture.ID))
            {
                return operation.Faild(ErrorMessage.DuplicatedRecord);
            }

            vehiclePicture.Edit(editVehiclePicture.VehicleID,editVehiclePicture.Picture
                ,editVehiclePicture.PictureTitle,editVehiclePicture.PictureAlt);

            _vehiclePictureRepository.SaveChanges();
            return operation.Succedded();

        }

        public EditVehiclePicture GetDetails(int id)
        {
            return _vehiclePictureRepository.GetDatails(id);
        }

        public OperationResult Remove(int id)
        {
            var operation = new OperationResult();
            var vehiclePicture = _vehiclePictureRepository.Get(id);

            if (vehiclePicture == null)
            {
                return operation.Faild(ErrorMessage.RecordNotFound);
            }

            vehiclePicture.Remove();
            _vehiclePictureRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Restore(int id)
        {
            var operation = new OperationResult();
            var vehiclePicture = _vehiclePictureRepository.Get(id);

            if (vehiclePicture == null)
            {
                return operation.Faild(ErrorMessage.RecordNotFound);
            }

            vehiclePicture.Restore();
            _vehiclePictureRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<VehiclePictureViewModel> Search(VehiclePictureSearchModel searchModel)
        {
            return _vehiclePictureRepository.Search(searchModel);
        }
    }
}

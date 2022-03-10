using _0_Framework.App;
using ShopManagement.Domain.VehicleAgg;
using ShopManegement.App.Vehicle;
using System.Collections.Generic;

namespace ShopManegment.App.Concrete
{
    public class VehicleApplication : IVehicleApplication
    {
        public readonly IVehicleRepository _vehicleRepository;

        public VehicleApplication(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public OperationResult Create(CreateVehicle createVehicle)
        {
            var operation = new OperationResult();
            if (_vehicleRepository.Exist(x => x.Name == createVehicle.Name && x.Model == createVehicle.Model &&
             x.CarFunction == createVehicle.CarFunction))
            {
                return operation.Faild(ErrorMessage.DuplicatedRecord);
            }

            var slug = createVehicle.Slug.Slugify();
            var vehicle = new Vehicle(createVehicle.Name, createVehicle.Model, createVehicle.CarFunction, createVehicle.UnitPrice,
                createVehicle.ShortDescription, createVehicle.Description, createVehicle.Picture, createVehicle.PictureAlt,
                createVehicle.PictureTitle, slug , createVehicle.Keyword, createVehicle.MetaDescription, createVehicle.CategoryID);

            _vehicleRepository.Create(vehicle);
            _vehicleRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditVehicle editVehicle)
        {
            var operation = new OperationResult();
            var vehicle = _vehicleRepository.Get(editVehicle.ID);
            if (vehicle == null)
            {
                return operation.Faild(ErrorMessage.RecordNotFound);
            }

            if (_vehicleRepository.Exist(x => x.Name == editVehicle.Name && x.Model == editVehicle.Model
            && x.CarFunction == editVehicle.CarFunction && x.ID != editVehicle.ID))
            {
                return operation.Faild(ErrorMessage.DuplicatedRecord);
            }

            var slug = editVehicle.Slug.Slugify();
            vehicle.Edit(editVehicle.Name, editVehicle.Model, editVehicle.CarFunction,
                editVehicle.UnitPrice, editVehicle.ShortDescription, editVehicle.Description, editVehicle.Picture,
                editVehicle.PictureAlt, editVehicle.PictureTitle, slug, editVehicle.Keyword
                , editVehicle.MetaDescription, editVehicle.CategoryID);

            _vehicleRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditVehicle GetDetails(int id)
        {
            return _vehicleRepository.GetDetails(id);
        }

        public List<VehicleViewModel> GetVehicles()
        {
            return _vehicleRepository.GetVehicles();
        }

        public OperationResult IsAvailable(int id)
        {
            var operation = new OperationResult();
            var vehicle = _vehicleRepository.Get(id);
            if (vehicle == null)
            {
                return operation.Faild(ErrorMessage.RecordNotFound);
            }

            vehicle.Available();

            _vehicleRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult IsNotAvailable(int id)
        {
            var operation = new OperationResult();
            var vehicle = _vehicleRepository.Get(id);
            if (vehicle == null)
            {
                return operation.Faild(ErrorMessage.RecordNotFound);
            }

            vehicle.NotAvailable();

            _vehicleRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<VehicleViewModel> Search(VehicleSearchModel searchModel)
        {
            return _vehicleRepository.Search(searchModel);
        }

        OperationResult IVehicleApplication.DeleteByID(int id)
        {
            var operation = new OperationResult();
            var vehicle = _vehicleRepository.DeleteByID(id);

            if (!vehicle)
            {
                return operation.Faild("خطا!");
            }

            _vehicleRepository.SaveChanges();
            return operation.Succedded();
        }
    }
}

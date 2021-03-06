using _0_Framework.App;
using ShopManagement.Domain;
using ShopManagement.Domain.VehicleCategoryAgg;
using ShopManegement.App.VehicleCategories;
using System;
using System.Collections.Generic;

namespace ShopManegment.App.Concrete
{
    public class VehicleCategoryApplication : IVehicleCategoryApplication
    {
        private readonly IVehicleCategoryRepository _vehicleCategory;

        public VehicleCategoryApplication(IVehicleCategoryRepository vehicleCategory)
        {
            _vehicleCategory = vehicleCategory;
        }
        public OperationResult Create(CreateVehicleCategory createVehicleCategory)
        {
            var operation = new OperationResult();
            if (_vehicleCategory.Exist(x=>x.Name == createVehicleCategory.Name))
            {
                return operation.Faild(ErrorMessage.DuplicatedRecord);
            }

            var slug = createVehicleCategory.Slug.Slugify();
            var vehicleCategory = new VehicleCategory(createVehicleCategory.Name, createVehicleCategory.Description, 
                createVehicleCategory.Picture,createVehicleCategory.PictureAlt, createVehicleCategory.PictureTitle, createVehicleCategory.Keyword
                , createVehicleCategory.MetaDescription, slug);

            _vehicleCategory.Create(vehicleCategory);
            _vehicleCategory.SaveChanges();
            
            return operation.Succedded();

        }

        public OperationResult Edit(EditVehicleCategory editVehicleCategory)
        {
            var operation = new OperationResult();
            var vehicleCategory = _vehicleCategory.Get(editVehicleCategory.ID);
            if (vehicleCategory == null)
            {
                return operation.Faild(ErrorMessage.RecordNotFound);
            }

            if (_vehicleCategory.Exist(x=>x.Name == editVehicleCategory.Name && x.ID != editVehicleCategory.ID))
            {
                return operation.Faild(ErrorMessage.DuplicatedRecord);
            }

            var slug = editVehicleCategory.Slug.Slugify();
            vehicleCategory.Edit(editVehicleCategory.Name,editVehicleCategory.Description, editVehicleCategory.Picture,
                editVehicleCategory.PictureAlt, editVehicleCategory.PictureTitle, editVehicleCategory.Keyword
                , editVehicleCategory.MetaDescription, slug);
            _vehicleCategory.SaveChanges();

            return operation.Succedded();
        }

        public EditVehicleCategory GetDetail(int id)
        {
            return _vehicleCategory.GetDetails(id);
        }

        public List<VehicleCategoryViewModel> GetVehicleCategories()
        {
            return _vehicleCategory.GetVehicleCategories();
        }

        public List<VehicleCategoryViewModel> Search(SearchVehicleCategory searchVehicleCategory)
        {
            return _vehicleCategory.Search(searchVehicleCategory);
        }

        public OperationResult Remove(int Id)
        {
            var operetion = new OperationResult();
            var vehiclecategory = _vehicleCategory.Get(Id);
            if (vehiclecategory == null)
            {
                return operetion.Faild(ErrorMessage.RecordNotFound);
            }

            vehiclecategory.Remove();
            _vehicleCategory.SaveChanges();

            return operetion.Succedded();
        }

        public OperationResult Restore(int Id)
        {
            var operetion = new OperationResult();
            var vehiclecategory = _vehicleCategory.Get(Id);
            if (vehiclecategory == null)
            {
                return operetion.Faild(ErrorMessage.RecordNotFound);
            }

            vehiclecategory.Restore();
            _vehicleCategory.SaveChanges();

            return operetion.Succedded();
        }
    }
}

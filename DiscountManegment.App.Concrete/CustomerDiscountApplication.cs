using _0_Framework.App;
using DiscountManagement.App.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Domain.UnitOfWorkAgg;
using System;
using System.Collections.Generic;

namespace DiscountManegment.App.Concrete
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        //private readonly ICustomerDiscountRepository _customerDiscountRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CustomerDiscountApplication(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_customerDiscountRepository = customerDiscountRepository;
        }

        public OperationResult Define(DefineCustomerDiscount customerDiscount)
        {
            var operation = new OperationResult();
            if (_unitOfWork.CustomerDiscounts.Exist(x => x.VehicleID == customerDiscount.VehicleID
            && x.DiscountRate == customerDiscount.DiscountRate))
            {
                return operation.Faild(ErrorMessage.DuplicatedRecord);
            }

            var startDate = customerDiscount.StartDate.ToGeorgianDateTime();
            var endDate = customerDiscount.EndDate.ToGeorgianDateTime();

            var discount = new CustomerDiscount(customerDiscount.VehicleID, customerDiscount.DiscountRate, startDate, endDate,
                customerDiscount.Reason);
            _unitOfWork.CustomerDiscounts.Create(discount);
            _unitOfWork.Complete();

            return operation.Succedded();
        }

        public OperationResult Edit(EditCustomerDiscount customerDiscount)
        {
            var operation = new OperationResult();
            var discount = _unitOfWork.CustomerDiscounts.Get(customerDiscount.ID);

            if (discount == null)
            {
                return operation.Faild(ErrorMessage.RecordNotFound);
            }

            if (_unitOfWork.CustomerDiscounts.Exist(x => x.VehicleID == customerDiscount.VehicleID
            && x.DiscountRate == customerDiscount.DiscountRate && x.ID != customerDiscount.ID))
            {
                return operation.Faild(ErrorMessage.DuplicatedRecord);
            }

            var startDate = customerDiscount.StartDate.ToGeorgianDateTime();
            var endDate = customerDiscount.EndDate.ToGeorgianDateTime();

           discount.Edit(customerDiscount.VehicleID, customerDiscount.DiscountRate, startDate, endDate,
                customerDiscount.Reason);
            _unitOfWork.Complete();

            return operation.Succedded();
        }

        public EditCustomerDiscount GetDetails(int id)
        {
            return _unitOfWork.CustomerDiscounts.GetDetails(id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel model)
        {
            return _unitOfWork.CustomerDiscounts.Search(model);
        }
        public void DeleteByID(int id)
        {
            _unitOfWork.CustomerDiscounts.DeleteByID(id);
            _unitOfWork.Complete();
        }
    }
}

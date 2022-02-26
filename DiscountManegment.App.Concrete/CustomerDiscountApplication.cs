using _0_Framework.App;
using DiscountManagement.App.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using System;
using System.Collections.Generic;

namespace DiscountManegment.App.Concrete
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _customerDiscountRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }

        public OperationResult Define(DefineCustomerDiscount customerDiscount)
        {
            var operation = new OperationResult();
            if (_customerDiscountRepository.Exist(x => x.VehicleID == customerDiscount.VehicleID
            && x.DiscountRate == customerDiscount.DiscountRate))
            {
                return operation.Faild(ErrorMessage.DuplicatedRecord);
            }

            var startDate = customerDiscount.StartDate.ToGeorgianDateTime();
            var endDate = customerDiscount.EndDate.ToGeorgianDateTime();

            var discount = new CustomerDiscount(customerDiscount.VehicleID, customerDiscount.DiscountRate, startDate, endDate,
                customerDiscount.Reason);
            _customerDiscountRepository.Create(discount);
            _customerDiscountRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditCustomerDiscount customerDiscount)
        {
            var operation = new OperationResult();
            var discount = _customerDiscountRepository.Get(customerDiscount.ID);

            if (discount == null)
            {
                return operation.Faild(ErrorMessage.RecordNotFound);
            }

            if (_customerDiscountRepository.Exist(x => x.VehicleID == customerDiscount.VehicleID
            && x.DiscountRate == customerDiscount.DiscountRate && x.ID != customerDiscount.ID))
            {
                return operation.Faild(ErrorMessage.DuplicatedRecord);
            }

            var startDate = customerDiscount.StartDate.ToGeorgianDateTime();
            var endDate = customerDiscount.EndDate.ToGeorgianDateTime();

           discount.Edit(customerDiscount.VehicleID, customerDiscount.DiscountRate, startDate, endDate,
                customerDiscount.Reason);
            _customerDiscountRepository.SaveChanges();

            return operation.Succedded();
        }

        public EditCustomerDiscount GetDetails(int id)
        {
            return _customerDiscountRepository.GetDetails(id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel model)
        {
            return _customerDiscountRepository.Search(model);
        }
    }
}

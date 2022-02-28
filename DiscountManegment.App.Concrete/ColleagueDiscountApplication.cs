using _0_Framework.App;
using DiscountManagement.App.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManegment.App.Concrete
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            _colleagueDiscountRepository = colleagueDiscountRepository;
        }

        public OperationResult Define(DefineColleagueDiscount defineColleague)
        {
            var operation = new OperationResult();
            if (_colleagueDiscountRepository.Exist(x => x.VehicleID == defineColleague.VehicleID
            && x.DiscountRate == defineColleague.DiscountRate))
            {
                return operation.Faild(ErrorMessage.DuplicatedRecord);
            }

            var colleagueDiscount = new ColleagueDiscount(defineColleague.VehicleID, defineColleague.DiscountRate);

            _colleagueDiscountRepository.Create(colleagueDiscount);
            _colleagueDiscountRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditColleagueDiscount editColleague)
        {
            var operation = new OperationResult();
            var colleagueDiscount = _colleagueDiscountRepository.Get(editColleague.ID);

            if (colleagueDiscount == null)
            {
                return operation.Faild(ErrorMessage.RecordNotFound);
            }
            if (_colleagueDiscountRepository.Exist(x => x.VehicleID == editColleague.VehicleID
            && x.DiscountRate == editColleague.DiscountRate && x.ID != editColleague.ID))
            {
                return operation.Faild(ErrorMessage.DuplicatedRecord);
            }

            colleagueDiscount.Edit(editColleague.VehicleID, editColleague.DiscountRate);
            _colleagueDiscountRepository.SaveChanges();

            return operation.Succedded();
        }

        public EditColleagueDiscount GetDetails(int id)
        {
            return _colleagueDiscountRepository.GetDetails(id);
        }

        public OperationResult Restore(int id)
        {
            var operation = new OperationResult();
            var colleagueDiscount = _colleagueDiscountRepository.Get(id);

            if (colleagueDiscount == null)
            {
                return operation.Faild(ErrorMessage.RecordNotFound);
            }

            colleagueDiscount.Restore();
            _colleagueDiscountRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Romove(int id)
        {
            var operation = new OperationResult();
            var colleagueDiscount = _colleagueDiscountRepository.Get(id);

            if (colleagueDiscount == null)
            {
                return operation.Faild(ErrorMessage.RecordNotFound);
            }

            colleagueDiscount.Remove();
            _colleagueDiscountRepository.SaveChanges();

            return operation.Succedded();
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel discountSearchModel)
        {
            return _colleagueDiscountRepository.Search(discountSearchModel);
        }
    }
}

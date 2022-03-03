using _0_Framework.App;
using DiscountManagement.App.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Domain.UnitOfWorkAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManegment.App.Concrete
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        //private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

        private readonly IUnitOfWork _unitOfWork;

        public ColleagueDiscountApplication(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public OperationResult Define(DefineColleagueDiscount defineColleague)
        {
            var operation = new OperationResult();
            if (_unitOfWork.ColleagueDiscounts.Exist(x => x.VehicleID == defineColleague.VehicleID
            && x.DiscountRate == defineColleague.DiscountRate))
            {
                return operation.Faild(ErrorMessage.DuplicatedRecord);
            }

            var colleagueDiscount = new ColleagueDiscount(defineColleague.VehicleID, defineColleague.DiscountRate);

            _unitOfWork.ColleagueDiscounts.Create(colleagueDiscount);
            _unitOfWork.Complete();

            return operation.Succedded();
        }

        public OperationResult Edit(EditColleagueDiscount editColleague)
        {
            var operation = new OperationResult();
            var colleagueDiscount = _unitOfWork.ColleagueDiscounts.Get(editColleague.ID);

            if (colleagueDiscount == null)
            {
                return operation.Faild(ErrorMessage.RecordNotFound);
            }
            if (_unitOfWork.ColleagueDiscounts.Exist(x => x.VehicleID == editColleague.VehicleID
            && x.DiscountRate == editColleague.DiscountRate && x.ID != editColleague.ID))
            {
                return operation.Faild(ErrorMessage.DuplicatedRecord);
            }

            colleagueDiscount.Edit(editColleague.VehicleID, editColleague.DiscountRate);
            _unitOfWork.Complete();

            return operation.Succedded();
        }

        public EditColleagueDiscount GetDetails(int id)
        {
            return _unitOfWork.ColleagueDiscounts.GetDetails(id);
        }

        public OperationResult Restore(int id)
        {
            var operation = new OperationResult();
            var colleagueDiscount = _unitOfWork.ColleagueDiscounts.Get(id);

            if (colleagueDiscount == null)
            {
                return operation.Faild(ErrorMessage.RecordNotFound);
            }

            colleagueDiscount.Restore();
            _unitOfWork.Complete();

            return operation.Succedded();
        }

        public OperationResult Romove(int id)
        {
            var operation = new OperationResult();
            var colleagueDiscount = _unitOfWork.ColleagueDiscounts.Get(id);

            if (colleagueDiscount == null)
            {
                return operation.Faild(ErrorMessage.RecordNotFound);
            }

            colleagueDiscount.Remove();
            _unitOfWork.Complete();

            return operation.Succedded();
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel discountSearchModel)
        {
            return _unitOfWork.ColleagueDiscounts.Search(discountSearchModel);
        }

        OperationResult IColleagueDiscountApplication.DeleteByID(int id)
        {
            var operation = new OperationResult();
            var ColleagueDiscount = _unitOfWork.ColleagueDiscounts.DeleteByID(id);

            if (!ColleagueDiscount)
            {
                return operation.Faild("خطا!");
            }

            _unitOfWork.Complete();
            return operation.Succedded();
        }
    }
}

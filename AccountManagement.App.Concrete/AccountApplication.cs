using _0_Framework.App;
using AccountManagement.App.Account;
using System;
using System.Collections.Generic;

namespace AccountManagement.App.Concrete
{
    public class AccountApplication : IAccountApplication
    {
        private readonly AccountManagement.Domain.AccountAgg.IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAuthHelper _authHelper;
        public AccountApplication(AccountManagement.Domain.AccountAgg.IAccountRepository accountRepository , 
            IPasswordHasher passwordHasher , IAuthHelper authHelper)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _authHelper = authHelper;
        }

        public OperationResult ChangePassword(ChangePassword model)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(model.ID);
            if (account == null)
            {
                return operation.Faild(ErrorMessage.RecordNotFound);
            }

            if (model.Password != model.RePassword)
            {
                return operation.Faild(ErrorMessage.PasswordsNotMatch);
            }

            var password = _passwordHasher.Hash(model.Password);
            account.ChangePassword(password);
            _accountRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Create(CreateAccount model)
        {
            var operation = new OperationResult();

            if (_accountRepository.Exist(x => x.UserName == model.UserName || x.Mobile == model.Mobile))
            {
                return operation.Faild(ErrorMessage.DuplicatedRecord);
            }

            var password = _passwordHasher.Hash(model.Password);
            if (password == null)
            {
                return operation.Faild(ErrorMessage.WrongUserPass);
            }
            var newAccount = new AccountManagement.Domain.AccountAgg.Account(model.FullName, model.UserName,
                password, model.Mobile, model.ProfilePhoto, model.RoleID);

            _accountRepository.Create(newAccount);
            _accountRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditAccount model)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(model.ID);

            if (account == null)
            {
                return operation.Faild(ErrorMessage.RecordNotFound);
            }
            if (_accountRepository.Exist(x => (x.UserName == model.UserName || x.Mobile == model.Mobile) && x.ID != model.ID))
            {
                return operation.Faild(ErrorMessage.DuplicatedRecord);
            }

            account.Edit(model.FullName, model.UserName,
                model.RoleID, model.Mobile, model.ProfilePhoto);
            _accountRepository.SaveChanges();

            return operation.Succedded();
        }

        public EditAccount GetDetails(int id)
        {
            return _accountRepository.GetDetails(id);
        }

        //public string GetPhoto(string photo)
        //{
        //    return _accountRepository.GetPhoto(photo);
        //}

        public OperationResult Login(Login login)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetByUserName(login.UserName);

            if (account == null)
            {
                return operation.Faild(ErrorMessage.WrongUserPass);
            }

            (bool Verified , bool NeedsUpgrade)result = _passwordHasher.Check(account.Password, login.Password);

            if (!result.Verified)
            {
                return operation.Faild(ErrorMessage.WrongUserPass);
            }

            var authViewModel = new AuthViewModel(account.ID, account.RoleID, account.UserName, account.FullName);
            _authHelper.Signin(authViewModel);

            return operation.Succedded();
        }

        public void Logout()
        {
            _authHelper.SignOut();
        }

        public List<AccountViewModel> Search(AccountSearchModel model)
        {
            return _accountRepository.Search(model);
        }
    }
}
